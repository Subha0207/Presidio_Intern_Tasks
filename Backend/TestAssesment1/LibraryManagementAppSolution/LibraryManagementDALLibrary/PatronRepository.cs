using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementModelLibrary;

namespace LibraryManagementDALLibrary
{
    public class PatronRepository : IRepository<string, Patron>
    {
        readonly Dictionary<string, Patron> _patrons;

        public PatronRepository()
        {
            _patrons = new Dictionary<string, Patron>();
        }

        public Patron Add(Patron item)
        {
            if (_patrons.ContainsKey(item.PatronID))
            {
                return null;
            }
            _patrons.Add(item.PatronID, item);
            return item;
        }

        

        public Patron Get(string key)
        {
            return _patrons.ContainsKey(key) ? _patrons[key] : null;
        }

        public List<Patron> GetAll()
        {
            if (_patrons.Count == 0)
                return null;
            return _patrons.Values.ToList();
        }

        public Patron Update(Patron item)
        {
            if (_patrons.ContainsKey(item.PatronID))
            {
                _patrons[item.PatronID] = item;
                return item;
            }
            return null;
        }
    }
}
