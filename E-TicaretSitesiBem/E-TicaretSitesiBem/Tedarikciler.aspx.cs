using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using E_TicaretSitesiBem.Class;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace E_TicaretSitesiBem.View
{
    public partial class Tedarikciler : System.Web.UI.Page
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
                    txtAdminID.Text = admink.ToString();
                    sehirid = 81;
                    ilceid = 928;
                    IlGetir();
                    IlceGetir();
                    MahGetir();
                    TedarikciGetir();
            }
        }
        }
        int sehirid;
        //SEÇİLEN TEDARİKCİNİN IDSİNE GÖRE EKLENME TARİH , GİRİŞ YAPAN ADMİN ID SİNİ VE TABLO ID TANIMLAMASINI YAPAR
        public void RaporMethod()
        {
            SecilenRaporEklenmeTarih();
            r.AdminIDGetir(txtAdminID.Text);
            r.tabloid = 4;
        }
        //VERİ TABININDAKİ İLLERİ drpSehir GETİRİR
        public void IlGetir()
        {
            SqlConnections sqlconn = new SqlConnections();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Sehirler", sqlconn.cs);
            DataTable dt = new DataTable();
            da.Fill(dt);
            drpSehir.DataSource = dt;
            drpSehir.DataValueField = "SehirId";
            drpSehir.DataTextField = "SehirAdi";
            drpSehir.DataBind();

        }
        //VERİ TABININDAKİ İLÇELERİ drpIlce GETİRİR
        public void IlceGetir()
        {
            SqlConnections sqlconn = new SqlConnections();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Ilceler where SehirId='" + sehirid + "'", sqlconn.cs);
            DataTable dt = new DataTable();
            da.Fill(dt);
            drpIlce.DataSource = dt;
            drpIlce.DataValueField = "ilceId";
            drpIlce.DataTextField = "IlceAdi";
            drpIlce.DataBind();

        }
        int ilceid;
        //VERİ TABININDAKİ MAHALLELERİ drpMah GETİRİR
        public void MahGetir()
        {
            SqlConnections sqlconn = new SqlConnections();
            SqlDataAdapter da = new SqlDataAdapter("Select * from SemtMah where ilceId='" + ilceid + "'", sqlconn.cs);
            DataTable dt = new DataTable();
            da.Fill(dt);
            drpMah.DataSource = dt;
            drpMah.DataValueField = "SemtMahId";
            drpMah.DataTextField = "MahalleAdi";
            drpMah.DataBind();
        }
       //KAYDET BUTTONI ÇALIŞTIĞINDA
        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                //TEXTBOXLAR BOŞ GEÇİLEMEZ SORGUSU
                if (string.IsNullOrEmpty(txtAdres.Text) || string.IsNullOrWhiteSpace(txtAdres.Text)
                    && string.IsNullOrEmpty(txtTedarikciAd.Text) || string.IsNullOrWhiteSpace(txtTedarikciAd.Text)
                    && string.IsNullOrEmpty(txtTedarikciTelefon.Text) || string.IsNullOrWhiteSpace(txtTedarikciTelefon.Text)
                    )
                {
                    Response.Write("<script>alert('Boş Geçilemez')</script>");
                }
                else
                {
                    //TELEFON NO 11 HANEDEN KISA OLAMAZ SORGUSU
                    string tel = txtTedarikciTelefon.Text;
                    if (tel.Length == 11)
                    {
                        //DATABASEDE GİRİLEN TEDARİKCİ İSMİNDE KAYIT VAR MI SORGUSU
                        SqlConnections sqlcon = new SqlConnections();
                        string vs_Select = "SELECT * FROM Tedarikciler where ";
                        vs_Select += "TedarikciAd='" + txtTedarikciAd.Text + "' or  ";
                        vs_Select += "Tiletisim = '" + txtTedarikciTelefon.Text + "' and ";
                        vs_Select += "Aktif=1 ";
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
                            //TEK BUTTONDA KAYIT YAPTIĞIMIZ İÇİN SEÇİLEN TEDARİKCİNİNS İD Sİ YOK İSE YENİ KAYIT EKLE SORUGUSU
                            if (string.IsNullOrEmpty(txtTedarikciID.Text) || string.IsNullOrWhiteSpace(txtTedarikciID.Text))
                            {
                                Response.Write("<script>alert('Tedarikci Eklendi')</script>");

                                TedarikciEkle();
                                TedarikciID();
                                RaporMethod();
                                r.RaporEkle();
                                r.id = 0;
                                tedarikciid = 0;
                                txtAdres.Text = "";
                                txtTedarikciAd.Text = "";
                                txtTedarikciTelefon.Text = "";
                            }
                            //TEDARİKCİ İD TEXT BOŞ DEĞİL İSE VERİ GÜNCELLEME METHODU ÇALIŞTIRIR
                            else
                            {
                                Response.Write("<script>alert('Tedarikci Güncellendi')</script>");
                                TedarikciGuncelle();
                                r.id = Convert.ToInt32(txtTedarikciID.Text);
                                tedarikciid = Convert.ToInt32(txtTedarikciID.Text);
                                RaporMethod();
                                r.RaporGuncelle();
                                r.id = 0;
                                tedarikciid = 0;
                                txtAdres.Text = "";
                                txtTedarikciAd.Text = "";
                                txtTedarikciTelefon.Text = "";
                                txtTedarikciID.Text = "";
                            }
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('TELEFON NUMARASI 11 HANEDEN AZ OLMAZ')</script>");
                    }
                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('"+ ex.ToString() + "')</sciprt>");
            }

        }
        //TEXTBOXLARA GİRİLEN VERİLERİ DATABASE KAYIT EDEN METHOD
        public void TedarikciEkle()
        {
            SqlConnections con = new SqlConnections();
            DataTable tablo = new DataTable();
            con.con.Open();
            con.komut = new SqlCommand("spTedarikciekle", con.con);
            con.komut.CommandType = CommandType.StoredProcedure;
            con.komut.Parameters.AddWithValue("@TedarikciAd", txtTedarikciAd.Text);
            con.komut.Parameters.AddWithValue("@Tiletisim", txtTedarikciTelefon.Text);
            con.komut.Parameters.AddWithValue("@SehirId", Convert.ToInt32(drpSehir.SelectedValue.ToString()));
            con.komut.Parameters.AddWithValue("@ilceId", Convert.ToInt32(drpIlce.SelectedValue.ToString()));
            con.komut.Parameters.AddWithValue("@SemtMahId", Convert.ToInt32(drpMah.SelectedValue));
            con.komut.Parameters.AddWithValue("@TedarikciAdresDetay", txtAdres.Text);
            con.komut.Parameters.AddWithValue("@OlusturmaTarih", DateTime.Now);
            con.komut.Parameters.AddWithValue("@Aktif", 1);
            con.komut.ExecuteNonQuery();
            con.con.Close();
            TedarikciGetir();
        }
        //drpIlce DEĞİŞTİĞİNDE VALUESİNİ ilceid YE ATAR ONA GÖRE MAH LARI LİSTELER
        protected void drpIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            ilceid = Convert.ToInt32(drpIlce.SelectedValue.ToString());
            MahGetir();
        }
        //drpSehir DEĞİŞTİĞİNDE SEÇİLİ OLAN ŞEHİR ID Yİ ALIR VE ONA GÖRE İLÇELERİ GETİRİR
        protected void drpSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            sehirid = Convert.ToInt32(drpSehir.SelectedValue.ToString());
            IlceGetir();
            ilceid = Convert.ToInt32(drpIlce.SelectedValue.ToString());
            IlceGetir();
            MahGetir();
        }
        //TEDARİKCİLERİ rptTedarikciler TABLOSUNA DATABASEDEN GELEN VERİLERİ DOLDURUR
        public void TedarikciGetir()
        {
            SqlConnections sqlconn = new SqlConnections();
            SqlConnection con = new SqlConnection(sqlconn.cs);
            SqlCommand cmd = new SqlCommand("spTedarikciGetir", con);
            con.Open();
            rptTedarikciler.DataSource = cmd.ExecuteReader();
            rptTedarikciler.DataBind();
            con.Close();
        }
        int mahid;
        int tedarikciid = 0;
        //SEÇİLEN TEDARİKCİNİN ID SİNİ ALIR VE ID YE GÖRE DATABASEDEN ÇEKİLEN VERİLERLE TEXTBOXLARI DOLDURUR
        protected void TedarikciSec_Click1(object sender, EventArgs e)
        {
            try
            {
                tedarikciid = int.Parse(((sender as LinkButton).NamingContainer.FindControl("tedarikciid") as Label).Text);

                SqlConnections Sqlconn = new SqlConnections();
                string sql = "select * from Tedarikciler where TedarikciID=@TedarikciID";
                SqlCommand sorgu = new SqlCommand(sql, Sqlconn.con);
                sorgu.Parameters.AddWithValue("@TedarikciID", tedarikciid);
                Sqlconn.con.Open();
                SqlDataReader sonuc = sorgu.ExecuteReader();
                while (sonuc.Read())
                {
                    txtTedarikciAd.Text = sonuc["TedarikciAd"].ToString();
                    txtTedarikciTelefon.Text = sonuc["Tiletisim"].ToString();
                    sehirid = Convert.ToInt32(sonuc["SehirId"].ToString());
                    ilceid = Convert.ToInt32(sonuc["ilceId"].ToString());
                    mahid = Convert.ToInt32(sonuc["SemtMahId"].ToString());
                    txtAdres.Text = sonuc["TedarikciAdresDetay"].ToString();
                }
                Sqlconn.con.Close();


                drpSehir.SelectedValue = sehirid.ToString();
                IlceGetir();
                drpIlce.SelectedValue = ilceid.ToString();
                MahGetir();
                drpMah.SelectedValue = mahid.ToString();

                txtTedarikciID.Text = tedarikciid.ToString();
                tedarikciid = Convert.ToInt32(txtTedarikciID.Text);
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.ToString() + "')</script>");
            }
            
        }
        //TEDARİKCİ GÜNCELLEME METHODU
        public void TedarikciGuncelle()
        {
            SqlConnections con = new SqlConnections();
            DataTable tablo = new DataTable();
            con.con.Open();
            con.komut = new SqlCommand("spTedarikciGuncelle", con.con);
            con.komut.CommandType = CommandType.StoredProcedure;
            con.komut.Parameters.AddWithValue("@TedarikciID", Convert.ToInt32(txtTedarikciID.Text));
            con.komut.Parameters.AddWithValue("@TedarikciAd", txtTedarikciAd.Text);
            con.komut.Parameters.AddWithValue("@Tiletisim", txtTedarikciTelefon.Text);
            con.komut.Parameters.AddWithValue("@SehirId", Convert.ToInt32(drpSehir.SelectedValue.ToString()));
            con.komut.Parameters.AddWithValue("@ilceId", Convert.ToInt32(drpIlce.SelectedValue.ToString()));
            con.komut.Parameters.AddWithValue("@SemtMahId", Convert.ToInt32(drpMah.SelectedValue.ToString()));
            con.komut.Parameters.AddWithValue("@TedarikciAdresDetay", txtAdres.Text);
            con.komut.Parameters.AddWithValue("@OlusturmaTarih", DateTime.Now);
            con.komut.ExecuteNonQuery();
            con.con.Close();
            TedarikciGetir();
        }
        //TEDARİKCİ SİL BUTTONU TEDARİKCİ SİL VE RAPOR METHODLARINI ÇALIŞTIRIR
        protected void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                tedarikciid = int.Parse(((sender as LinkButton).NamingContainer.FindControl("tedarikciid") as Label).Text);
                TedarikciSil();
                RaporMethod();
                r.id = tedarikciid;
                r.RaporSil();
                r.id = 0;
                txtTedarikciID.Text = "";
            }
            catch (Exception ex)
            {

                Response.Write("<sript>alert('" + ex.ToString() + "')</script>");
            }
            
        }
        //SEÇİLEN ID NİN EKLENME TARİHİNİ ÇEKER
        public void SecilenRaporEklenmeTarih()
        {
            DateTime eklenmetarih = DateTime.Now;
            SqlConnections sqlcon = new SqlConnections();
            string sql = "select * from Tedarikciler where TedarikciID='" + tedarikciid + "'";
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
        //VERİ TABANINA SON EKLENEN TEDARİKCİNİN ID SİNİ ÇEKER
        public void TedarikciID()
        {
            SqlConnections sqlcon = new SqlConnections();
            string sql = "Select top 1 TedarikciID from Tedarikciler order by TedarikciID desc";
            SqlCommand cmd2 = new SqlCommand(sql, sqlcon.con);

            sqlcon.con.Open();
            SqlDataReader sonuc = cmd2.ExecuteReader();
            while (sonuc.Read())
            {
                tedarikciid = Convert.ToInt32(sonuc["TedarikciID"].ToString());
            }
            sqlcon.con.Close();
            r.id = tedarikciid;
        }
        //TEDARİKCİ SİL METHODU
        public void TedarikciSil()
        {
            int sil = 0;
            SqlConnections con = new SqlConnections();
            DataTable tablo = new DataTable();
            con.con.Open();
            con.komut = new SqlCommand("spTedarikciSil", con.con);
            con.komut.CommandType = CommandType.StoredProcedure;
            con.komut.Parameters.AddWithValue("@TedarikciID", tedarikciid);
            con.komut.Parameters.AddWithValue("@SilinmeTarihi", DateTime.Now);
            con.komut.Parameters.AddWithValue("@aktif", sil);
            con.komut.ExecuteNonQuery();
            con.con.Close();
            TedarikciGetir();
        }

        protected void txtTedarikciTelefon_TextChanged(object sender, EventArgs e)
        {

        }
    }
}