using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kavezo_ASZAF.Model
{
    internal class Dolgozo
    {
        private int _dolgozoId;

        private string _nev;

        public int DolgozoId

        {

            get { return _dolgozoId; }

            set

            {

                if (value >= 0)

                    _dolgozoId = value;

            }

        }

        public string Nev

        {

            get { return _nev; }

            set

            {

                if (value != "")

                    _nev = value;

                else

                    _nev = "Ismeretlen";

            }

        }

        public Dolgozo(int dolgozoId, string nev)

        {

            DolgozoId = dolgozoId;

            Nev = nev;

        }

        public Dolgozo() { }

        public override string ToString()

        {

            return $"{DolgozoId,3} {Nev,-25}";

        }

    }
}
