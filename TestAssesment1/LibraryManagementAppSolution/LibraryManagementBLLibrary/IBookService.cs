using LibraryManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementBLLibrary
{
    public interface IBookService
    {
        string AddBook(Book book);
        List<Book> GetAllAvailableBooks();

         Book GetAvailableBookById(string id);


    }
}
