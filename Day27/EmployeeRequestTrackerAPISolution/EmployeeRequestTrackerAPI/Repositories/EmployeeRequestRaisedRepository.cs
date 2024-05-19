using EmployeeRequestTrackerAPI.Contexts;
using EmployeeRequestTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequestTrackerAPI.Repositories
{
    public class EmployeeRequestRaisedRepository : EmployeeRepository
    {
        protected readonly RequestTrackerContext _context;

        public EmployeeRequestRaisedRepository(RequestTrackerContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Employee> Get(int id)
        {
            try
            {
                return await _context.Employees.Include(e => e.RequestsRaised).SingleOrDefaultAsync(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override async Task<IEnumerable<Employee>> Get()
        {
            try
            {
                return await _context.Employees.Include(e => e.RequestsRaised).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
