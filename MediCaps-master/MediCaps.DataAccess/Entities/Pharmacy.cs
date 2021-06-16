using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace MediCaps.DataAccess.Entities
{
    public class Pharmacy
    {
        [Key]
        public int PsID { get; set; }
        public string PsName { get; set; }

        public string Location { get; set; }

        public int Pincode { get; set; }
    }
}
