using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementBLLibrary.PatronExceptions
{
    public class PatronDetailsMissingException : Exception
    {
        string msg;
        public PatronDetailsMissingException()
        {
            msg = "Details of a patron (name, contact information, etc.) are missing";
        }
        public override string Message => msg;
    }
}
