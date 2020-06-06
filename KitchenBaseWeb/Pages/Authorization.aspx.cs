using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data.SqlClient;
using Crypt_Library;
using System.Text;

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
            string Password;
            DBConnection connection = new DBConnection();
            connection.Authorization(tbLogin.Text);
            connection.getIDKlienta(DBConnection.idUser);
            connection.getIDPersonal(DBConnection.idUser);
            switch (DBConnection.idUser)
            {
                case (0):
                    tbLogin.BackColor = ColorTranslator.FromHtml("#cc0000");
                    tbPassword.BackColor = ColorTranslator.FromHtml("#cc0000");
                    lblAuthorization.Visible = true;
                    break;
                default:
                    //Проверка пароля
                    SqlCommand command = new SqlCommand("", DBConnection.connection);
                    command.CommandText = "select [Password] from [Authorization] where [ID_Authorization] = '" + DBConnection.idUser + "'";
                    DBConnection.connection.Open();
                    Password = command.ExecuteScalar().ToString(); //Строка (пароль) из базы данных
                    DBConnection.connection.Close();
                    if (tbPassword.Text.ToString() == Crypt.Decrypt(Password))
                    {
                        switch (connection.userRole(DBConnection.idUser))
                        {
                            case ("Customer"):
                                Response.Redirect("Reservation.aspx");
                                break;
                            case ("Employee"):
                                switch (connection.userDoljnost(DBConnection.idUser))
                                {
                                    //Официант
                                    case ("3"):
                                        Response.Redirect("Service.aspx");
                                        break;
                                    //Повар
                                    case ("4"):
                                        Response.Redirect("Orders.aspx");
                                        break;
                                }
                                break;
                        }
                        break;
                    }
                    else
                    {
                        tbLogin.BackColor = ColorTranslator.FromHtml("#cc0000");
                        tbPassword.BackColor = ColorTranslator.FromHtml("#cc0000");
                        lblAuthorization.Visible = true;
                    }
                    break;
            }
        }
    }
}