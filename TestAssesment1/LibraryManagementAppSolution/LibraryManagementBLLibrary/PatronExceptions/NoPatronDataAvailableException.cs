using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementBLLibrary.PatronExceptions
{
    public class NoPatronDataAvailableException : Exception
    {
        string msg;
        public NoPatronDataAvailableException()
        {
            msg = "No Patron Data Available";
        }
        public override string Message => msg;
    }
}
