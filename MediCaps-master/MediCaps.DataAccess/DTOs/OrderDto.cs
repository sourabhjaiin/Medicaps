using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCaps.DataAccess.DTOs
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
        public int CartId { get; set; }
    }
}
