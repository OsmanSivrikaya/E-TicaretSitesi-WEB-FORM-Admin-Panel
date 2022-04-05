using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using E_TicaretSitesiBem.Class;

namespace E_TicaretSitesiBem
{
    
    public partial class RaporGetir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                object admink = Session["adminadi"];
                if (admink == null)
                {
                    Response.Redirect("Admin.aspx");
                }
                else
                {
                    RaporDoldur();
                }
            }
        }
        //RAPOR TABLOSUNUN İÇİNDEKİ VERİLERİ rptPapor TABLOSUNA DOLDURUR
        public void RaporDoldur()
        {
            SqlConnections sqlconn = new SqlConnections();
            SqlConnection con = new SqlConnection(sqlconn.cs);
            SqlCommand cmd = new SqlCommand("spRaporGetir", con);
            con.Open();
            rptRapor.DataSource = cmd.ExecuteReader();
            rptRapor.DataBind();
            con.Close();
        }
    }
}