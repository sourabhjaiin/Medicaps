using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MediCaps.DataAccess
{
    public enum UserType
    {
        Admin, User
    }
    public class Login
    {

        [Key]
        public int UserId { get; set; }

        [StringLength(30), Required]
        public string UserName { set; get; }

        [StringLength(30)]
        public string Email { get; set; }

        [Required, StringLength(30)]
        public string Password { set; get; }

        public UserType UserType { get; set; }

        public string Phone { get; set; }
        public bool Confirmed { get; set; }
    }
}
