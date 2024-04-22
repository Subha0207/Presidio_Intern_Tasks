using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementBLLibrary.BookExceptions
{
    public class BookDetailsMissingException : Exception
    {
        string msg;
        public BookDetailsMissingException()
        {
            msg = "Details of a book (title, author, genre, etc.) are missing";
        }
        public override string Message => msg;
    }
}
