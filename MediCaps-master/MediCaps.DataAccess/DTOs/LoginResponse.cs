using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCaps.DataAccess.DTOs
{
    public class LoginResponse
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public string UserType { get; set; }
    }
}
