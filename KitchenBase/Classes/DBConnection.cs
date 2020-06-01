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
           "Data Source = DESKTOP-RV6IQJS\\SQLEXPRESS; " +
               " Initial Catalog = KitchenBase3; Persist Security Info = true;" +
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
        public static string qrYchetProductovNaSklade = "SELECT [ID_Producta], [NameProduct] as \"Наименование продукта\", [VesProducta] as \"ВесПродукта\", [KolichestvoNaSklade] as \"КоличествоНаСкладе\", [SrokGodnosti] as \"СрокГодности\"," +
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
        public static string qrMenu = "SELECT[ID_Menu], [NameBluda] as \"Наименование Блюда\", [TimePrigorovleniy] as \"Время приготовления\", [CenaBluda] as \"Цена блюда\", "+
        "[dbo].[Ingridient].[ID_Producta], [dbo].[YchetProductovNaSklade].[NameProduct] as \"Название продукта\", "+
		"[dbo].[Ingridient].[ID_SostaveBluda],  [dbo].[SostavaBluda].[VesProducta] as \"Вес продукта\" FROM[dbo].[Ingridient] "+
        "INNER JOIN[dbo].[SostavaBluda] ON [dbo].[Ingridient].[ID_SostaveBluda] = [dbo].[SostavaBluda].[ID_SostavaBluda] "+
        "INNER JOIN [dbo].[Menu] ON [dbo].[Menu].[ID_SostavaBluda] = [dbo].[SostavaBluda].[ID_SostavaBluda] " +
        "INNER JOIN[dbo].[YchetProductovNaSklade] ON[dbo].[Ingridient].[ID_Producta] = [dbo].[YchetProductovNaSklade].[ID_Producta]";
            
            /*  Старый запрос на всякий случай
            "SELECT [ID_Menu], [NameBluda] as \"НаименованиеБлюда\", [TimePrigorovleniy] as \"ВремяПриготовления\", [CenaBluda] as \"ЦенаБлюда\", "+
        "[dbo].[SostavaBluda].[ID_SostavaBluda], [VesProducta] as \"ВесПродукта\" FROM [dbo].[Menu]" +
        "INNER JOIN [dbo].[SostavaBluda] ON [dbo].[Menu].[ID_SostavaBluda] = [dbo].[SostavaBluda].[ID_SostavaBluda]";  */

        //Таблица клиент (Запрос работает)
        public DataTable dtLichnieDannieKlienta = new DataTable("LichnieDannieKlienta");
        
        public static string qrLichnieDannieKlienta = "SELECT [ID_InformationOKliente], [Name] as \"Имя\", [Surname] as \"Фамилия\", [MiddleName] as \"Отчество\", [Email] as \"Почта\"," +
        "[PhoneNumber] as \"НомерТелефона\", [dbo].[LichnieDannieKlienta].[ID_Authorization], [Login] as \"Логин\", [Password] as \"Пароль\" FROM [dbo].[LichnieDannieKlienta]" +
         " INNER JOIN [dbo].[Authorization] ON [dbo].[LichnieDannieKlienta].[ID_Authorization] = [dbo].[Authorization].[ID_Authorization]";

        public static int NomerZakaza = new int();
        public static string qrRabotaKuhni = "select * from [OrderMore_View] where [NomerZakaza] = '" + NomerZakaza + "'";


        private SqlCommand command = new SqlCommand("", connection);
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
    }
}
