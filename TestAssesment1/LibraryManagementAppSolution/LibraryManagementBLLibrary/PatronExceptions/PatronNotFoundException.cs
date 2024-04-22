using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementBLLibrary.PatronExceptions
{
    public class PatronNotFoundException : Exception
    {
        string msg;
        public PatronNotFoundException()
        {
            msg = "Patron ID does not exist in the system";
        }
        public override string Message => msg;
    }
}
