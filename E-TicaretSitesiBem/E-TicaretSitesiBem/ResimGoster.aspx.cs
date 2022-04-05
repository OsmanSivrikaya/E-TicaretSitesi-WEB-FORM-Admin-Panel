using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using E_TicaretSitesiBem.Class;

namespace E_TicaretSitesiBem
{
    public partial class ResimGoster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //object admink = Session["adminadi"];
                //if (admink == null)
                //{
                //    Response.Redirect("Admin.aspx");
                //}
                //else
                //{
                    FotoGoster();
                //}
            }
        }
        private void FotoGoster()
        {



            List<MyImages> myImages = new List<MyImages>();
            DirectoryInfo DI = new DirectoryInfo(Server.MapPath("~/Upload"));
            foreach (var file in DI.GetFiles())
            {
                myImages.Add(new MyImages { FileName = file.Name });
            }
            Repeater1.DataSource = myImages;
            Repeater1.DataBind();
        }
    }
}