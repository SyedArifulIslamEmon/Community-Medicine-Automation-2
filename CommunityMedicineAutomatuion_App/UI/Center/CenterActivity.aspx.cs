using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CommunityMedicineAutomatuion_App.UI.Center
{
    public partial class CenterActivity : System.Web.UI.Page
    {
        DAL.DAO.Center newCenter = new DAL.DAO.Center();
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now);
            if (Session["CenterInfoDetails"] != null)
            {
                
                newCenter = (DAL.DAO.Center) Session["CenterInfoDetails"];
                centerName.Text = newCenter.Name;
            }
            else
            {
                Response.Redirect("~/CenterLoginUI.aspx");
            }
            
        }
    }
}