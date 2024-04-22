using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementBLLibrary.ReturnExceptions
{
    
    public class InvalidReturnException : Exception
    {
        string msg;
        public InvalidReturnException()
        {
            msg = "A patron tried to return a book they didn’t borrow";
        }
        public override string Message => msg;
    }
}
