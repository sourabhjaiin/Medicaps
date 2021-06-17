using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCaps.DataAccess;
using MediCaps.DataAccess.Entities;

namespace MediCaps.BusinessLogic
{
    public class PharmacyRepository : IDisposable
    {
        private readonly MedicapsContext context;
        public PharmacyRepository()
        {
            context = new MedicapsContext();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public List<Pharmacy> GetPharamcy()
        {
            var query = from obj in context.Pharmacies
                        select obj;
            return query.ToList();
        }

        public bool Add(Pharmacy pharmacy)
        {
            context.Pharmacies.Add(pharmacy);
            int Rows = context.SaveChanges();
            return Rows == 1;
        }

    }
}
