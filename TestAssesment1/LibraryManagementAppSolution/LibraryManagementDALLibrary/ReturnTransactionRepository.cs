using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementModelLibrary;

namespace LibraryManagementDALLibrary
{
    public class ReturnTransactionRepository : IRepository<string, ReturnTransaction>
    {
        readonly Dictionary<string, ReturnTransaction> returnTransactions;

        public ReturnTransactionRepository()
        {
            returnTransactions = new Dictionary<string, ReturnTransaction>();
        }

        public ReturnTransaction Add(ReturnTransaction item)
        {
            if (returnTransactions.ContainsKey(item.BookID))
            {
                return null;
            }
            returnTransactions.Add(item.BookID, item);
            return item;
        }

        public ReturnTransaction Get(string key)
        {
            return returnTransactions.ContainsKey(key) ? returnTransactions[key] : null;
        }

        public List<ReturnTransaction> GetAll()
        {
            if (returnTransactions.Count == 0)
                return null;
            return returnTransactions.Values.ToList();
        }

        public ReturnTransaction Update(ReturnTransaction item)
        {
            if (returnTransactions.ContainsKey(item.BookID))
            {
                returnTransactions[item.BookID] = item;
                return item;
            }
            return null;
        }
    }
}
