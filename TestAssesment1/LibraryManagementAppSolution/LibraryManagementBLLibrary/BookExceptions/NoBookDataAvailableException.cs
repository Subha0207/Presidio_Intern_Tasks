using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementBLLibrary.BookExceptions
{
    public class NoBookDataAvailableException : Exception
    {
        string msg;
        public NoBookDataAvailableException()
        {
            msg = "No Book Data Available";
        }
        public override string Message => msg;
    }
}
