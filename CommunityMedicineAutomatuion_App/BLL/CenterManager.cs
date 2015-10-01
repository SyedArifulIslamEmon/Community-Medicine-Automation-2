using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommunityMedicineAutomatuion_App.DAL.DAO;
using CommunityMedicineAutomatuion_App.DAL.Gateway;

namespace CommunityMedicineAutomatuion_App.BLL
{
    public class CenterManager
    {
        CenterGateway aCenterGateway = new CenterGateway();
        CodeGenerator Code=new CodeGenerator();

        public List<District> GetAllDistricts()
        {
            return aCenterGateway.GetAllDistricts();
        }

        public List<Thana> GetAllThanas()
        {
            return aCenterGateway.GetAllThanas();
        }

        public bool CenterInfoCheck(string Name, string password,out DAL.DAO.Center newCenter)
        {
            return aCenterGateway.IsCenterExist(Name, Code.Encrypt(password),out newCenter);
        }

        public bool SaveDoctorInfo(Doctor newDoctor)
        {
            return aCenterGateway.SaveNewDoctorInfo(newDoctor);
        }

        public bool TreatmentGivenSave(Treatment treatmentDetails, List<Prescription> treatmentList)
        {
            aCenterGateway.TreatmentGivenSave(treatmentDetails);
            int treatmentID = aCenterGateway.GetTreatmentID(treatmentDetails);

            foreach (Prescription aTreatment in treatmentList)
            {

                aCenterGateway.SavePrescription(aTreatment, treatmentID);

                int medicineQuantity = aCenterGateway.GetQuantity(aTreatment.MedicineID, treatmentDetails.CenterID);
                medicineQuantity = (medicineQuantity - aTreatment.Quantity);
                aCenterGateway.UpdateQuantity(aTreatment.MedicineID, treatmentDetails.CenterID,
                    medicineQuantity);
            }
            return true;
        }

        public List<CenterMedicineStock> GetStock(DAL.DAO.Center newCenter)
        {
            List<CenterMedicineStock> listofStock = aCenterGateway.ListofStocks(newCenter);
            List<CenterMedicineStock> medicineStockWithDetails=new List<CenterMedicineStock>();
            foreach (CenterMedicineStock medicineStock in listofStock)
            {
                CenterMedicineStock newMedicineStock=new CenterMedicineStock();
                newMedicineStock.Quantity = medicineStock.Quantity;
                newMedicineStock.MedicineName = aCenterGateway.MedicineName(medicineStock.MedicineID);
                medicineStockWithDetails.Add(newMedicineStock);
            }

            return medicineStockWithDetails;
        }

        public List<Doctor> GetAllDoctorByCenterID(int CenterID)
        {
            return aCenterGateway.GetAllDoctorByCenterID(CenterID);
        }

        public List<Disease> GetAllDiseases()
        {
            return aCenterGateway.GetAllDiseases();
        }

        public List<CenterMedicineStock> GetAllMedicineByCenterID(DAL.DAO.Center center)
        {
            return aCenterGateway.ListofStocks(center);
        }

        public string GetMedicineInfo(int medicineID)
        {
            return aCenterGateway.MedicineName(medicineID);
        }

        public int ServiceGiven(string voterID)
        {
            return aCenterGateway.ServiceGiven(voterID);
        }

        public List<Treatment> GetTreatmentList(string voterId)
        {
           List<Treatment> treatment=aCenterGateway.GetTreatmentList(voterId);
            foreach (Treatment newTreatment in treatment)
            {
                newTreatment.newDoctor = aCenterGateway.Doctor(newTreatment.DoctorID);
                newTreatment.centerName = aCenterGateway.CenterInfo(newTreatment.CenterID);
            }
            return treatment;
        }

        public List<Prescription> NewPrescriptions(Treatment treatment)
        {
            List<Prescription> newPrescriptions=aCenterGateway.GetPrescription(treatment);
            foreach (Prescription prescription in newPrescriptions)
            {
                prescription.MedicineName = aCenterGateway.MedicineName(prescription.MedicineID);
                prescription.DiseaseName = aCenterGateway.DiseaseName(prescription.DiseaseID);

            }
            return newPrescriptions;
        }

        private List<Patient> newPatient;
        public List<Patient> GetPatientList(string startDate,string endDate,District newDistrict)
        {
          newPatient = new List<Patient>();
            List<Thana> thanaList = aCenterGateway.GetAllThanasByDistrict(newDistrict.ID);
            foreach (Thana aThana in thanaList)
            {
                List<DAL.DAO.Center> aCenter=aCenterGateway.GetAllCenterByThana(aThana.ID);
                foreach (DAL.DAO.Center newCenter in aCenter)
                {
                    List<Treatment> treatmentList = aCenterGateway.GetTreatmentListByCenterID(newCenter.ID,startDate,endDate);
                    foreach (Treatment treatment in treatmentList)
                    {
                        List<int> getDiseases = aCenterGateway.GetAllDiseasesbyTreatment(treatment.ID);
                        foreach (int newDisease in getDiseases)
                        {
                            if (IsDiseaseExist(newDisease))
                            {
                                continue;
                            }
                            else
                            {
                                Patient aPatient=new Patient();
                                aPatient.ID = newDisease;
                                aPatient.number = 1;
                                newPatient.Add(aPatient);
                            }
                        }
                    }
                }


            }
            foreach (Patient aPatient in newPatient)
            {
                aPatient.DiseaseName = aCenterGateway.DiseaseName(aPatient.ID);
            }


            return newPatient;
        }

        public bool IsDiseaseExist(int newDisease)
        {
            bool result = false;
            foreach (Patient patient in newPatient)
            {
                if (patient.ID == newDisease)
                {
                    patient.number++;
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}