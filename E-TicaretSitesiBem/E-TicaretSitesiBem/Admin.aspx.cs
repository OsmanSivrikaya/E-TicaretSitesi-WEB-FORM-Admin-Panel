using Google.Authenticator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using E_TicaretSitesiBem.Class;
using E_TicaretSitesiBem.View;

namespace E_TicaretSitesiBem.View
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
            //    lblResult.Text = String.Empty;
            //    lblResult.Visible = false;
            //    GenerateTwoFactorAuthentication();
            //    imgQrCode.ImageUrl = AuthenticationBarCodeImage;
            //    lblManualSetupCode.Text = AuthenticationManualCode;
            //    lblAccountName.Text = AuthenticationTitle;
            //}
        }
       
        static int kod;
  
        protected void btnGiris_Click1(object sender, EventArgs e)
        {
            //FA CONTROL CLASS INI ÇEKİYORUZ
            //GİRİLEN TEXTBOX BİLGİLERİNİ DATABASE İLE KARŞILAŞTIRIP GİRİŞ SORGUSUNU YAPIYORUZ
            FaControl kontrol = new FaControl();
            SqlConnections scon = new SqlConnections();
            SqlCommand sorgula = new SqlCommand("SELECT AKullaniciAd,ASifre,AdminMail FROM Admin WHERE AKullaniciAd=@KullaniciAdi AND ASifre=@Sifre AND AdminMail=@Email", scon.con);
            sorgula.Parameters.AddWithValue("@KullaniciAdi", txtKulAd.Text.ToString()); 
            sorgula.Parameters.AddWithValue("@Sifre", txtKsifre.Text.ToString());
            sorgula.Parameters.AddWithValue("@Email", txtKmail.Text.ToString());
            scon.con.Open();
            SqlDataReader oku = sorgula.ExecuteReader();
            if (oku.Read())
            {
                //EĞER DOĞRU İSE GİRİLEN BİLGİLER MAİLE KOD GÖNDERİLİYOR VE ONAY KODU GİRİLEN TEXTBOX AKTİF HALE GETİRİLİYOR
                kod = Convert.ToInt32(kontrol.dkod(txtKmail.Text));
                txtKmail.Enabled = false;
                txtKsifre.Enabled = false;
                txtKsifre.Visible = true;
                txtKulAd.Enabled = false;
                txtkod.Visible = true;
                btnGirisKod.Visible = true;
                btnGiris.Visible = false;



                
            }
            else
            { 
                Response.Write("<script>alert('Email/Şifre/Kullanıcı Adı hatalı tekrar deneyiniz...')</script>"); 
            }

            oku.Close();
            scon.con.Close();
        }

        protected void btnGirisKod_Click(object sender, EventArgs e)
        {
            FaControl kontrol = new FaControl();


            //String pin = txtkod.Text.Trim();
            //Boolean status = ValidateTwoFactorPIN(pin);
            //if (status)
            //{
            //    Response.Redirect("Default.aspx");
            //    lblResult.Visible = true;
            //    lblResult.Text = "Code Successfully Verified.";

            //}
            //else
            //{
            //    lblResult.Visible = true;
            //    lblResult.Text = "Invalid Code.";
            //}

            Page.Validate("OnayClck");
            if (Page.IsValid)
            {

                int txtkod1 = Convert.ToInt32(txtkod.Text);
                if (txtkod1 == kod)
                {
                    Session.Timeout = 15;
                    Session.Add("adminadi", txtKulAd.Text);
                    Response.Redirect("Default.aspx");
                }
                else { Response.Write("<script>alert('Kod hatalı')</script>"); }



            }
            else
            {
                Response.Write("<script>alert('Giriş başarısız')</script>");
            }
        }
        //String AuthenticationCode
        //{
        //    get
        //    {
        //        if (ViewState["AuthenticationCode"] != null)
        //            return ViewState["AuthenticationCode"].ToString().Trim();
        //        return String.Empty;
        //    }
        //    set
        //    {
        //        ViewState["AuthenticationCode"] = value.Trim();
        //    }
        //}

        //String AuthenticationTitle
        //{
        //    get
        //    {
        //        return "E-TICARET";
        //    }
        //}


        //String AuthenticationBarCodeImage
        //{
        //    get;
        //    set;
        //}

        //String AuthenticationManualCode
        //{
        //    get;
        //    set;
        //}

        
       

        //public Boolean ValidateTwoFactorPIN(String pin)
        //{
        //    TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
        //    return tfa.ValidateTwoFactorPIN(AuthenticationCode, pin);
        //}

        //public Boolean GenerateTwoFactorAuthentication()
        //{
        //    Guid guid = Guid.NewGuid();
        //    String uniqueUserKey = Convert.ToString(guid).Replace("-", "").Substring(0, 10);
        //    AuthenticationCode = uniqueUserKey;

        //    Dictionary<String, String> result = new Dictionary<String, String>();
        //    TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
        //    var setupInfo = tfa.GenerateSetupCode("Complio", AuthenticationTitle, AuthenticationCode, 300, 300);
        //    if (setupInfo != null)
        //    {
        //        AuthenticationBarCodeImage = setupInfo.QrCodeSetupImageUrl;
        //        AuthenticationManualCode = setupInfo.ManualEntryKey;
        //        return true;
        //    }
        //    return false;
        //}
    }
}