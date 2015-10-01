using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CommunityMedicineAutomatuion_App
{
    public partial class HeadOffice : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/index.aspx");
        }
        protected void SelectHead_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/HeadOffice/HeadOfficeActivity.aspx");
        }
       
    }
}