using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zavrsni_rad
{
    public class UnosUBazu
    {
        public string Spremi(string id, string ime, string prezime, pisanje_u_bazu upisivanje)
        {
            string upit = "INSERT INTO[Student](ID_studenta ,Ime_studenta, Prezime_studenta)VALUES(@id, @ime, @prezime)";
            return upisivanje.UnosUBazuPodataka(upit);

        }
    }
    public interface pisanje_u_bazu
    {
        string UnosUBazuPodataka(string upit);
    }

    public class stvarni_upis_u_bazu : pisanje_u_bazu
    {
        public string UnosUBazuPodataka(string upit)
        {
            OleDbConnection konekcija = new OleDbConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["zavrsni_rad.Properties.Settings.zavrsniRad_bazaPodatakaConnectionString2"].ToString();
            konekcija.Open();
            OleDbCommand komanda = new OleDbCommand();
            komanda.CommandText = upit;
            komanda.Connection = konekcija;
            komanda.ExecuteNonQuery();
            return upit;
        }
    }
    public class stub : pisanje_u_bazu
    {
        public string UnosUBazuPodataka(string upit)
        {
            return upit;
        }

    }
}
