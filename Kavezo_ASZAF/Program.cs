using Kavezo_ASZAF.Database;
using Kavezo_ASZAF.Model;
using System.Data;

internal class Program
{
    //connection adatai
    public static readonly string connectionString = "Server=localhost;Database=kavezo;User=root;";

    //adattároló
    public static DataTable adatok = new DataTable();

    public static List<Termek> termekekLista = new();
    public static List<Dolgozo> dolgozokLista = new();
    public static List<RendelesTetel> rendelesTetelekLista = new();

    public static List<List<string>> csvAdatok = new List<List<string>>();
    public static Dictionary<int, int> akciok = new Dictionary<int, int>();
    public static FileIO.ReadFromFile reader = new FileIO.ReadFromFile();

    private static void Main(string[] args)
    {
        SelectFromTable("termekek", connectionString);
        TermekekBetoltese(adatok);

        SelectFromTable("dolgozok", connectionString);
        DolgozokBetoltese(adatok);

        SelectFromTable("rendelestetelek", connectionString);
        RendelesTetelekBetoltese(adatok);

        if (!File.Exists("akciok.csv"))
        {
            Console.WriteLine("HIBA: akciok.csv nem található!");
            Console.WriteLine("Tedd a fájlt a bin/Debug mappába.");
        }
        else
        {
            Fajlbeolvasas("akciok.csv", 2, ';', true);
            AkciokBetoltese(csvAdatok);
        }

        Menu();
    }

    private static void Menu()
    {
        while (true)
        {
            Console.WriteLine("\nKÁVÉZÓ - MENÜ");
            Console.WriteLine("1 - Listázás (Termék / Dolgozó / Rendelés / Kedvezmények)");
            Console.WriteLine("2 - Termék keresése névre");
            Console.WriteLine("3 - Legdrágább termék");
            Console.WriteLine("4 - Összbevétel rendeléstételekből");
            Console.WriteLine("5 - Dolgozónként rendelések száma");
            Console.WriteLine("6 - Új rendelés felvétele");
            Console.WriteLine("7 - Törlés (Rendelés / Termék)");
            Console.WriteLine("0 - Kilépés");

            Console.Write("\nTe: ");
            string valasz = Console.ReadLine();

            if (valasz == "0")
            {
                Console.WriteLine("Program: Kilépés. Szia!");
                break;
            }

            switch (valasz)
            {
                case "1":
                    ListazasAlMenu();
                    break;
                case "2":
                    KeresesAlMenu();
                    break;
                case "3":
                    LegdragabbTermek();
                    break;
                case "4":
                    OsszBevetel();
                    break;
                case "5":
                    DolgozonkentRendelesDb();
                    break;
                case "6":
                    UjRendelesFelvetele();
                    break;
                case "7":
                    TorlesAlMenu();
                    break;
                default:
                    Console.WriteLine("Program: Ezt nem értem 😅 (0-8)");
                    break;
            }
        }
    }

    

    private static void ListazasAlMenu()
    {
        Console.WriteLine("\nLISTÁZÁS:");
        Console.WriteLine("1 - Termékek");
        Console.WriteLine("2 - Dolgozók");
        Console.WriteLine("3 - Rendelések");
        Console.WriteLine("4 - Kedvezmények");
        Console.WriteLine("0 - Vissza");

        Console.Write("\nTe: ");
        string v = Console.ReadLine();

        switch (v)
        {
            case "1":
                TermekekListazasa();
                break;
            case "2":
                DolgozokListazasa();
                break;
            case "3":
                RendelesekListazasa();
                break;
            case "4":
                AkciosTermekekKiirasa();
                break;
            case "0":
                break;
            default:
                Console.WriteLine("Program: Hibás választás.");
                break;
        }
    }

    private static void KeresesAlMenu()
    {
        Console.WriteLine("\nKERESÉS:");
        Console.WriteLine("1 - Termékre keresés");
        Console.WriteLine("2 - Rendelésre keresés");
        Console.WriteLine("0 - Vissza");


        Console.Write("Te:");
        string valasz2 = Console.ReadLine();

        switch (valasz2)
        {
            case "1":
                Console.Write("Program: Add meg a keresett termék nevét (részlet is jó): ");
                TermekKeresesNevre(Console.ReadLine());
                break;
            case "2":
                Console.Write("Program: Add meg a keresett rendelés dátumát (részlet is jó): ");
                RendelesKeresesDatumra(Console.ReadLine());
                break;
            case "0":
                break;
            default:
                Console.WriteLine("Program: Hibás választás.");
                break;
        }
    }

