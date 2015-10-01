using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace CommunityMedicineAutomatuion_App.DAL.DAO
{
    [Serializable]
    public class CenterMedicineStock
    {
        public int ID { get; set; }
        public int MedicineID { get; set; }
        public string MedicineName { get; set; }
        public int Quantity { get; set; }
        public int CenterID { get; set; }
    }
}