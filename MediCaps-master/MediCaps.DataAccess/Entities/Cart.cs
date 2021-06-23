using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCaps.DataAccess.Entities
{
    public class Cart
    {
        public int ID { get; set; }

        public int UserId { get; set; }
        public Login Login { get; set; }

        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }

        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
