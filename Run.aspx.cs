using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Test
{
    public partial class Run : System.Web.UI.Page
    {
        public const int QUEST_NUM = 20;
        private const int POINTS_MAX = 100;
        private const int ONE_POINT = POINTS_MAX / QUEST_NUM;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;

            if ((bool)Session["StReg"] == false)
            { //Запрет на простой переход
                Response.Redirect("Default.aspx");
                return;
            }

            int[] rand = Randomize();
            Session["StRand"] = rand;

            for (int i = 0; i < QUEST_NUM; i++)
            { //Заполнение вопросами
                Label labTmp = (Label)FindControl("l" + (i + 1));
                if (labTmp != null)
                    labTmp.Text = (i + 1) + ". " + Global.Quests[rand[i]].Quest;

                RadioButtonList radTmp = (RadioButtonList)FindControl("r" + (i + 1));
                if (radTmp != null)
                {
                    radTmp.Items.Add(Global.Quests[rand[i]].Answer[0]);
                    radTmp.Items.Add(Global.Quests[rand[i]].Answer[1]);
                    radTmp.Items.Add(Global.Quests[rand[i]].Answer[2]);
                    radTmp.Items.Add(Global.Quests[rand[i]].Answer[3]);
                }
            }
        }

        //===================================================================//
        private int[] Randomize()
        { //Создание рандомной последовательности из неповторяющихся чисел
            int[] rand = new int[QUEST_NUM];
            int[] arr = Enumerable.Range(0, Global.Quests.Count).ToArray(); //Создание массива со значениями от 0 до N
            Random rnd = new Random();

            for (int i = arr.Length - 1; i >= 0; i--)
            { //Перемешивание
                int j = rnd.Next(0, i + 1);
                int tmp = arr[i];
                arr[i] = arr[j];
                arr[j] = tmp;
            }

            if (rnd.Next() % 2 == 0)
            { //Берём значения с начала
                for (int i = 0; i < QUEST_NUM; i++)
                    rand[i] = arr[i];
            }
            else
            { //Берём значения с конца
                for (int i = arr.Length - 1, j = 0; i >= 0 && j < QUEST_NUM; i--, j++)
                    rand[j] = arr[i];
            }

            return rand;
        }

        //===================================================================//
        private void PutStudent(int points)
        {
            using (SqlConnection connection = new SqlConnection(Global.CONNECT_STR))
            { //Добавление студента в БД
                connection.Open();
                String insertTable = "insert into students(FirstName, SecondName, GroupID, Points) values(" +
                                        "'" + (String)Session["StFirst"] + "'," +
                                        "'" + (String)Session["StSecond"] + "'," +
                                        (int)Session["StGroupID"] + "," +
                                        points + ")";
                using (SqlCommand command = new SqlCommand(insertTable, connection))
                    command.ExecuteNonQuery();
            }
        }

        protected void ButtonClickEnd(object sender, EventArgs e)
        { //Завершение теста
            int points = 0;

            int[] rand = (int[] )Session["StRand"];
            for (int i = 0; i < QUEST_NUM; i++)
            { //Вычисление оценки
                RadioButtonList radTmp = (RadioButtonList)FindControl("r" + (i + 1));
                if (radTmp == null)
                    continue;

                if (radTmp.SelectedIndex == -1)
                    continue;

                if ((radTmp.SelectedIndex + 1) == Global.Quests[rand[i]].Correct)
                    points += ONE_POINT;
            }

            PutStudent(points);
            Session["StReg"] = false;
            Session["StEnd"] = true;
            Session["StPoints"] = points;
            Response.Redirect("End.aspx");
        }
    }
}