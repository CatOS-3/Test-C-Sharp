using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Test
{
    public partial class Result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;

            using (SqlConnection connection = new SqlConnection(Global.CONNECT_STR))
            { 
                connection.Open();

                String selectTable = "select * from students order by Points desc";
                using (SqlCommand command = new SqlCommand(selectTable, connection))
                {//Считываем результаты всех студентов из БД
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int i = 0;
                        while (reader.Read())
                        {
                            TableRow row = new TableRow();

                                TableCell tmp = new TableCell();
                                tmp.Text = reader.GetInt32(0).ToString();
                                row.Cells.Add(tmp); //ID студента

                                tmp = new TableCell();
                                tmp.Text = reader.GetString(1) + " " + reader.GetString(2);
                                row.Cells.Add(tmp); //Имя и фамилия студента

                                tmp = new TableCell();
                                tmp.Text = Global.getGroupNameByID(reader.GetInt32(3));
                                row.Cells.Add(tmp); //Группа студента

                                tmp = new TableCell();
                                tmp.Text = reader.GetInt32(4).ToString();
                                row.Cells.Add(tmp); //Баллы за тест студента

                            Table1.Rows.Add(row);

                            if (i % 2 == 0) //Чередование цвета строк
                                row.CssClass = "table1row";
                            else
                                row.CssClass = "table2row";
                            i++;
                        }
                    }
                }
            }
        }
    }
}