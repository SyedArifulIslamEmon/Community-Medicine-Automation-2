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
    public partial class MedicineEntryUI : System.Web.UI.Page
    {

        HeadOfficeManager aHeadOfficeManager = new HeadOfficeManager();
        Medicine aMedicine = new Medicine();
        List<Medicine> MedicineList = new List<Medicine>();
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {

            LoadDataGridView();

        }

        protected void SaveMedicineButton_Click(object sender, EventArgs e)
        {
            aMedicine.MedicineName = medicineNameCreateTextBox.Text;

            if (medicineNameCreateTextBox.Text == null || (aHeadOfficeManager.IsMedicineExist(aMedicine.MedicineName) == true))
            {
                string script = "alert(\" This Medicine is Exist!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                    "ServerControlScript", script, true);
            }
            else
            {

                if (aHeadOfficeManager.SaveMedicine(aMedicine) == 1)
                {

                    saveSuccessResult.Text = "Saved Successfully";
                    Response.Redirect("MedicineEntryUI.aspx");
                }

            }
        }

        public void LoadDataGridView()
        {
            MedicineList = aHeadOfficeManager.GetMedicineList();

            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("Serial No", typeof(string));
                dt.Columns.Add("Medicine Name", typeof(string));

            }
            int count = 1;
            foreach (var Medicine in MedicineList)
            {




                DataRow NewRow = dt.NewRow();
                NewRow[0] = count.ToString();

                NewRow[1] = Medicine.MedicineName;
                dt.Rows.Add(NewRow);
                count++;





            }
            MedicineGridView.DataSource = dt;
            MedicineGridView.DataBind();


        }

        protected void MedicineGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            MedicineGridView.PageIndex = e.NewPageIndex;
            MedicineGridView.DataSource = dt;
            MedicineGridView.DataBind();
        }
    }
}