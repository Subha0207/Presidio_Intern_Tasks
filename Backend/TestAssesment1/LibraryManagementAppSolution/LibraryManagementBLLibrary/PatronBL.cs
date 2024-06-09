using LibraryManagementModelLibrary;
using LibraryManagementDALLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementBLLibrary.PatronExceptions;

namespace LibraryManagementBLLibrary
{
    public class PatronBL : IPatronService
    {
        readonly IRepository<string, Patron> _patronRepository;
        public PatronBL()
        {
            _patronRepository = new PatronRepository();
        }

        //Function to Add Patron
        public string AddPatron(Patron patron)
        {
            var result = _patronRepository.Add(patron);

            if (result != null)
            {
                return result.PatronID;
            }
            throw new DuplicatePatronIDException();
        }

        //Function to Get Patron By ID
        public Patron GetPatronById(string patronId)
        {
            var patron = _patronRepository.Get(patronId);
            if (patron != null)
            {
                return patron;
            }
            throw new PatronNotFoundException();
        }

        //Function to Get All Patrons
        public List<Patron> GetAllPatrons()
        {
            var patrons = _patronRepository.GetAll();
            if (patrons != null)
            {
                return new List<Patron>(patrons);
            }
            throw new NoPatronDataAvailableException();
        }

        //Function to Get Patrons By Name
        public List<Patron> GetPatronsByName(string name)
        {
            var patrons = _patronRepository.GetAll();
            List<Patron> result = new List<Patron>();
            if (patrons != null)
            {
                foreach (var patron in patrons)
                {
                    if (patron.PatronName == name)
                    {
                        result.Add(patron);
                    }
                }
                return result;
            }
            throw new PatronNotFoundException();
        }
    }
}
