using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Crypt_Library;

namespace KitchenBaseWeb.Pages
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Регистрация
        protected void btEnter_Click(object sender, EventArgs e)
        {
            DBConnection connection = new DBConnection();
            //Проверка уникальности логина
            if(connection.LoginCheck(tbLogin.Text) > 0 & tbLogin.Text != "")
            {
                lblLoginCheck.Visible = true;
            }
            else
            {
                if(tbPassword.Text != tbPasswordConfirm.Text)
                {
                    lblPasswordConfirm.Visible = true;
                }
                else
                {
                    lblLoginCheck.Visible = false;
                    lblPasswordConfirm.Visible = false;
                    DBProcedures procedures = new DBProcedures();
                    procedures.UsersRegistration(tbLogin.Text.ToString(), tbPassword.Text.ToString(), tbName.Text.ToString(), tbSurname.Text.ToString(),
                        tbMiddleName.Text.ToString(), tbEmail.Text.ToString(), tbPhone.Text.ToString());
                    Response.Redirect("Authorization.aspx");
                }
            }
        }
    }
}