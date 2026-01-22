using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kavezo_ASZAF.Database
{
    internal class DatabaseService
    {
        private static string connectionString;
        private static string table;
        private static string query_parameters;

        public static void DbConnectionCheck(string connectionString)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Sikeres a csatlakozás!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sikertelen kapcsolodás!");
                Console.WriteLine(ex);
            }
        }

        public static DataTable GetAllData(string tableName, string connectionString)
        {
            //1. kell egy kapcsolodás
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            //2. kell egy parancs
            using var command = new MySqlCommand("select * from " + tableName, connection);

            //3. parancs eredményként feldolgozása
            using var reader = command.ExecuteReader();

            //4. adatszerkezet létrehozása
            var dataTable = new DataTable();

            //5. adatszerkezet betöltése
            dataTable.Load(reader);

            return dataTable;
        }

        public static int DeleteById(string tableName, string connectionString, int id)
        {
            //1. kell egy kapcsolat
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            //2. kell egy parancs
            using var command = new MySqlCommand($"delete from {tableName} where id=@id", connection);
            command.Parameters.AddWithValue("@id", id); //behelyettesíti az id-t 

            return command.ExecuteNonQuery();
            //1-sikeres command, 0-sikertelen utasítás
        }
    }
}
