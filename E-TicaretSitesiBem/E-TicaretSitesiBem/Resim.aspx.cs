using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using E_TicaretSitesiBem.Class;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace E_TicaretSitesiBem
{
    public partial class Resim : System.Web.UI.Page
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
                    txtkullanici.Text = admink.ToString();
                    SqlConnections sqlcon = new SqlConnections();
                    string sql = "select UrunID,UrunAd from Urunler where Aktif=1 order by UrunID ";
                    SqlCommand cmd = new SqlCommand(sql, sqlcon.con);
                    sqlcon.con.Open();
                    repurun.DataSource = cmd.ExecuteReader();
                    repurun.DataBind();
                    sqlcon.con.Close();

                }
            }
            

        }
        
        protected void fotyukle_Click(object sender, EventArgs e)
        {
           
            //DOSYANIN YÜKLENİP YÜKLENMEDİĞİNİ KONTROL EDEN SORGU
            SqlConnections sqlcon2 = new SqlConnections();
            sqlcon2.con.Open();
            string logopath = " ";
            string fotpath = " ";
            if (FotoSec.HasFile)
            {
                string extension = System.IO.Path.GetExtension(FotoSec.FileName);
                //YÜKLENEN DOSYANIN UZANTILARINI KONROL EDEN SORGU
                if (extension == ".jpg" || extension == ".png" || extension == ".gif" || extension == ".jpeg")
                {

                    logopath = "~//Upload//" + Guid.NewGuid() + FotoSec.FileName;
                   
                    FotoSec.SaveAs(Server.MapPath(logopath));
                    fotpath = Server.MapPath(logopath);
                    fpath.Value = fotpath.ToString();
                    sqlcon2.komut = new SqlCommand("spFotografEkle", sqlcon2.con);
                    sqlcon2.komut.CommandType = CommandType.StoredProcedure;
                    sqlcon2.komut.Parameters.AddWithValue("@urunfot", fpath.Value.ToString());
                    sqlcon2.komut.Parameters.AddWithValue("@urunid", txtuid.Text);
                    sqlcon2.komut.ExecuteNonQuery();


                    


                    Response.Write("<script>alert('Fotoğraf Eklendi.')</script>");
                }


                else { Response.Write("<script>alert('Fotoğraf Tipi Sadece gif,jpg,png,jpeg Olabilir.')</script>"); }

            }

            else
            { Response.Write("<script>alert('Fotoğraf seçiniz.')</script>"); }

        }
        //SEÇİLEN ÜRÜNÜN ID SİNİ GETİRİR
        protected void Usec_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((sender as LinkButton).NamingContainer.FindControl("labelurunid") as Label).Text);
            txtuid.Text = id.ToString();
        }
    }
}