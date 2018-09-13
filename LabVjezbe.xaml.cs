using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Interaction logic for LabVjezbe.xaml
    /// </summary>
    public partial class LabVjezbe : Page
    {
        public LabVjezbe()
        {
            InitializeComponent();
        }

        private void LoadGrid()
        {
            OleDbConnection konekcija = new OleDbConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["zavrsni_rad.Properties.Settings.zavrsniRad_bazaPodatakaConnectionString2"].ToString();
            konekcija.Open();
            OleDbCommand upit = new OleDbCommand();
            if ((string)predmet.Content == "Strukture podataka")
                upit.CommandText = "SELECT Student.ID_studenta, Student.ime_studenta, Student.prezime_studenta, [Student-Predmet].[lab_strukture] FROM Student, [Student-Predmet] WHERE Student.ID_studenta=[Student-Predmet].ID_studenta AND [Student-Predmet].ID_predmeta = 1";
            else
                upit.CommandText = "SELECT Student.ID_studenta, Student.ime_studenta, Student.prezime_studenta, [Student-Predmet].[projekt_1dio], [Student-Predmet].[projekt_2dio], [Student-Predmet].[projekt_3dio] FROM Student, [Student-Predmet] WHERE Student.ID_studenta=[Student-Predmet].ID_studenta AND [Student-Predmet].ID_predmeta = 2";
            upit.Connection = konekcija;
            OleDbDataReader prikaz = upit.ExecuteReader();
            tablica_vjezbe.ItemsSource = prikaz;
        }

        public LabVjezbe(string data) : this()
        {
            predmet.Content = data;
            if (data == "Strukture podataka")
                podnaslov.Content = "Laboratorijske vježbe";
            else
                podnaslov.Content = "Projekti";
            LoadGrid();
        }
    }
}
