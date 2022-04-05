using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using E_TicaretSitesiBem.Class;

namespace E_TicaretSitesiBem.View
{
    public partial class Musteriler : System.Web.UI.Page
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
                    MusteriGetir();
                    sehirid = 81;
                    ilceid = 928;
                    sehirid2 = 81;
                    ilceid2 = 928;
                    SehirIlIlce();

                }
            }
        }
        //SEÇİLEN MÜŞTERİRİNİN IDSİNE GÖRE EKLENME TARİH , GİRİŞ YAPAN ADMİN ID SİNİ VE TABLO ID TANIMLAMASINI YAPAR
        public void RaporMethod()
        {
            SecilenRaporEklenmeTarih();
            r.AdminIDGetir(txtAdminID.Text);
            r.tabloid = 3;
        }

        int musteriid;
        //SON EKLENEN ÜRÜNÜN ID SİNİ ALIR
        public void MusteriID()
        {
            SqlConnections sqlcon = new SqlConnections();
            string sql = "Select top 1 MusteriID from Musteriler order by MusteriID desc";
            SqlCommand cmd2 = new SqlCommand(sql, sqlcon.con);

            sqlcon.con.Open();
            SqlDataReader sonuc = cmd2.ExecuteReader();
            while (sonuc.Read())
            {
                musteriid = Convert.ToInt32(sonuc["MusteriID"].ToString());
            }
            sqlcon.con.Close();
            r.id = musteriid;
        }
        #region ililcesehir
        //ŞEHİR METHODLARINI ÇALIŞTIRAN METHOD
        public void SehirIlIlce()
        {
            IlGetir();
            IlceGetir();
            MahGetir();
            IlGetir2();
            IlceGetir2();
            MahGetir2();
        }
        int sehirid;
        //ŞEHİRLERİ DropDKİlce DropDownList İÇİNE YAZDIRIR
        public virtual void IlGetir()
        {
            SqlConnections sqlconn = new SqlConnections();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Sehirler Order By SehirAdi asc", sqlconn.cs);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DropDKSehir.DataSource = dt;
            DropDKSehir.DataValueField = "SehirId";
            DropDKSehir.DataTextField = "SehirAdi";
            DropDKSehir.DataBind();
        }
        //İLÇELERİ DropDKİlce DropDownList İÇİNE YAZDIRIR
        int ilceid;
        public virtual void IlceGetir()
        {
            SqlConnections sqlconn = new SqlConnections();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Ilceler where SehirId='" + sehirid + "' Order By IlceAdi asc ", sqlconn.cs);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DropDKİlce.DataSource = dt;
            DropDKİlce.DataValueField = "ilceId";
            DropDKİlce.DataTextField = "IlceAdi";
            DropDKİlce.DataBind();

        }
        //MAHALLELERİ DropDKMahalle DropDownList İÇİNE YAZDIRIR
        public virtual void MahGetir()
        {
            SqlConnections sqlconn = new SqlConnections();
            SqlDataAdapter da = new SqlDataAdapter("Select * from SemtMah  where ilceId='" + ilceid + "' Order By MahalleAdi asc", sqlconn.cs);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DropDKMahalle.DataSource = dt;
            DropDKMahalle.DataValueField = "SemtMahId";
            DropDKMahalle.DataTextField = "MahalleAdi";
            DropDKMahalle.DataBind();
        }
        //ŞEHİRLERİ DropDFSehir DropDownList İÇİNE YAZDIRIR
        int sehirid2;
        public virtual void IlGetir2()
        {
            SqlConnections sqlconn = new SqlConnections();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Sehirler Order By SehirAdi", sqlconn.cs);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DropDFSehir.DataSource = dt;
            DropDFSehir.DataValueField = "SehirId";
            DropDFSehir.DataTextField = "SehirAdi";
            DropDFSehir.DataBind();

        }
        //İLÇELERİ DropDFİlce DropDownList İÇİNE YAZDIRIR
        int ilceid2;
        public virtual void IlceGetir2()
        {
            SqlConnections sqlconn = new SqlConnections();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Ilceler  where SehirId='" + sehirid2 + "' Order By IlceAdi asc", sqlconn.cs);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DropDFİlce.DataSource = dt;
            DropDFİlce.DataValueField = "ilceId";
            DropDFİlce.DataTextField = "IlceAdi";
            DropDFİlce.DataBind();

        }
        //MAHELLELERİ DropDFMahalle DropDownList İÇİNE YAZDIRIR
        public virtual void MahGetir2()
        {
            SqlConnections sqlconn = new SqlConnections();
            SqlDataAdapter da = new SqlDataAdapter("Select * from SemtMah  where ilceId='" + ilceid2 + "' Order By MahalleAdi", sqlconn.cs);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DropDFMahalle.DataSource = dt;
            DropDFMahalle.DataValueField = "SemtMahId";
            DropDFMahalle.DataTextField = "MahalleAdi";
            DropDFMahalle.DataBind();
        }
        //DropDKİlce DropDownList DEĞİŞTİĞİNDE MAH'I İLÇE ID YE GÖRE DEĞİŞTİRİR
        protected void DropDKİlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            ilceid = Convert.ToInt32(DropDKİlce.SelectedValue.ToString());
            MahGetir();
        }
        //DropDKSehir DropDownList DEĞİŞTİĞİNDE İLÇELERİ ŞEHİR ID YE GÖRE DEĞİŞTİRİR
        protected void DropDKSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            sehirid = Convert.ToInt32(DropDKSehir.SelectedValue.ToString());
            ilceid = Convert.ToInt32(DropDKİlce.SelectedValue.ToString());
            IlceGetir();
            MahGetir();
        }
        //DropDFSehir DropDownList DEĞİŞTİĞİNDE İLÇELERİ ŞEHİR ID YE GÖRE DEĞİŞTİRİR
        protected void DropDFSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            sehirid2 = Convert.ToInt32(DropDFSehir.SelectedValue.ToString());
            ilceid2 = Convert.ToInt32(DropDKİlce.SelectedValue.ToString());
            IlceGetir2();
            MahGetir2();
        }
        //DropDFİlce DropDownList DEĞİŞTİĞİNDE MAH'I İLÇE ID YE GÖRE DEĞİŞTİRİR
        protected void DropDFİlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            ilceid2 = Convert.ToInt32(DropDFİlce.SelectedValue.ToString());
            MahGetir2();
        }
        #endregion

        //MÜŞTERİLERİ VERİ TABANINA KAYDEDEN METHOD
        public void MusteriEkle()
        {
            SqlConnections con = new SqlConnections();
            con.con.Open();
            con.komut = new SqlCommand("spMusteriEkle", con.con);
            con.komut.CommandType = CommandType.StoredProcedure;
            con.komut.Parameters.AddWithValue("@ad", MusAd.Text);
            con.komut.Parameters.AddWithValue("@soyad", MusSoyad.Text);
            con.komut.Parameters.AddWithValue("@telefon", MusTelefon.Text);
            con.komut.Parameters.AddWithValue("@tc", MusTc.Text);
            con.komut.Parameters.AddWithValue("@olust", DateTime.Now);
            con.komut.Parameters.AddWithValue("@Aktif", 1);
            con.komut.ExecuteNonQuery();
            con.con.Close();
        }
        //MÜŞTERİ EKSTRA TABLOSUNA VERİ EKLEMEK İÇİN MÜŞTERİLER TABLOSUNA EKLENEN VERİNİN İD SİNİ ÇEKİYOR
        public void MusteriIDGetir()
        {
            SqlConnections sqlcon = new SqlConnections();
            string sql = "Select top 1 MusteriId from Musteriler order by MusteriId desc";
            SqlCommand cmd2 = new SqlCommand(sql, sqlcon.con);

            sqlcon.con.Open();
            SqlDataReader sonuc = cmd2.ExecuteReader();
            while (sonuc.Read())
            {
                TextBox1.Text = (sonuc["MusteriId"].ToString());

            }
            sqlcon.con.Close();
        }
        //MÜŞTERİ EKSTRA BİLGİLERİNİ MÜŞTERİEKSTRA TABLOSUNA EKLİYOR
        public void MusteriEkstraEkle()
        {
            SqlConnections con2 = new SqlConnections();
            con2.con.Open();
            con2.komut = new SqlCommand("spMusteriEkstraEkle", con2.con);
            con2.komut.CommandType = CommandType.StoredProcedure;
            con2.komut.Parameters.AddWithValue("@musid", Convert.ToInt32(TextBox1.Text));
            con2.komut.Parameters.AddWithValue("@mail", MusEmail.Text);
            con2.komut.Parameters.AddWithValue("@ksehir", Convert.ToInt32(DropDKSehir.SelectedValue.ToString()));
            con2.komut.Parameters.AddWithValue("@kilce", Convert.ToInt32(DropDKİlce.SelectedValue.ToString()));
            con2.komut.Parameters.AddWithValue("@kmahalle", Convert.ToInt32(DropDKMahalle.SelectedValue.ToString()));
            con2.komut.Parameters.AddWithValue("@fsehir", Convert.ToInt32(DropDFSehir.SelectedValue.ToString()));
            con2.komut.Parameters.AddWithValue("@filce", Convert.ToInt32(DropDFİlce.SelectedValue.ToString()));
            con2.komut.Parameters.AddWithValue("@fmahalle", Convert.ToInt32(DropDFMahalle.SelectedValue.ToString()));
            con2.komut.Parameters.AddWithValue("@fadres", FAdres.Text);
            con2.komut.Parameters.AddWithValue("@kadres", KAdres.Text);
            con2.komut.ExecuteNonQuery();
            con2.con.Close();
        }
        //MÜŞETRİ EKLE BUTONU ÇALIŞTIĞINDA
        protected void MusEkle_Click(object sender, EventArgs e)
        {
            try
            {
                //TEXTBOXLAR BOŞ GEÇİLEMEZ SORGUSU
                if (string.IsNullOrEmpty(MusEmail.Text) || string.IsNullOrWhiteSpace(MusEmail.Text)
                    && string.IsNullOrEmpty(MusAd.Text) || string.IsNullOrWhiteSpace(MusAd.Text)
                    && string.IsNullOrEmpty(MusSoyad.Text) || string.IsNullOrWhiteSpace(MusSoyad.Text)
                    && string.IsNullOrEmpty(MusTelefon.Text) || string.IsNullOrWhiteSpace(MusTelefon.Text)
                    && string.IsNullOrEmpty(MusTc.Text) || string.IsNullOrWhiteSpace(MusTc.Text)
                    && string.IsNullOrEmpty(KAdres.Text) || string.IsNullOrWhiteSpace(KAdres.Text)
                    && string.IsNullOrEmpty(FAdres.Text) || string.IsNullOrWhiteSpace(FAdres.Text))
                {
                    Response.Write("<script>alert('Boş Geçilemez')</script>");
                }
                else
                {
                    //TELEFON NO 11 HANEDEN KISA OLAMAZ SORGUSU
                    string tel = MusTelefon.Text;
                    if (tel.Length == 11)
                    {
                        //TC KİMLİK NO SORUGUSU
                        string tcKimlikNo = MusTc.Text;
                        bool returnvalue = false;
                        if (tel.Length == 11)
                        {
                            Int64 ATCNO, BTCNO, TcNo;
                            long C1, C2, C3, C4, C5, C6, C7, C8, C9, Q1, Q2;

                            TcNo = Int64.Parse(tcKimlikNo);

                            ATCNO = TcNo / 100;
                            BTCNO = TcNo / 100;

                            C1 = ATCNO % 10; ATCNO = ATCNO / 10;
                            C2 = ATCNO % 10; ATCNO = ATCNO / 10;
                            C3 = ATCNO % 10; ATCNO = ATCNO / 10;
                            C4 = ATCNO % 10; ATCNO = ATCNO / 10;
                            C5 = ATCNO % 10; ATCNO = ATCNO / 10;
                            C6 = ATCNO % 10; ATCNO = ATCNO / 10;
                            C7 = ATCNO % 10; ATCNO = ATCNO / 10;
                            C8 = ATCNO % 10; ATCNO = ATCNO / 10;
                            C9 = ATCNO % 10; ATCNO = ATCNO / 10;
                            Q1 = ((10 - ((((C1 + C3 + C5 + C7 + C9) * 3) + (C2 + C4 + C6 + C8)) % 10)) % 10);
                            Q2 = ((10 - (((((C2 + C4 + C6 + C8) + Q1) * 3) + (C1 + C3 + C5 + C7 + C9)) % 10)) % 10);

                            returnvalue = ((BTCNO * 100) + (Q1 * 10) + Q2 == TcNo);
                        }


                        if (returnvalue)
                        {
                            //TEK BUTTONDA KAYIT YAPTIĞIMIZ İÇİN SEÇİLEN MÜŞTERİNİN İD Sİ YOK İSE YENİ KAYIT EKLE SORUGUSU
                            if (string.IsNullOrEmpty(txtmusteriid.Text) || string.IsNullOrWhiteSpace(txtmusteriid.Text))
                            {
                                //DATABASEDE GİRİLEN TC DE KAYIT VAR MI SORGUSU
                                SqlConnections sqlcon = new SqlConnections();
                                string vs_Select = "SELECT * FROM Musteriler where ";
                                vs_Select += "MTC='" + MusTc.Text + "' and ";
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

                                    Page.Validate("ClickEvent");
                                    if (Page.IsValid)
                                    {
                                        MusteriEkle();
                                        MusteriIDGetir();
                                        MusteriEkstraEkle();

                                        RaporMethod();
                                        MusteriID();
                                        r.RaporEkle();
                                        r.id = 0;

                                        Response.Write("<script>alert('Müşteri Eklendi')</script>");
                                        MusteriGetir();
                                        TxtBoşalt();

                                    }
                                    else
                                    {
                                        Response.Write("<script>alert('Hatalı Giriş')</script>");
                                    }
                                }
                                sqlcon.con.Close();
                            }
                            //MÜŞTERİ İD TEXT BOŞ DEĞİL İSE VERİ GÜNCELLEME METHODU ÇALIŞTIRIR
                            else
                            {
                                Page.Validate("ClickEvent");
                                if (Page.IsValid)
                                {


                                    musteriid = Convert.ToInt32(txtmusteriid.Text);
                                    r.id = musteriid;
                                    RaporMethod();
                                    r.RaporGuncelle();
                                    r.id = 0;



                                    MusteriGuncelle();
                                    Response.Write("<script>alert('Müşteri Güncellendi')</script>");
                                    MusteriGetir();
                                    TxtBoşalt();
                                    txtmusteriid.Text = "";
                                }
                                else
                                {
                                    Response.Write("<script>alert('Hatalı Giriş')</script>");
                                }
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('TC HATALI')</script>");
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

                Response.Write("<script>alert('" + ex.ToString() + "')</sciprt>");
            }
            
        }
        //TEXTBOXLARI BOŞALTMA METHODU
        public void TxtBoşalt()
        {
            MusEmail.Text = "";
            MusAd.Text = "";
            MusSoyad.Text = "";
            MusTelefon.Text = "";
            MusTc.Text = "";
            KAdres.Text = "";
            FAdres.Text = "";
        }
        //MÜŞTERİLER TABLOSUNUN İÇİNİ DOLDURAN METHOD
        public void MusteriGetir()
        {
            SqlConnections sqlcon = new SqlConnections();
            SqlConnection con = new SqlConnection(sqlcon.cs);
            SqlCommand cmd = new SqlCommand("spMusteriGetir", con);
            con.Open();
            rptMusteri.DataSource = cmd.ExecuteReader();
            rptMusteri.DataBind();
            con.Close();
        }
        //TABLODA TIKLANAN SATIRIN MÜŞTERİ IDSINE GÖRE MÜŞTERİNİN VERİLERİNİ 2 TABLODAN ÇEKEREK TEXTBOXLARA VE DROPDOWNLISTLERE YAZDIRIYOR

        #region MüşteriVerileriniTextBoxsaDoldurur
        protected void bntGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                musteriid = int.Parse(((sender as LinkButton).NamingContainer.FindControl("txtmusteriid") as Label).Text);
                MusteriYaz();
                MusteriEkstraYaz();
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.ToString() + "')</script>");
            }
            
        }
        //TABLODA SEÇİLEN VERİNİN EKLENME TARİHİNİ RAPOR CLASSINA GÖNDERİR
        public void SecilenRaporEklenmeTarih()
        {
            DateTime eklenmetarih = DateTime.Now;
            SqlConnections sqlcon = new SqlConnections();
            string sql = "select * from Musteriler where MusteriID='" + musteriid + "'";
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
        //MÜŞTERİ TABLOSUNDAN GELEN btnGuncelle TIKLANDIĞINDA GELEN ID'YE GÖRE VERİLERİ YAZDIRIR
        public void MusteriYaz()
        {
            SqlConnections sqlcon = new SqlConnections();
            string sql = "select * from Musteriler where MusteriID=@MusteriID";
            SqlCommand cmd = new SqlCommand(sql, sqlcon.con);
            cmd.Parameters.AddWithValue("@MusteriID", musteriid);
            sqlcon.con.Open();
            SqlDataReader sonuc = cmd.ExecuteReader();
            while (sonuc.Read())
            {
                txtmusteriid.Text = musteriid.ToString();
                MusAd.Text = sonuc["MAd"].ToString();
                MusSoyad.Text = sonuc["MSoyad"].ToString();
                MusTelefon.Text = sonuc["MTelefon"].ToString();
                MusTc.Text = sonuc["MTC"].ToString();

            }
            sqlcon.con.Close();
        }
        //MÜŞTERİEKSTRA TABLOSUNDAN GELEN btnGuncelle TIKLANDIĞINDA GELEN ID'YE GÖRE VERİLERİ YAZDIRIR
        int mahid, mahid2;
        public void MusteriEkstraYaz()
        {
            SqlConnections sqlcon = new SqlConnections();
            string sql = "select * from MusteriEkstra where MusteriID=@MusteriID";
            SqlCommand cmd = new SqlCommand(sql, sqlcon.con);
            cmd.Parameters.AddWithValue("@MusteriID", musteriid);
            sqlcon.con.Open();
            SqlDataReader sonuc = cmd.ExecuteReader();
            while (sonuc.Read())
            {
                MusEmail.Text = sonuc["Mail"].ToString();
                sehirid2 = Convert.ToInt32(sonuc["SehirId"].ToString());
                ilceid2 = Convert.ToInt32(sonuc["ilceId"].ToString());
                mahid2 = Convert.ToInt32(sonuc["SemtMahId"].ToString());
                KAdres.Text = sonuc["KargoAdresD"].ToString();
                sehirid = Convert.ToInt32(sonuc["FSehirId"].ToString());
                ilceid = Convert.ToInt32(sonuc["FilceId"].ToString());
                mahid = Convert.ToInt32(sonuc["FSemtMahId"].ToString());
                FAdres.Text = sonuc["FaturaAdresD"].ToString();
            }
            sqlcon.con.Close();
            DropDKSehir.SelectedValue = sehirid.ToString();
            IlceGetir();
            DropDKİlce.SelectedValue = ilceid.ToString();
            MahGetir();
            DropDKMahalle.SelectedValue = mahid.ToString();
            IlceGetir2();
            MahGetir2();
            DropDFSehir.SelectedValue = sehirid2.ToString();
            DropDFİlce.SelectedValue = ilceid2.ToString();
            DropDFMahalle.SelectedValue = mahid2.ToString();
        }
        #endregion

        protected void MusTc_TextChanged(object sender, EventArgs e)
        {


        }
        //MÜŞTERİNİN AKTİFLİĞİNİ 0 A ÇEVİREREK SİLİNMİŞ GİBİ GÖSTERİR
        public void MusteriSil()
        {
            SqlConnections sqlcon = new SqlConnections();
            DataTable tablo = new DataTable();
            sqlcon.con.Open();
            sqlcon.komut = new SqlCommand("spMusteriSil", sqlcon.con);
            sqlcon.komut.CommandType = CommandType.StoredProcedure;
            sqlcon.komut.Parameters.AddWithValue("@MusteriID", musteriid);
            sqlcon.komut.Parameters.AddWithValue("@Aktif", 0);
            sqlcon.komut.Parameters.AddWithValue("@SilinmeTarih", DateTime.Now);

            sqlcon.komut.ExecuteNonQuery();
            sqlcon.con.Close();
        }
        //MÜŞTERİ SİL BUTTONU MÜŞTERİ SİL VE RAPOR METHODLARINI ÇALIŞTIRIR
        protected void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                musteriid = int.Parse(((sender as LinkButton).NamingContainer.FindControl("txtmusteriid") as Label).Text);
                r.id = musteriid;
                RaporMethod();
                MusteriSil();
                r.RaporSil();
                r.id = 0;
                MusteriGetir();
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.ToString() + "')</sciprt>");
            }        
        }
        //MÜŞTERİ GÜNCELLE METHODU
        public void MusteriGuncelle()
        {
            SqlConnections sqlcon = new SqlConnections();
            DataTable tablo = new DataTable();
            sqlcon.con.Open();
            sqlcon.komut = new SqlCommand("spMusteriGuncelle", sqlcon.con);
            sqlcon.komut.CommandType = CommandType.StoredProcedure;
            sqlcon.komut.Parameters.AddWithValue("@MusteriID", Convert.ToInt32(txtmusteriid.Text));
            sqlcon.komut.Parameters.AddWithValue("@MAd", MusAd.Text);
            sqlcon.komut.Parameters.AddWithValue("@MSoyad", MusSoyad.Text);
            sqlcon.komut.Parameters.AddWithValue("@MTelefon", MusTelefon.Text);
            sqlcon.komut.Parameters.AddWithValue("@Mail", MusEmail.Text);
            sqlcon.komut.Parameters.AddWithValue("@MTC", MusTc.Text);
            sqlcon.komut.Parameters.AddWithValue("@GuncellemeTarih", DateTime.Now);
            sqlcon.komut.Parameters.AddWithValue("@SehirId", Convert.ToInt32(DropDKSehir.SelectedValue));
            sqlcon.komut.Parameters.AddWithValue("@ilceId", Convert.ToInt32(DropDKİlce.SelectedValue));
            sqlcon.komut.Parameters.AddWithValue("@SemtMahId", Convert.ToInt32(DropDKMahalle.SelectedValue));
            sqlcon.komut.Parameters.AddWithValue("@FSehirId", Convert.ToInt32(DropDFSehir.SelectedValue));
            sqlcon.komut.Parameters.AddWithValue("@FilceId", Convert.ToInt32(DropDFİlce.SelectedValue));
            sqlcon.komut.Parameters.AddWithValue("@FSemtMahId", Convert.ToInt32(DropDFMahalle.SelectedValue));
            sqlcon.komut.Parameters.AddWithValue("@KargoAdresD", KAdres.Text);
            sqlcon.komut.Parameters.AddWithValue("@FaturaAdresD", FAdres.Text);
            sqlcon.komut.ExecuteNonQuery();
            sqlcon.con.Close();
        }
    }
}