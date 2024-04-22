using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementBLLibrary.BookExceptions
{
    public class BookNotFoundException : Exception
    {
        string msg;
        public BookNotFoundException()
        {
            msg = "Book ID does not exist in the catalog";
        }
        public override string Message => msg;
    }
}
