using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace CommunityMedicineAutomatuion_App.DAL.DAO
{
[Serializable]
    public class Treatment
    {
        public int ID{ get; set; }

         public string VoterID { get; set; }
          
        public int  CenterID { get; set; }
        public int DoctorID { get; set; }
        
        public string TreatmentDate { get; set; }
        public string Observation { get; set; }
        public Doctor newDoctor { get; set; }
        public string centerName { get; set; }

    

        
    }
}