    private static void TorlesAlMenu()
    {
        Console.WriteLine("\nTÖRLÉS:");
        Console.WriteLine("1 - Rendelés törlése");
        Console.WriteLine("2 - Termék törlése");
        Console.WriteLine("0 - Vissza");

        Console.Write("\nTe: ");
        string valasz3 = Console.ReadLine();

        switch (valasz3)
        {
            case "1":
                RendelesTorlese();
                break;
            case "2":
                TermekTorlese();
                break;
            case "0":
                break;
            default:
                Console.WriteLine("Program: Hibás választás.");
                break;
        }
    }

    private static void TermekekListazasa()
    {
        Console.WriteLine("\nProgram: Termékek:");
        Console.WriteLine($"{"ID",3} {"Név",-30} {"Ár",10}");
        Console.WriteLine(new string('-', 48));

        foreach (var t in termekekLista)
        {
            Console.WriteLine($"{t.ToString()}");
        }
    }

    private static void AkciosTermekekKiirasa()
    {
        if (akciok.Count == 0)
        {
            Console.WriteLine("Program: Nincs akció betöltve (akciok.csv hiányzik vagy üres).");
            return;
        }

        Console.WriteLine("\nProgram: Akciós termékek:");
        Console.WriteLine($"{"Név",-20} {"Eredeti",10} {"Kedv",6} {"Akciós",10}");
        Console.WriteLine(new string('-', 52));

        foreach (var t in termekekLista)
        {
            if (akciok.ContainsKey(t.TermekId))
            {
                int kedv = akciok[t.TermekId];
                decimal akciosAr = t.Ar * (100 - kedv) / 100m;
                Console.WriteLine($"{t.Nev,-20} {t.Ar,10:N0} {kedv,5}% {akciosAr,10:N0} Ft");
            }
        }
    }

    private static void DolgozokListazasa()
    {
        Console.WriteLine("\nProgram: Dolgozók:");
        Console.WriteLine($"{"ID",3} {"Név",-25}");
        Console.WriteLine(new string('-', 32));

        foreach (var d in dolgozokLista)
        {
            Console.WriteLine($"{d.ToString()}");
        }
    }

    private static void RendelesekListazasa()
    { 
        Console.WriteLine("\nProgram: Rendeléstételek:");
        Console.WriteLine($"{"TetelID",7} {"DolgozoID",9} {"TermekID",8} {"Menny",6} {"Dátum",12}");
        Console.WriteLine(new string('-', 55));

        foreach (var r in rendelesTetelekLista)
        {
            Console.WriteLine($"{r.ToString()}");
        }
    }

    private static void TermekKeresesNevre(string keres)
    {
        if (keres == null) keres = "";
        keres = keres.ToLower();

        bool volt = false;

        foreach (var t in termekekLista)
        {
            if (t.Nev.ToLower().Contains(keres))
            {
                if (!volt)
                {
                    Console.WriteLine("\nProgram: Találatok:");
                    Console.WriteLine($"{"ID",3} {"Név",-30} {"Ár",10}");
                    Console.WriteLine(new string('-', 52));
                }

                volt = true;
                Console.WriteLine($"{t.ToString()} Ft");
            }
        }

        if (!volt)
        {
            Console.WriteLine("Program: Nincs találat.");
        }
    }

    private static void RendelesKeresesDatumra(string? v)
    {
        
    }

    private static void LegdragabbTermek()
    {
        if (termekekLista.Count == 0)
        {
            Console.WriteLine("Program: Nincsenek termékek.");
            return;
        }

        Termek max = termekekLista[0];

        for (int i = 1; i < termekekLista.Count; i++)
        {
            if (termekekLista[i].Ar > max.Ar)
                max = termekekLista[i];
        }

        Console.WriteLine($"\nProgram: Legdrágább termék: {max.Nev} - {max.Ar:N0} Ft");
    }

    private static void OsszBevetel()
    {
        decimal bevetel;
        BevetelSzamitas(out bevetel);
        Console.WriteLine($"\nProgram: Összbevétel: {bevetel:N0} Ft");
    }

    private static void BevetelSzamitas(out decimal bevetel)
    {
        bevetel = 0;

        foreach (var r in rendelesTetelekLista)
        {
            decimal ar = 0;
            foreach (var t in termekekLista)
            {
                if (t.TermekId == r.TermekId)
                {
                    ar = t.Ar;
                    break;
                }
            }

            bevetel += ar * r.Mennyiseg;
        }
    }

