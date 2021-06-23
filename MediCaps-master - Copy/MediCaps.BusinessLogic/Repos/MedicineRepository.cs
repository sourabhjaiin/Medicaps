using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCaps.DataAccess;
using MediCaps.DataAccess.Entities;

namespace MediCaps.BusinessLogic
{
    public class MedicineRepository : IDisposable
    {
        private readonly MedicapsContext context;
        public MedicineRepository()
        {
            context = new MedicapsContext();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public List<Medicine> GetMed()
        {
            var query = from obj in context.Medicines
                        select obj;
            return query.ToList();
        }

        public bool Add(Medicine medicine)
        {
            if (context.Medicines.Any(o => o.MedicineName==medicine.MedicineName))
            {
                return false;
            }
            else
            {
                context.Medicines.Add(medicine);
                int Rows = context.SaveChanges();
                return Rows == 1;
            }
           
        }

        public List<Medicine> GetMedicinebyName(string MedicineName)
        {
            var query = from obj in context.Medicines
                        where obj.MedicineName == MedicineName
                        select obj;
            return query.ToList();
        }

        
        public List<Medicine> GetMedicineByComposition(string Composition)
        {
            var query = from obj in context.Medicines
                        where obj.Composition == Composition
                        select obj;
            return query.ToList();
        }

        public List<Medicine> GetMedicinebyId(int id)
        {
            var query = from obj in context.Medicines
                        where obj.MedicineId==id
                        select obj;
            return query.ToList();
        }


        public bool  MedDelete(int id)
        {
            var med = context.Medicines.Find(id);
            context.Medicines.Remove(med);
            var row = context.SaveChanges();
            return row == 1;
        }

        public Medicine GetM(int Id)
        {
            var med = context.Medicines.Find(Id);
            return med;
        }

        public bool updateMedicine1(Medicine medicine)
        {
            var obj = GetM(medicine.MedicineId);
            if (obj == null)
            {
                return Add(medicine);
            }

            obj.MedicineName = medicine.MedicineName;
            obj.MedicinePrice = medicine.MedicinePrice;
            obj.IsDelivable = medicine.IsDelivable;

            int rows = context.SaveChanges();
            return rows == 1;
        }

        public bool updateMedicine(int id,Medicine medicine)
        {
            var obj = GetM(id);
            if (obj == null)
            {
                return Add(medicine);
            }

           
            obj.MedicinePrice = medicine.MedicinePrice;
            obj.IsDelivable = medicine.IsDelivable;

            int rows = context.SaveChanges();
            return rows == 1;
        }




    }
}
