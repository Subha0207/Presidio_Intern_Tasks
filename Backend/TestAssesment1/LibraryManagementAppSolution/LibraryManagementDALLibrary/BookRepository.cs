
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementModelLibrary;

namespace LibraryManagementDALLibrary
{
    public class BookRepository : IRepository<string, Book>
    {
        readonly Dictionary<string, Book> _books;

        public BookRepository()
        {
            _books = new Dictionary<string, Book>();
        }

        public Book Add(Book item)
        {
            if (_books.ContainsKey(item.BookID))
            {
                return null;
            }
            _books.Add(item.BookID, item);
            return item;
        }

        public Book Get(string key)
        {

            if (_books.ContainsKey(key))
            {
                Console.WriteLine(_books[key].BookID);
                return _books[key];
            }


            return  null;
        }

        public List<Book> GetAll()
        {
            if (_books.Count == 0)
                return null;
            return _books.Values.ToList();
        }

        public Book Update(Book item)
        {
            if (_books.ContainsKey(item.BookID))
            {
                _books[item.BookID] = item;
                return item;
            }
            return null;
        }
    }
}
