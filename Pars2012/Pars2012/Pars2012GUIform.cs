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

namespace Pars2012
{
    public partial class Pars2012GUIform : Form
    {
        class versenyzo
        {
            public string nev { get; set; }
            public string csoport { get; set; }
            public string Nemzeteskod { get; set; }
            public double D1 { get; set; }
            public double D2 { get; set; }
            public double D3 { get; set; }

            public versenyzo(string sor)
            {
                string[] darabok = sor.Split(';');
                this.nev = darabok[0];
                this.csoport = darabok[1];
                this.Nemzeteskod = darabok[2];
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
        }
        public Pars2012GUIform()
        {
            InitializeComponent();
            List<versenyzo> versenyzolista = new List<versenyzo>();
            StreamReader sr = new StreamReader("Selejtezo2012.txt");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                versenyzo v = new versenyzo(sor);
                versenyzolista.Add(v);
                comboBox1.Items.Add(v);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //label2.Text=$"Csoport "+v.csoport; 
        }
    }
}
