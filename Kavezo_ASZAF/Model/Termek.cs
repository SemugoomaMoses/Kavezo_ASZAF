using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kavezo_ASZAF.Model
{
    internal class Termek
    {
        public int TermekId { get; set; }       // adatbázis ID
        public string Nev { get; set; }         // termék neve
        public decimal Ar { get; set; }         // ára

        public Termek(int termekId, string nev, decimal ar)
        {
            TermekId = termekId;
            Nev = nev;
            Ar = ar;
        }

        public Termek()
        {
           
        }

        public override string ToString()
        {
            return $"{Nev} ({Ar} Ft)";
        }
    }
}
