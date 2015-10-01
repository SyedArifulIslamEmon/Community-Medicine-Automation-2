using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;

namespace CommunityMedicineAutomatuion_App.DAL.DAO
{
    [Serializable]
    public class Doctor
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Degree { get; set; }
        public string Specialization { get; set; }
        public int CenterID { get; set; }

    }
}