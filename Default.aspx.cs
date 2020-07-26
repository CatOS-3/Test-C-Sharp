using System;
using System.Data.SqlClient;

namespace Test
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;

            Session["StReg"] = false;
            Session["StEnd"] = false;
        }

        //===================================================================//
        private bool StudentExist(int group)
        {
            using (SqlConnection connection = new SqlConnection(Global.CONNECT_STR))
            {
                connection.Open();

                String selectTable = "select * from students where " +
                                     "FirstName='" + Text1.Text + "' and " +
                                     "SecondName='" + Text2.Text + "' and " +
                                     "GroupID=" + group;
                using (SqlCommand command = new SqlCommand(selectTable, connection))
                { //Проверка на существование студента в БД
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                                return true; //Студент прошёл тест
                        }
                    }
                }
            }
 
            return false;
        }

        private bool TextHasOnlyLetters(String s)
        {
            if (s.Length < 1)
                return false;

            for(int i = 0; i < s.Length; i++)
            {
                if ((s[i] < 'а' || s[i] > 'я') && (s[i] < 'А' || s[i] > 'Я') && s[i] != 'ё' && s[i] != 'Ё')
                    return false;
            }

            return true;
        }

        //===================================================================//
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Global.Quests.Count < Run.QUEST_NUM)
            {
                Label1.Text = "В системе недостаточно вопросов";
                Label1.Visible = true;
                return;
            }

            if (!TextHasOnlyLetters(Text1.Text))
            {
                Label1.Text = "Для имени используйте русские буквы (а-я А-Я ё Ё)";
                Label1.Visible = true;
                return;
            }

            if (!TextHasOnlyLetters(Text2.Text))
            {
                Label1.Text = "Для фамилии используйте русские буквы (а-я А-Я ё Ё)";
                Label1.Visible = true;
                return;
            }

            int group;
            if ((group = Global.getGroupIDByName(Text3.Text)) == -1)
            {
                Label1.Text = "Такой группы не существует";
                Label1.Visible = true;
                return;
            }

            if(StudentExist(group))
            {
                Label1.Text = "Данный пользователь прошёл тест (cмотрите результаты)";
                Label1.Visible = true;
                return;
            }

            Label1.Visible = false;
            Session["StReg"] = true;
            Session["StFirst"] = Text1.Text;
            Session["StSecond"] = Text2.Text;
            Session["StGroupID"] = group;
            Response.Redirect("Run.aspx");
        }
    }
}