using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontrolltooMang
{
    class Ese : IUksus //наследует от IUksus
    {
        public int punktArv;
        private string nimetus;

        public Ese(string nimetus, int punktArv) //Klassis peab olema kahe parameetriga konstruktor, mille abil saab määrata nimetuse ja punktide
        {
            this.nimetus = nimetus;
            this.punktArv = punktArv;
        }
        public int PunktideArv() //Meetod punktideArv tagastab punktide arvu.
        {
            return punktArv;
        }

        public string info() //Meetod info tagastab selle eseme nimetuse.
        {
            return nimetus;
        }


    }
}