using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MediCaps.DataAccess.Entities
{
    public class Medicine
    {
        [Key]
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public int MedicinePrice { get; set; }
        public Boolean IsDelivable { get; set; }

        public string Composition { get; set; }

        
    }
}
