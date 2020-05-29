using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Crypt_Library;

namespace KitchenBaseWeb
{
    public class DBProcedures
    {
        private SqlCommand command = new SqlCommand("", DBConnection.connection);
        //Процедуры для работы с  данными из БД
        private void commandConfig(string config)
        {
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "[dbo].[" + config + "]";
            command.Parameters.Clear();
        }

        //Регистрация пользователя
        public void UsersRegistration(string Login, string Password, string Name, string Surname, string MiddleName, 
            string Email, string PhoneNumber)
        {
            Password = BitConverter.ToString(Crypt.Encryption(Password));
            commandConfig("Users_Registration");
            command.Parameters.AddWithValue("@Login", Login);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Surname", Surname);
            command.Parameters.AddWithValue("@MiddleName", MiddleName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
    }
}