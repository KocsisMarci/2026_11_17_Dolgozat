using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text;
using System.IO;
using System.Security.RightsManagement;

namespace _2026_11_17_Dolgozat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public class Dolgozat
        {
            public string Nev { get; set; }
            public int Eletkor { get; set; }

            public int Pontszam { get; set; }

            public Dolgozat(string nev, int eletkor, int pontszam)
            {
                this.Nev = nev;
                this.Eletkor = eletkor;
                this.Pontszam = pontszam;
            }


            public override string ToString()
            {
                /*
                Ezt a megoldást azért mellőzöm, mert ha olvasni is kell fájlból ez nem a legszerencsésebb mód.

                return $"A dolgozatíró neve: {this.Nev} {this.Eletkor} éves 100/{this.Pontszam} pontot ért el";
                */

                return $"{this.Nev};{this.Eletkor};{this.Pontszam}";
                }

        };

     
        

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += feltolt;

        }


        public List<Dolgozat> dolgozatok = new List<Dolgozat> {
            new  Dolgozat("Kiss Péter",16,87),
            new Dolgozat("Nagy Anna",17,92),
            new Dolgozat("Szabó Tamás",16,78),
            new  Dolgozat("Tóth Éva",18,95),
            new Dolgozat("Varga Bence",17,81),
            new Dolgozat("Horváth Zsolt",16,65),
            new Dolgozat("Molnár Réka",18,89),
            new Dolgozat("Lakatos Dániel",17,72)

        };



        private void feltolt(object sender, RoutedEventArgs e) {
            dataGrid.ItemsSource =dolgozatok;

            dataGrid.Items.Refresh();
        }


        private void hozzaad(object sender, RoutedEventArgs e) {

            /*
             Természetesen lehetne még egyéb optimalizálásokat csinálni.
             Ha lesz még időm, meg kedvem lehet dolgozgatok még vele.
             */

            if (nev.Text != "" && eletkor.Text != "" && pontszam.Text != "")
            {

                //Egy kis bónusz kivételkezelés:
                try
                {
                    if (Convert.ToInt32(pontszam.Text) <= 100 && Convert.ToInt32(pontszam.Text) >= 0)
                    {
                        Dolgozat dolgozat = new Dolgozat(nev.Text, Convert.ToInt32(eletkor.Text), Convert.ToInt32(pontszam.Text));

                        dolgozatok.Add(dolgozat);

                        nev.Text = "";
                        eletkor.Text = "";
                        pontszam.Text = "";
                        
                        dataGrid.ItemsSource = dolgozatok;

                        dataGrid.Items.Refresh();
                    }

                    else if (Convert.ToInt32(pontszam.Text) > 100)
                    {
                        MessageBox.Show("Maximum 100 pontot lehetett elérni");
                        pontszam.Text = "";
                    }

                    else if (Convert.ToInt32(pontszam.Text) < 0) {
                        MessageBox.Show("Negatív pontszámot nem lehetett elérni");
                        pontszam.Text = "";

                    }

                    //Most ezt életkorral is el lehetne játszani ugyanígy egyébként.
                }

                catch (FormatException ex) {
                    MessageBox.Show("Feltehetőleg nem szám típus lett megadva");
                    eletkor.Text = "";
                    pontszam.Text = "";
                }
            }

            else
            {
                MessageBox.Show("Minden mezőt kötelező kitölteni");
            }
        
        }



        private void mentes(object sender, RoutedEventArgs e) {
            //A mentés gomb lehet, hogy azt akarta jelenteni, hogy a dataGrid frissül, de én most itt fájlba fogok írni.
            //Kell a using System.Text, meg a Using System.IO


            File.WriteAllText("eredmeny.txt","A dolgozatot megírókról:\n");
            
            foreach (Dolgozat dolgozat in dolgozatok) {
                File.AppendAllText("eredmeny.txt", dolgozat.ToString() + "\n");
            }

            MessageBox.Show("Sikeres fájlba írás");
           
        }
    }
}