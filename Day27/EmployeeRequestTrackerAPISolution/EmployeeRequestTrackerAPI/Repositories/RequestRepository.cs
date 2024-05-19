using EmployeeRequestTrackerAPI.Contexts;
using EmployeeRequestTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequestTrackerAPI.Repositories
{
    public class RequestRepository : IRepository<int, Request>
    {
        private readonly RequestTrackerContext _context;

        public RequestRepository(RequestTrackerContext requestTrackerContext)
        {
            _context = requestTrackerContext;
        }

        public async Task<Request> Add(Request item)
        {
            try
            {
                _context.Requests.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Request> Delete(int key)
        {
            try
            {
                var item = await Get(key);
                if (item != null)
                {
                    _context.Requests.Remove(item);
                    await _context.SaveChangesAsync();
                    return item;
                }
                throw new Exception("Cannot get item details");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Request> Update(Request item)
        {
            try
            {
                var user = await Get(item.RequestNumber);
                if (user != null)
                {
                    _context.Requests.Update(item);
                    await _context.SaveChangesAsync();
                    return item;
                }
                throw new Exception("Cannot get item details");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Request> Get(int key)
        {
            try
            {
                return await _context.Requests.SingleOrDefaultAsync(r => r.RequestNumber == key);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Request>> Get()
        {
            try
            {
                return await _context.Requests.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        
    }
}
