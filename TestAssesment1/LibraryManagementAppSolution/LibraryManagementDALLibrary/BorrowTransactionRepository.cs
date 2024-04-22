using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementModelLibrary;

namespace LibraryManagementDALLibrary
{
    public class BorrowTransactionRepository : IRepository<string, BorrowTransaction>
    {
        readonly Dictionary<string, BorrowTransaction> _transactions;

        public BorrowTransactionRepository()
        {
            _transactions = new Dictionary<string, BorrowTransaction>();
        }

        public BorrowTransaction Add(BorrowTransaction item)
        {
            if (_transactions.ContainsKey(item.BookID))
            {
                return null;
            }
            _transactions.Add(item.BookID, item);
            return item;
        }

        public BorrowTransaction Get(string key)
        {
            return _transactions.ContainsKey(key) ? _transactions[key] : null;
        }

        public List<BorrowTransaction> GetAll()
        {
            if (_transactions.Count == 0)
                return null;
            return _transactions.Values.ToList();
        }

        public BorrowTransaction Update(BorrowTransaction item)
        {
            if (_transactions.ContainsKey(item.BookID))
            {
                _transactions[item.BookID] = item;
                return item;
            }
            return null;
        }
    }
}