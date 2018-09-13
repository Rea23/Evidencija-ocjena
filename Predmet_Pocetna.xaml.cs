using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace zavrsni_rad
{
    /// <summary>
    /// Interaction logic for Strukture_Pocetna.xaml
    /// </summary>
    public partial class Predmet_Pocetna : Page
    {
        public Predmet_Pocetna()
        {
            InitializeComponent();
        }

        public Predmet_Pocetna(string data) : this()
        {
            predmet.Content = data;
            podnaslov2.Content = IzborPodnaslova(data);
        }

        public string IzborPodnaslova(string predmet)
        {
            string podnaslov;
            if (predmet == "Strukture podataka")
                podnaslov = "Laboratorijske vježbe";
            else
                podnaslov = "Projekti";
            return podnaslov;
        }

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PismeniIspiti pismeniIspiti = new PismeniIspiti(predmet.Content.ToString());
            this.NavigationService.Navigate(pismeniIspiti);
        }

        private void Label_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            LabVjezbe labVjezbe = new LabVjezbe(predmet.Content.ToString());
            this.NavigationService.Navigate(labVjezbe);
        }

        private void Label_MouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
        {
            IspisListe ispisListe = new IspisListe(predmet.Content.ToString());
            this.NavigationService.Navigate(ispisListe);
        }
    }
}
