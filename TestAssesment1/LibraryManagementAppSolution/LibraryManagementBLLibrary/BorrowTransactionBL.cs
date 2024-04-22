using LibraryManagementBLLibrary.BookExceptions;
using LibraryManagementDALLibrary;
using LibraryManagementModelLibrary;

namespace LibraryManagementBLLibrary
{
    public class BorrowTransactionBL : IBorrowTransactionService
    {
        private readonly BorrowTransactionRepository _borrowTransactionRepository;
        private readonly BookRepository _bookRepository; // Assuming you have a BookRepository

        public BorrowTransactionBL(BorrowTransactionRepository borrowTransactionRepository, BookRepository bookRepository)
        {
            _borrowTransactionRepository = borrowTransactionRepository;
            _bookRepository = bookRepository;
        }

        // Function to Get Available Book by ID
        public Book GetAvailableBookById(string bookId)
        {
            var book = _bookRepository.Get(bookId);
            if (book != null && book.IsAvailable == true)
            {
                return book;
            }
            throw new NoBookDataAvailableException();
        }

        public string CheckAndBorrowBook(string bookId)
        {
            var book = GetAvailableBookById(bookId);
            if (book == null)
            {
                return "Book does not exist";
            }

            var borrowTransaction = _borrowTransactionRepository.Get(bookId);
            if (borrowTransaction != null)
            {
                return "Book is already borrowed";
            }

            borrowTransaction = new BorrowTransaction
            {
                BookID = bookId,
                BorrowDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(14) // Assuming the due date is 2 weeks from now
            };

            _borrowTransactionRepository.Add(borrowTransaction);

            book.IsAvailable = false;
            _bookRepository.Update(book);

            return "Book borrowed successfully";
        }

    }
}
