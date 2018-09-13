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
    /// Interaction logic for PocetnaStranica.xaml
    /// </summary>
    public partial class PocetnaStranica : Page
    {
        public PocetnaStranica()
        {
            InitializeComponent();
        }

        private void Label_MouseLeftButtonUp(object sender, MouseEventArgs e)
        {
            Studenti_Izbornik studenti_izbornik = new Studenti_Izbornik();
            this.NavigationService.Navigate(studenti_izbornik);
        }

        private void Label_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            Predmet_Pocetna predmet_pocetna = new Predmet_Pocetna(strukt_pod.Content.ToString());
            this.NavigationService.Navigate(predmet_pocetna);
        }

        private void Label_MouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
        {
            Predmet_Pocetna predmet_pocetna = new Predmet_Pocetna(prog_inz.Content.ToString());
            this.NavigationService.Navigate(predmet_pocetna);
        }
    }
}
