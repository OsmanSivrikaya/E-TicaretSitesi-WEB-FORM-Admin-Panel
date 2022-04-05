using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace E_TicaretSitesiBem.Class
{
    //HER SEFERİNDE CONNECTION EKLMEK YERİNE TEK SEFER EKLİYİP HER YERE BU CLASSI ÇEKİYORUZ
    public class SqlConnections
    {
        public SqlConnection con = new SqlConnection("server=OSMANSIVRIKAYA;Database=eticaret;Integrated Security=True");
        public SqlDataAdapter adtr { get; set; }
        public SqlCommand komut { get; set; }

        public string cs = "server=OSMANSIVRIKAYA;Database=eticaret;Integrated Security=True";
    }
}