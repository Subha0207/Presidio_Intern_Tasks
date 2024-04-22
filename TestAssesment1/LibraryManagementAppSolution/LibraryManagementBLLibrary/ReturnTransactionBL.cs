using LibraryManagementDALLibrary;
using LibraryManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryManagementBLLibrary.ReturnExceptions;
namespace LibraryManagementBLLibrary
{
    public class ReturnTransactionBL : IReturnTransactionService
    {
        private readonly ReturnTransactionRepository _returnRepository;
        private readonly BookRepository _bookRepository; // Add this line

        public ReturnTransactionBL()
        {
        }

        public ReturnTransactionBL(ReturnTransactionRepository returnRepository, BookRepository bookRepository) // Modify this line
        {
            _returnRepository = returnRepository;
            _bookRepository = bookRepository; // Add this line
        }

        public ReturnTransaction ReturnBook(string patronId, string bookId)
        {
            // Get the return transaction
            var returnTransaction = _returnRepository.Get(bookId);

            if (returnTransaction == null)
            {
                // Handle the case where the book has not been borrowed
                throw new InvalidReturnException();
            }

            // Update the return transaction
            returnTransaction.ReturnDate = DateTime.Now;

            // Calculate late fees if any
            var daysLate = (DateTime.Now - returnTransaction.ReturnDate).Days;
            if (daysLate > 0)
            {
                returnTransaction.LateFees = daysLate * 5.00m; // Assume a late fee of 50 cents per day
            }

            // Update the return transaction in the repository
            _returnRepository.Update(returnTransaction);

            // Get the book from the repository
            var book = _bookRepository.Get(bookId);

            if (book != null)
            {
                // Update the availability of the book
                book.IsAvailable = true;

                // Update the book in the repository
                _bookRepository.Update(book);
            }

            return returnTransaction;
        }
    }
}
