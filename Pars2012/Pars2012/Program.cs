using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pars2012
{
    class Program
    {
        class versenyzo
        {
            public string nev { get; set; }
            public string csoport { get; set; }
            public string nemzeteskod { get; set; }
            public string kod => nemzeteskod.Split(' ').Last().Replace("(", "").Replace(")", "");
            public string nemzet;
            public double D1 { get; set; }
            public double D2 { get; set; }
            public double D3 { get; set; }
        

            public versenyzo(string sor)
              {
                string[] darabok = sor.Split(';');
                this.nev = darabok[0];
                this.csoport = darabok[1];
                this.nemzeteskod = darabok[2];
                //Dobás 1
                if (darabok[3] == "X")
                {
                    this.D1 = -1;
                }
                else if (darabok[3] == "-")
                {
                    this.D1 = -2;
                }
                else
                {
                    this.D1 = Convert.ToDouble(darabok[3]);
                }
                //Dobás 2
                if (darabok[4] == "X")
                {
                    this.D2 = -1;
                }
                else if (darabok[4] == "-")
                {
                    this.D2 = -2;
                }
                else
                {
                    this.D2 = Convert.ToDouble(darabok[4]);
                }
                //Dobás 3
                if (darabok[5] == "X")
                {
                    this.D3 = -1;
                }
                else if (darabok[5] == "-")
                {
                    this.D3 = -2;
                }
                else
                {
                    this.D3 = Convert.ToDouble(darabok[5]);
                }
                String[] nemzetdarabok = nemzeteskod.Split(' ');
                nemzet = nemzetdarabok[0];
                for (int i = 1; i < nemzetdarabok.Length - 1; i++)
                {
                    nemzet += " ";
                    nemzet += nemzetdarabok[i];
                }
            }

            public double maxdobas()
            {
                if(D1>D2 && D1 > D3)
                {
                    return D1;
                }
                else if(D2>D1&& D2>D3)
                {
                    return D2;
                }
                else
                {
                    return D3;
                }
            }
        }
        static void Main(string[] args)
        {
            Pars2012GUIform f = new Pars2012GUIform();
            f.Show();
            StreamReader sr = new StreamReader("Selejtezo2012.txt");
            List<versenyzo> kalapascvetes2 = new List<versenyzo>();
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                versenyzo sb = new versenyzo(sor);
                kalapascvetes2.Add(sb);
            }
            sr.Close();

            //5. feladat
            int versenyzok1 = 0;
            foreach (var item in kalapascvetes2)
            {
                versenyzok1 = kalapascvetes2.Count();
            }
            Console.WriteLine($"5. feladat: Versenyzők száma a selejtezőben: {versenyzok1} fő");

            //6. feladat
            int legnagyobb = 0;
            foreach (var item in kalapascvetes2)
            {
                if (item.D1 > 78 || item.D2 > 78 || item.D3 > 78)
                {
                    legnagyobb++;
                }                
            }
            Console.WriteLine($"6. feladat: 78,00 méter feletti eredménnyel továbbjutott: {legnagyobb} fő");

            //9.feladat
            double max = 0;
            versenyzo legjobb = kalapascvetes2[0];
            foreach (var item in kalapascvetes2)
            {
                if (item.maxdobas()>max)
                {
                    max = item.maxdobas();
                    legjobb = item;
                }
            }
            Console.WriteLine($"9. feladat: Selejtező nyertese:\nNév: {legjobb.nev}\nCsoport: {legjobb.csoport}\nNemzet: {legjobb.nemzet}\nNemzet kód: {legjobb.kod}\nSorozat: {legjobb.D1};{legjobb.D2};{legjobb.D3}\nEredmeny: {legjobb.maxdobas()}");

            //10. feladat
            string fajlnev = "Dontos2012.txt";
            StreamWriter sw = new StreamWriter(fajlnev);
            for (int i = 0; i < 12; i++)
            {
                double max2 = 0;
                versenyzo legjobb2 = kalapascvetes2[0];
                foreach (var item in kalapascvetes2)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        if (item.maxdobas() > max)
                        {
                            max2 = item.maxdobas();
                            legjobb2 = item;
                        }
                    }
                }
                sw.WriteLine($"{legjobb2.nev};{legjobb2.csoport};{legjobb2.nemzet};{legjobb2.kod};{legjobb2.D1};{legjobb2.D2};{legjobb2.D3};\n");
                kalapascvetes2.Remove(legjobb2);                
            }
            sw.Close();
            Console.ReadKey();
        }
    }
}
