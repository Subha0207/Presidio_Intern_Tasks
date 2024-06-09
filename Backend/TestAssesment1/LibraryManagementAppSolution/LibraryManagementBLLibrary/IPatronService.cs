using LibraryManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementBLLibrary
{
    public interface IPatronService
    {

        string AddPatron(Patron patron);
        List<Patron> GetPatronsByName(string name);
        Patron GetPatronById(string patronId);
        List<Patron> GetAllPatrons();
    }
}
