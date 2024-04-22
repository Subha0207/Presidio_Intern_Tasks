using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementModelLibrary
{
    public class BorrowTransaction
    {
        public string PatronID { get; set; }
        public string BookID { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
    }

}
