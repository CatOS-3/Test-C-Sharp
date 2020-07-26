using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace Test
{
    public class Global : System.Web.HttpApplication
    {
        //Глобальные переменные
        private static List<Group> groups = new List<Group>();
        private static List<TestQuest> quests = new List<TestQuest>();

        public static List<TestQuest> Quests { get => quests; }

        public const String CONNECT_STR = "Data Source=.\\SQLEXPRESS;" +
                                           "Initial Catalog=TestCont;" +
                                           "Integrated Security=True";// +
                                         //";User ID=Sasha;" +
                                         //"Password=Password12";

        public static String getGroupNameByID(int id)
        {
            if (groups.Count < 1)
                return "";

            foreach (Group g in groups)
            {
                if (g.ID == id)
                    return g.Name;
            }

            return "";
        }

        public static int getGroupIDByName(String name)
        {
            if (name.Length < 1 || groups.Count < 1)
                return -1;

            foreach (Group g in groups)
            {
                if (String.Compare(name, g.Name, true) == 0)
                    return g.ID;
            }

            return -1;
        }

        //===================================================================//
        private bool TableExist(String tableName, SqlConnection connection)
        {//Проверка на существование таблицы в БД
            using (SqlCommand command = new SqlCommand("select object_id('" + tableName + "')", connection))
            { 
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                            return true; //Таблица в БД существует
                    }
                }
            }

            return false;
        }

        private void ParseDefaultGroup(SqlConnection connection)
        {
            using (StreamReader read = new StreamReader(Server.MapPath("~/Res/DefaultGroup.txt")))
            { //Берём стандартные группы из файла
                int id = 1;
                String str;

                while ((str = read.ReadLine()) != null)
                {
                    groups.Add(new Group(id++, str)); //Записываем в память

                    String insertTable = "insert into groups(Name) values('" + str + "')";
                    using (SqlCommand command = new SqlCommand(insertTable, connection))
                        command.ExecuteNonQuery(); //Добавляем в БД
                }
            }
        }

        private void ParseTest()
        {
            using (StreamReader read = new StreamReader(Server.MapPath("~/Res/Quests.txt")))
            { //Считываем вопросы теста из файла
                String str;
                while ((str = read.ReadLine()) != null)
                {
                    quests.Add(new TestQuest(str, read.ReadLine(), read.ReadLine(), read.ReadLine(), read.ReadLine(), Convert.ToInt32(read.ReadLine())));
                    read.ReadLine();//Пробел
                }
            }
        }

        //===================================================================//
        private void CheckGroups(SqlConnection connection)
        {
            if (TableExist("groups", connection))
            {
                using (SqlCommand command = new SqlCommand("select * from groups", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            groups.Add(new Group(reader.GetInt32(0), reader.GetString(1))); //Считываем группы из БД в память
                    }
                }

                if (groups.Count < 1) //Есть таблица, но нет записей
                    ParseDefaultGroup(connection);//Заполним БД стандартными группами
            }
            else
            { //Если нет таблицы групп, то создадим её
                String createTable = "create table groups(" +
                                     "ID int not null identity(1, 1)," +
                                     "Name varchar(16) not null," +
                                     "primary key(ID))";
                using (SqlCommand command = new SqlCommand(createTable, connection))
                    command.ExecuteNonQuery();

                ParseDefaultGroup(connection);//Заполним БД стандартными группами
            }
        }

        private void CheckStudents(SqlConnection connection)
        {
            if (!TableExist("students", connection))
            { //Если нет таблицы студентов, то создадим её
                String createTable = "create table students(" +
                                     "ID int not null identity(1, 1)," +
                                     "FirstName varchar(256) not null," +
                                     "SecondName varchar(256) not null," +
                                     "GroupID int not null," +
                                     "Points int not null," +
                                     "primary key(ID)," +
                                     "foreign key (GroupID) references groups(ID))";
                using (SqlCommand command = new SqlCommand(createTable, connection))
                    command.ExecuteNonQuery();
            }
        }

        //===================================================================//
        protected void Application_Start(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(CONNECT_STR))
            {
                connection.Open();
                CheckGroups(connection);
                CheckStudents(connection);
            }

            ParseTest();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 60;
            Session["StReg"] = false; //Студент прошёл регистрацию
            Session["StEnd"] = false; //Студент прошёл тест
            Session["StFirst"] = ""; //Имя студента
            Session["StSecond"] = ""; //Фамилия студента
            Session["StGroupID"] = -1; //Группа студента
            Session["StPoints"] = 0; //Баллы студента за тест
            Session["StRand"] = null; // Ссылка на рандомную последовательность для теста
        }
        
    }
}