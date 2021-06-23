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
            if (context.Pharmacies.Any(o => o.PsName==pharmacy.PsName))
            {
                return false;
                throw new Exception("This Pharmacy already exist in the database");
            }
            else
            {
                context.Pharmacies.Add(pharmacy);
                int Rows = context.SaveChanges();
                return Rows == 1;
            }
            
        }


        public bool PharDelete(int id)
        {
            var phar = context.Pharmacies.Find(id);
            context.Pharmacies.Remove(phar);
            var row = context.SaveChanges();
            return row == 1;
        }

        public List<Pharmacy> GetPharmacybyPincode(int pincode)
        {
            var query = from obj in context.Pharmacies
                        where obj.Pincode == pincode
                        select obj;

            return query.ToList();
        }

        public Pharmacy GetP(int id)
        {
            var phamobj = context.Pharmacies.Find(id);
            return phamobj;
        }

        public bool updatePharamacy(Pharmacy pharm)
        {
            var obj = GetP(pharm.PsID);
            if (obj == null)
            {
                return Add(pharm);
            }

            obj.PsName = pharm.PsName;
            obj.Location = pharm.Location;
            obj.Pincode = pharm.Pincode;

            int row = context.SaveChanges();

            return row == 1;
        }
    }
}
