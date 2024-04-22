using LibraryManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementBLLibrary
{
    public interface IBorrowTransactionService
    {
        string CheckAndBorrowBook(string bookId);
    }

}
