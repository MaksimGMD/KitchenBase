using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace KitchenBaseWeb.Pages
{
    public partial class Authorization : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Авторизация
        protected void btEnter_Click(object sender, EventArgs e)
        {
            DBConnection connection = new DBConnection();
            connection.Authorization(tbLogin.Text, tbPassword.Text);
            switch(DBConnection.idUser)
            {
                case (0):
                    tbLogin.BackColor = ColorTranslator.FromHtml("#cc0000");
                    tbPassword.BackColor = ColorTranslator.FromHtml("#cc0000");
                    lblAuthorization.Visible = true;
                    break;
                default:
                    switch (connection.userRole(DBConnection.idUser))
                    {
                        case ("Customer"):
                            Response.Redirect("Reservation.aspx");
                            break;
                        case ("Employee"):
                            Response.Redirect("Service.aspx");
                            break;
                    }
                    break;
            }
        }
    }
}