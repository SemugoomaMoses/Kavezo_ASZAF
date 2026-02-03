using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kavezo_ASZAF.Model
{
    internal class RendelesTetel
    {
        private int _tetelId;
        private int _dolgozoId;
        private int _termekId;
        private int _mennyiseg;
        private DateTime _rendelesDatum;

        public int TetelId
        {
            get { return _tetelId; }
            set
            {
                if (value >= 0)
                    _tetelId = value;
            }
        }

        public int DolgozoId
        {
            get { return _dolgozoId; }
            set
            {
                if (value >= 0)
                    _dolgozoId = value;
            }
        }

        public int TermekId
        {
            get { return _termekId; }
            set
            {
                if (value >= 0)
                    _termekId = value;
            }
        }

        public int Mennyiseg
        {
            get { return _mennyiseg; }
            set
            {
                if (value > 0)
                    _mennyiseg = value;
            }
        }

        public DateTime RendelesDatum
        {
            get { return _rendelesDatum; }
            set
            {
                _rendelesDatum = value;
            }
        }

        public RendelesTetel(int tetelId, int dolgozoId, int termekId, int mennyiseg, DateTime datum)
        {
            TetelId = tetelId;
            DolgozoId = dolgozoId;
            TermekId = termekId;
            Mennyiseg = mennyiseg;
            RendelesDatum = datum;
        }

        public RendelesTetel() { }

        public override string ToString()
        {

            return $"{TetelId,7} {DolgozoId,9} {TermekId,8} {Mennyiseg,6} {RendelesDatum.ToShortDateString(),20}";
        }
    }
}
