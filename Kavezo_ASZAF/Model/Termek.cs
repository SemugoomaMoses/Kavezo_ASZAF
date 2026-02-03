using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kavezo_ASZAF.Model
{
    internal class Termek
    {
        private int _termekId;

        private string _nev;

        private decimal _ar;

        public int TermekId

        {

            get { return _termekId; }

            set

            {

                if (value >= 0)

                    _termekId = value;

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

                    _nev = "Névtelen termék";

            }

        }

        public decimal Ar

        {

            get { return _ar; }

            set

            {

                if (value >= 0)

                    _ar = value;

            }

        }

        public Termek(int termekId, string nev, decimal ar)

        {

            TermekId = termekId;

            Nev = nev;

            Ar = ar;

        }

        public Termek() { }

        public override string ToString()

        {

            return $"{TermekId,3} {Nev,-30} {Ar,10:N0} Ft";

        }

    }
}
