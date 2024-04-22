using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementBLLibrary.PatronExceptions
{
    public class DuplicatePatronIDException : Exception
    {
        string msg;
        public DuplicatePatronIDException()
        {
            msg = "A new patron tried to register with an ID that already exists";
        }
        public override string Message => msg;
    }
}
