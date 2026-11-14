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


        public void hozzaad(object sender, RoutedEventArgs e) {

            if (nev.Text != "" && eletkor.Text != "" && pontszam.Text != "")
            {

                //Egy kis bónusz kivételkezelés:
                try
                {
                    if (Convert.ToInt32(pontszam.Text) <= 100 && Convert.ToInt32(pontszam.Text) >= 0)
                    {
                        Dolgozat dolgozat = new Dolgozat(nev.Text, Convert.ToInt32(eletkor.Text), Convert.ToInt32(pontszam.Text));

                        dolgozatok.Add(dolgozat);

                        dataGrid.ItemsSource = dolgozatok;

                        dataGrid.Items.Refresh();
                    }

                    else if (Convert.ToInt32(pontszam.Text) > 100)
                    {
                        MessageBox.Show("Maximum 100 pontot lehetett elérni");
                    }

                    else if (Convert.ToInt32(pontszam.Text) < 0) {
                        MessageBox.Show("Negatív pontszámot nem lehetett elérni");
                    }

                    //Most ezt életkorral is el lehetne játszani egyébként.
                }

                catch (FormatException ex) {
                    MessageBox.Show("Feltehetőleg nem szám típus lett megadva");
                }
            }

            else
            {
                MessageBox.Show("Minden mezőt kötelező kitölteni");
            }
        
        }



        public void mentes(object sender, RoutedEventArgs e) { }
    }
}