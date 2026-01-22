using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kavezo_ASZAF.Model
{
    internal class RendelesTetel
    {
        public int TetelId { get; set; }        // adatbázis ID (egyértelmű azonosító)
        public int DolgozoId { get; set; }      // ki vette fel
        public int TermekId { get; set; }       // melyik termék
        public int Mennyiseg { get; set; }      // darabszám
        public DateTime RendelesDatum { get; set; } // mikor történt

        // Konstruktor
        public RendelesTetel(int tetelId, int dolgozoId, int termekId, int mennyiseg, DateTime datum)
        {
            TetelId = tetelId;
            DolgozoId = dolgozoId;
            TermekId = termekId;
            Mennyiseg = mennyiseg;
            RendelesDatum = datum;
        }

        public RendelesTetel()
        {
            
        }

        public override string ToString()
        {
            return $"Tetel {TetelId}: DolgozoID={DolgozoId}, TermekID={TermekId}, Mennyiseg={Mennyiseg}, Datum={RendelesDatum}";
        }
    }
}
