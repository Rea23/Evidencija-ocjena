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
using System.Data.OleDb;
using System.Configuration;

namespace zavrsni_rad
{
    /// <summary>
    /// Interaction logic for UnosStudenta.xaml
    /// </summary>
    public partial class UnosStudenta : Page
    {
        public UnosStudenta()
        {
            InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            OleDbConnection konekcija = new OleDbConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["zavrsni_rad.Properties.Settings.zavrsniRad_bazaPodatakaConnectionString2"].ToString();
            konekcija.Open();
            //Otvoriti konkekciju prema bazi podataka
            OleDbCommand komanda = new OleDbCommand();
            OleDbCommand komanda2 = new OleDbCommand();
            komanda.CommandText = "insert into [Student](ID_studenta ,Ime_studenta, Prezime_studenta)values(@id, @ime, @prezime)";
            if(id_stud.Text=="")
                MessageBox.Show("Obavezno je navesti ID studenta za uspješan unos!");
            else
            {
                komanda.Parameters.AddWithValue("@id", id_stud.Text);
                komanda.Parameters.AddWithValue("@ime", ime_stud.Text);
                komanda.Parameters.AddWithValue("@prezime", prez_stud.Text);
                komanda.Connection = konekcija;
                int izlaz = komanda.ExecuteNonQuery();
                if (izlaz > 0)
                {
                    MessageBox.Show("Uspješan unos u tablicu Student!");
                }
                komanda2.CommandText = "INSERT INTO [Student-Predmet] ( ID_predmeta, ID_studenta ) SELECT Predmet.ID_predmeta, Student.ID_studenta FROM Predmet, Student WHERE Predmet.ID_predmeta =@predmet AND Student.ID_studenta =@id";
                komanda2.Parameters.AddWithValue("@predmet", Int32.Parse(id_pred.Text));
                komanda2.Parameters.AddWithValue("@id", id_stud.Text);
                komanda2.Connection = konekcija;
                izlaz = komanda2.ExecuteNonQuery();
                if (izlaz > 0)
                {
                    MessageBox.Show("Uspješan unos u tablicu Student-Predmet!");
                }
            }
        }
    }
}
