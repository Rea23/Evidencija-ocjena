using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for PismeniIspiti.xaml
    /// </summary>
    public partial class PismeniIspiti : Page
    {
        public PismeniIspiti()
        {
            InitializeComponent();
        }

        public PismeniIspiti(string data) : this()
        {
            predmet.Content = data;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int selektirani = ispitniRokovi.SelectedIndex;
            PismeniIspiti_Odabrani pismeniIspitiOdabrani = new PismeniIspiti_Odabrani(this.ispitniRokovi.SelectedItem, predmet.Content.ToString(), selektirani);
            this.NavigationService.Navigate(pismeniIspitiOdabrani);
        }
    }
}
