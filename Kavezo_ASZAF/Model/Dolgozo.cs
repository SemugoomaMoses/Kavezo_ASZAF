using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kavezo_ASZAF.Model
{
    internal class Dolgozo
    {
        public int DolgozoId { get; set; }      // adatbázis ID
        public string Nev { get; set; }         // dolgozó neve

        // Konstruktor
        public Dolgozo(int dolgozoId, string nev)
        {
            DolgozoId = dolgozoId;
            Nev = nev;
        }

        public Dolgozo()
        {
          
        }

        public override string ToString()
        {
            return $"{DolgozoId}: {Nev}";
        }
    }
}
