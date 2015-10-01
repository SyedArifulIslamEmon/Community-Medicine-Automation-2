using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using CommunityMedicineAutomatuion_App.BLL;
using CommunityMedicineAutomatuion_App.DAL.DAO;
using iTextSharp.text;
using iTextSharp.text.pdf;

using iTextSharp.text.html.simpleparser;
using Newtonsoft.Json;

namespace CommunityMedicineAutomatuion_App.UI.Center
{
    public partial class TreatmentGiven : System.Web.UI.Page
    {

        CenterManager aCenterManager = new CenterManager();
        public DAL.DAO.Center newCenter;
        private List<CenterMedicineStock> medicineStockList;
        private List<Medicine> newMedicineList = new List<Medicine>();
        protected void Page_Load(object sender, EventArgs e)
        {
            newCenter = (DAL.DAO.Center)Session["CenterInfoDetails"];
            if (!IsPostBack)
            {
                LoadDoctorDropDownList();
                LoadDiseaseDropDownList();
                GetMedicineList();
                LoadMedicineDropDownList();
                LoadDataGridView();
            }



        }





        protected void pdfButton_Click(object sender, EventArgs e)
        {

           
            PdfPTable pdfPTable = new PdfPTable(TreatmentGivenGridView.HeaderRow.Cells.Count);

            foreach (TableCell headerCell in TreatmentGivenGridView.HeaderRow.Cells)
            {
                PdfPCell pdfCell = new PdfPCell(new Phrase(headerCell.Text));
                pdfPTable.AddCell(pdfCell);
            }

            int count = 0;

            foreach (GridViewRow gridViewRow in TreatmentGivenGridView.Rows)
            {
                if(count!=0)
                foreach (TableCell tableCell in gridViewRow.Cells)
                {
                    PdfPCell pdfCell = new PdfPCell(new Phrase(tableCell.Text));
                    pdfPTable.AddCell(pdfCell);
                }
                count++;

            }
            Document document = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter.GetInstance(document, Response.OutputStream);
            //PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("test.pdf", FileMode.Create));

            Paragraph nationalID = new Paragraph("Voter Id: "+voterIdTextBox.Text);
            Paragraph name = new Paragraph("Patient Name: " + nameTextBox1.Text);
            Paragraph centerName = new Paragraph("Center Name: " + newCenter.Name);
            Paragraph address = new Paragraph("Center Name: " + addressTextBox.Text);
            Paragraph age = new Paragraph("Date of Birth: " + ageTextBox.Text);
            Paragraph date = new Paragraph("Treatment Date: " + treatmentDate.SelectedDate.ToString("d"));
            Paragraph doctor = new Paragraph("Doctor Name: " + doctorDropDownList.SelectedItem.Text);
            Paragraph service = new Paragraph("Service Given: " + serviceTimeTextBox.Text);
            Paragraph observation = new Paragraph("Observation: " + observationTextBox.Text);
            Paragraph text=new Paragraph("\n\n");

            document.Open();
            document.Add(nationalID);
            document.Add(name);
            document.Add(address);
            document.Add(centerName);
            document.Add(date);
            document.Add(doctor);
            document.Add(observation);
            

            document.Add(age);
            document.Add(service);


            document.Add(text);
            document.Add(pdfPTable);
            document.Close();

            Response.ContentType = "Application";
            Response.AppendHeader("content-disposition", "attachment;filename=Prescription.pdf");
            Response.Write(document);
            Response.Flush();
            Response.End();
            document.Close();
        }


        public void LoadDoctorDropDownList()
        {
            doctorDropDownList.DataSource = aCenterManager.GetAllDoctorByCenterID(newCenter.ID);
            doctorDropDownList.DataTextField = "Name";
            doctorDropDownList.DataValueField = "ID";
            doctorDropDownList.DataBind();
        }

        public void LoadDiseaseDropDownList()
        {
            diseaseDropDownList.DataSource = aCenterManager.GetAllDiseases();
            diseaseDropDownList.DataTextField = "Name";
            diseaseDropDownList.DataValueField = "ID";
            diseaseDropDownList.DataBind();
        }

        public void GetMedicineList()
        {
            medicineStockList = aCenterManager.GetAllMedicineByCenterID(newCenter);

            foreach (CenterMedicineStock medicine in medicineStockList)
            {
                Medicine newMedicine = new Medicine();
                newMedicine.ID = medicine.MedicineID;
                newMedicine.MedicineName = aCenterManager.GetMedicineInfo(medicine.MedicineID);
                newMedicineList.Add(newMedicine);
            }

        }
        public void LoadMedicineDropDownList()
        {
            medicineDropDownList.DataSource = newMedicineList;

            medicineDropDownList.DataTextField = "MedicineName";
            medicineDropDownList.DataValueField = "ID";
            medicineDropDownList.DataBind();

        }

        protected void showButton_Click(object sender, EventArgs e)
        {
            WebRequest request =
                WebRequest.Create("http://nerdcastlebd.com/web_service/voterdb/index.php/voters/all/format/json");
            WebResponse response = request.GetResponse();
            string json;
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                json = sr.ReadToEnd();
            }
            var serializer = new JavaScriptSerializer();
            RootObject persons = JsonConvert.DeserializeObject<RootObject>(json);
            bool check = false;

