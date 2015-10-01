using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicineAutomatuion_App.BLL;
using CommunityMedicineAutomatuion_App.DAL.DAO;

namespace CommunityMedicineAutomatuion_App.UI.HeadOffice
{
    public partial class SendMedicineUI : System.Web.UI.Page
    {
        CenterManager aCenterManager = new CenterManager();
        HeadOfficeManager aHeadOfficeManager = new HeadOfficeManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDistrictDropDownList();
                LoadThanaDropDownList();
                LoadCenterDropDownList();
                LoadMedicineDropDownList();
                LoadMedicineGridView();
            }
            if (Session["NotificationMedicineList"] != null)
            {
                notificationText.Text = (string)Session["NotificationMedicineList"];
                notificationText.ForeColor = Color.Green;
                Session["NotificationMedicineList"] = null;
            }

        }

        protected void districtMedicineDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadThanaDropDownList();
            LoadCenterDropDownList();
        }

        protected void thanaMedicineDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCenterDropDownList();

        }


        public void LoadDistrictDropDownList()
        {
            districtMedicineDropDownList.DataSource = aCenterManager.GetAllDistricts();
            districtMedicineDropDownList.DataTextField = "Name";
            districtMedicineDropDownList.DataValueField = "ID";
            districtMedicineDropDownList.DataBind();
        }

        public void LoadThanaDropDownList()
        {
            thanaMedicineDropDownList.DataSource =
           aHeadOfficeManager.GeThanaByDistrictId(int.Parse(districtMedicineDropDownList.SelectedItem.Value));
            thanaMedicineDropDownList.DataTextField = "Name";
            thanaMedicineDropDownList.DataValueField = "ID";
            thanaMedicineDropDownList.DataBind();
        }

        public void LoadCenterDropDownList()
        {
            centerDropDownList.DataSource = aHeadOfficeManager.GetCenterByThanaID(int.Parse(thanaMedicineDropDownList.SelectedItem.Value));
            centerDropDownList.DataTextField = "Name";
            centerDropDownList.DataValueField = "ID";
            centerDropDownList.DataBind();
        }

        public void LoadMedicineDropDownList()
        {
            medicineDropDownList.DataSource = aHeadOfficeManager.GetAllMedicines();
            medicineDropDownList.DataTextField = "MedicineName";
            medicineDropDownList.DataValueField = "ID";
            medicineDropDownList.DataBind();
            medicineAddNotification.Text = null;
        }


        private void LoadMedicineGridView()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("slNo", typeof(string)));
            dt.Columns.Add(new DataColumn("medicineName", typeof(string)));
            dt.Columns.Add(new DataColumn("quantity", typeof(string)));
            dr = dt.NewRow();
            dr["slNo"] = string.Empty;
            dr["medicineName"] = string.Empty;
            dr["quantity"] = string.Empty;
            dt.Rows.Add(dr);
            ViewState["CurrentTable"] = dt;
            medicineListGridView.DataSource = dt;
            medicineListGridView.DataBind();
            ViewState["SerialNo"] = 0;
            List<CenterMedicineStock> newStockList = new List<CenterMedicineStock>();
            ViewState["MedicineStock"] = newStockList;




        }

        protected void addMedicineToSendButton_Click(object sender, EventArgs e)
        {
            int medicineId = int.Parse(medicineDropDownList.SelectedItem.Value);
            int quantity = int.Parse(quantityMedicineTextBox.Text);

            if (CheckMedicineStock(medicineId, quantity) == false)
            {
                bool exist = false;
                AddMedicineToDataGrid(exist);
                medicineAddNotification.Text = "Added Successfully";
                medicineAddNotification.ForeColor = Color.Green;

            }
            else
            {
                bool exist = true;
                AddMedicineToDataGrid(exist);
                medicineAddNotification.Text = "Added quantity to existing medicine";
                medicineAddNotification.ForeColor = Color.Green;
            }
        }

        private void AddMedicineToDataGrid(bool exist)
        {
            if (!exist)
                StockSave();
            DataTable currentTable = (DataTable)ViewState["CurrentTable"];

            int i = (int)ViewState["SerialNo"];
            DataRow dr = currentTable.NewRow();
            dr["slNo"] = (++i).ToString();
            dr["medicineName"] = medicineDropDownList.SelectedItem.Text;
            dr["quantity"] = quantityMedicineTextBox.Text;
            currentTable.Rows.Add(dr);
            ViewState["CurrentTable"] = currentTable;
            ViewState["SerialNo"] = i;
            medicineListGridView.DataSource = currentTable;
            medicineListGridView.DataBind();


        }

        private bool CheckMedicineStock(int id, int quantity)
        {
            List<CenterMedicineStock> medicineStocks = (List<CenterMedicineStock>)ViewState["MedicineStock"];
            bool result = false;
            foreach (CenterMedicineStock medicine in medicineStocks)
            {
                if (medicine.MedicineID == id)
                {
                    medicine.Quantity += quantity;
                    result = true;
                    break;
                }
            }
            return result;

        }
        private void StockSave()
        {
            List<CenterMedicineStock> currentStocks = (List<CenterMedicineStock>)ViewState["MedicineStock"];
            CenterMedicineStock newMedicineStock = new CenterMedicineStock();
            newMedicineStock.MedicineID = int.Parse(medicineDropDownList.SelectedItem.Value);
            newMedicineStock.Quantity = int.Parse(quantityMedicineTextBox.Text);
            newMedicineStock.CenterID = int.Parse(centerDropDownList.SelectedItem.Value);
            currentStocks.Add(newMedicineStock);
            ViewState["MedicineStock"] = currentStocks;
        }

        protected void resetButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            List<CenterMedicineStock> newCenterMedicineStocks = (List<CenterMedicineStock>)ViewState["MedicineStock"];
            if (aHeadOfficeManager.CenterMedicineSend(newCenterMedicineStocks))
            {

                Session["NotificationMedicineList"] = "Medicine stocks saved to center";

                Response.Redirect("SendMedicineUI.aspx");
            }
            else
            {
                notificationText.Text = "Medicine stocks can't save to center";
                notificationText.ForeColor = Color.Red;
            }
        }

      
    }
}