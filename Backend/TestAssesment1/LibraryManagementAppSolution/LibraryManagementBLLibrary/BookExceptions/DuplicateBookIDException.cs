using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementBLLibrary.BookExceptions
{
    public class DuplicateBookIDException : Exception
    {
        string msg;
        public DuplicateBookIDException()
        {
            msg = "A new book tried to register with an ID that already exists";
        }
        public override string Message => msg;
    }

}
