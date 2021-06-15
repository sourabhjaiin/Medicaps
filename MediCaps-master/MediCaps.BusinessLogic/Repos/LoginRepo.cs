using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCaps.DataAccess;


namespace MediCaps.BusinessLogic.Repos
{
    public class LoginRepo : IDisposable
    {
        private readonly MedicapsContext context;
        public LoginRepo()
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

        public bool AddUser(Login dto)
        {
            if (context.Logins.Any(o => o.UserName == dto.UserName))
            {
                throw new Exception("Username already taken"); //indicates the username already is taken
            }
            else
            {
                context.Logins.Add(dto);
                int RowsAffected = context.SaveChanges();
                return RowsAffected > 0;
            }
        }

        public Login getUser(int Id)
        {
            var Obj = context.Logins.Find(Id);
            return Obj;
        }


    }
}
