using System;

namespace Test
{
    public partial class End : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;

            if ((bool)Session["StEnd"] == false)
            { //Запрет на простой переход
                Response.Redirect("Default.aspx");
                return;
            }

            Label1.Text = "Студент группы " + Global.getGroupNameByID((int)Session["StGroupID"]) + 
                ": " + (String)Session["StFirst"] + " " + (String)Session["StSecond"];
            Label2.Text = "Ваши баллы: " + (int)Session["StPoints"];
        }
    }
}