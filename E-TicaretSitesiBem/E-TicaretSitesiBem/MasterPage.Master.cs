using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_TicaretSitesiBem
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    object admink = Session["adminadi"];
            //    if (admink == null)
            //    {
            //        Response.Redirect("Admin.aspx");
            //    }
            //    else { lblAdminAd.Text = admink.ToString(); }
            //}
        }

        protected void btnCikis_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Admin.aspx");
        }
    }
}
