using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zavrsni_rad
{
    public class IspravniIspRok
    {
        public string Check(int odabir)
        {
            switch (odabir)
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
    }
}
