using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicineAutomatuion_App.DAL.DAO
{
    public class RootObject
    {
        public List<Voter> voters{ get; set; }
    }
    public class Voter
    {
        public string id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string date_of_birth { get; set; }
    }
}