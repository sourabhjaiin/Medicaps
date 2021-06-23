using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCaps.DataAccess.Entities
{
    public class OrderItem
    {
        public int ID { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }
    }
}
