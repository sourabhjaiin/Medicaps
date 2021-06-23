using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MediCaps.DataAccess.DTOs
{
    public class LoginDto
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Username is mandatory")]
        [StringLength(20)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is mandatory")]
        [StringLength(20)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is mandatory")]
        [StringLength(13)]
        public string Password { get; set; }
        [Required(ErrorMessage = "UserType is mandatory")]
        [StringLength(5)]
        public string UserType { get; set; }
        [StringLength(13)]
        public string Phone { get; set; }
        public bool Confirmed { get; set; }
    }
}
