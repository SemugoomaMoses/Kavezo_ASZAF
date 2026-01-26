using Kavezo_ASZAF.Database;
using Kavezo_ASZAF.Model;
using System.Data;

internal class Program
{
    //connection adatai
    public static readonly string connectionString = "Server=localhost;Database=kavezo;User=root;";

    //adattároló
    public static DataTable adatok = new DataTable();


    public static List<Termek> termekekLista = new List<Termek>();
    private static void Main(string[] args)
    {
        DBcheck(connectionString);
        SelectFromTable("termekek", connectionString);
        AdatBetoltes(adatok);
    }
    private static void AdatBetoltes(DataTable adatok)
    {
        foreach (DataRow o in adatok.Rows)
        {
            Termek termek = new Termek();

             termek.TermekId = o.Field<int>(0);
             termek.Nev = o.Field<string>(1);
             termek.Ar = o.Field<decimal>(2);

            termekekLista.Add(termek);
        }
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