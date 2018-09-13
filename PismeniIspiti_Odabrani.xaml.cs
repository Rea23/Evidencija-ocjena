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
    /// Interaction logic for PismeniIspiti_Odabrani.xaml
    /// </summary>
    public partial class PismeniIspiti_Odabrani : Page
    {
        public PismeniIspiti_Odabrani()
        {
            InitializeComponent();
        }

        public string Check(int odabir)
        {
            switch(odabir)
            {
                case 0:
                    return " [Student-Predmet].[1kolokvij]";
                case 1:
                    return " [Student-Predmet].[2kolokvij]";
                case 2:
                    return " [Student-Predmet].[1_1kolokvij], [Student-Predmet].[1_2kolokvij], [Student-Predmet].[1_ispit]";
                case 3:
                    return " [Student-Predmet].[2_1kolokvij], [Student-Predmet].[2_2kolokvij], [Student-Predmet].[2_ispit]";
                case 4:
                    return " [Student-Predmet].[3_ispit]";
                case 5:
                    return " [Student-Predmet].[4_ispit]";
                default:
                    return " [Student-Predmet].[1kolokvij], [Student-Predmet].[2kolokvij]";
            }
        }

        public void LoadGrid(int izabrani_rok)
        {
            OleDbConnection konekcija = new OleDbConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["zavrsni_rad.Properties.Settings.zavrsniRad_bazaPodatakaConnectionString2"].ToString();
            konekcija.Open();
            OleDbCommand upit = new OleDbCommand();
            string odabir_predmeta, odabir_ispita;
            if ((string)predmet.Content == "Strukture podataka")
                odabir_predmeta = " AND [Student-Predmet].ID_predmeta = 1";
            else
                odabir_predmeta = " AND [Student-Predmet].ID_predmeta = 2";
            odabir_ispita = Check(izabrani_rok);
            upit.CommandText = "SELECT Student.ID_studenta, Student.ime_studenta, Student.prezime_studenta," + odabir_ispita + " FROM [Student-Predmet], Student WHERE Student.ID_studenta=[Student-Predmet].ID_studenta" + odabir_predmeta;
            upit.Connection = konekcija;
            OleDbDataReader prikaz = upit.ExecuteReader();
            tablica_postotaka.ItemsSource = prikaz;
        }

        //Custom konstruktor za prijenos odabranog ispitnog roka u ListBox-u
        //u formi PismeniIspiti
        public PismeniIspiti_Odabrani(object data, string naslov, int a) : this()
        {
            //povezivanje podataka
            this.DataContext = data;
            predmet.Content = naslov;
            LoadGrid(a);
        }
    }
}
