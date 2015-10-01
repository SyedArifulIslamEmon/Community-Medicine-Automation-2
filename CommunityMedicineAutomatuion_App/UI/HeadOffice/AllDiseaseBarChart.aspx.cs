using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using CommunityMedicineAutomatuion_App.BLL;
using CommunityMedicineAutomatuion_App.DAL.DAO;

namespace CommunityMedicineAutomatuion_App.UI.HeadOffice
{
    public partial class AllDiseaseBarChart : System.Web.UI.Page
    {
        CenterManager aCenterManager=new CenterManager();
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            LoadDistrictDropDownList();
           
                
               
            
        }

        
        public void LoadDistrictDropDownList()
        {
            districtDropDownList.DataSource = aCenterManager.GetAllDistricts();
            districtDropDownList.DataTextField = "Name";
            districtDropDownList.DataValueField = "ID";
            districtDropDownList.DataBind();
        }

        protected void showButton_Click(object sender, EventArgs e)
        {
            string startDate = FromCalendar.SelectedDate.ToString("d");
            string endDate = ToCalendar.SelectedDate.ToString("d");
            District newDistrict= new District();
            newDistrict.ID = int.Parse(districtDropDownList.SelectedItem.Value);
            List<Patient> newPatient = aCenterManager.GetPatientList(startDate, endDate, newDistrict);
            diseaseReportChart.DataSource = newPatient;
            diseaseReportChart.DataBind();
         
        }



    }
}