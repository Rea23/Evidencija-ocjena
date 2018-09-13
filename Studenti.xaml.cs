using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
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
    /// Interaction logic for Studenti.xaml
    /// </summary>
    public partial class Studenti : Page
    {
        public Studenti()
        {
            InitializeComponent();
            LoadGrid();
        }

        public void LoadGrid()
        {
            OleDbConnection konekcija = new OleDbConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["zavrsni_rad.Properties.Settings.zavrsniRad_bazaPodatakaConnectionString2"].ToString();
            konekcija.Open();
            OleDbCommand upit = new OleDbCommand();

            upit.CommandText = "SELECT [Student-Predmet].ID_predmeta, [Student-Predmet].ID_studenta, Student.ime_studenta, Student.prezime_studenta FROM [Student-Predmet], Student WHERE [Student-Predmet].ID_studenta=Student.ID_studenta ORDER BY ID_predmeta ASC";
            upit.Connection = konekcija;
            OleDbDataReader prikaz = upit.ExecuteReader();
            tablica_studenti.ItemsSource = prikaz;          
        }
    }
}
