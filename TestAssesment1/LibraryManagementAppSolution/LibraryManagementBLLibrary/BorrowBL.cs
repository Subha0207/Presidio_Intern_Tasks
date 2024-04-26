using LibraryManagementBLLibrary;
using LibraryManagementBLLibrary.BookBorrowExceptions;
using LibraryManagementBLLibrary.PatronExceptions;
using LibraryManagementDALLibrary;
using LibraryManagementModelLibrary;

public class BorrowBL
{
    readonly IRepository<string, Book> _bookRepository;
    readonly IRepository<string, Patron> _patronRepository;
    readonly IRepository<string, BorrowTransaction> _borrowTransactionRepository;
    BookBL bookBL;
    
    public BorrowBL()
    {
        bookBL = new BookBL();
        _bookRepository = new BookRepository();
        _patronRepository = new PatronRepository();
        _borrowTransactionRepository = new BorrowTransactionRepository();
    }
    public DateTime BorrowBook(BorrowTransaction borrowTransaction)
    {
        
            var book1 =_bookRepository.Get(borrowTransaction.BookID);
          Console.WriteLine("hi");
        //   Console.WriteLine(  book.IsAvailable);
         book1.IsAvailable = false;
            Book book2 = book1;
            var   updatedbook = _bookRepository.Update(book2);
            Console.WriteLine("hello");

            return borrowTransaction.DueDate;

       
        

        //var book = _bookRepository.Get(bookId);
        //var patron = _patronRepository.Get(patronId);

        //if (book != null && book.IsAvailable && patron != null)
        //{
        //    book.IsAvailable = false;
        //    _bookRepository.Update(book);

        //    var borrowTransaction = new BorrowTransaction
        //    {
        //        BookID = bookId,
        //        PatronID = patronId,
        //        BorrowDate = DateTime.Now,
        //        DueDate = DateTime.Now.AddDays(14)
        //    };
        //    _borrowTransactionRepository.Add(borrowTransaction);

        //    return borrowTransaction;
        //}
        //else if (book == null || !book.IsAvailable)
        //{
        //    throw new BookNotAvailableException();
        //}
        //else if (patron == null)
        //{
        //    throw new PatronNotFoundException();
        //}
        //return null;
    }

}
