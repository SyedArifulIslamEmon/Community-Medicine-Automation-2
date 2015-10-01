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
    public partial class CreateNewCenterUI : System.Web.UI.Page
    {
        CenterManager aCenterManager = new CenterManager();
        HeadOfficeManager aHeadOfficeManager = new HeadOfficeManager();
        DAL.DAO.Center aCenter = new DAL.DAO.Center();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDistrictDropDownList();
                LoadThanaDropDownList();
            }



        }

        protected void createCenterSaveButton_Click(object sender, EventArgs e)
        {
            aCenter.Name = aCenter.Code = aCenter.Password = createCenterNameTextBox.Text;
            aCenter.ThanaID = int.Parse(createCentreThanaDropDownList.SelectedItem.Value);
            aCenter.Code = aCenter.Name + "-0" + aCenter.ThanaID.ToString() + "-0" +
                           Convert.ToString(createCenterDistrictDropDownList.SelectedItem.Value);

            string password;
            if (aHeadOfficeManager.SaveCenter(aCenter, out password) == 1)
            {
                Session["CenterCode"] = aCenter.Code;
                Session["ThanaName"] = Convert.ToString(createCentreThanaDropDownList.SelectedItem.Text);
                Session["DistrictName"] = Convert.ToString(createCenterDistrictDropDownList.SelectedItem.Text);
                Session["Password"] = password;
                Session["CenterName"] = aCenter.Name;
                Response.Redirect("Center Information Saved.aspx");

            }
            else
            {
                labelNotification.Text = "Center name is already exist";
                labelNotification.ForeColor = Color.Red;
            }


        }

        protected void createCenterDistrictDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadThanaDropDownList();

        }

        protected void createCentreThanaDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void LoadDistrictDropDownList()
        {
            createCenterDistrictDropDownList.DataSource = aCenterManager.GetAllDistricts();
            createCenterDistrictDropDownList.DataTextField = "Name";
            createCenterDistrictDropDownList.DataValueField = "ID";
            createCenterDistrictDropDownList.DataBind();
        }

        public void LoadThanaDropDownList()
        {
            createCentreThanaDropDownList.DataSource =
           aHeadOfficeManager.GeThanaByDistrictId(int.Parse(createCenterDistrictDropDownList.SelectedItem.Value));
            createCentreThanaDropDownList.DataTextField = "Name";
            createCentreThanaDropDownList.DataValueField = "ID";
            createCentreThanaDropDownList.DataBind();
        }
    }
}