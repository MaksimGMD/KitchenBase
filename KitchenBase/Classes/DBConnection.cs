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
        public static SqlConnection connection = new SqlConnection(@"Data Source = DESKTOP-T819KVA\SQLEXPRESS; Initial Catalog = KitchenBase; " + 
            "Integrated Security = True; Connect Timeout = 30; Encrypt=False;" +
            "TrustServerCertificate=False; ApplicationIntent=ReadWrite;" +
            "MultiSubnetFailover=False");
        //Таблица персонал
        public DataTable dtPersonal = new DataTable("Personal");
        public static string qrPersonal = "SELECT [ID_Personala], [Surname] as \"Фамилия\", [Name] as \"Имя\", [MiddleName] as \"Отчество\", [Email] as \"Почта\"," +
            "[PhoneNumber] as \"НомерТелефона\", [dbo].[Personal].[ID_Doljnosti], [Doljnost] as \"Должность\" FROM [dbo].[Personal], " +
                                                "[dbo].[Personal].[ID_Authorization], [Login] as \"Логин\" FROM [dbo].[Personal], " +
                                                "[dbo].[Personal].[ID_Authorization], [Password] as \"Пароль\" FROM [dbo].[Personal]" +
             " INNER JOIN [dbo].[Authorization] ON [dbo].[Personal].[ID_Personala] = [dbo].[Authorization].[ID_Authorization]" +
             " INNER JOIN [dbo].[Doljnost] ON [dbo].[Personal].[ID_Personala] = [dbo].[Doljnost].[ID_Doljnosti]";
        //Таблица учёт продуктов на складе
        // public DataTable dtYchetProductovNaSklade = new DataTable("YchetProductovNaSklade");
        // public static string qrYchetProductovNaSklade = "SELECT [ID_Producta], [NameProduct] as \"Наименование\"," +
        //Таблица тип продуктов
        //Таблица должности
        //Таблица состав блюда
        //Таблица вес продуктов
        //Таблица информация о бронировании
        //Таблица ингридиенты
        private SqlCommand command = new SqlCommand("", connection);
        private void dtFill(DataTable table, string query)
        {
            command.CommandText = query;
            connection.Open();
            table.Load(command.ExecuteReader());
            connection.Close();

        }
        public void PersonalFill()
        {
            dtFill(dtPersonal, qrPersonal);
        }


    }
}
