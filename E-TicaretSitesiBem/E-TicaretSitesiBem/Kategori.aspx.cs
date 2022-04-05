using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using E_TicaretSitesiBem.Class;
using System.Security.Cryptography;
using System.Text;

namespace E_TicaretSitesiBem.View
{
    public partial class Kategori : System.Web.UI.Page
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
                    KategoriGetir();
                }
            }
        }
        //SEÇİLEN KATEGORİNİN IDSİNE GÖRE EKLENME TARİH , GİRİŞ YAPAN ADMİN ID SİNİ VE TABLO ID TANIMLAMASINI YAPAR
        public void RaporMethod()
        {
            SecilenRaporEklenmeTarih();
            r.AdminIDGetir(txtkullanici.Text);
            r.tabloid = 1;
        }
        string SifrelenmisKategori;
        protected void KategoriEkle_Click(object sender, EventArgs e)
        {
            try
            {
                //TEXTBOXLAR BOŞ GEÇİLEMEZ SORGUSU
                if (string.IsNullOrEmpty(KategoriAd.Text) || string.IsNullOrWhiteSpace(KategoriAd.Text))
                {
                    Response.Write("<script>alert('Boş Geçilemez')</script>");
                }
                else
                {
                    //TEK BUTTONDA KAYIT YAPTIĞIMIZ İÇİN SEÇİLEN KATEGORİNİN İD Sİ YOK İSE YENİ KAYIT EKLE SORUGUSU
                    if (string.IsNullOrEmpty(txtKategoriID.Text) || string.IsNullOrWhiteSpace(txtKategoriID.Text))
                    {
                        SqlConnections sqlcon = new SqlConnections();
                        string vs_Select = "SELECT * FROM Kategori where ";
                        vs_Select += "KategoriAd='" + KategoriAd.Text + "'  ";
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
                        //KATEGORİNİN İD TEXT BOŞ DEĞİL İSE VERİ GÜNCELLEME METHODU ÇALIŞTIRIR
                        else
                        {
                            Page.Validate("ButtonClick");
                            if (Page.IsValid)
                            {
                                SifrelenmisKategori = SezarKategori(KategoriAd.Text);
                                kategoriEkle();
                                r.RaporEkle();
                                Response.Write("<script>alert('Kategori Eklendi')</script>");
                                KategoriAd.Text = " ";
                                txtKategoriID.Text = " ";
                                KategoriGetir();
                            }
                        }
                    }
                    else
                    {
                        Page.Validate("ButtonClick");
                        if (Page.IsValid)
                        {
                            kategoriGuncelle();
                            RaporMethod();
                            KategoriID();
                            r.RaporGuncelle();
                            Response.Write("<script>alert('Kategori Güncellendi')</script>");
                            txtKategoriID.Text = "";
                            KategoriAd.Text = " ";
                            KategoriGetir();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.ToString() + "')</sciprt>");
            }
            
        }
        //rptKategori TABLOSUNU VERİ TABANINDAKİ VERİLER İLE DOLDURUR
        SezarCoz s = new SezarCoz();
        public void KategoriGetir()
        {
            try
            {
                SqlConnections sqlcon = new SqlConnections();
                SqlConnection con = new SqlConnection(sqlcon.cs);
                SqlCommand cmd = new SqlCommand("spKategoriGetir", con);
                List<KategoriGetir> kategorilist = new List<KategoriGetir>();
                con.Open();
                SqlDataReader sonuc = cmd.ExecuteReader();

                while (sonuc.Read())
                {
                    var kategoriler = new KategoriGetir { KategoriID = sonuc.GetInt32(0), KategoriAd = s.SezarKategoricoz(sonuc.GetString(1)) };
                    kategorilist.Add(kategoriler);
                }
                rptKategori.DataSource = kategorilist;
                rptKategori.DataBind();
                sonuc.Close();
                con.Close();
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.ToString() + "')</sciprt>");
            }
           
            
        }
        //GÜNCELLE BUTTONUNA BASILINCA TIKLANAN KATEGORİNİN ID SİNİ ALIR VE VERİLERİ TEXTBOXLARA DOLDURUR
        int kategoriid;
        string kategori;
        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            SezarCoz s = new SezarCoz();
            
            kategoriid = int.Parse(((sender as LinkButton).NamingContainer.FindControl("txtkategoriid") as Label).Text);
            r.id = kategoriid;
            SqlConnections sqlcon = new SqlConnections();
            string sql = "select * from Kategori where KategoriID=@KategoriID";
            SqlCommand cmd = new SqlCommand(sql,sqlcon.con);
            cmd.Parameters.AddWithValue("@KategoriID", kategoriid);
            sqlcon.con.Open();
            SqlDataReader sonuc = cmd.ExecuteReader();
            while (sonuc.Read())
            {
                kategori = sonuc["KategoriAd"].ToString();
                txtKategoriID.Text = sonuc["KategoriID"].ToString();
            }
            sqlcon.con.Close();
            KategoriAd.Text=(s.SezarKategoricoz(kategori));
        }
        //SİL BUTTONUNA BASILINCA TIKLANAN SATIRIN ID SİNİ ALIR VE KATEGORİYİ AKTİF KISMINI SIFIRA ÇEKEREK GÖZÜKMEMESİNİ SAĞLAR SİLEN ADMİNİN ID SİNİ VE SİLME TARİHİNİ RAPORA KAYIT EDER
        protected void btnKategoriSil_Click(object sender, EventArgs e)
        {
            kategoriid = int.Parse(((sender as LinkButton).NamingContainer.FindControl("txtkategoriid") as Label).Text);
            r.id = kategoriid;
            RaporMethod();
            KategoriSil();
            KategoriID();
            r.RaporSil();
            KategoriGetir();
        }
        //TEXTBOXDAKİ VERİLERİ DATABASE KAYIT EDER
        public virtual void kategoriEkle()
        {
            SqlConnections sqlconn = new SqlConnections();
            SqlCommand cmd = new SqlCommand(sqlconn.cs);
            sqlconn.con.Open();
            cmd.Connection = sqlconn.con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "kategoriEkle";
            cmd.Parameters.AddWithValue("@kategori", SifrelenmisKategori);
            cmd.Parameters.AddWithValue("@Aktif", 1);
            cmd.Parameters.AddWithValue("@KEklenmeTarihi", DateTime.Now);
            cmd.ExecuteNonQuery();
            sqlconn.con.Close();
            KategoriGetir();
            RaporMethod();
            KategoriID();
            
        }
        //SEÇİLEN ID NİN EKLENME TARİHİNİ ÇEKER
        DateTime eklenmetarih = DateTime.Now;
        public void SecilenRaporEklenmeTarih()
        {
            
            SqlConnections sqlcon = new SqlConnections();
            string sql = "select * from Kategori where KategoriID='" +kategoriid+"'";
            SqlCommand cmd = new SqlCommand(sql, sqlcon.con);
            sqlcon.con.Open();
            SqlDataReader sonuc = cmd.ExecuteReader();
            while (sonuc.Read())
            {
                eklenmetarih = Convert.ToDateTime(sonuc["KEklenmeTarihi"]);

            }
            sqlcon.con.Close();
            r.et = eklenmetarih;
        }
        //DATABASE SON EKLENEN KATEGORİNİN IDSİNİ ÇEKER
        public void KategoriID()
        {
            SqlConnections sqlcon = new SqlConnections();
            string sql = "Select top 1 KategoriID from Kategori order by KategoriID desc";
            SqlCommand cmd2 = new SqlCommand(sql, sqlcon.con);

            sqlcon.con.Open();
            SqlDataReader sonuc = cmd2.ExecuteReader();
            while (sonuc.Read())
            {
                kategoriid = Convert.ToInt32(sonuc["KategoriID"].ToString());

            }
            sqlcon.con.Close();
            r.id = kategoriid;
        }
        //KATEGORİ AKTİFLİK KISMINI 0 YAPAN METHOD
        public void KategoriSil()
        {
            SqlConnections sqlcon = new SqlConnections();
            DataTable tablo = new DataTable();
            sqlcon.con.Open();
            sqlcon.komut = new SqlCommand("spKategoriSil", sqlcon.con);
            sqlcon.komut.CommandType = CommandType.StoredProcedure;
            sqlcon.komut.Parameters.AddWithValue("@KategoriID", kategoriid);
            sqlcon.komut.Parameters.AddWithValue("@Aktif", 0);
            sqlcon.komut.Parameters.AddWithValue("@KSilinmeTarihi", DateTime.Now);
            sqlcon.komut.ExecuteNonQuery();
            sqlcon.con.Close();
        }
        //KATEGORİ GÜNCELLEME METHODU
        private void kategoriGuncelle()
        {
            SqlConnections sqlcon = new SqlConnections();
            DataTable tablo = new DataTable();
            sqlcon.con.Open();
            string kategoriG = SezarKategori(KategoriAd.Text);
            sqlcon.komut = new SqlCommand("spKategoriGuncelle", sqlcon.con);
            sqlcon.komut.CommandType = CommandType.StoredProcedure;
            sqlcon.komut.Parameters.AddWithValue("@KategoriID", Convert.ToInt32(txtKategoriID.Text));
            sqlcon.komut.Parameters.AddWithValue("@GuncellenmeTarihi", DateTime.Now);
            sqlcon.komut.Parameters.AddWithValue("@KategoriAd", kategoriG);
            sqlcon.komut.ExecuteNonQuery();
            sqlcon.con.Close();
        }

        public string SezarKategori(string sifrele)
        {
            
            string veri = "";
            veri = sifrele;
            sifrele = "";
            char[] karakterler = veri.ToCharArray();
            foreach (char eleman in karakterler)
            {
                sifrele += Convert.ToChar(eleman + 3).ToString();
            }
            return sifrele;
        }
       
    }

}