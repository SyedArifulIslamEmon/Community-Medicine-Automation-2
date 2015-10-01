using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicineAutomatuion_App.BLL;
using CommunityMedicineAutomatuion_App.DAL.DAO;

namespace CommunityMedicineAutomatuion_App.UI.HeadOffice
{
    public partial class CreateDiseaseEntryUI : System.Web.UI.Page
    {
        HeadOfficeManager aHeadOfficeManager = new HeadOfficeManager();
        Disease aDisease = new Disease();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDiseaseGridView();
        }

        protected void saveDiseaseButton_Click(object sender, EventArgs e)
        {
            aDisease.Name = nameTextBox.Text;
            aDisease.Description = descriptionTextBox.Text;
            aDisease.Treatment = treatmentProcedureTextBox.Text;
            if (aHeadOfficeManager.IsDiseaseExist(aDisease.Name) == true)
            {
                string script = "alert(\" This Disease is already Exist!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                    "ServerControlScript", script, true);
            }
            else
            {

                if (aHeadOfficeManager.SaveDisease(aDisease) == 1)
                {
                    notificationText.Text = "Disease Save Successfully.";
                }
            }

            nameTextBox.Text = descriptionTextBox.Text = treatmentProcedureTextBox.Text = "";

        }

        public List<Disease> GetDiseasesList = new List<Disease>();

        public void LoadDiseaseGridView()
        {
            GetDiseasesList = aHeadOfficeManager.GetDiseasesList();



            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("Serial No", typeof(string));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Description", typeof(string));
                dt.Columns.Add("Treatment", typeof(string));
            }

            int count = 1;
            foreach (var disease in GetDiseasesList)
            {
                DataRow NewRow = dt.NewRow();
                NewRow[0] = count.ToString();

                NewRow[1] = disease.Name;
                NewRow[2] = disease.Description;
                NewRow[3] = disease.Treatment;
                dt.Rows.Add(NewRow);
                count++;


            }
            DiseaseGridView.DataSource = dt;
            DiseaseGridView.DataBind();

        }

        protected void DiseaseGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DiseaseGridView.PageIndex = e.NewPageIndex;
            DiseaseGridView.DataSource = dt;
            DiseaseGridView.DataBind();

        }
    }
}