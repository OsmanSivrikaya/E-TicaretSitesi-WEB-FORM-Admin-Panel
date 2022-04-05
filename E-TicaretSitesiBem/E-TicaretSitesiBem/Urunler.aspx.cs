using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using E_TicaretSitesiBem.Class;
using System.Data.SqlClient;
using System.Data;

namespace E_TicaretSitesiBem.View
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Rapor r = new Rapor();
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
                    KategoriAdGetir();
                    TedarikciGetir();
                    UrunlerGetir();
                }
            }
        }
        //SEÇİLEN ÜRÜNÜN IDSİNE GÖRE EKLENME TARİH , GİRİŞ YAPAN ADMİN ID SİNİ VE TABLO ID TANIMLAMASINI YAPAR
        public void RaporMethod()
        {
            SecilenRaporEklenmeTarih();
            r.AdminIDGetir(txtkullanici.Text);
            r.tabloid = 2;
        }
        //URUNLERİ DATABASEDEN ÇEKEREK TABLOYA DOLDURUR
        public void UrunlerGetir()
        {
            SqlConnections sqlcon = new SqlConnections();
            SqlConnection con = new SqlConnection(sqlcon.cs);
            SqlCommand cmd = new SqlCommand("spUrunGetir", con);
            con.Open();
            rptUrunler.DataSource = cmd.ExecuteReader();
            rptUrunler.DataBind();
            con.Close();
        }
        //KATEGORİLERİ DROPDOWNA ÇEKER
        SezarCoz s = new SezarCoz();
        public void KategoriAdGetir()
        {
            //SqlConnections sqlconn = new SqlConnections();
            //SqlDataAdapter da = new SqlDataAdapter("Select * from Kategori", sqlconn.cs);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //List<string> kategori = new List<string>();
            //sqlconn.con.Open();
            //SqlDataReader sonuc = dt.Rows.Count.ToString

            //while (sonuc.Read())
            //{
            //    var kategoriler = new KategoriGetir { KategoriID = sonuc.GetInt32(0), KategoriAd = s.SezarKategoricoz(sonuc.GetString(1)) };
            //    kategorilist.Add(kategoriler);
            //}
            //sqlconn.con.Close();


            SqlConnections sqlcon = new SqlConnections();
            SqlConnection con = new SqlConnection(sqlcon.cs);
            SqlCommand cmd = new SqlCommand("Select * from Kategori", con);
            List<KategoriGetir> kategorilist = new List<KategoriGetir>();
            con.Open();
            SqlDataReader sonuc = cmd.ExecuteReader();

            while (sonuc.Read())
            {
                var kategoriler = new KategoriGetir { KategoriID = sonuc.GetInt32(0), KategoriAd = s.SezarKategoricoz(sonuc.GetString(1)) };
                kategorilist.Add(kategoriler);
            }
            drpKategori.DataSource = kategorilist;
            drpKategori.DataValueField = "KategoriID";
            drpKategori.DataTextField = "KategoriAd";
            drpKategori.DataBind();
            sonuc.Close();
            con.Close();



            
        }
        //TEDARİKCİLERİ DROPDOWNA ÇEKER
        public void TedarikciGetir()
        {
            SqlConnections sqlconn = new SqlConnections();
            SqlDataAdapter da = new SqlDataAdapter("Select TedarikciID,TedarikciAd from Tedarikciler", sqlconn.cs);
            DataTable dt = new DataTable();
            da.Fill(dt);
            drpTedarikci.DataSource = dt;
            drpTedarikci.DataValueField = "TedarikciID";
            drpTedarikci.DataTextField = "TedarikciAd";
            drpTedarikci.DataBind();
        }
        //SEÇİLEN URUNUN EKLENME TARİHİNİ ÇEKER
        DateTime eklenmetarih = DateTime.Now;
        public void SecilenRaporEklenmeTarih()
        {

            SqlConnections sqlcon = new SqlConnections();
            string sql = "select * from Urunler where UrunID='" + id + "'";
            SqlCommand cmd = new SqlCommand(sql, sqlcon.con);
            sqlcon.con.Open();
            SqlDataReader sonuc = cmd.ExecuteReader();
            while (sonuc.Read())
            {
                eklenmetarih = Convert.ToDateTime(sonuc["OlusturmaTarih"]);

            }
            sqlcon.con.Close();
            r.et = eklenmetarih;
        }
        //SON EKLENEN URUNUN ID SİNİ ÇEKER
        public void UrunID()
        {
            SqlConnections sqlcon = new SqlConnections();
            string sql = "Select top 1 UrunID from Urunler order by UrunID desc";
            SqlCommand cmd2 = new SqlCommand(sql, sqlcon.con);

            sqlcon.con.Open();
            SqlDataReader sonuc = cmd2.ExecuteReader();
            while (sonuc.Read())
            {
                id = Convert.ToInt32(sonuc["UrunID"].ToString());

            }
            sqlcon.con.Close();
            r.id = id;
        }
        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUrunDetay.Text) || string.IsNullOrWhiteSpace(txtUrunDetay.Text)
                && string.IsNullOrEmpty(txtUrunFiyat.Text) || string.IsNullOrWhiteSpace(txtUrunFiyat.Text)
                && string.IsNullOrEmpty(txtUrunismi.Text) || string.IsNullOrWhiteSpace(txtUrunismi.Text)
                && string.IsNullOrEmpty(txtUrunStok.Text) || string.IsNullOrWhiteSpace(txtUrunStok.Text))
                {
                    Response.Write("<script>alert('Boş Geçilemez')</script>");
                }
                else
                {
                    if (txtUrunFiyat.Text.Length <= 50 && txtUrunStok.Text.Length <= 50)
                    {


                        Page.Validate("ClickEvent");
                        if (Page.IsValid)
                        {
                            if (string.IsNullOrEmpty(txtUrunID.Text) || string.IsNullOrWhiteSpace(txtUrunID.Text))
                            {
                                SqlConnections sqlcon = new SqlConnections();
                                string vs_Select = "SELECT * FROM Urunler where ";
                                vs_Select += "UrunAd='" + txtUrunismi.Text + "'  ";
                                SqlCommand komut = new SqlCommand(vs_Select, sqlcon.con);
                                sqlcon.con.Open();
                                SqlDataAdapter oku = new SqlDataAdapter();
                                oku.SelectCommand = komut;
                                DataTable dt = new DataTable();
                                oku.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    Response.Write("<script>alert('Bu İsimde Veri Kayıtlı')</script>");
                                }
                                else
                                {
                                    Response.Write("<script>alert('Urun Eklendi')</script>");
                                    UrunEkle();
                                    RaporMethod();
                                    UrunID();
                                    r.RaporEkle();
                                    txtUrunDetay.Text = "";
                                    txtUrunFiyat.Text = "";
                                    txtUrunismi.Text = "";
                                    txtUrunStok.Text = "";
                                    SqlConnections sqlcon2 = new SqlConnections();
                                    sqlcon2.con.Open();
                                    string logopath = " ";
                                    string fotpath = " ";
                                    string extension = System.IO.Path.GetExtension(FotoSec.FileName);

                                    if (extension == ".jpg" || extension == ".png" || extension == ".gif" || extension == ".jpeg")
                                    {

                                        logopath = "~//Upload//" + Guid.NewGuid() + FotoSec.FileName;
                                        FotoSec.SaveAs(Server.MapPath(logopath));
                                        fotpath = Server.MapPath(logopath);
                                        fpath.Value = fotpath.ToString();
                                        sqlcon2.komut = new SqlCommand("spFotografEkle", sqlcon2.con);
                                        sqlcon2.komut.CommandType = CommandType.StoredProcedure;
                                        sqlcon2.komut.Parameters.AddWithValue("@urunfot", fpath.Value.ToString());
                                        sqlcon2.komut.Parameters.AddWithValue("@urunid", id);
                                        sqlcon2.komut.ExecuteNonQuery();
                                    }
                                    else { Response.Write("<script>alert('Fotoğraf Tipi Sadece gif,jpg,png,jpeg Olabilir.')</script>"); }
                                    UrunlerGetir();
                                }
                                sqlcon.con.Close();
                            }
                            else
                            {
                                Response.Write("<script>alert('Tedarikci Güncellendi')</script>");

                                UrunGuncelle();

                                r.id = Convert.ToInt32(txtUrunID.Text);
                                RaporMethod();
                                r.RaporEkle();
                                r.id = 0;
                                txtUrunDetay.Text = "";
                                txtUrunFiyat.Text = "";
                                txtUrunismi.Text = "";
                                txtUrunStok.Text = "";
                                txtUrunID.Text = "";
                                UrunlerGetir();
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Hatalı Giriş')</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Stok veya Fiyat 50 karakterden uzun olamaz')</script>");

                    }
                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.ToString() + "')</sciprt>");
            }
            
        }
        int id = 0;
        protected void UrunSec_Click(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(((sender as LinkButton).NamingContainer.FindControl("txturunid") as Label).Text);
                SqlConnections sqlcon = new SqlConnections();
                string sql = "select * from Urunler where UrunID='" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, sqlcon.con);
                cmd.Parameters.AddWithValue("@UrunID", id);
                sqlcon.con.Open();
                SqlDataReader sonuc = cmd.ExecuteReader();
                while (sonuc.Read())
                {
                    txtUrunismi.Text = sonuc["UrunAd"].ToString();
                    txtUrunDetay.Text = sonuc["UrunDetay"].ToString();
                    txtUrunFiyat.Text = sonuc["UrunFiyat"].ToString();
                    txtUrunStok.Text = sonuc["StokID"].ToString();
                    drpTedarikci.SelectedValue = sonuc["TedarikciID"].ToString();
                    drpKategori.SelectedValue = sonuc["UrunKategoriID"].ToString();
                }
                txtUrunID.Text = id.ToString();
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.ToString() + "')</script>");
            }
            

        }
        public void UrunEkle()
        {
            SqlConnections con = new SqlConnections();
            DataTable tablo = new DataTable();
            con.con.Open();
            con.komut = new SqlCommand("spUrunEkle", con.con);
            con.komut.CommandType = CommandType.StoredProcedure;
            con.komut.Parameters.AddWithValue("@UrunAd", txtUrunismi.Text.ToString());
            con.komut.Parameters.AddWithValue("@UrunKategoriID", Convert.ToInt32(drpKategori.SelectedValue.ToString()));
            con.komut.Parameters.AddWithValue("@UrunFiyat", Convert.ToDouble(txtUrunFiyat.Text.ToString()));
            con.komut.Parameters.AddWithValue("@UrunDetay", txtUrunDetay.Text.ToString());
            con.komut.Parameters.AddWithValue("@OlusturmaTarih", DateTime.Now);
            con.komut.Parameters.AddWithValue("@TedarikciID", Convert.ToInt32(drpTedarikci.SelectedValue.ToString()));
            con.komut.Parameters.AddWithValue("@Stok", Convert.ToInt32(txtUrunStok.Text.ToString()));
            con.komut.Parameters.AddWithValue("@Aktif", 1);
            con.komut.ExecuteNonQuery();
            con.con.Close();
        }
        protected void UrunSil_Click(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(((sender as LinkButton).NamingContainer.FindControl("txturunid") as Label).Text);
                UrunSil();
                RaporMethod();
                UrunID();
                r.RaporSil();

                UrunlerGetir();
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('"+ex.ToString()+"')</script>");
            }
            
        }
        public void UrunSil()
        {
            SqlConnections sqlcon = new SqlConnections();
            DataTable tablo = new DataTable();
            sqlcon.con.Open();
            sqlcon.komut = new SqlCommand("spUrunSil", sqlcon.con);
            sqlcon.komut.CommandType = CommandType.StoredProcedure;
            sqlcon.komut.Parameters.AddWithValue("@UrunID", id);
            sqlcon.komut.Parameters.AddWithValue("@Aktif", 0);
            sqlcon.komut.ExecuteNonQuery();
            sqlcon.con.Close();
        }
        private void UrunGuncelle()
        {
            SqlConnections sqlcon = new SqlConnections();
            DataTable tablo = new DataTable();
            sqlcon.con.Open();
            sqlcon.komut = new SqlCommand("spUrunGuncelle", sqlcon.con);
            sqlcon.komut.CommandType = CommandType.StoredProcedure;
            sqlcon.komut.Parameters.AddWithValue("@UrunID", Convert.ToInt32(txtUrunID.Text));
            sqlcon.komut.Parameters.AddWithValue("@UrunAd", txtUrunismi.Text);
            sqlcon.komut.Parameters.AddWithValue("@UrunKategoriID", Convert.ToInt32(drpKategori.SelectedValue.ToString()));
            sqlcon.komut.Parameters.AddWithValue("@UrunFiyat", Convert.ToDouble(txtUrunFiyat.Text));
            sqlcon.komut.Parameters.AddWithValue("@UrunDetay", txtUrunDetay.Text);
            sqlcon.komut.Parameters.AddWithValue("@GuncellemeTarih", DateTime.Now);
            sqlcon.komut.Parameters.AddWithValue("@TedarikciID", Convert.ToInt32(drpTedarikci.SelectedValue.ToString()));
            sqlcon.komut.Parameters.AddWithValue("@Stok", txtUrunStok.Text);
            sqlcon.komut.ExecuteNonQuery();
            sqlcon.con.Close();
        }

        protected void FotoSec_Load(object sender, EventArgs e)
        {

        }

 

    }

}