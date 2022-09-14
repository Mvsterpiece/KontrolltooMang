using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontrolltooMang
{
    internal class Mang
    {
        private Tegelane[] tegelased;

        public Mang(Tegelane[] tegelased)
        {
            this.tegelased = tegelased;
        }

        public List<Tegelane> SuurimEsemArvu()
        {
            List<Tegelane> voitjad = new List<Tegelane>();
            Tegelane sorted = tegelased[0];
            foreach (Tegelane t in tegelased)
            {
                int num = sorted.CompareTo(t);
                if(num < 0)
                {
                    sorted = t;
                    voitjad.Clear();
                }
                if (num == 0) voitjad.Add(t);
            }
            voitjad.Add(sorted);
            return voitjad;

        }

        public Tegelane suurPunktArv()
        {
            int parim = 0;
            Tegelane voitja = tegelased[0];
            foreach (var t in tegelased)
            {
                int arv = t.punktideArv();
                if (arv>parim)
                {
                    parim = arv;
                    voitja = t;
                }
            }
            return voitja;
        }








    }
}