using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MediCaps.DataAccess.DTOs
{
    public class PharmacyRequest
    {
        public int PsID { get; set; }

        [Required]
        public string PsName { get; set; }

        [Required]
        public string Location { get; set; }

        public int Pincode { get; set; }
        public int UserId { get; set; }
    }
}
