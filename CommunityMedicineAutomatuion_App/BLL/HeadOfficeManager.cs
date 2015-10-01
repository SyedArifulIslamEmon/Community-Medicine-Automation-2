using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommunityMedicineAutomatuion_App.DAL.DAO;
using CommunityMedicineAutomatuion_App.DAL.Gateway;

namespace CommunityMedicineAutomatuion_App.BLL
{
    public class HeadOfficeManager
    {
        HeadOfficeGateway aHeadOfficeGateway=new HeadOfficeGateway();
        CenterGateway aCenterGateway=new CenterGateway();
        CodeGenerator newCode=new CodeGenerator();
        DAL.DAO.Center newCenter=new DAL.DAO.Center();

        public int SaveMedicine(Medicine aMedicine)
        {
            return aHeadOfficeGateway.SaveMedicine(aMedicine);
        }

        public bool IsMedicineExist(string MedicineName)
        {
            return aHeadOfficeGateway.CheckMedicineName(MedicineName);
        }

        public List<Medicine> GetMedicineList()
        {
            return aHeadOfficeGateway.MedicineList();
        }
        public int SaveDisease(Disease aDisease)
        {
            return aHeadOfficeGateway.SaveDisease(aDisease);
        }

        public bool IsDiseaseExist(string DiseaseName)
        {
            return aHeadOfficeGateway.CheckDiseaseName(DiseaseName);
        }

        public List<Disease> GetDiseasesList()
        {
            return aHeadOfficeGateway.DiseaseList();
        }
        public List<Thana> GeThanaByDistrictId(int DistrictID)
        {


            return aCenterGateway.GetAllThanasByDistrict(DistrictID);


        }
        public int SaveCenter(DAL.DAO.Center aCenter,out string password)
        {
            password = newCode.PasswordGenerate();
            if (aCenterGateway.IsCenterExist(aCenter.Name,aCenter.ThanaID))
            {
                return -1;


            }
            else
            {
                aCenter.Password = newCode.Encrypt(password);
                return aCenterGateway.SaveCenter(aCenter);
            }
        }
        public List<DAL.DAO.Center> GetCenterByThanaID(int ThanaID)
        {
            return aCenterGateway.GetAllCenterByThana(ThanaID);
        }

        public List<Medicine> GetAllMedicines()
        {
            return aHeadOfficeGateway.GetAllMedicines();
        }

        public bool CenterMedicineSend(List<CenterMedicineStock> medicineStocks)
        {
            bool result = true;
            foreach (CenterMedicineStock medicine in medicineStocks)
            {
                int quantity;
                if (aCenterGateway.IsMedicineExist(medicine,out quantity))
                {
                    aCenterGateway.UpdateQuantity(medicine.MedicineID, medicine.CenterID, (quantity + medicine.Quantity));
                }
                else
                {
                    aHeadOfficeGateway.CenterStockSave(medicine);
                }

            }
            return result;
        }


    }
}