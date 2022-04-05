using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Text;
using E_TicaretSitesiBem.View;
using E_TicaretSitesiBem.Class;

namespace E_TicaretSitesiBem.Class
{
    public class FaControl
    {

        static MailMessage mail;
        SmtpClient smtp;
        static Random rnd = new Random();
        static string onaykodu;

        public string dkod(string kmail )
        {
            onaykodu = (rnd.Next(1000, 9999)).ToString();



            string from = "eticaret.prj@gmail.com"; //From address
            MailMessage message = new MailMessage(from, kmail);

           

            string mailbody = "Doğrulama Kodunuz : " + onaykodu; ;
            message.Subject = "Doğrulama Kodu";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp
            NetworkCredential basicCredential1 = new
            NetworkCredential("eticaret.prj@gmail.com", "Eticaret123");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return onaykodu;





        }


    }
}