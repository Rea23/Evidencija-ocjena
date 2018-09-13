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
    /// Interaction logic for IspisListe_Odabrani.xaml
    /// </summary>
    public partial class IspisListe_Odabrani : Page
    {
        public IspisListe_Odabrani()
        {
            InitializeComponent();
        }

        private void LoadGrid()
        {
            OleDbConnection konekcija = new OleDbConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["zavrsni_rad.Properties.Settings.zavrsniRad_bazaPodatakaConnectionString2"].ToString();
            konekcija.Open();
            OleDbCommand upit = new OleDbCommand();
            string izabrani_predmet_where, izabrani_predmet_select, izabrani_rok;
            if ((string)predmet.Content == "Strukture podataka")
            {
                izabrani_predmet_where = " AND [Student-Predmet].ID_predmeta = 1";
                izabrani_predmet_select = " [Student-Predmet].lab_strukture,";
            }
            else
            {
                izabrani_predmet_where = " AND [Student-Predmet].ID_predmeta = 2";
                izabrani_predmet_select = " [Student-Predmet].[projekt_1dio], [Student-Predmet].[projekt_2dio], [Student-Predmet].[projekt_3dio],";
            }
            if ((string)rok.Content == "Zimski rokovi")
                izabrani_rok = " [Student-Predmet].[1kolokvij], [Student-Predmet].[2kolokvij], [Student-Predmet].[1_1kolokvij], [Student-Predmet].[1_2kolokvij], [Student-Predmet].[1_ispit], [Student-Predmet].[2_1kolokvij], [Student-Predmet].[2_2kolokvij], [Student-Predmet].[2_ispit] ";
            else
                izabrani_rok = " [Student-Predmet].[3_ispit], [Student-Predmet].[4_ispit] ";
            upit.CommandText= "SELECT [Student-Predmet].ID_studenta, Student.ime_studenta, Student.prezime_studenta," + izabrani_predmet_select + izabrani_rok + " FROM [Student-Predmet], Student WHERE Student.ID_studenta=[Student-Predmet].ID_studenta" + izabrani_predmet_where + " ORDER BY Student.prezime_studenta ASC";
            upit.Connection = konekcija;
            OleDbDataReader prikaz = upit.ExecuteReader();
            tablica_studenti.ItemsSource = prikaz;
            List<Student_strukt> lista_strukt = new List<Student_strukt>();
            List<Student_strukt> lista_strukt_z = new List<Student_strukt>();
            List<Student_strukt> lista_strukt_lj = new List<Student_strukt>();
            List<Student_pi> lista_pi = new List<Student_pi>();
            List<Student_pi> lista_pi_z = new List<Student_pi>();
            List<Student_pi> lista_pi_lj = new List<Student_pi>();
            while (prikaz.Read())
            {
                if((string)predmet.Content == "Strukture podataka")
                {
                    Student_strukt student_strukt = new Student_strukt();
                    student_strukt.id = prikaz["ID_studenta"].ToString();
                    student_strukt.ime = prikaz["ime_studenta"].ToString();
                    student_strukt.prezime = prikaz["prezime_studenta"].ToString();
                    /*student_strukt.lab = CheckIfNull(prikaz["lab_strukture"]);
                    if((string)rok.Content == "Zimski rokovi")
                    {
                        student_strukt.kol1 = CheckIfNull(prikaz["1kolokvij"]);
                        student_strukt.kol2 = CheckIfNull(prikaz["2kolokvij"]);
                        student_strukt.kol1_1 = CheckIfNull(prikaz["1_1kolokvij"]);
                        student_strukt.kol2_1 = CheckIfNull(prikaz["1_2kolokvij"]);
                        student_strukt.isp1 = CheckIfNull(prikaz["1_ispit"]);
                        student_strukt.kol1_2 = CheckIfNull(prikaz["2_1kolokvij"]);
                        student_strukt.kol2_2 = CheckIfNull(prikaz["2_2kolokvij"]);
                        student_strukt.isp2 = CheckIfNull(prikaz["2_ispit"]);
                    }
                    else
                    {
                        student_strukt.isp3 = CheckIfNull(prikaz["3_ispit"]);
                        student_strukt.isp4 = CheckIfNull(prikaz["4_ispit"]);
                    }*/
                    lista_strukt.Add(student_strukt);
                }
                else
                {
                    Student_pi student_pi = new Student_pi();
                    student_pi.id = prikaz["ID_studenta"].ToString();
                    student_pi.ime = prikaz["ime_studenta"].ToString();
                    student_pi.prezime = prikaz["prezime_studenta"].ToString();
                    /*student_pi.p1 = CheckIfNull(prikaz["projekt_1dio"]);
                    student_pi.p2 = CheckIfNull(prikaz["projekt_2dio"]);
                    student_pi.p3 = CheckIfNull(prikaz["projekt_3dio"]);
                    if ((string)rok.Content == "Zimski rokovi")
                    {
                        student_pi.kol1 = CheckIfNull(prikaz["1kolokvij"]);
                        student_pi.kol2 = CheckIfNull(prikaz["2kolokvij"]);
                        student_pi.kol1_1 = CheckIfNull(prikaz["1_1kolokvij"]);
                        student_pi.kol2_1 = CheckIfNull(prikaz["1_2kolokvij"]);
                        student_pi.isp1 = CheckIfNull(prikaz["1_ispit"]);
                        student_pi.kol1_2 = CheckIfNull(prikaz["2_1kolokvij"]);
                        student_pi.kol2_2 = CheckIfNull(prikaz["2_2kolokvij"]);
                        student_pi.isp2 = CheckIfNull(prikaz["2_ispit"]);
                    }
                    else
                    {
                        student_pi.isp3 = CheckIfNull(prikaz["3_ispit"]);
                        student_pi.isp4 = CheckIfNull(prikaz["4_ispit"]);
                    }*/
                    lista_pi.Add(student_pi);
                }
            }
            if ((string)predmet.Content == "Strukture podataka")
            {
                SloziUListe_strukt(lista_strukt, lista_strukt_z, lista_strukt_lj);
                if((string)rok.Content == "Zimski rokovi")
                    tablica_studenti.ItemsSource = lista_strukt_z;
                else
                    tablica_studenti.ItemsSource = lista_strukt_lj;
            }              
            else //Programsko inzenjerstvo
            {
                SloziUListe_pi(lista_pi, lista_pi_z, lista_pi_lj);
                if ((string)rok.Content == "Zimski rokovi")
                    tablica_studenti.ItemsSource = lista_pi_z;
                else
                    tablica_studenti.ItemsSource = lista_pi_lj;
            }
            //prikaz.Close();
        }

        public class Student_strukt
        {
            public string id, ime, prezime;
            public int lab, kol1, kol2, kol1_1, kol2_1, kol1_2, kol2_2, isp1, isp2, isp3, isp4;
            public int naj_1kol = 0, naj_2kol = 0, naj_z_ispit = 0, naj_lj_ispit = 0, ocjena = 1;
        }

        public class Student_pi
        {
            public string id, ime, prezime;
            public int p1, p2, p3, kol1, kol2, kol1_1, kol2_1, kol1_2, kol2_2, isp1, isp2, isp3, isp4;
            public int projekt=0, naj_1kol=0, naj_2kol=0, naj_z_ispit=0, naj_lj_ispit=0, ocjena = 1;
        }

        public int VratiNajveci(int v1, int v2, int v3)
        {
            int temp = v1;
            if (v1 < v2)
                temp = v2;
            if (temp < v3)
                temp = v3;
            return temp;
        }

        public int IzracunajOcjenu(int teorija, int vjezbe, int predmet)
        {
            int ocjena = 0;
            if (teorija <= 88)
                teorija = 5;
            else if (teorija < 88 && teorija >= 75)
                teorija = 4;
            else if (teorija < 75 && teorija >= 60)
                teorija = 3;
            else
                teorija = 2;
            if (predmet == 1) //strukture podataka
                ocjena = (int)(0.5 * teorija + 0.5 * vjezbe);
            else //programsko inzenjerstvo
                ocjena = (int)(0.4 * teorija + 0.6 * vjezbe);
            return ocjena;
        }

        public void SloziUListe_strukt(List<Student_strukt> lista_strukt, List<Student_strukt> lista_strukt_z, List<Student_strukt> lista_strukt_lj)
        {
            for (int i = 0; i < lista_strukt.Count(); i++)
            {
                lista_strukt[i].naj_1kol = VratiNajveci(lista_strukt[i].kol1, lista_strukt[i].kol1_1, lista_strukt[i].kol1_2);
                lista_strukt[i].naj_2kol = VratiNajveci(lista_strukt[i].kol2, lista_strukt[i].kol1_2, lista_strukt[i].kol2_2);
                lista_strukt[i].naj_z_ispit = VratiNajveci((lista_strukt[i].naj_1kol + lista_strukt[i].naj_2kol) / 2, lista_strukt[i].isp1, lista_strukt[i].isp2);
                if (lista_strukt[i].isp3 <= lista_strukt[i].isp4)
                    lista_strukt[i].naj_lj_ispit = lista_strukt[i].isp4;
                else
                    lista_strukt[i].naj_lj_ispit = lista_strukt[i].isp3;
                if (lista_strukt[i].naj_z_ispit >= 50 && lista_strukt[i].lab >= 2)
                {
                    lista_strukt[i].ocjena = IzracunajOcjenu(lista_strukt[i].naj_z_ispit, lista_strukt[i].lab, 2);
                    lista_strukt_z.Add(lista_strukt[i]);
                }
                if (lista_strukt[i].naj_lj_ispit >= 50 && lista_strukt[i].lab >= 2)
                {
                    lista_strukt[i].ocjena = IzracunajOcjenu(lista_strukt[i].naj_lj_ispit, lista_strukt[i].lab, 2);
                    lista_strukt_lj.Add(lista_strukt[i]);
                }
            }
        }

        public void SloziUListe_pi(List<Student_pi>lista_pi, List<Student_pi>lista_pi_z, List<Student_pi> lista_pi_lj)
        {
            for (int i = 0; i < lista_pi.Count(); i++)
            {
                lista_pi[i].projekt = (lista_pi[i].p1 + lista_pi[i].p2 + lista_pi[i].p3) / 3;
                lista_pi[i].naj_1kol = VratiNajveci(lista_pi[i].kol1, lista_pi[i].kol1_1, lista_pi[i].kol1_2);
                lista_pi[i].naj_2kol = VratiNajveci(lista_pi[i].kol2, lista_pi[i].kol1_2, lista_pi[i].kol2_2);
                lista_pi[i].naj_z_ispit = VratiNajveci((lista_pi[i].naj_1kol+lista_pi[i].naj_2kol)/2, lista_pi[i].isp1, lista_pi[i].isp2);
                if (lista_pi[i].isp3 <= lista_pi[i].isp4)
                    lista_pi[i].naj_lj_ispit = lista_pi[i].isp4;
                else
                    lista_pi[i].naj_lj_ispit = lista_pi[i].isp3;
                if (lista_pi[i].naj_z_ispit >= 50 && lista_pi[i].projekt>=2)
                {
                    lista_pi[i].ocjena = IzracunajOcjenu(lista_pi[i].naj_z_ispit, lista_pi[i].projekt, 2);
                    lista_pi_z.Add(lista_pi[i]);
                }
                if (lista_pi[i].naj_lj_ispit >= 50 && lista_pi[i].projekt >= 2)
                {
                    lista_pi[i].ocjena = IzracunajOcjenu(lista_pi[i].naj_lj_ispit, lista_pi[i].projekt, 2);
                    lista_pi_lj.Add(lista_pi[i]);
                }
            }
        }

        public IspisListe_Odabrani(string data, string naslov) : this()
        {
            rok.Content = data;
            predmet.Content = naslov;
            LoadGrid();
        }
    }
}
