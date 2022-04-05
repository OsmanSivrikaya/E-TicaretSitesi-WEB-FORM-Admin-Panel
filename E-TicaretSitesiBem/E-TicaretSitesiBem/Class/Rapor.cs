using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace E_TicaretSitesiBem.Class
{
    public class Rapor
    {
        public int adminid { get; set; }
        public string adminad { get; set; }
        public DateTime et;
        public int tabloid { get; set; }
        public int id { get; set; }
        //ADMIN KULLANICI ADINA GÖRE ID SİNİ ALIR
        public int AdminIDGetir(string sens)
        {          
            SqlConnections sqlcon = new SqlConnections();
            string sql = "Select * from Admin where AKullaniciAd='" + sens + "'";
            SqlCommand cmd2 = new SqlCommand(sql, sqlcon.con);

            sqlcon.con.Open();
            SqlDataReader sonuc = cmd2.ExecuteReader();
            while (sonuc.Read())
            {
                adminid = Convert.ToInt32(sonuc["AdminID"].ToString());
            }
            sqlcon.con.Close();
            return adminid;
        }  
        //GELEN VERİLERİ RAPOR TABLOSUNA EKLER
        public void RaporEkle()
        {
            SqlConnections con = new SqlConnections();
            con.con.Open();
            con.komut = new SqlCommand("spRaporEkle", con.con);
            con.komut.CommandType = CommandType.StoredProcedure;
            con.komut.Parameters.AddWithValue("@AdminID", adminid);
            con.komut.Parameters.AddWithValue("@ID", id);
            con.komut.Parameters.AddWithValue("@EklenmeTarihi", DateTime.Now);
            con.komut.Parameters.AddWithValue("@TabloID", tabloid);
            con.komut.ExecuteNonQuery();
            con.con.Close();
        }
        //GELEN VERİLERİ RAPOR TABLOSUNA EKLER
        public void RaporSil()
        {
            SqlConnections con = new SqlConnections();
            con.con.Open();
            con.komut = new SqlCommand("spSilRapor", con.con);
            con.komut.CommandType = CommandType.StoredProcedure;
            con.komut.Parameters.AddWithValue("@AdminID", adminid);
            con.komut.Parameters.AddWithValue("@EklenmeTarihi", et);
            con.komut.Parameters.AddWithValue("@id", id);
            con.komut.Parameters.AddWithValue("@SilinmeTarihi", DateTime.Now);
            con.komut.Parameters.AddWithValue("@TabloID", tabloid);
            con.komut.ExecuteNonQuery();
            con.con.Close();
        }
        //GELEN VERİLERİ RAPOR TABLOSUNA EKLER
        public void RaporGuncelle()
        {
            SqlConnections con = new SqlConnections();
            con.con.Open();
            con.komut = new SqlCommand("spGuncelleRapor", con.con);
            con.komut.CommandType = CommandType.StoredProcedure;
            con.komut.Parameters.AddWithValue("@AdminID", adminid);
            con.komut.Parameters.AddWithValue("@EklenmeTarihi", et);
            con.komut.Parameters.AddWithValue("@ID", id);
            con.komut.Parameters.AddWithValue("@GuncelleTarihi", DateTime.Now);
            con.komut.Parameters.AddWithValue("@TabloID", tabloid);
            con.komut.ExecuteNonQuery();
            con.con.Close();
        }
    }
}