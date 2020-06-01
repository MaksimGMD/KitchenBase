using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Crypt_Library;

namespace KitchenBaseWeb
{
    public class DBConnection
    {
        //Подключение к базе данных 
        public static SqlConnection connection = new SqlConnection("DESKTOP-RV6IQJS\\SQLEXPRESS; Initial Catalog = KitchenBase; " +
            "Integrated Security = True; Connect Timeout = 30; Encrypt=False;" +
            "TrustServerCertificate=False; ApplicationIntent=ReadWrite;" +
            "MultiSubnetFailover=False User ID = sa; Password = \"pass13\"");
        public static string qrNameBluda = "select [ID_Menu], [NameBluda] as 'Название блюда', [TimePrigorovleniy] as 'Время приготовления', [CenaBluda] as 'Цена блюда'" +
            "from [Menu]",
            qrService = "select * from [ObslujivanieKlienta_View]",
            qrTime = "select * from [VremyBronirovanie]",
            qrReservation = "select[InformationOBronirovanie].[ID_Vremeni_Bronirovaniy], [VremyaBronirovaniy] as 'Время бронирования', [DateBronirovaniy] as 'Дата бронирования', " +
            "[KolichestvoGostey] as 'Количеесто гостей', [ID_Stola] as 'Номер стола', [InformationOBronirovanie].[ID_Bronirovaniya] as 'Номер бронирования', [Kommentariy] as 'Комментарий' " +
            "from[InformationOBronirovanie] " +
            "inner join[VremyBronirovanie] on[VremyBronirovanie].[ID_Vremeni_Bronirovaniy] = [InformationOBronirovanie].[ID_Vremeni_Bronirovaniy] " +
            "inner join[KlientBronirovanie] on[KlientBronirovanie].[ID_Bronirovaniya] = [InformationOBronirovanie].[ID_Bronirovaniya] " +
            "inner join[LichnieDannieKlienta] on[LichnieDannieKlienta].[ID_InformationOKliente] = [KlientBronirovanie].[ID_InformationOKliente] " +
            "where[KlientBronirovanie].[ID_InformationOKliente] = '" + idUser + "'";

        public static int idUser;
        private SqlCommand command = new SqlCommand("", connection);
        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="login"></param>
        /// <returns>Возвращает id записи</returns>
        public Int32 Authorization (string login)
        {
            //password = BitConverter.ToString(Crypt_Library.Crypt.Encryption(password));
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select [ID_Authorization] from" +
                    "[Authorization] where [Login] = '" + login + "'";
                DBConnection.connection.Open();
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
                DBConnection.connection.Close();
            }
        }
        /// <summary>
        /// Роль
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>Роль пользователя</returns>
        public string userRole(Int32 userID)
        {
            string RoleID;
            command.CommandText = "select [Stasus] from [Authorization_View] where [ID_Authorization] like '%" + idUser + "%'";
            connection.Open();
            RoleID = command.ExecuteScalar().ToString();
            connection.Close();
            return RoleID;
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