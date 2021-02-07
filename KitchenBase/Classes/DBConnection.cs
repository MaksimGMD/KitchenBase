using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace KitchenBase.Classes
{
    class DBConnection
    {
        //                                                     ||||||||||||||||||||||||||||||||||||ВНИМАНИЕ!!!!||||||||||||||||||||||||||||||||||||
        //Подключение к базе данных |||||||||||||||||||||||||||||||||||| Пока хз как для всех сразу путь прописать, поэтому меняйте сами! ||||||||||||||||||||||||||||||||||||
        public static SqlConnection connection = new SqlConnection(

             //ПУТЬ САНИ
             //  @"Data Source = DESKTOP-T819KVA\SQLEXPRESS; " +
             // " Initial Catalog = KitchenBase; Persist Security Info = true;" +
             // " User ID = sa; Password = \"psl14082001\""); 

             //ПУТЬ МАКСА
             // "Data Source=DESKTOP-2OC8HFJ\\MYGRIT;Initial Catalog=KitchenBase;" +
             //"Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
             //"ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

             //ПУТЬ ДАНИЛЫ
             "Data Source = DESKTOP-RV6IQJS\\SQLEXPRESS; " +
                " Initial Catalog = KitchenBase Final; Persist Security Info = true;" +
                " User ID = sa; Password = \"pass13\"");

        //Таблица персонал (Запрос работает)
        public DataTable dtPersonal = new DataTable("Personal");
        public static string qrPersonal = "SELECT [ID_Personala], [Surname] as \"Фамилия\", [Name] as \"Имя\", [MiddleName] as \"Отчество\", [Email] as \"Почта\"," +
        "[PhoneNumber] as \"Номер телефона\", [dbo].[Personal].[ID_Doljnosti], [Doljnost] as \"Должность\", " +
                                            "[dbo].[Personal].[ID_Authorization], [Login] as \"Логин\", [Password] as \"Пароль\" FROM [dbo].[Personal]" +
         " INNER JOIN [dbo].[Authorization] ON [dbo].[Personal].[ID_Authorization] = [dbo].[Authorization].[ID_Authorization]" +
         " INNER JOIN [dbo].[Doljnost] ON [dbo].[Personal].[ID_Doljnosti] = [dbo].[Doljnost].[ID_Doljnosti]";

        //Таблица вес продуктов (СОСТАВ БЛЮДА) (Запрос работает)
        public DataTable dtSostavaBluda = new DataTable("SostavaBluda");
        public static string qrSostavaBluda = "SELECT [ID_SostavaBluda], [VesProducta] as \"Вес продукта\" FROM [dbo].[SostavaBluda]";

        //Таблица учёт продуктов на складе (Запрос работает)
        public DataTable dtYchetProductovNaSklade = new DataTable("YchetProductovNaSklade");
        public static string qrYchetProductovNaSklade = "SELECT [ID_Producta], [NameProduct] as \"Наименование продукта\", [VesProducta] as \"Вес продукта\", [KolichestvoNaSklade] as \"Количество на складе\", [SrokGodnosti] as \"СрокГодности\"," +
           "[dbo].[YchetProductovNaSklade].[ID_TypeProduct], [TypeProduct] as \"Название типа продукта\" FROM [dbo].[YchetProductovNaSklade]" +
             " INNER JOIN [dbo].[TypeProduct] ON [dbo].[YchetProductovNaSklade].[ID_TypeProduct] = [dbo].[TypeProduct].[ID_TypeProduct]";

        //Таблица тип продуктов (Запрос работает)
        public DataTable dtTypeProduct = new DataTable("TypeProduct");
        public static string qrTypeProduct = "SELECT [ID_TypeProduct], [TypeProduct] as \"Название типа продукта\" FROM [dbo].[TypeProduct]";

        //Таблица должности (Запрос работает)
        public DataTable dtDoljnost = new DataTable("Doljnost");
        public static string qrDoljnost = "SELECT [ID_Doljnosti], [Doljnost] as \"Должность\" FROM [dbo].[Doljnost]";

        //Таблица меню (Запрос работает)
        public DataTable dtMenu = new DataTable("Menu");
        public static string qrMenu = "SELECT [dbo].[Menu].[ID_Menu], [NameBluda] as \"Наименование Блюда\", [TimePrigorovleniy] as \"Время приготовления\", [CenaBluda] as \"Цена блюда\", " +
        "[dbo].[Ingridient].[ID_Ingridientov], [dbo].[Ingridient].[ID_Producta], [dbo].[YchetProductovNaSklade].[NameProduct] as \"Название продукта\", " +
		"[dbo].[Ingridient].[ID_SostaveBluda],  [dbo].[SostavaBluda].[VesProducta] as \"Вес продукта\" FROM[dbo].[Ingridient] "+
        "INNER JOIN [dbo].[SostavaBluda] ON [dbo].[Ingridient].[ID_SostaveBluda] = [dbo].[SostavaBluda].[ID_SostavaBluda] "+
        "INNER JOIN [dbo].[Menu] ON [dbo].[Ingridient].[ID_Menu] = [dbo].[Menu].[ID_Menu] " +
        "INNER JOIN [dbo].[YchetProductovNaSklade] ON [dbo].[Ingridient].[ID_Producta] = [dbo].[YchetProductovNaSklade].[ID_Producta]";          

        //Таблица клиент (Запрос работает)
        public DataTable dtLichnieDannieKlienta = new DataTable("LichnieDannieKlienta");
        
        public static string qrLichnieDannieKlienta = "SELECT [ID_InformationOKliente], [Name] as \"Имя\", [Surname] as \"Фамилия\", [MiddleName] as \"Отчество\", [Email] as \"Почта\"," +
        "[PhoneNumber] as \"Номер телефона\", [dbo].[LichnieDannieKlienta].[ID_Authorization], [Login] as \"Логин\", [Password] as \"Пароль\" FROM [dbo].[LichnieDannieKlienta]" +
         " INNER JOIN [dbo].[Authorization] ON [dbo].[LichnieDannieKlienta].[ID_Authorization] = [dbo].[Authorization].[ID_Authorization]";

        public static int NomerZakaza = new int();
        public DataTable dtOrderMore_View = new DataTable("OrderMore_View");
        public static string qrRabotaKuhni = "select * from [OrderMore_View]";


        /// <summary>
        /// Количество блюд
        /// </summary>
        /// <param name="Nazvanie">Название блюда</param>
        /// <returns>Количество найденных записей</returns>
        public int MenuFind(string Nazvanie)
        {
            int Found;
            command.CommandText = "SELECT count(*) FROM [Menu] where [NameBluda] like '%" + Nazvanie + "%'";
            connection.Open();
            Found = Convert.ToInt32(command.ExecuteScalar().ToString());
            connection.Close();
            return Found;        
        }

        private SqlCommand command = new SqlCommand("", connection);

        public static int idUser; //id Авторизации
        private void dtFill(DataTable table, string query)
        {
            command.CommandText = query;
            connection.Open();
            table.Load(command.ExecuteReader());
            connection.Close();

        }
        //заполнение персонал
        public void PersonalFill()
        {
            dtFill(dtPersonal, qrPersonal);
        }
        //заполнение тип продуктов
        public void TypeProductFill()
        {
            dtFill(dtTypeProduct, qrTypeProduct);
        }
        //заполнение вес продуктов
        public void SostavaBludaFill()
        {
            dtFill(dtSostavaBluda, qrSostavaBluda);
        }
        //заполнение учёт продуктов на складе
        public void YchetProductovNaSkladeFill()
        {
            dtFill(dtYchetProductovNaSklade, qrYchetProductovNaSklade);
        }
        //заполнение должность
        public void DoljnostFill()
        {
            dtFill(dtDoljnost, qrDoljnost);
        }
        //заполнение меню
        public void MenuFill()
        {
            dtFill(dtMenu, qrMenu);
        }
        //заполнение клиента
        public void LichnieDannieKlientaFill()
        {
            dtFill(dtLichnieDannieKlienta, qrLichnieDannieKlienta);
        }
        //заполнение заказа
        public void RabotaKuhniFill()
        {
            dtFill(dtOrderMore_View, qrRabotaKuhni);
        }    

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="login">Логин</param>
        /// <returns>Возвращает id записи</returns>
        public Int32 Authorization(string login)
        {
            try
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "select [ID_Authorization] from" +
                    "[Authorization] where [Login] = '" + login + "'";
                connection.Open();
                idUser = Convert.ToInt32(command.ExecuteScalar().ToString());
                return (idUser);
            }
            catch
            {
                idUser = 0;
                return (idUser);
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Должность
        /// </summary>
        /// <param name="userID">id Авторизованного пользователя</param>
        /// <returns>Роль пользователя</returns>
        public string userDoljnost(Int32 userID)
        {
            string DoljnostID;
            command.CommandText = "select [ID_Doljnosti] from [Personal] where [ID_Personala]  like '%" + idUser + "%'";
            connection.Open();
            DoljnostID = command.ExecuteScalar().ToString();
            connection.Close();
            return DoljnostID;
        }
        /// <summary>
        /// Проверка уникальностии логина
        /// </summary>
        /// <param name="login">Логин</param>
        /// <returns>Количество найденных пользователей</returns>
        public Int32 LoginCheck(string login)
        {
            int loginCheck;
            command.CommandText = "select count (*) from [Authorization] where Login like '%" + login + "%'";
            connection.Open();
            loginCheck = Convert.ToInt32(command.ExecuteScalar().ToString());
            connection.Close();
            return loginCheck;
        }
    }
}
