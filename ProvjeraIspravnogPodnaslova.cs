using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zavrsni_rad
{
    public class ProvjeraIspravnogPodnaslova
    {
        public string IzborPodnaslova(string predmet)
        {
            string podnaslov;
            if (predmet == "Strukture podataka")
                podnaslov = "Laboratorijske vježbe";
            else
                podnaslov = "Projekti";
            return podnaslov;
        }
    }
}
