using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicineAutomatuion_App.BLL;

namespace CommunityMedicineAutomatuion_App.UI.HeadOffice
{
    public partial class Center_Information_Saved : System.Web.UI.Page
    {
        HeadOfficeManager newHeadOfficeManager = new HeadOfficeManager();
        DAL.DAO.Center newCenter = new DAL.DAO.Center();
        protected void Page_Load(object sender, EventArgs e)
        {
            Code.Text = (string)Session["CenterCode"];
            Code.ForeColor = Color.Green;
            Password.Text = (string)Session["Password"];
            Password.ForeColor = Color.Green;
            DistrictName.Text = (string)Session["DistrictName"];
            CenterName.Text = (string)Session["CenterName"];
            ThanaName.Text = (string)Session["ThanaName"];

        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateNewCenterUI.aspx");
        }
    }
}