using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using CommunityMedicineAutomatuion_App.DAL.DAO;
using iTextSharp.xmp.impl;

namespace CommunityMedicineAutomatuion_App.DAL.Gateway
{
    public class CenterGateway
    {
        private Gateway aGateway = new Gateway();

        public List<District> GetAllDistricts()
        {
            aGateway.command.CommandText = "SELECT * FROM District_tbl";
            aGateway.sqlConnection.Open();
            SqlDataReader reader = aGateway.command.ExecuteReader();
            List<District> districtslList = new List<District>();

            if (reader != null)
                while (reader.Read())
                {
                    District aDistrict = new District();
                    aDistrict.ID = Convert.ToInt16(reader["ID"].ToString());
                    aDistrict.Name = reader["Name"].ToString();
                    districtslList.Add(aDistrict);

                }
            reader.Close();
            aGateway.sqlConnection.Close();
            return districtslList;

        }
        public int TreatmentGivenSave(Treatment aTreatment)
        {
            string query = "insert into Treatment_tbl(CenterID,voterID,DoctorID,TreatmentDate,Observation) values('" + aTreatment.CenterID + "','" + aTreatment.VoterID + "','" + aTreatment.DoctorID + "','" + aTreatment.TreatmentDate + "','" + aTreatment.Observation + "')";
            aGateway.sqlConnection.Open();
            aGateway.command.CommandText = query;
            int rowAffected = aGateway.command.ExecuteNonQuery();
            aGateway.sqlConnection.Close();
            return rowAffected;
        }

        public int GetTreatmentID(Treatment aTreatment)
        {
             aGateway.command.CommandText = "SELECT * FROM Treatment_tbl WHERE CenterID='"+aTreatment.CenterID+"' AND VoterID='"+aTreatment.VoterID+"' AND TreatmentDate='"+aTreatment.TreatmentDate+"'";
            aGateway.sqlConnection.Open();
            SqlDataReader reader = aGateway.command.ExecuteReader();
            int id=0;
            while (reader.Read())
            {
                id =int.Parse(reader["ID"].ToString());
                break;

            }
            reader.Close();
            ;
            aGateway.sqlConnection.Close();
            return id;

        }


        public List<Thana> GetAllThanas()
        {
            aGateway.command.CommandText = "SELECT * FROM Thana_tbl";
            aGateway.sqlConnection.Open();
            SqlDataReader reader = aGateway.command.ExecuteReader();
            List<Thana> thanasList = new List<Thana>();

            if (reader != null)
                while (reader.Read())
                {
                    Thana aThana = new Thana();
                    aThana.ID = Convert.ToInt16(reader["ID"].ToString());
                    aThana.Name = reader["Name"].ToString();
                    aThana.DistrictID = Convert.ToInt16(reader["DistrictID"].ToString());
                    thanasList.Add(aThana);

                }
            reader.Close();
            aGateway.sqlConnection.Close();
            return thanasList;

        }


        public int SaveCenter(DAO.Center aCenter)
        {
            string query = "insert into Center_tbl(Name,Code,Password,ThanaID) values('" + aCenter.Name + "', '" + aCenter.Code + "','" + aCenter.Password + "','" + aCenter.ThanaID + "')";
            aGateway.sqlConnection.Open();
            aGateway.command.CommandText = query;
            int rowAffected = aGateway.command.ExecuteNonQuery();
            aGateway.sqlConnection.Close();
            return rowAffected;
        }
        public List<Thana> GetAllThanasByDistrict(int DistrictID)
        {
            aGateway.command.CommandText = "SELECT * FROM Thana_tbl WHERE DistrictID='" + DistrictID + "'";
            aGateway.sqlConnection.Open();
            SqlDataReader reader = aGateway.command.ExecuteReader();
            List<Thana> thanasList = new List<Thana>();

           
                while (reader.Read())
                {
                    Thana aThana = new Thana();
                    aThana.ID = Convert.ToInt16(reader["ID"].ToString());
                    aThana.Name = reader["Name"].ToString();
                    aThana.DistrictID = Convert.ToInt16(reader["DistrictID"].ToString());
                    thanasList.Add(aThana);

                }
            reader.Close();
            aGateway.sqlConnection.Close();
            return thanasList;

        }
        public List<DAO.Center> GetAllCenterByThana(int ThanaID)
        {
            aGateway.command.CommandText = "SELECT * FROM Center_tbl WHERE ThanaID='" + ThanaID + "'";
            aGateway.sqlConnection.Open();
            SqlDataReader reader = aGateway.command.ExecuteReader();
            List<DAO.Center> centersList = new List<DAO.Center>();

            if (reader != null)
                while (reader.Read())
                {
                    DAO.Center aCenter =new DAO.Center();
                    aCenter.ID = int.Parse(reader["ID"].ToString());
                    aCenter.Name = reader["Name"].ToString();
                    aCenter.Code = reader["Code"].ToString();
                    aCenter.Password = reader["Password"].ToString();
                    aCenter.ThanaID = Convert.ToInt16(reader["ThanaID"].ToString());
                    centersList.Add(aCenter);

                }
            reader.Close();
            aGateway.sqlConnection.Close();
            return centersList;

        }

