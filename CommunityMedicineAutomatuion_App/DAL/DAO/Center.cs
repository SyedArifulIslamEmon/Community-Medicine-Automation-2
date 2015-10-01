using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicineAutomatuion_App.DAL.DAO
{

     [Serializable]
    public class Center
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Password { get; set; }
        public int ThanaID { get; set; }
    }
}