    private static void DolgozonkentRendelesDb()
    {
        Console.WriteLine("\nProgram: Dolgozónként rendelések száma:");

        Dictionary<int, int> stat = new Dictionary<int, int>();

        foreach (var r in rendelesTetelekLista)
        {
            if (!stat.ContainsKey(r.DolgozoId))
                stat[r.DolgozoId] = 0;

            stat[r.DolgozoId] = stat[r.DolgozoId] + 1;
        }

        Console.WriteLine($"{"Dolgozó",-25} {"Rendelések",10}");
        Console.WriteLine(new string('-', 38));

        foreach (var d in dolgozokLista)
        {
            int db = 0;
            if (stat.ContainsKey(d.DolgozoId))
                db = stat[d.DolgozoId];

            Console.WriteLine($"{d.Nev,-25} {db,10}");
        }
    }

    private static void UjRendelesFelvetele()
    {
        Console.WriteLine("\n--- Új rendelés felvétele ---");

        Console.Write("Add meg a dolgozó ID-t: ");
        int dolgozoId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Add meg a termék ID-t: ");
        int termekId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Add meg a mennyiséget: ");
        int mennyiseg = Convert.ToInt32(Console.ReadLine());

        int siker = DatabaseService.RendelesFelvetel(
            connectionString,
            dolgozoId,
            termekId,
            mennyiseg,
            DateTime.Now
        );

        if (siker == 1)
        {
            Console.WriteLine("Program: Rendelés sikeresen elmentve az adatbázisba!");
            SelectFromTable("rendelestetelek", connectionString);
            RendelesTetelekBetoltese(adatok);
        }
        else
        {
            Console.WriteLine("Program: Hiba történt mentés közben.");
        }
    }

    //törlések
    private static void RendelesTorlese()
    {
        Console.Write("\nAdd meg a törlendő rendelés (TetelId) azonosítóját: ");
        int id = Convert.ToInt32(Console.ReadLine());

        int siker = DatabaseService.DeleteById("rendelestetelek", "TetelId", connectionString, id);

        if (siker == 1)
        {
            Console.WriteLine("Program: Rendelés sikeresen törölve!");
            SelectFromTable("rendelestetelek", connectionString);
            RendelesTetelekBetoltese(adatok);
        }
        else
        {
            Console.WriteLine("Program: Nem sikerült törölni (nincs ilyen ID).");
        }
    }

    private static void TermekTorlese()
    {
        Console.Write("\nAdd meg a törlendő termék (TermekId) azonosítóját: ");
        int id = Convert.ToInt32(Console.ReadLine());

        int siker = DatabaseService.DeleteById("termekek", "TermekId", connectionString, id);

        if (siker == 1)
        {
            Console.WriteLine("Program: Termék sikeresen törölve!");
            SelectFromTable("termekek", connectionString);
            TermekekBetoltese(adatok);
        }
        else
        {
            Console.WriteLine("Program: Nem sikerült törölni (nincs ilyen ID).");
        }
    }


    //csv fájl
    private static void AkciokBetoltese(List<List<string>> csvAdatok)
    {
        akciok.Clear();

        foreach (var sor in csvAdatok)
        {
            int termekId = Convert.ToInt32(sor[0]);
            int kedvezmeny = Convert.ToInt32(sor[1]);
            akciok[termekId] = kedvezmeny;
        }
    }

    private static void Fajlbeolvasas(string v1, int v2, char v3, bool v4)
    {
        csvAdatok = reader.FileRead(v1, v2, v3, v4);
    }


    //adatbázis
    private static void TermekekBetoltese(DataTable adatok)
    {
        termekekLista.Clear();

        foreach (DataRow t in adatok.Rows)
        {
            Termek termek = new Termek
            {
                TermekId = t.Field<int>(0),
                Nev = t.Field<string>(1),
                Ar = t.Field<decimal>(2)
            };

            termekekLista.Add(termek);
        }
    }

    private static void DolgozokBetoltese(DataTable adatok)
    {
        dolgozokLista.Clear();

        foreach (DataRow d in adatok.Rows)
        {
            Dolgozo dolgozo = new Dolgozo
            {
                DolgozoId = d.Field<int>(0),
                Nev = d.Field<string>(1)
            };

            dolgozokLista.Add(dolgozo);
        }
    }

    private static void RendelesTetelekBetoltese(DataTable adatok)
    {
        rendelesTetelekLista.Clear();

        foreach (DataRow r in adatok.Rows)
        {
            RendelesTetel tetel = new RendelesTetel
            {
                TetelId = r.Field<int>(0),
                DolgozoId = r.Field<int>(1),
                TermekId = r.Field<int>(2),
                Mennyiseg = r.Field<int>(3),
                RendelesDatum = r.Field<DateTime>(4)
            };

            rendelesTetelekLista.Add(tetel);
        }
    }

    private static void SelectFromTable(string tableName, string connectionString)
    {
        adatok = DatabaseService.GetAllData(tableName, connectionString);
    }

    private static void DBcheck(string connectionString)
    {
        DatabaseService.DbConnectionCheck(connectionString);
    }
}