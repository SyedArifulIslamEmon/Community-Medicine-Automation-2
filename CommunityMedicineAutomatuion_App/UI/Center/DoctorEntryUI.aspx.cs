using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicineAutomatuion_App.BLL;
using CommunityMedicineAutomatuion_App.DAL.DAO;

namespace CommunityMedicineAutomatuion_App.UI.Center
{
    public partial class DoctorEntryUI : System.Web.UI.Page
    {
        CenterManager aCenterManager = new CenterManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now);

        }
        protected void saveDoctorButton_Click(object sender, EventArgs e)
        {
            Doctor newDoctor = new Doctor();
            DAL.DAO.Center newCenter = (DAL.DAO.Center)Session["CenterInfoDetails"];
            newDoctor.CenterID = newCenter.ID;
            newDoctor.Name = nameOfDoctorTextBox.Text;
            newDoctor.Degree = degreeOfDoctorTextBox.Text;
            newDoctor.Specialization = specializationOfDoctorTextBox.Text;
            if (aCenterManager.SaveDoctorInfo(newDoctor) == true)
            {

                labelNotification.Text = "Doctor Information Saved Successfully";
                labelNotification.ForeColor = Color.Green;
                nameOfDoctorTextBox.Text = degreeOfDoctorTextBox.Text = specializationOfDoctorTextBox.Text = null;
            }
            else
            {
                labelNotification.Text = "Doctor Information can't save";
                labelNotification.ForeColor = Color.Red;

            }


        }
    }
}