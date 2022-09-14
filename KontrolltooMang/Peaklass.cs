﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KontrolltooMang
{
    internal static class Peaklass
    {
        public static Random rnd = new Random();
        public static List<Ese> LoeEsemed()
        {
            List<Ese> esed = new List<Ese>();
            using (StreamReader sr = new StreamReader(@"../../../esemed.txt")) //Rakendatakse vastavat staatilist meetodit, et lugeda failist esemed.txt esemete andmed.
            {
                while (!sr.EndOfStream)
                {

                    string[] rida = sr.ReadLine().Split(";");
                    Ese ese = new Ese(rida[0].ToString(), Int32.Parse(rida[1]));
                    esed.Add(ese);
                }
            }
            return esed;
        }

        static string getNimi() //Luuakse vähemalt 5 tegelast (nimed mõelge ise välja).
        {
            string[] nimed = { "Denis", "Artjom", "Daniil", "Timofei", "Edgar" };
            return nimed[rnd.Next(nimed.Length)];
        }


        static Tegelane[] MostTegelane(int tegCount)
        {
            if (tegCount < 4) throw new Exception();
            Tegelane[] teges = new Tegelane[tegCount];
            for (int i = 0; i < tegCount; i++)
            {
                Tegelane tege = new Tegelane(getNimi());
                teges[i] = tege;
            }


            return giveOutItems(teges);
        }

        public static void GenEse<T>(this IList<T> list) //Iga tegelase jaoks genereeritakse juhuslik arv n vahemikust [2,10], mis näitab selle tegelase esemete arvu.Iga tegelase jaoks valitakse juhuslikult n eset.Selleks tuleb kasutadaGollections.shuffle meetodit.Antud meetod võtab argumendiks listi ning järjestab sellesuvalises järjekorras. Esemete list järjestada iga tegelase jaoks uuesti ümber ning lisada tegelaseleesimest n eset.
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }


        static Tegelane[] giveOutItems(Tegelane[] teges)
        {
            List<Ese> itemList = LoeEsemed();
            if (itemList.Count <= 0) throw new ArgumentOutOfRangeException();
            foreach (Tegelane tege in teges)
            {
                GenEse(itemList);
                int amount = rnd.Next(2, 10); //Iga tegelase jaoks genereeritakse juhuslik arv n vahemikust [2,10]
                for (int i = 0; i < amount; i++)
                {
                    tege.LisaEse(itemList[i]);
                }
            }
            return teges;

        }

        internal static void Uus_Mang(int tegCount) //Tegelaste info ja esemed väljastatakse ekraanile (kasutades vastavaid meetodeid).
        {
            Tegelane[] tege = MostTegelane(tegCount);
            Mang mang = new Mang(tege);
            foreach (Tegelane voitja in mang.SuurimEsemArvu())
            {
                Console.WriteLine(voitja.info());//Leitakse ja väljastatakse ekraanile suurima esemete arvuga tegelase info (kasutades vastavaid meetodeid).
            }
            Tegelane voit = mang.suurPunktArv();
            Console.WriteLine(voit.info());
            Console.WriteLine("Tegelasel on need esed:");
            voit.väljastaEsemed();

        }
    }
}
