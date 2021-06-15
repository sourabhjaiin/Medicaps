using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCaps.DataAccess.DTOs
{
   public class PharmacyResponse
    {
        public int PsID { get; set; }
        public string PsName { get; set; }

        public string Location { get; set; }

    }
}
