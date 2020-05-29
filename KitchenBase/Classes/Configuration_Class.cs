using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace KitchenBase.Classes
{
    class Configuration_class
    {
        public event Action<DataTable> Server_Collection;
        public event Action<DataTable> Data_Base_Collection;
        public event Action<bool> Connection_Checked;
        public string DS = "Empty", IC = "Empty";
        public string ds = "";
        public static SqlConnection connection = new SqlConnection();

        public void SQL_Server_Configuration_Get()
        {
            RegistryKey registry = Registry.CurrentUser;
            RegistryKey key = registry.CreateSubKey("Server_Configuration");
            try
            {
                DS = key.GetValue("DS").ToString();
                IC = key.GetValue("IC").ToString();
            }
            catch
            {
                DS = "Empty";
                IC = "Empty";
            }
            finally
            {
                connection.ConnectionString = "Data Source = " + DS + "; Initial Catalog = " + IC + "; Integrated Security = true;";
            }
        }
        public void SQL_Server_Configuration_Set(string ds, string ic)
        {
            RegistryKey registry = Registry.CurrentUser;
            RegistryKey key = registry.CreateSubKey("Server_Configuration");
            key.SetValue("DS", ds);
            key.SetValue("IC", ic);
            SQL_Server_Configuration_Get();
        }
        public void SQL_Server_Enumuretor()
        {
            SqlDataSourceEnumerator sourceEnumerator = SqlDataSourceEnumerator.Instance;
            Server_Collection(sourceEnumerator.GetDataSources());
        }
        public void SQL_Data_Base_Checking()
        {
            connection.ConnectionString = "Data Source = " + ds + "; Initial Catalog = master; Integrated Security = True;";
            try
            {
                connection.Open();
                Connection_Checked(true);
            }
            catch
            {
                Connection_Checked(false);
            }
            finally
            {
                connection.Close();
            }
        }
        public void SQL_Data_Base_Collection()
        {

            SqlCommand command = new SqlCommand("select name from sys.databases where name not in ('master', 'tempdb', 'model', 'msdb')", connection);

            try
            {
                connection.Open();
                DataTable table = new DataTable();
                table.Load(command.ExecuteReader());
                Data_Base_Collection(table);
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }
        }


    }
}
