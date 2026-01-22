using Kavezo_ASZAF.Database;
using System.Data;

internal class Program
{
    //connection adatai
    public static readonly string connectionString = "Server=localhost;Database=kavezo;User=root;";

    //adattároló
    public static DataTable adatok = new DataTable();


    public static List<Orszag> orszagokLista = new List<Orszag>();
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine("Github kapcsolás teszt");
        Console.WriteLine("Github összekapcsolás");
    }

    private static void SelectFromTable(string tableName, string connectionString)
    {
        adatok = DatabaseService.GetAllData(tableName, connectionString);
        Console.WriteLine("Adatok sikeresen szinkronizálva, átmeneti tároló");
    }

    private static void DBcheck(string connectionString)
    {
        DatabaseService.DbConnectionCheck(connectionString);
    }
}