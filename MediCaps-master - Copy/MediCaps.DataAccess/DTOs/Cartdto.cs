using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCaps.DataAccess.DTOs
{
    public class Cartdto
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public int Quantity { get; set; }
        public int MedicinePrice { get; set; }
        public int SubTotal { get => Quantity * MedicinePrice; }
    }
}
