using Microsoft.VisualStudio.TestTools.UnitTesting;
using zavrsni_rad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zavrsni_rad.Tests
{
    [TestClass()]
    public class UnosUBazuTests
    {
        [TestMethod()]
        public void UnosUBazu_UspjesanUnos_VracenTrue()
        {
            //Priprema okruženja za testiranje
            stub pisanje = new stub();
            UnosUBazu izvrsavanje = new UnosUBazu();
            //Izvođenje funkcionalnosti koja se testira
            string vraceno = izvrsavanje.Spremi("11-120", "Ante", "Antic", pisanje);
            string id = "11-120";
            string ime = "Ante";
            string prezime = "Antic";
            //Provjera ispravnosti
            Assert.IsTrue(vraceno == "INSERT INTO[Student](ID_studenta ,Ime_studenta, Prezime_studenta)VALUES(@id, @ime, @prezime)");
        }
    }
}