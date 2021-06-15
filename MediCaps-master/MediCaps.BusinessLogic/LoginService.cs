using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCaps.DataAccess;
using MediCaps.DataAccess.Entities;

namespace MediCaps.BusinessLogic
{
    public class LoginService : IDisposable
    {
        private readonly MedicapsContext context;
        public LoginService()
        {
            context = new MedicapsContext();
        }
        public void Dispose()
        {
            context.Dispose();
        }

        public List<Login> GetAll()
        {
            var query = from obj in context.Logins
                        select obj;
            return query.ToList();
        }

        public bool ValidatedAdmin(Login log)
        {
            return context.Logins.Any(user => user.UserName.Equals(log.UserName) && user.Password.Equals(log.Password));
        }
    }
}
