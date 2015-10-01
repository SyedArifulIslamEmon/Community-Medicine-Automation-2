using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicineAutomatuion_App.DAL.DAO
{
    [Serializable]
    public class Patient
    {
        public int number { get; set; }
        public int ID { get; set; }

        public string DiseaseName { get; set; }
    }
}