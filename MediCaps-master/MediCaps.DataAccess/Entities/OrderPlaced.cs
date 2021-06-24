using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCaps.DataAccess.Entities
{
    public class OrderPlaced
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
        public ICollection<Login> User { get; set; }

        public int CartId { get; set; }
        
    }
}
