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
        public static SqlConnection connection = new SqlConnection("Data Source=DESKTOP-2OC8HFJ\\MYGRIT;Initial Catalog=KitchenBase;" +
            "Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
            "ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public static string qrNameBluda = "select [ID_Menu], [NameBluda] as 'Название блюда', [TimePrigorovleniy] as 'Время приготовления', [CenaBluda] as 'Цена блюда'" +
            "from [Menu]",
            qrService = "select * from [ObslujivanieKlienta_View]",
            qrOrders = "select [ObslujivanieKlienta].[NomerZakaza], [VremyZakaza] from [ObslujivanieKlienta] " +
            "inner join [RabotaKuhni] on [RabotaKuhni].[NomerZakaza] = [ObslujivanieKlienta].[NomerZakaza] " +
            "where [StatusZakaza] = 0",
            qrOrdersMore = "select * from [OrderMore_View]",
            qrTime = "select * from [VremyBronirovanie]",
            qrReservation = "select[InformationOBronirovanie].[ID_Vremeni_Bronirovaniy], [VremyaBronirovaniy] as 'Время бронирования', [DateBronirovaniy] as 'Дата бронирования', " +
            "[KolichestvoGostey] as 'Количество гостей', [ID_Stola] as 'Номер стола', [InformationOBronirovanie].[ID_Bronirovaniya] as 'Номер бронирования', [Kommentariy] as 'Комментарий' " +
            "from[InformationOBronirovanie] " +
            "inner join[VremyBronirovanie] on[VremyBronirovanie].[ID_Vremeni_Bronirovaniy] = [InformationOBronirovanie].[ID_Vremeni_Bronirovaniy] " +
            "inner join[KlientBronirovanie] on[KlientBronirovanie].[ID_Bronirovaniya] = [InformationOBronirovanie].[ID_Bronirovaniya] " +
            "inner join[LichnieDannieKlienta] on[LichnieDannieKlienta].[ID_InformationOKliente] = [KlientBronirovanie].[ID_InformationOKliente]";

        public static int idUser,
            idKlient,
            idRecord, //id Выбранной записи
            idPersonal, //id Сотрудника
            idBludaSelected, //id Выбранного блюда
            idOffic; //id официанта для обслуживания клиентов

        private SqlCommand command = new SqlCommand("", connection);
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
        /// id клиента
        /// </summary>
        /// <param name="idUser">id из авторизации</param>
        public void getIDKlienta(int idUser)
        {
            try
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "select [ID_InformationOKliente] from [LichnieDannieKlienta] where [ID_Authorization] = '" + idUser + "'";
                connection.Open();
                idKlient = Convert.ToInt32(command.ExecuteScalar().ToString());
            }
            catch
            {
                idKlient = 0;
                
            }
            finally
            {
                DBConnection.connection.Close();
            }
        }
        /// <summary>
        /// id сотрудника
        /// </summary>
        /// <param name="idUser">id из авторизации</param>
        public void getIDPersonal(int idUser)
        {
            try
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "select [ID_Personala] from [Personal] where [ID_Authorization] = '" + idUser + "'";
                connection.Open();
                idPersonal = Convert.ToInt32(command.ExecuteScalar().ToString());
            }
            catch
            {
                idPersonal = 0;

            }
            finally
            {
                DBConnection.connection.Close();
            }
        }
        /// <summary>
        /// Роль
        /// </summary>
        /// <param name="userID">id Авторизованного пользователя</param>
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
        /// <summary>
        /// Возвращает фамилию и имя
        /// </summary>
        /// <param name="idKlient">id авторизованного клиента</param>
        /// <returns>Фамилия и имя клиента</returns>
        public string KlientData(Int32 idKlient)
        {
            string Data;
            command.CommandText = "select [Surname] + ' ' + [Name] from [LichnieDannieKlienta] " +
                "where [ID_InformationOKliente] like '%" + idKlient + "%'";
            connection.Open();
            Data = command.ExecuteScalar().ToString();
            connection.Close();
            return Data;
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
    }
}