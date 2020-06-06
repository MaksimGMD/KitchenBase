using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Crypt_Library;

namespace KitchenBase.Classes
{
    class DataProcedure
    {
        private SqlCommand command
           = new SqlCommand("", DBConnection.connection);

        private void commandConfig(string config)
        {
            command.CommandType =
                System.Data.CommandType.StoredProcedure;
            command.CommandText = "[dbo].[" + config + "]";
            command.Parameters.Clear();
        }

        //Процедуры для типа продуктов

        public void spTypeProduct_insert(string TypeProduct)
        {
            commandConfig("TypeProduct_insert");
            command.Parameters.AddWithValue("@TypeProduct", TypeProduct);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
        public void spTypeProduct_update(Int32 ID_TypeProduct, string TypeProduct)
        {
            commandConfig("TypeProduct_update");
            command.Parameters.AddWithValue("@ID_TypeProduct", ID_TypeProduct);
            command.Parameters.AddWithValue("@TypeProduct", TypeProduct);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void spTypeProduct_delete(Int32 ID_TypeProduct)
        {
            commandConfig("TypeProduct_delete");
            command.Parameters.AddWithValue("@ID_TypeProduct", ID_TypeProduct);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        //Процедуры для должности

        public void spDoljnost_insert(string Doljnost)
        {
            commandConfig("Doljnost_insert");
            command.Parameters.AddWithValue("@Doljnost", Doljnost);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
        public void spDoljnost_update(Int32 ID_Doljnosti, string Doljnost)
        {
            commandConfig("Doljnost_update");
            command.Parameters.AddWithValue("@ID_Doljnosti", ID_Doljnosti);
            command.Parameters.AddWithValue("@Doljnost", Doljnost);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void spDoljnost_delete(Int32 ID_Doljnosti)
        {
            commandConfig("Doljnost_delete");
            command.Parameters.AddWithValue("@ID_Doljnosti", ID_Doljnosti);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        //Процедуры для авторизации

        public void spAuthorization_insert(string Login, string Password)
        {
            commandConfig("Authorization_insert");
            command.Parameters.AddWithValue("@Login", Login);
            command.Parameters.AddWithValue("@Password", Password);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
        public void spAuthorization_update(Int32 ID_Authorization, string Login, string Password)
        {
            commandConfig("Authorization_update");
            command.Parameters.AddWithValue("@ID_Authorization", ID_Authorization);
            command.Parameters.AddWithValue("@Login", Login);
            command.Parameters.AddWithValue("@Password", Password);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void spAuthorization_delete(Int32 ID_Authorization)
        {
            commandConfig("Authorization_delete");
            command.Parameters.AddWithValue("@ID_Authorization", ID_Authorization);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        //Процедуры для состава блюд

        public void spSostavaBluda_insert(string VesProducta)
        {
            commandConfig("SostavaBluda_insert");
            command.Parameters.AddWithValue("@VesProducta", VesProducta);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
        public void spSostavaBluda_update(Int32 ID_SostavaBluda, string VesProducta)
        {
            commandConfig("SostavaBluda_update");
            command.Parameters.AddWithValue("@ID_SostavaBluda", ID_SostavaBluda);
            command.Parameters.AddWithValue("@VesProducta", VesProducta);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void spSostavaBluda_delete(Int32 ID_SostavaBluda)
        {
            commandConfig("SostavaBluda_delete");
            command.Parameters.AddWithValue("@ID_SostavaBluda", ID_SostavaBluda);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        //Процедуры для времени бронирования 

        public void spVremyBronirovanie_insert(string VremyaBronirovaniy)
        {
            commandConfig("VremyBronirovanie_insert");
            command.Parameters.AddWithValue("@VremyaBronirovaniy", VremyaBronirovaniy);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
        public void spVremyBronirovanie_update(Int32 ID_Vremeni_Bronirovaniy, string VremyaBronirovaniy)
        {
            commandConfig("VremyBronirovanie_update");
            command.Parameters.AddWithValue("@ID_Vremeni_Bronirovaniy", ID_Vremeni_Bronirovaniy);
            command.Parameters.AddWithValue("@VremyaBronirovaniy", VremyaBronirovaniy);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void spVremyBronirovanie_delete(Int32 ID_Vremeni_Bronirovaniy)
        {
            commandConfig("VremyBronirovanie_delete");
            command.Parameters.AddWithValue("@ID_Vremeni_Bronirovaniy", ID_Vremeni_Bronirovaniy);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        //Процедуры для учёта продуктов на складе

        public void spYchetProductovNaSklade_insert(string NameProduct, string VesProducta, string KolichestvoNaSklade, string SrokGodnosti, Int32 ID_TypeProduct)
        {
            commandConfig("YchetProductovNaSklade_insert");
            command.Parameters.AddWithValue("@NameProduct", NameProduct);
            command.Parameters.AddWithValue("@VesProducta", VesProducta);
            command.Parameters.AddWithValue("@KolichestvoNaSklade", KolichestvoNaSklade);
            command.Parameters.AddWithValue("@SrokGodnosti", SrokGodnosti);
            command.Parameters.AddWithValue("@ID_TypeProduct", ID_TypeProduct);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
        public void spYchetProductovNaSklade_update(Int32 ID_Producta, string NameProduct, string VesProducta, string KolichestvoNaSklade, string SrokGodnosti, Int32 ID_TypeProduct)
        {
            commandConfig("YchetProductovNaSklade_update");
            command.Parameters.AddWithValue("@ID_Producta", ID_Producta);
            command.Parameters.AddWithValue("@NameProduct", NameProduct);
            command.Parameters.AddWithValue("@VesProducta", VesProducta);
            command.Parameters.AddWithValue("@KolichestvoNaSklade", KolichestvoNaSklade);
            command.Parameters.AddWithValue("@SrokGodnosti", SrokGodnosti);
            command.Parameters.AddWithValue("@ID_TypeProduct", ID_TypeProduct);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void spYchetProductovNaSklade_delete(Int32 ID_Producta)
        {
            commandConfig("YchetProductovNaSklade_delete");
            command.Parameters.AddWithValue("@ID_Producta", ID_Producta);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        //Процедуры для меню 

        public void spMenu_insert(string NameBluda, string TimePrigorovleniy, string CenaBluda)
        {
            commandConfig("Menu_insert");
            command.Parameters.AddWithValue("@NameBluda", NameBluda);
            command.Parameters.AddWithValue("@TimePrigorovleniy", TimePrigorovleniy);
            command.Parameters.AddWithValue("@CenaBluda", CenaBluda);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
        public void spMenu_update(Int32 ID_Menu, string NameBluda, string TimePrigorovleniy, string CenaBluda)
        {
            commandConfig("Menu_update");
            command.Parameters.AddWithValue("@ID_Menu", ID_Menu);
            command.Parameters.AddWithValue("@NameBluda", NameBluda);
            command.Parameters.AddWithValue("@TimePrigorovleniy", TimePrigorovleniy);
            command.Parameters.AddWithValue("@CenaBluda", CenaBluda);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void spMenu_delete(Int32 ID_Menu)
        {
            commandConfig("Menu_delete");
            command.Parameters.AddWithValue("@ID_Menu", ID_Menu);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        //Процедуры для ингридиента

        public void spIngridient_insert(Int32 ID_Menu, Int32 ID_Producta, Int32 ID_SostaveBluda)
        {
            commandConfig("Ingridient_insert");
            command.Parameters.AddWithValue("@ID_Menu", ID_Menu);
            command.Parameters.AddWithValue("@ID_Producta", ID_Producta);
            command.Parameters.AddWithValue("@ID_SostaveBluda", ID_SostaveBluda);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
        public void spIngridient_update(Int32 ID_Ingridientov, Int32 ID_Menu, Int32 ID_Producta, Int32 ID_SostaveBluda)
        {
            commandConfig("Ingridient_update");
            command.Parameters.AddWithValue("@ID_Ingridientov", ID_Ingridientov);
            command.Parameters.AddWithValue("@ID_Menu", ID_Menu);
            command.Parameters.AddWithValue("@ID_Producta", ID_Producta);
            command.Parameters.AddWithValue("@ID_SostaveBluda", ID_SostaveBluda);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void spIngridient_delete(Int32 ID_Ingridientov)
        {
            commandConfig("Ingridient_delete");
            command.Parameters.AddWithValue("@ID_Ingridientov", ID_Ingridientov);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        //Процедуры для бронирования

        public void spInformationOBronirovanie_insert(Int32 ID_Stola, string DateBronirovaniy, string StatusStola, string KolichestvoGostey, string Kommentariy, Int32 ID_Vremeni_Bronirovaniy)
        {
            commandConfig("InformationOBronirovanie_insert");
            command.Parameters.AddWithValue("@ID_Stola", ID_Stola);
            command.Parameters.AddWithValue("@DateBronirovaniy", DateBronirovaniy);
            command.Parameters.AddWithValue("@StatusStola", StatusStola);
            command.Parameters.AddWithValue("@KolichestvoGostey", KolichestvoGostey);
            command.Parameters.AddWithValue("@Kommentariy", Kommentariy);
            command.Parameters.AddWithValue("@ID_Vremeni_Bronirovaniy", ID_Vremeni_Bronirovaniy);
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
        public void spInformationOBronirovanie_update(Int32 ID_Bronirovaniya, Int32 ID_Stola, string DateBronirovaniy, string StatusStola, string KolichestvoGostey, string Kommentariy, Int32 ID_Vremeni_Bronirovaniy)
        {
            commandConfig("InformationOBronirovanie_update");
            command.Parameters.AddWithValue("@ID_Bronirovaniya", ID_Bronirovaniya);
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

        public void spInformationOBronirovanie_delete(Int32 ID_Bronirovaniya)
        {
            commandConfig("InformationOBronirovanie_delete");
            command.Parameters.AddWithValue("@ID_Bronirovaniya", ID_Bronirovaniya);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        //Процедуры для персонала

        public void PresonalAdd(string Login, string Password, string Surname, string Name, string MiddleName, string Email, string PhoneNumber, int ID_Doljnosti)
        {
            Password = Crypt.Encrypt(Password);
            commandConfig("PresonalAdd");
            command.Parameters.AddWithValue("@Login", Login);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@Surname", Surname);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@MiddleName", MiddleName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            command.Parameters.AddWithValue("@ID_Doljnosti", ID_Doljnosti);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
        public void PresonalUpdate(Int32 ID_Personala, string Login, string Password, string Name, string Surname, string MiddleName, string Email, string PhoneNumber, Int32 ID_Doljnosti)
        {
            Password = Crypt.Encrypt(Password);
            commandConfig("PresonalUpdate");
            command.Parameters.AddWithValue("@Login", Login);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@ID_Personala", ID_Personala);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Surname", Surname);
            command.Parameters.AddWithValue("@MiddleName", MiddleName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            command.Parameters.AddWithValue("@ID_Doljnosti", ID_Doljnosti);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void spPersonal_delete(Int32 ID_Personala)
        {
            commandConfig("Personal_delete");
            command.Parameters.AddWithValue("@ID_Personala", ID_Personala);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }


        //Процедуры для бронирования

        public void spKlientBronirovanie_insert(Int32 ID_Bronirovaniya, Int32 ID_InformationOKliente)
        {
            commandConfig("KlientBronirovanie_insert");
            command.Parameters.AddWithValue("@ID_Bronirovaniya", ID_Bronirovaniya);
            command.Parameters.AddWithValue("@ID_InformationOKliente", ID_InformationOKliente);
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
        public void spKlientBronirovanie_update(Int32 ID_KlientBronirovanie, Int32 ID_Bronirovaniya, Int32 ID_InformationOKliente)
        {
            commandConfig("KlientBronirovanie_update");
            command.Parameters.AddWithValue("@ID_KlientBronirovanie", ID_KlientBronirovanie);
            command.Parameters.AddWithValue("@ID_Bronirovaniya", ID_Bronirovaniya);
            command.Parameters.AddWithValue("@ID_InformationOKliente", ID_InformationOKliente);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void spKlientBronirovanie_delete(Int32 ID_KlientBronirovanie)
        {
            commandConfig("KlientBronirovanie_delete");
            command.Parameters.AddWithValue("@ID_KlientBronirovanie", ID_KlientBronirovanie);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
        //Добавление пользователя
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
        //Обновление данных пользователя
        public void UsersRegistrationUpdate(int ID_InformationOKliente, string Login, string Password, string Name, string Surname, string MiddleName,
            string Email, string PhoneNumber)
        {
            Password = Crypt.Encrypt(Password);
            commandConfig("Users_RegistrationUpdate");
            command.Parameters.AddWithValue("@ID_InformationOKliente", ID_InformationOKliente);
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
        //Удаление пользователя
        public void LichnieDannieKlientaDelete(int ID_InformationOKliente)
        {
            commandConfig("LichnieDannieKlienta_delete");
            command.Parameters.AddWithValue("@ID_InformationOKliente", ID_InformationOKliente);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }
    }
}
    