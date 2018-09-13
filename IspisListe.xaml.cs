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
    /// Interaction logic for IspisListe.xaml
    /// </summary>
    public partial class IspisListe : Page
    {
        public IspisListe()
        {
            InitializeComponent();
        }

        public IspisListe(string data) : this()
        {
            predmet.Content = data;
        }

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            IspisListe_Odabrani ispisListe_odabrani = new IspisListe_Odabrani(z_rok.Content.ToString(), predmet.Content.ToString());
            this.NavigationService.Navigate(ispisListe_odabrani);
        }

        private void Label_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            IspisListe_Odabrani ispisListe_odabrani = new IspisListe_Odabrani(lj_rok.Content.ToString(), predmet.Content.ToString());
            this.NavigationService.Navigate(ispisListe_odabrani);
        }
    }
}
