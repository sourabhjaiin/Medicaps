using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MediCaps.DataAccess.Entities
{
    public class Registration
    {
        [Key]
        public int userId { get; set; }



        [Required(ErrorMessage = "Enter User Name")]
        public string username { get; set; }



        [Required(ErrorMessage = "Enter Email Address")]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Correct Email Address")]
        public string email { get; set; }



        [Required(ErrorMessage = "Enter Phone Number")]
        [StringLength(10, ErrorMessage = "The Mobile must contains 10 characters", MinimumLength = 10)]
        public string phoneNo { get; set; }



        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
