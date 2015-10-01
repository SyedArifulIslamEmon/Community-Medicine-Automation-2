using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicineAutomatuion_App.BLL;

namespace CommunityMedicineAutomatuion_App
{
    public partial class CenterLoginUI : System.Web.UI.Page
    {
        CenterManager aCenterManager=new CenterManager();
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Global.asax");
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            DAL.DAO.Center centerInfo = new DAL.DAO.Center();
            if (aCenterManager.CenterInfoCheck(codeTextBox.Text, passwordTextBox.Text, out centerInfo))
            {
                Session["CenterInfoDetails"] = centerInfo;
                FormsAuthentication.RedirectFromLoginPage(codeTextBox.Text, true);

            }
            else
            {
                labelAuthentication.Text = "Invalid User Name and password";
            }
        }
    }
}