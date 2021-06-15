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

        public List<Medicine> GetAllMMedicine()
        {
            var query = from obj in context.Medicines
                        select obj;
            return query.ToList();
        }

        public bool Add(Medicine medicine)
        {
            context.Medicines.Add(medicine);
            int Rows = context.SaveChanges();
            return Rows == 1;
        }
    }
}
