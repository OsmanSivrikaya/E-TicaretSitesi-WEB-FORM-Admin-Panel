using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_TicaretSitesiBem.Class
{
    public class SezarCoz
    {
        public string SezarKategoricoz(string sifrele)
        {
            string veri = "";
            veri = sifrele;
            sifrele = "";
            char[] karakterler = veri.ToCharArray();
            foreach (char eleman in karakterler)
            {
                sifrele += Convert.ToChar(eleman - 3).ToString();
            }
            return sifrele;
        }
    }
}