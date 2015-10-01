using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CommunityMedicineAutomatuion_App.DAL.Gateway
{
    public class Gateway
    {
         private string connect =WebConfigurationManager.ConnectionStrings["ConnectionLink"].ConnectionString;
       private SqlConnection connectionPath;
       private SqlCommand sqlcommmand;
        
        public Gateway()
        {
            connectionPath = new SqlConnection(connect);
            sqlcommmand=new SqlCommand();
            
        }
        public SqlConnection sqlConnection
        {
            get
            {
                return connectionPath;

            }
        }
        public SqlCommand command
        {
            get
            {
                sqlcommmand.Connection = connectionPath;
                return sqlcommmand;
            }
        }
    }
}