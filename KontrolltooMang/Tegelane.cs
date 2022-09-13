using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace KontrolltooMang
{
    class Tegelane : IUksus, IComparable<Tegelane> //наследует от IUksus
    {

        List<Ese> eses = new List<Ese>(); //Klassis on privaatsed isendiväljad järgmise info jaoks: nimi (String) ja esemete nimekiri (List<Ese>).

        string nimi;
        double summary;
        public string info() //Meetod info tagastab tegelase info tekstina, näidates tegelase nime, esemete arvu ja punktidearvu.
        {
            Console.WriteLine($"Nimi: {nimi}");
            foreach (string line in File.ReadLines(@"..\..\..\esemed.txt"))
            {
                string[] row = line.Split(';');
                summary += Double.Parse(row[1]);
                Ese ese = new Ese(row[0], Int32.Parse(row[1]));
                eses.Add(ese);
                Console.WriteLine($"Nimetus: {row[0]}, Punktide arvu: {row[1]}");
            }
            Console.WriteLine($"Esemete arvu: {eses.Count}, Summa: {summary}");
            return $"{nimi}";
        }

        public void väljastaEsemed() //Klassis peab olema ka meetod väljastaEsemed, kus väljastatakse ekraanile tegelase esemed nii,et iga ese on eraldi real.
        {
            foreach (Ese item in eses)
            {
                Console.WriteLine(item.info() + " " + item.PunktideArv());
            }
        }

        public Tegelane(string nimi) //Klassis peab olema ühe parameetriga konstruktor, mille abil saab määrata nime.
        {
            this.nimi = nimi;
        }

        public int LisaEse(int item) //Äsjaloodud tegelasel ei ole ühtegi eset. Eseme lisamiseks peab olema meetod lisaEse, mis jätabargumendiks antud eseme meelde.
        {
            return item;
        }

        public int PArv(int punktArv) //Meetod punktideArv tagastab tegelase esemete punktide arvude summa.
        {
            int sum = 0;
            foreach (Ese item in eses) { sum += item.PunktideArv(); }
            return sum;
        }

        public int CompareTo(Tegelane? other)  //Klass Tegelane realiseerib liidese Comparable<Tegelane>, kusjuures compareTo meetodrealiseeritakse nii, et võrdlemine toimub esemete arvu alusel.
        {
            if (other == null) return 1;
            return this.eses.Count - other.ItemCount();
        }

        public int ItemCount() { return eses.Count; }





    }
}