            foreach (Voter voters in persons.voters)
            {
                if (voterIdTextBox.Text == voters.id)
                {
                    nameTextBox1.Text = voters.name;
                    addressTextBox.Text = voters.address;
                    ageTextBox.Text = voters.date_of_birth;

                }

            }
            string voterID = voterIdTextBox.Text;
            serviceTimeTextBox.Text = aCenterManager.ServiceGiven(voterID).ToString();

        }


        

      
        protected void addButton_Click(object sender, EventArgs e)
        {
            List<Prescription> treatmentList = (List<Prescription>)ViewState["TreatmentGiven"];
            bool result = false;
            if (CheckMedicine(int.Parse(diseaseDropDownList.SelectedItem.Value), int.Parse(medicineDropDownList.SelectedItem.Value), int.Parse(qtyGivenTextBox.Text)))
            {
                result = true;
                AddToDataGrid(result);


            }
            else
            {
                AddToDataGrid(result);

            }


        }

        public void LoadDataGridView()
        {

            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("diseaseName", typeof(string)));
            dt.Columns.Add(new DataColumn("medicineName", typeof(string)));
            dt.Columns.Add(new DataColumn("dose", typeof(string)));
            dt.Columns.Add(new DataColumn("mealCheck", typeof(string)));
            dt.Columns.Add(new DataColumn("quantity", typeof(string)));
            dt.Columns.Add(new DataColumn("note", typeof(string)));
            dr = dt.NewRow();
            dr["diseaseName"] = string.Empty;
            dr["medicineName"] = string.Empty;
            dr["dose"] = string.Empty;
            dr["mealCheck"] = string.Empty;
            dr["quantity"] = string.Empty;
            dr["note"] = string.Empty;
            dt.Rows.Add(dr);
            ViewState["CurrentTable"] = dt;
            TreatmentGivenGridView.DataSource = dt;
            TreatmentGivenGridView.DataBind();
            ViewState["SerialNo"] = 0;
            List<Prescription> treatmentList = new List<Prescription>();
            ViewState["TreatmentGiven"] = treatmentList;

        }

        public void AddToDataGrid(bool exist)
        {
            if (!exist)
            {
                TreatmentSave();
            }
            DataTable currentTable = (DataTable)ViewState["CurrentTable"];

            string mealTime;
            if (afterMealRadioButton.Checked)
            {
                mealTime = "After Meal";

            }
            else
            {
                mealTime = "Before Meal";
            }
            DataRow dr = currentTable.NewRow();
            dr["diseaseName"] = diseaseDropDownList.SelectedItem.Text;
            dr["medicineName"] = medicineDropDownList.SelectedItem.Text;
            dr["dose"] = doseTextBox.Text;
            dr["mealCheck"] = mealTime;
            dr["quantity"] = qtyGivenTextBox.Text;
            dr["note"] = noteTextBox.Text;
            currentTable.Rows.Add(dr);
            ViewState["CurrentTable"] = currentTable;

            TreatmentGivenGridView.DataSource = currentTable;
            TreatmentGivenGridView.DataBind();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            List<Prescription> treatmentList = (List<Prescription>)ViewState["TreatmentGiven"];
            Treatment newTreatment = new Treatment();
            newTreatment.VoterID = voterIdTextBox.Text;
            newTreatment.CenterID = newCenter.ID;
            newTreatment.DoctorID = int.Parse(doctorDropDownList.SelectedItem.Value);
            newTreatment.TreatmentDate = treatmentDate.SelectedDate.ToString("d");
            newTreatment.Observation = observationTextBox.Text;
            if (aCenterManager.TreatmentGivenSave(newTreatment, treatmentList))
            {
               
                labelNotification.Text = "save successfully";
                labelNotification.ForeColor = Color.Green;

            }


        }

        public void TreatmentSave()
        {
            List<Prescription> treatmentList = (List<Prescription>)ViewState["TreatmentGiven"];
            Prescription newTreatment = new Prescription();

            newTreatment.DiseaseID = int.Parse(diseaseDropDownList.SelectedItem.Value);

            newTreatment.MedicineID = int.Parse(medicineDropDownList.SelectedItem.Value);
            newTreatment.Quantity = int.Parse(qtyGivenTextBox.Text);
            newTreatment.Note = noteTextBox.Text;
            newTreatment.Dose = doseTextBox.Text;
            if (afterMealRadioButton.Checked)
            {
                newTreatment.mealTime = "After Meal";
            }
            else
            {
                newTreatment.mealTime = "Before Meal";
            }

            treatmentList.Add(newTreatment);
            ViewState["TreatmentGiven"] = treatmentList;


        }

        public bool CheckMedicine(int diseaseid, int id, int quantity)
        {
            bool result = false;
            List<Prescription> PrescriptionDetails = (List<Prescription>)ViewState["TreatmentGiven"];
            foreach (Prescription prescription in PrescriptionDetails)
            {
                if (prescription.MedicineID == id && prescription.DiseaseID == diseaseid)
                {
                    prescription.Quantity += quantity;
                    result = true;
                }
            }
            return result;


        }

        protected void resetButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Center/TreatmentGiven.aspx");
        }

     




    }
}