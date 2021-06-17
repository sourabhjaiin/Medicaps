using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCaps.BusinessLogic
{
    public class MediCapsException : Exception
    {
        public MediCapsException():base() { }
        public MediCapsException(string message) : base(message) { }
        public MediCapsException(string message, Exception innerException) : base(message, innerException) { }
    }
}
