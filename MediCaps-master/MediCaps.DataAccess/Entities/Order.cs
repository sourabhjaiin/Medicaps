using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MediCaps.DataAccess.Entities
{
    public class Order
    {
        public int ID { get; set; }

        public DateTime OrderDate { get; set; }

        [Required, StringLength(100)]
        public string DeliveryAddress { get; set; }


        public int Amount { get; set; }

        public int UserId { get; set; }
        public Login login { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();

    }
}
