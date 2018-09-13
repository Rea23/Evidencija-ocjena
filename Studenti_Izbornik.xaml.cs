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
    /// Interaction logic for Studenti_Izbornik.xaml
    /// </summary>
    public partial class Studenti_Izbornik : Page
    {
        public Studenti_Izbornik()
        {
            InitializeComponent();
        }

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Studenti studenti = new Studenti();
            this.NavigationService.Navigate(studenti);
        }

        private void Label_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            UnosStudenta unos_studenta = new UnosStudenta();
            this.NavigationService.Navigate(unos_studenta);
        }
    }
}
