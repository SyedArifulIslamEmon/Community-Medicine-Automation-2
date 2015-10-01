using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CommunityMedicineAutomatuion_App.DAL.DAO;

namespace CommunityMedicineAutomatuion_App.DAL.Gateway
{
    public class HeadOfficeGateway
    {
        Gateway aGateway = new Gateway();

        public int SaveMedicine(Medicine aMedicine)
        {
            string query = "insert into MedicineList_tbl(MedicineNameWithML) values('" + aMedicine.MedicineName + "')";
            aGateway.sqlConnection.Open();
            aGateway.command.CommandText = query;
            int rowAffected = aGateway.command.ExecuteNonQuery();
            aGateway.sqlConnection.Close();
            return rowAffected;
        }

        public bool CheckMedicineName(string MedicineName)
        {
            bool result = false;
            aGateway.command.CommandText = "SELECT * FROM MedicineList_tbl WHERE MedicineNameWithML='" + MedicineName + "'";
            aGateway.sqlConnection.Open();
            SqlDataReader reader = aGateway.command.ExecuteReader();
            while (reader.Read())
            {
                result = true;
                break;
            }
            reader.Close();
            aGateway.sqlConnection.Close();
            return result;
        }
        public List<Medicine> MedicineList()
        {
            List<Medicine> MedicineList=new List<Medicine>();
            aGateway.command.CommandText = "SELECT * FROM MedicineList_tbl ORDER BY MedicineNameWithML ASC";
            aGateway.sqlConnection.Open();
            SqlDataReader reader = aGateway.command.ExecuteReader();
            while (reader.Read())
            {
                Medicine newMedicine =new Medicine();
                newMedicine.MedicineName = reader[1].ToString();
                MedicineList.Add(newMedicine);

            }
            reader.Close();
            aGateway.sqlConnection.Close();
            return MedicineList;
        }
        public int SaveDisease(Disease aDisease)
        {
            string query = "insert into Disease_tbl(Name,Description,Treatment) values('" + aDisease.Name + "','" + aDisease.Description + "','" + aDisease.Treatment + "')";
            aGateway.sqlConnection.Open();
            aGateway.command.CommandText = query;
            int rowAffected = aGateway.command.ExecuteNonQuery();
            aGateway.sqlConnection.Close();
            return rowAffected;
        }
        public int CenterStockSave(CenterMedicineStock medicine)
        {
            string query = "insert into Quantity_tbl(Quantity,CenterID,MedicineID) values('" + medicine.Quantity + "','" + medicine.CenterID + "','" + medicine.MedicineID + "')";
            aGateway.sqlConnection.Open();
            aGateway.command.CommandText = query;
            int rowAffected = aGateway.command.ExecuteNonQuery();
            aGateway.sqlConnection.Close();
            return rowAffected;
        }

        public bool CheckDiseaseName(string DiseaseName)
        {
            bool result = false;
            aGateway.command.CommandText = "SELECT * FROM Disease_tbl WHERE Name='" + DiseaseName + "'";
            aGateway.sqlConnection.Open();
            SqlDataReader reader = aGateway.command.ExecuteReader();
            while (reader.Read())
            {
                result = true;
                break;
            }
            reader.Close();
            aGateway.sqlConnection.Close();
            return result;
        }
        public List<Disease> DiseaseList()
        {
            List<Disease> DiseaseList = new List<Disease>();
            aGateway.command.CommandText = "SELECT * FROM Disease_tbl";
            aGateway.sqlConnection.Open();
            SqlDataReader reader = aGateway.command.ExecuteReader();
            while (reader.Read())
            {
                Disease newDisease = new Disease();
                newDisease.Name = reader[1].ToString();
                newDisease.Description = reader[2].ToString();
                newDisease.Treatment = reader[3].ToString();
                DiseaseList.Add(newDisease);

            }
            reader.Close();
            aGateway.sqlConnection.Close();
            return DiseaseList;
        }
        public List<Medicine> GetAllMedicines()
        {
            aGateway.command.CommandText = "SELECT * FROM MedicineList_tbl";
            aGateway.sqlConnection.Open();
            SqlDataReader reader = aGateway.command.ExecuteReader();
            List<Medicine> medicinesList = new List<Medicine>();

            if (reader != null)
                while (reader.Read())
                {
                    Medicine aMedicine = new Medicine();
                    aMedicine.ID = Convert.ToInt16(reader["ID"].ToString());
                    aMedicine.MedicineName = reader["MedicineNameWithML"].ToString();
                    medicinesList.Add(aMedicine);

                }
            reader.Close();
            aGateway.sqlConnection.Close();
            return medicinesList;

        }



    }
}