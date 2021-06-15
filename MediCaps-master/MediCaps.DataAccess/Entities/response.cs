using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCaps.DataAccess.Entities
{
    
        public class Response
        {
            [Key]
            public string Status { set; get; }
            public string Message { set; get; }
        }
    
}
