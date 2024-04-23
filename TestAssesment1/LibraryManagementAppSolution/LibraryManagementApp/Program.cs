using LibraryManagementBLLibrary;
using LibraryManagementBLLibrary.BookBorrowExceptions;
using LibraryManagementBLLibrary.ReturnExceptions;
using LibraryManagementDALLibrary;
using LibraryManagementModelLibrary;
using System;

namespace LibraryManagementApp
{
    internal class Program
    {
        private static readonly BookRepository _bookRepository = new BookRepository();
        

        private static readonly BookBL _bookBL = new BookBL();
        private static readonly PatronBL _patronBL = new PatronBL();
        
        private static int _lastBookId = 0;
        private static int _lastPatronId = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO XYZ LIBRARY !");

            while (true)
            {
                Console.WriteLine("\nPlease select an option:");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Register Patron");
                Console.WriteLine("3. Search for a book/Patron");
                Console.WriteLine("4. Borrow a book");
                Console.WriteLine("5. Return a book");
                Console.WriteLine("6. Exit");

                var option = Console.ReadLine();

                // If the user enters "stop", exit the application
                if (option.ToLower() == "stop")
                {
                    Console.WriteLine("Exiting the application. Goodbye!");
                    return;
                }

                switch (option)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        AddPatron();
                        break;
                    case "3":
                        SearchBook();
                        break;
                    case "4":
                       BorrowBook();
                        break;
                    case "5":
                        ReturnBook();
                        break;
                    case "6":
                        Console.WriteLine("Thank you for using XYZ Library. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private static void AddBook()
        {
            Console.WriteLine("Enter the book title:");
            var title = Console.ReadLine();
            Console.WriteLine("Enter the book author:");
            var author = Console.ReadLine();
            Console.WriteLine("Enter the book genre:");
            var genre = Console.ReadLine();
            Console.WriteLine("Enter the book publication date (yyyy-mm-dd):");
            var publicationDate = DateTime.Parse(Console.ReadLine());
            var bookId = (++_lastBookId).ToString();

            var book = new Book { BookID = bookId, Title = title, Author = author, Genre = genre, PublicationDate = publicationDate, IsAvailable = true };
            var addedBookId = _bookBL.AddBook(book);

            Console.WriteLine($"Book added with ID: {addedBookId}");
        }
        private static void AddPatron()
        {
            Console.WriteLine("Enter the patron's name:");
            var name = Console.ReadLine();
            Console.WriteLine("Enter the patron's contact info:");
            var contactInfo = Console.ReadLine();

            var patronId = "P" + (++_lastPatronId).ToString();

            var patron = new Patron { PatronID = patronId, PatronName = name, ContactInfo = contactInfo };
            var addedPatronId = _patronBL.AddPatron(patron);

            Console.WriteLine($"Patron added with ID: {addedPatronId}");
        }
        private static void SearchBook()
        {
            while (true)
            {
                Console.WriteLine("\nPlease select a search option:");
                Console.WriteLine("1. Search patron by ID");
                Console.WriteLine("2. Search patron by name");
                Console.WriteLine("3. Search book by ID");
                Console.WriteLine("4. Get all available books");
                Console.WriteLine("5. Back to main menu");

                var option = Console.ReadLine();

                // If the user enters "stop", exit the application
                if (option.ToLower() == "stop")
                {
                    Console.WriteLine("Exiting the application. Goodbye!");
                    return;
                }

                switch (option)
                {
                    case "1":
                        SearchPatronById();
                        break;
                    case "2":
                        SearchPatronByName();
                        break;
                    case "3":
                        GetAndDisplayBookDetails();

                        break;
                    case "4":
                        GetAllAvailableBooks();
                        break;
                    case "5":
                        return; // Go back to the main menu
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private static void SearchBookById()
        {
            throw new NotImplementedException();
        }

        private static void GetAllAvailableBooks()
        {
            var books = _bookBL.GetAllAvailableBooks();
            if (books.Count > 0)
            {
                Console.WriteLine("\nAvailable Books:");
                foreach (var book in books)
                {
                    Console.WriteLine($"ID: {book.BookID}, Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}, Publication Date: {book.PublicationDate}");
                }
            }
            else
            {
                Console.WriteLine("No books are currently available.");
            }
        }
        public static void GetAndDisplayBookDetails()
        {
            Console.Write("Enter the book ID: ");
            string bookId = Console.ReadLine();

            try
            {
                Book book = _bookBL.GetAvailableBookById(bookId);
                Console.WriteLine($"Book ID: {book.BookID}");
                Console.WriteLine($"Book Title: {book.Title}");
                Console.WriteLine($"Book Author: {book.Author}");
                // Add more properties as needed
            }
            catch (BookNotAvailableException)
            {
                Console.WriteLine("The requested book is not available.");
            }
        }
        private static void SearchPatronById()
        {
            Console.WriteLine("Enter the patron ID:");
            var id = Console.ReadLine();
            var patron = _patronBL.GetPatronById(id);
            if (patron != null)
            {
                Console.WriteLine($"ID: {patron.PatronID}, Name: {patron.PatronName}, Contact Info: {patron.ContactInfo}");
            }
            else
            {
                Console.WriteLine("No patron found with the given ID.");
            }
        }

        private static void SearchPatronByName()
        {
            Console.WriteLine("Enter the patron name:");
            var name = Console.ReadLine();
            var patrons = _patronBL.GetPatronsByName(name);
            if (patrons.Count > 0)
            {
                Console.WriteLine("\nPatrons:");
                foreach (var patron in patrons)
                {
                    Console.WriteLine($"ID: {patron.PatronID}, Name: {patron.PatronName}, Contact Info: {patron.ContactInfo}");
                }
            }
            else
            {
                Console.WriteLine("No patrons found with the given name.");
            }
        }

        public static void BorrowBook()
        {
            Console.WriteLine("Enter the book ID:");
            var bookId = Console.ReadLine();

            

            
        }
        private static void ReturnBook()
        {
            Console.WriteLine("Enter your patron ID:");
            var patronId = Console.ReadLine();

            Console.WriteLine("Enter the book ID:");
            var bookId = Console.ReadLine();

            try
            {
               // var returnTransaction = _returnTransactionBL.ReturnBook(patronId, bookId);
              //  if (returnTransaction.LateFees > 0)
                //{
               //     Console.WriteLine($"Book returned late. Late fees: {returnTransaction.LateFees:C}");
               // }
                //else
               // {
                   // Console.WriteLine("Book returned on time. No late fees.");
                //}
            }
            catch (InvalidReturnException)
            {
                Console.WriteLine("Invalid return. The book has not been borrowed.");
            }
        }

    }
}
