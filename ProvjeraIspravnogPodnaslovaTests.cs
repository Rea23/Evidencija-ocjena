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
    public class ProvjeraIspravnogPodnaslovaTests
    {
        [TestMethod()]
        public void IzborPodnaslova_NaslovStruktPod_PodnaslovLabVjezbe()
        {
            //Priprema okruženja za testiranje
            ProvjeraIspravnogPodnaslova stranica = new ProvjeraIspravnogPodnaslova();
            //Izvođenje funkcionalnosti koja se testira
            string podnaslov = stranica.IzborPodnaslova("Strukture podataka");
            //Provjera ispravnosti
            Assert.AreEqual("Laboratorijske vježbe", podnaslov);
        }

        [TestMethod()]
        public void IzborPodnaslova_NaslovProgInz_PodnaslovProjekti()
        {
            //Priprema okruženja za testiranje
            ProvjeraIspravnogPodnaslova stranica = new ProvjeraIspravnogPodnaslova();
            //Izvođenje funkcionalnosti koja se testira
            string podnaslov = stranica.IzborPodnaslova("Programsko inženjerstvo");
            //Provjera ispravnosti
            Assert.AreEqual("Projekti", podnaslov);
        }
    }
}