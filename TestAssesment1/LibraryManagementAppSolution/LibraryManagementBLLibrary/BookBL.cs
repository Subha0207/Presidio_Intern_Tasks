using LibraryManagementModelLibrary;
using LibraryManagementDALLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementBLLibrary.BookExceptions;
using LibraryManagementBLLibrary.BookBorrowExceptions;

namespace LibraryManagementBLLibrary
{
    public class BookBL : IBookService
    {
         IRepository<string, Book> _bookRepository;
        public BookBL()
        {
            _bookRepository = new BookRepository();
        }

        //Function to Add Book
        public string AddBook(Book book)
        {
            var result = _bookRepository.Add(book);

            if (result != null)
            {
                return result.BookID;
            }
            throw new DuplicateBookIDException();
        }

        //Function to Get All Available Books
       
        public List<Book> GetAllAvailableBooks()
        {
            var books = _bookRepository.GetAll();
            if (books != null)
            {
                return books.Where(book => book.IsAvailable == true).ToList();

            }
            throw new NoBookDataAvailableException();
        }
        public Book GetAvailableBookById(string id)
        {
            Console.WriteLine(id);
            var book = _bookRepository.Get(id);
            Console.WriteLine(book);
            if (book != null && book.IsAvailable)
            {
                
                return book;

            }
            throw new BookNotAvailableException();
        }
        public Book UpdateBook (Book book){
            
            var updatedbook=_bookRepository. Update(book);
            if(updatedbook!= null)
            {
                return updatedbook;
            }
            throw new Exception("not updated");


        }
        

    }
}
