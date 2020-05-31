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
            Password = Crypt.Encrypt(Password);
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

        //Добавление бронирования стола
        public void InformationOBronirovanieInsert(int ID_Stola, string DateBronirovaniy, bool StatusStola, int KolichestvoGostey, string Kommentariy,
            int ID_Vremeni_Bronirovaniy)
        {
            commandConfig("InformationOBronirovanie_insert");
            command.Parameters.AddWithValue("@ID_Stola", ID_Stola);
            command.Parameters.AddWithValue("@DateBronirovaniy", DateBronirovaniy);
            command.Parameters.AddWithValue("@StatusStola", StatusStola);
            command.Parameters.AddWithValue("@KolichestvoGostey", KolichestvoGostey);
            command.Parameters.AddWithValue("@Kommentariy", Kommentariy);
            command.Parameters.AddWithValue("@ID_Vremeni_Bronirovaniy", ID_Vremeni_Bronirovaniy);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
        //Добавление в таблицу KlientBronirovanie
        public void KlientBronirovanieInsert(int ID_InformationOKliente)
        {
            commandConfig("KlientBronirovanie_insert");
            command.Parameters.AddWithValue("@ID_InformationOKliente", ID_InformationOKliente);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
        //Удаление из таблицы KlientBronirovanie
        public void KlientBronirovanieDelete(int ID_KlientBronirovanie)
        {
            commandConfig("KlientBronirovanie_delete");
            command.Parameters.AddWithValue("@ID_KlientBronirovanie", ID_KlientBronirovanie);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
        //Удаление из бронирования стола 
        public void InformationOBronirovanieDelete(int ID_Bronirovaniya)
        {
            commandConfig("InformationOBronirovanie_delete");
            command.Parameters.AddWithValue("@ID_Bronirovaniya", ID_Bronirovaniya);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
    }
}