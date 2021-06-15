using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MediCaps.DataAccess.DTOs
{
    public class ProductRequest
    {
        public int MedicineId { get; set; }

        [Required]
        public string MedicineName { get; set; }
        [Required]
        public int MedicinePrice { get; set; }
        public Boolean IsDelivable { get; set; }

        [Required]
        public string Composition { get; set; }

        public int UserId { get; set; }
    }
}
