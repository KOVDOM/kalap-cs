using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Pars2012GUI
{
    public partial class Form1 : Form
    {
        class versenyzo
        {
            public string nev { get; set; }
            public string csoport { get; set; }
            public string nemzeteskod { get; set; }
            public string kod => nemzeteskod.Split(' ').Last().Replace("(", "").Replace(")", "");
            public string nemzet => nemzeteskod.Split(' ').First();
            public double D1 { get; set; }
            public double D2 { get; set; }
            public double D3 { get; set; }

            public versenyzo(string sor)
            {
                string[] darabok = sor.Split(';');
                this.nev = darabok[0];
                this.csoport = darabok[1];
                this.nemzeteskod = darabok[2];
                //dobás1
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
                //dobás2
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
                //dobás3
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
            }
            public double maxdobas()
            {
                if (D1 > D2 && D1 > D3)
                {
                    return D1;
                }
                else if (D2 > D1 && D2 > D3)
                {
                    return D2;
                }
                else
                {
                    return D3;
                }
            }
        }
        List<versenyzo> versenyzolista = new List<versenyzo>();
        public Form1()
        {
            InitializeComponent();
            
            StreamReader sr = new StreamReader("Selejtezo2012.txt");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                versenyzo v = new versenyzo(sor);
                versenyzolista.Add(v);
                comboBox1.Items.Add(v.nev);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            versenyzo legjobb = versenyzolista[comboBox1.SelectedIndex];
            
            label2.Text = $"Csoport {legjobb.csoport}";
            label3.Text = $"Nemzet {legjobb.nemzet}";
            label4.Text = $"NemzetKód {legjobb.kod}";
            label5.Text = $"Sororzat {legjobb.D1};{legjobb.D2};{legjobb.D3}";
            label6.Text = $"Eredmény {legjobb.maxdobas()};";
        }
    }
}