        public bool IsCenterExist(string Code, string password, out DAO.Center centerInfo)
        {
            bool result = false;
            aGateway.command.CommandText = "SELECT * FROM Center_tbl WHERE Code='" + Code + "' AND Password='" + password + "'";
            aGateway.sqlConnection.Open();
            SqlDataReader reader = aGateway.command.ExecuteReader();
            centerInfo =new DAO.Center();

            while (reader.Read())
            {


                centerInfo.ID = int.Parse(reader[0].ToString());
                centerInfo.Name = reader[1].ToString();

                result = true;
                break;
            }
            reader.Close();
            aGateway.sqlConnection.Close();
            return result;
        }

        public bool SaveNewDoctorInfo(Doctor newDoctor)
        {
            string query = "INSERT INTO Doctor_tbl(Name,Degree,Specialization,CenterID)VALUES('" + newDoctor.Name + "','" + newDoctor.Degree + "','" + newDoctor.Specialization + "','" + newDoctor.CenterID + "')";
            aGateway.command.CommandText = query;
            aGateway.sqlConnection.Open();
            aGateway.command.ExecuteNonQuery();
            aGateway.sqlConnection.Close();
            return true;
        }
        public bool IsCenterExist(string name, int thanaID)
        {
            bool result = false;
            aGateway.command.CommandText = "SELECT * FROM Center_tbl WHERE Name='" + name + "' AND ThanaID='" + thanaID + "'";
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

        public List<CenterMedicineStock> ListofStocks(DAO.Center aCenter)
        {

            List<CenterMedicineStock> stock= new List<CenterMedicineStock>();
            aGateway.command.CommandText = "SELECT * FROM Quantity_tbl WHERE CenterID='"+ aCenter.ID +"'";
            aGateway.sqlConnection.Open();
            SqlDataReader reader = aGateway.command.ExecuteReader();
            while (reader.Read())
            {
                CenterMedicineStock newMedicine=new CenterMedicineStock();
                newMedicine.Quantity = int.Parse(reader[1].ToString());
                newMedicine.MedicineID = int.Parse(reader[3].ToString());
                stock.Add(newMedicine);
            }
            reader.Close();
            aGateway.sqlConnection.Close();
            return stock;

        }

        public string MedicineName(int MedicineID)
        {
            string name=null;
            aGateway.command.CommandText = "SELECT * FROM MedicineList_tbl WHERE ID='" +MedicineID+ "'";
            aGateway.sqlConnection.Open();
            SqlDataReader reader = aGateway.command.ExecuteReader();
            while (reader.Read())
            {
                name = reader[1].ToString();
            }
            reader.Close();
            aGateway.sqlConnection.Close();
            return name;
        }

        public List<Doctor> GetAllDoctorByCenterID(int CenterID)
        {
            aGateway.command.CommandText = "SELECT * FROM Doctor_tbl WHERE CenterID='" + CenterID + "'";
            aGateway.sqlConnection.Open();
            SqlDataReader reader = aGateway.command.ExecuteReader();
            List<Doctor> doctorList = new List<Doctor>();

            if (reader != null)
                while (reader.Read())
                {
                    Doctor aDoctor=new Doctor();
                    aDoctor.ID = Convert.ToInt16(reader["ID"].ToString());
                    aDoctor.CenterID = Convert.ToInt16(reader["CenterID"].ToString());
                    aDoctor.Name = reader["Name"].ToString();
                    doctorList.Add(aDoctor);

                }
            reader.Close();
            aGateway.sqlConnection.Close();
            return doctorList;

        }

        public List<Disease> GetAllDiseases()
        {
            aGateway.command.CommandText = "SELECT * FROM Disease_tbl";
            aGateway.sqlConnection.Open();
            SqlDataReader reader = aGateway.command.ExecuteReader();
            List<Disease> diseasesList = new List<Disease>();

            if (reader != null)
                while (reader.Read())
                {
                    Disease aDisease=new Disease();
                    aDisease.ID = Convert.ToInt16(reader["ID"].ToString());
                    aDisease.Name = reader["Name"].ToString();                                    
                    diseasesList.Add(aDisease);

                }
            reader.Close();
            aGateway.sqlConnection.Close();
            return diseasesList;

        }

        public int ServiceGiven(string voterID)
        {
            aGateway.command.CommandText = "SELECT DISTINCT TreatmentDate FROM Treatment_tbl WHERE voterID='"+voterID+"'";
            aGateway.sqlConnection.Open();
            int count= 0;
            SqlDataReader reader = aGateway.command.ExecuteReader();
           

                while (reader.Read())
                {
                    count++;

                }
            reader.Close();
            aGateway.sqlConnection.Close();
            return count;
        }

        public int GetQuantity(int medicineID,int CenterID)
        {
            int quantity = 0;
            aGateway.command.CommandText = "SELECT * FROM Quantity_tbl WHERE MedicineID='" + medicineID + "' AND CenterID='"+CenterID+"'";
            aGateway.sqlConnection.Open();
            SqlDataReader reader = aGateway.command.ExecuteReader();
            while (reader.Read())
            {
                quantity = int.Parse(reader[1].ToString());
            }
            reader.Close();
            aGateway.sqlConnection.Close();
            return quantity;
            
        }

        public int UpdateQuantity(int medicineID, int centerID, int quantity)
        {
            aGateway.command.CommandText = "UPDATE Quantity_tbl SET Quantity='"+quantity+"' WHERE MedicineID='" + medicineID + "' AND CenterID='" + centerID + "'";
            aGateway.sqlConnection.Open();
            aGateway.command.ExecuteNonQuery();
            aGateway.sqlConnection.Close();
            return quantity;
            
        }


        public void SavePrescription(Prescription aTreatment,int treatmentID)
        {
            string query = "INSERT INTO Prescription_tbl(MedicineID,DiseaseID,Dose,Quantity,MealTime,Note,TreatmentID)VALUES('" + aTreatment.MedicineID + "','" + aTreatment.DiseaseID + "','" + aTreatment.Dose+ "','" + aTreatment.Quantity + "','"+aTreatment.mealTime+"','"+aTreatment.Note+"','"+treatmentID+"')";
            aGateway.command.CommandText = query;
            aGateway.sqlConnection.Open();
            aGateway.command.ExecuteNonQuery();
            aGateway.sqlConnection.Close();
            
        }

        public List<Treatment> GetTreatmentList(string voterId)
        {
            aGateway.command.CommandText = "SELECT * FROM Treatment_tbl WHERE VoterID='" + voterId + "'";
            List<Treatment> treatmentList=new List<Treatment>();
            aGateway.sqlConnection.Open();
            SqlDataReader reader = aGateway.command.ExecuteReader();
            while (reader.Read())
            {
                Treatment newTreatment = new Treatment();
                newTreatment.ID = int.Parse(reader["ID"].ToString());
                newTreatment.CenterID = int.Parse(reader["CenterID"].ToString());
                newTreatment.DoctorID = int.Parse(reader["DoctorID"].ToString());
                newTreatment.Observation = reader["Observation"].ToString();
                newTreatment.TreatmentDate = reader["TreatmentDate"].ToString();
                treatmentList.Add(newTreatment);

            }

            reader.Close();
            aGateway.sqlConnection.Close();
            return treatmentList;





        }
        public Doctor Doctor(int id)
        {
            aGateway.command.CommandText = "SELECT * FROM Doctor_tbl WHERE ID='" + id+ "'";
            aGateway.sqlConnection.Open();
            SqlDataReader reader = aGateway.command.ExecuteReader();
            Doctor aDoctor = new Doctor();

           
                while (reader.Read())
                {
                    
                    aDoctor.ID = Convert.ToInt16(reader["ID"].ToString());
                    aDoctor.CenterID = Convert.ToInt16(reader["CenterID"].ToString());
                    aDoctor.Name = reader["Name"].ToString();
                   

                }
            reader.Close();
            aGateway.sqlConnection.Close();
            return aDoctor;

        }

        public string CenterInfo(int centerID)
        {
            aGateway.command.CommandText = "SELECT * FROM Center_tbl WHERE ID='" + centerID + "'";
            aGateway.sqlConnection.Open();
            SqlDataReader reader = aGateway.command.ExecuteReader();
            string name="";

            
                while (reader.Read())
                {
                    
                    name+= reader["Name"].ToString();
                   

                }
            reader.Close();
            aGateway.sqlConnection.Close();
            return name;
        }

        public List<Prescription> GetPrescription(Treatment treatment)
        {
            aGateway.command.CommandText = "SELECT * FROM Prescription_tbl WHERE TreatmentID='" + treatment.ID + "'";
            aGateway.sqlConnection.Open();
            SqlDataReader reader = aGateway.command.ExecuteReader();
            List<Prescription> newPrescriptions=new List<Prescription>();


            while (reader.Read())
            {
                Prescription aPrescription=new Prescription();

                aPrescription.MedicineID= int.Parse(reader["MedicineID"].ToString());
                aPrescription.DiseaseID = int.Parse(reader["DiseaseID"].ToString());
                aPrescription.Dose = reader["Dose"].ToString();
                aPrescription.Quantity = int.Parse(reader["Quantity"].ToString());
                aPrescription.mealTime = reader["MealTime"].ToString();
                aPrescription.Note = reader["Note"].ToString();
                newPrescriptions.Add(aPrescription);


            }
            reader.Close();
            aGateway.sqlConnection.Close();
            return newPrescriptions;
        }

        public string DiseaseName(int diseaseId)
        {
            string name = null;
            aGateway.command.CommandText = "SELECT * FROM Disease_tbl WHERE ID='" + diseaseId + "'";
            aGateway.sqlConnection.Open();
            SqlDataReader reader = aGateway.command.ExecuteReader();
            while (reader.Read())
            {
                name = reader[1].ToString();
            }
            reader.Close();
            aGateway.sqlConnection.Close();
            return name;
        }

        public bool IsMedicineExist(CenterMedicineStock medicine,out int quantity)
        {
            bool result = false;
            quantity = 0;
            aGateway.command.CommandText = "SELECT * FROM Quantity_tbl WHERE CenterID='" + medicine.CenterID + "' AND MedicineID='"+medicine.MedicineID+"'";
            aGateway.sqlConnection.Open();
            SqlDataReader reader = aGateway.command.ExecuteReader();
            while (reader.Read())
            {
                result = true;
                quantity = int.Parse(reader["Quantity"].ToString());
                break;

            }
            reader.Close();
            aGateway.sqlConnection.Close();
            return result;

        }

        public List<Treatment> GetTreatmentListByCenterID(int id,string start,string end)
        {
            aGateway.command.CommandText = "SELECT * FROM Treatment_tbl WHERE CenterID='" + id+ "' AND TreatmentDate BETWEEN '"+start+"' AND '"+end+"'";
            List<Treatment> treatmentList = new List<Treatment>();
            aGateway.sqlConnection.Open();
            SqlDataReader reader = aGateway.command.ExecuteReader();
            while (reader.Read())
            {
                Treatment newTreatment = new Treatment();
                newTreatment.ID = int.Parse(reader["ID"].ToString());
                newTreatment.CenterID = int.Parse(reader["CenterID"].ToString());
                newTreatment.DoctorID = int.Parse(reader["DoctorID"].ToString());
                newTreatment.Observation = reader["Observation"].ToString();
                newTreatment.TreatmentDate = reader["TreatmentDate"].ToString();
                treatmentList.Add(newTreatment);

            }

            reader.Close();
            aGateway.sqlConnection.Close();
            return treatmentList;




        }

        public List<int> GetAllDiseasesbyTreatment(int id)
        {
            aGateway.command.CommandText = "SELECT DISTINCT DiseaseID FROM Prescription_tbl WHERE TreatmentID='" + id + "'";
            aGateway.sqlConnection.Open();
            SqlDataReader reader = aGateway.command.ExecuteReader();
            List<int> diseaseList = new List<int>();


            while (reader.Read())
            {
                int i = 0;

                i =int.Parse( reader["DiseaseID"].ToString());
                diseaseList.Add(i);
            }
            reader.Close();
            aGateway.sqlConnection.Close();
            return diseaseList;
            
        }
    }
}