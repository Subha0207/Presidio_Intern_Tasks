using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementBLLibrary.BookBorrowExceptions
{
    public class BookNotAvailableException : Exception
    {
        string msg;
        public BookNotAvailableException()
        {
            msg = "You have tried to borrow a book that is not available (already borrowed)";
        }
        public override string Message => msg;
    }

}
