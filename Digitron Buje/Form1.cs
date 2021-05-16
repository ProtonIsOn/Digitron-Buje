using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Digitron_Buje
{
    public partial class Form1 : Form
    {
        bool operacija_izvrsena = false, Novi_Unos = false;
        String operacija = "";
        Double rezultat = 0, unos,d;
        List<double> Niz_Brojeva = new List<double>();
        List<string> Niz_Operacija = new List<string>();



        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Bttn_Click(object sender, EventArgs e)
        {
                       
                Button button = (Button)sender;
                Button Broj = (Button)sender;


                if ((Ekran.Text == "0") || (operacija_izvrsena) || (Novi_Unos))
                {
                    Ekran.Text = "";
                    //rezultat = 0;
                    operacija_izvrsena = false;
                }

                if (Broj.Text == ".")
                {
                    if (!Ekran.Text.Contains(".")) Ekran.Text = Ekran.Text + Broj.Text;
                }
                else
                    Ekran.Text = Ekran.Text + Broj.Text;
               
                label2.Text = label2.Text + Broj.Text;
                
                unos = double.Parse(Ekran.Text);
          
        }

        private void Obrisi_Sve(object sender, EventArgs e)
        {
            rezultat = 0;
            Niz_Brojeva.Clear();
            Niz_Operacija.Clear();

        }

        private void Poz_Neg_Click(object sender, EventArgs e)
        {
            Ekran.Text = (Double.Parse(Ekran.Text) * -1).ToString();
        }

        private void Operacija(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operacija = button.Text;

            if ((Novi_Unos) | (operacija_izvrsena))
            {
                Ekran.Text="";
                label2.Text = rezultat.ToString();
                Niz_Brojeva.Add(rezultat);
                Niz_Operacija.Add(operacija);
                rezultat = 0;
                Novi_Unos = false;
            }
            else
            {
                Niz_Brojeva.Add(unos);
                Niz_Operacija.Add(operacija);
            }

            if (double.TryParse(Ekran.Text, out d))
            {
                operacija_izvrsena = true;
            }
            else
            Ekran.Text = "";

            label2.Text = label2.Text + operacija;
        }

        private void Izracunaj(object sender, EventArgs e)
        {
            Niz_Brojeva.Add(unos);
            for (int i = 0; i < Niz_Operacija.Count; i++)
            {
                if (Niz_Operacija[i] == "*")
                {
                    double n = Niz_Brojeva[i] * Niz_Brojeva[i + 1];
                    Niz_Brojeva[i] = 0;
                    Niz_Brojeva[i + 1] = n;
                    
                }
                else if (Niz_Operacija[i] == "/")
                {
                    double n = Niz_Brojeva[i] / Niz_Brojeva[i + 1];
                    Niz_Brojeva[i] = 0;
                    Niz_Brojeva[i + 1] = n;
                }
                else if (Niz_Operacija[i] == "-")
                {
                    double n = Niz_Brojeva[i] - Niz_Brojeva[i + 1];
                    Niz_Brojeva[i] = 0;
                    Niz_Brojeva[i + 1] = n;
                }
            }

            for (int j = 0; j < Niz_Brojeva.Count; j++)
            {
                rezultat = rezultat + Niz_Brojeva[j];
            }
            unos = 0;
            Niz_Brojeva.Clear();
            Niz_Operacija.Clear();
            label2.Text = "";
            Ekran.Text = rezultat.ToString();
            Novi_Unos = true;
        }
    }
}
