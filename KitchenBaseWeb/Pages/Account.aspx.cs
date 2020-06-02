using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Crypt_Library;
using System.Data;
using System.Data.SqlClient;

namespace KitchenBaseWeb.Pages
{
    public partial class Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataFill();
            }
        }
        //Заполнение данных на странице
        private void DataFill()
        {
            string Password;
                DataTable dt = new DataTable();
                DBConnection.connection.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("select [Name], [Surname], [MiddleName], [Email], [PhoneNumber], [Login], [Password] from [LichnieDannieKlienta] " +
                        "inner join[Authorization] on[Authorization].[ID_Authorization] = [LichnieDannieKlienta].[ID_Authorization] " +
                        "where[LichnieDannieKlienta].[ID_Authorization] = '" + DBConnection.idUser + "'", DBConnection.connection);

                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    tbEmail.Text = (myReader["Email"].ToString());
                    tbLogin.Text = (myReader["Login"].ToString());
                    tbMiddleName.Text = (myReader["MiddleName"].ToString());
                    tbName.Text = (myReader["Name"].ToString());
                    Password = (myReader["Password"].ToString());
                    tbPhone.Text = (myReader["PhoneNumber"].ToString());
                    tbSurname.Text = (myReader["Surname"].ToString());
                    tbPassword.Text = Crypt.Decrypt(Password);
                }
                DBConnection.connection.Close();
        }
        //Изменение свойств полей
        private void TBStatus()
        {
            tbEmail.Enabled = true;
            tbLogin.Enabled = true;
            tbMiddleName.Enabled = true;
            tbName.Enabled = true;
            tbPassword.Enabled = true;
            tbPhone.Enabled = true;
            tbSurname.Enabled = true;

            tbEmail.CssClass = "Account";
            tbLogin.CssClass = "Account";
            tbMiddleName.CssClass = "Account";
            tbName.CssClass = "Account";
            tbPassword.CssClass = "Account";
            tbPhone.CssClass = "Account";
            tbSurname.CssClass = "Account";
        }
        //Поля не доступны
        private void TBStatusDisabled()
        {
            tbEmail.Enabled = false;
            tbLogin.Enabled = false;
            tbMiddleName.Enabled = false;
            tbName.Enabled = false;
            tbPassword.Enabled = false;
            tbPhone.Enabled = false;
            tbSurname.Enabled = false;

            tbEmail.CssClass = "AccountDisabled";
            tbLogin.CssClass = "AccountDisabled";
            tbMiddleName.CssClass = "AccountDisabled";
            tbName.CssClass = "AccountDisabled";
            tbPassword.CssClass = "AccountDisabled";
            tbPhone.CssClass = "AccountDisabled";
            tbSurname.CssClass = "AccountDisabled";
        }
        //Редактирование данных
        protected void btEdit_Click(object sender, EventArgs e)
        {
            DataFill();
            TBStatus();
            btCansel.Visible = true;
            btSave.Visible = true;
            tbPassword.TextMode = TextBoxMode.SingleLine;
        }
        //Отмена редактирования
        protected void btCansel_Click(object sender, EventArgs e)
        {
            TBStatusDisabled();
            DataFill();
            btCansel.Visible = false;
            btSave.Visible = false;
        }
        //Сохранение данных
        protected void btSave_Click(object sender, EventArgs e)
        {
            DBProcedures procedures = new DBProcedures();
            procedures.UsersRegistrationUpdate(DBConnection.idKlient, tbLogin.Text.ToString(), tbPassword.Text.ToString(), tbName.Text.ToString(), tbSurname.Text.ToString(),
                tbMiddleName.Text.ToString(), tbEmail.Text.ToString(), tbPhone.Text.ToString());
            TBStatusDisabled();
            btCansel.Visible = false;
            btSave.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Authorization.aspx");
            DBConnection.idUser = 0;
        }
    }
}