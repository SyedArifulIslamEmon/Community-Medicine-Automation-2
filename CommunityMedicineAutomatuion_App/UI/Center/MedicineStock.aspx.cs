using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicineAutomatuion_App.BLL;
using CommunityMedicineAutomatuion_App.DAL.DAO;

namespace CommunityMedicineAutomatuion_App.UI.Center
{
    public partial class MedicineStock : System.Web.UI.Page
    {
        CenterManager aCenterManager = new CenterManager();
        DAL.DAO.Center aCenter = new DAL.DAO.Center();
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now);
            aCenter = (DAL.DAO.Center)Session["CenterInfoDetails"];
            centerName.Text = aCenter.Name;
            List<CenterMedicineStock> medicinStockList = aCenterManager.GetStock(aCenter);
            LoadDataGridView(medicinStockList);

        }

        public void LoadDataGridView(List<CenterMedicineStock> stocks)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("MedicineName", typeof(string));
            dt.Columns.Add("Quantity", typeof(string));


            foreach (CenterMedicineStock medicine in stocks)
            {
                DataRow newRow = dt.NewRow();
                newRow[0] = medicine.MedicineName;
                newRow[1] = medicine.Quantity.ToString();
                dt.Rows.Add(newRow);
            }
            medicineStockDataGrid.DataSource = dt;
            medicineStockDataGrid.DataBind();

        }
    }
}