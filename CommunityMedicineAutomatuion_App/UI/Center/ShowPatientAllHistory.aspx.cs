using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicineAutomatuion_App.BLL;
using CommunityMedicineAutomatuion_App.DAL.DAO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;

namespace CommunityMedicineAutomatuion_App.UI.Center
{
    public partial class ShowPatientAllHistory : System.Web.UI.Page
    {
        private bool result = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now);
            if (Session["TreatmentGet"] != null)
            {
                voterIdTextBox.Text=(string)Session["TreatmentGet"];
                GetJSONdata();
                showPrescription();
                Session["TreatmentGet"] = null;
            }


        }
        CenterManager aCenterManager = new CenterManager();
        private string mainHtml = "";

        protected void show_Click(object sender, EventArgs e)
        {
           
            showPrescription();

        }

        public void showPrescription()
        {
            if (!result)
            {
                GetJSONdata();
            }
            Treatment aTreatment = new Treatment();
            aTreatment.VoterID = voterIdTextBox.Text;

            List<Treatment> treatment = aCenterManager.GetTreatmentList(aTreatment.VoterID);
            ViewState["Treatment"] = treatment;
            int count = 1;
            foreach (Treatment aNewTreatment in treatment)
            {
                mainHtml += GetTreatment(count, aNewTreatment);
                count++;



            }
            Content.InnerHtml = mainHtml;
        }

        public string GetTreatment(int number, Treatment newTreatment)
        {
            string html = "<div>";
            html += "<h3>Treatment " + number + " </h3>";
            html += "<p>Center Name: " + newTreatment.centerName + " </p>";
            html += "<p>Doctor Name: " + newTreatment.newDoctor.Name + " </p>";
            html += "<p>Treatment Date: " + newTreatment.TreatmentDate + " </p>";
            html += "<p>Observation: " + newTreatment.Observation + " </p>";


            string prescription = GetPrescritption(newTreatment, number);
            html += prescription + "</div>";
            return html;
        }

        public void GetJSONdata()
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
                    nameTextBox.Text = voters.name;
                    addressTextBox.Text = voters.address;
                    ageTextBox.Text = voters.date_of_birth;

                }

            }

        }


        public string GetPrescritption(Treatment newTreatment, int number)
        {
            string code = "<div><table cellspacing=\"0\" cellpadding=\"4\" style=\"color:#333333;width:802px;border-collapse:collapse;\"><tbody><tr style=\"color:White;background-color:#5D7B9D;font-weight:bold;\"><th >Disease</th><th >Medicine</th><th>Dose</th><th>Before/After Meal</th><th>Quantity</th><th>Note</th></tr>";
            List<Prescription> newPrescriptions = aCenterManager.NewPrescriptions(newTreatment);
            foreach (Prescription prescription in newPrescriptions)
            {
                code += "<tr>";
                code += "<td> " + prescription.DiseaseName + " </td>";
                code += "<td> " + prescription.MedicineName + " </td>";
                code += "<td> " + prescription.Dose + " </td>";
                code += "<td> " + prescription.mealTime + " </td>";
                code += "<td> " + prescription.Quantity + " </td>";
                code += "<td> " + prescription.Note + " </td>";
                code += "</tr>";
            }
            code += "</tbody></table></div>";
            return code;
        }

        protected void Pdf_Click(object sender, EventArgs e)
        {
            int pcount = 1;
            Paragraph nationalID = new Paragraph("Voter Id: " + voterIdTextBox.Text);
            Paragraph name = new Paragraph("Patient Name: " + nameTextBox.Text);
            Paragraph address = new Paragraph("Address: " + addressTextBox.Text);
            Paragraph age = new Paragraph("Date of Birth: " + ageTextBox.Text);
            Paragraph text = new Paragraph("\n\n");
            Document document = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 40);
            var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
            PdfWriter.GetInstance(document, Response.OutputStream);
            document.Open();
            document.Add(nationalID);
            document.Add(name);
            document.Add(age);
            document.Add(address);
            document.Add(text);
            document.Add(text);
            

            List<Treatment> treatmentGot = (List<Treatment>) ViewState["Treatment"];
            foreach (Treatment aTreatment in treatmentGot)
            {


                PdfPTable pdfPTable = new PdfPTable(6);


                PdfPCell pdfcell = new PdfPCell(new Phrase("Disease"));
                pdfPTable.AddCell(pdfcell);
                pdfcell = new PdfPCell(new Phrase("Medicine"));
                pdfPTable.AddCell(pdfcell);
                pdfcell = new PdfPCell(new Phrase("Dose"));
                pdfPTable.AddCell(pdfcell);
                pdfcell = new PdfPCell(new Phrase("Before/After Meal"));
                pdfPTable.AddCell(pdfcell);
                pdfcell = new PdfPCell(new Phrase("Quantity"));
                pdfPTable.AddCell(pdfcell);
                pdfcell = new PdfPCell(new Phrase("Note"));
                pdfPTable.AddCell(pdfcell);


                int count = 1;
                List<Prescription> newPrescriptions = aCenterManager.NewPrescriptions(aTreatment);
                foreach (Prescription aPrescription in newPrescriptions)
                {
                    
                            PdfPCell pdfCell = new PdfPCell(new Phrase(aPrescription.DiseaseName));
                            pdfPTable.AddCell(pdfCell);
                            pdfCell = new PdfPCell(new Phrase(aPrescription.MedicineName));
                            pdfPTable.AddCell(pdfCell);
                            pdfCell = new PdfPCell(new Phrase(aPrescription.Dose));
                            pdfPTable.AddCell(pdfCell);
                            pdfCell = new PdfPCell(new Phrase(aPrescription.mealTime));
                            pdfPTable.AddCell(pdfCell);
                            pdfCell = new PdfPCell(new Phrase(aPrescription.Quantity.ToString()));
                            pdfPTable.AddCell(pdfCell);
                            pdfCell = new PdfPCell(new Phrase(aPrescription.Note));
                            pdfPTable.AddCell(pdfCell);
                        
                    

                }
                
                //PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("test.pdf", FileMode.Create));
                Paragraph treatmentCount = new Paragraph("Treatment " + (pcount++).ToString(), boldFont);
                
                Paragraph centerName = new Paragraph("Center Name: " + aTreatment.centerName);
               
                Paragraph date = new Paragraph("Treatment Date: " + aTreatment.TreatmentDate);
                Paragraph doctor = new Paragraph("Doctor Name: " + aTreatment.newDoctor.Name);
                
                Paragraph observation = new Paragraph("Observation: " + aTreatment.Observation);
               
                
                
                document.Add(treatmentCount);
                document.Add(centerName);
                document.Add(date);
                document.Add(doctor);
                document.Add(observation);


                
                


                document.Add(text);
                document.Add(pdfPTable);
                
                document.Add(text);
                


               
            }
            document.Close();
            Response.ContentType = "Application";
            Response.AppendHeader("content-disposition", "attachment;filename=FullPrescription.pdf");
            Response.Write(document);
            Response.Flush();
            Response.End();
            document.Close();
        }
    }
}