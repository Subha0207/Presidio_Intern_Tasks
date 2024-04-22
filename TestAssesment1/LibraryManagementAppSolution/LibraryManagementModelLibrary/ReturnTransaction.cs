using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementModelLibrary
{
    public class ReturnTransaction
    {
        public string PatronID { get; set; }
        public string BookID { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal LateFees { get; set; }
    }
}
