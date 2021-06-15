using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCaps.DataAccess;
using MediCaps.DataAccess.Entities;

namespace MediCaps.BusinessLogic
{
    public class signupService
    {
        private readonly MedicapsContext context;
        Registration regis = new Registration();
        public signupService()
        {
            context = new MedicapsContext();
        }
        public void Dispose()
        {
            context.Dispose();
        }

        public  bool Add(Registration registration)
        {
            context.Registrations.Add(registration);
            int Rows = context.SaveChanges();
            return Rows == 1;
        }
        


    }
}
