using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicineAutomatuion_App.DAL.DAO
{
    [Serializable]
    public class Prescription
    {
        public int ID { get; set; }
        public string Dose { get; set; }
        public string mealTime { get; set; }
        public int DiseaseID { get; set; }
        public string Note { get; set; }
        public string MedicineName { get; set; }
        public string DiseaseName { get; set; }
        public int MedicineID { get; set; }
        public int Quantity { get; set; }
        public int TreatmentID { get; set; }

    }
}