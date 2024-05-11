using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class RequestSolutionRepository : IRepository<int, RequestSolution>
    {
        private readonly RequestTrackerContext _context;

        public RequestSolutionRepository(RequestTrackerContext context)
        {
            _context = context;
        }

        public async Task<RequestSolution> Add(RequestSolution entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<RequestSolution> Delete(int key)
        {
            var requestSolution = await Get(key);
            if (requestSolution != null)
            {
                _context.RequestSolutions.Remove(requestSolution);
                await _context.SaveChangesAsync();
            }
            return requestSolution;
        }

        public virtual async Task<RequestSolution> Get(int key)
        {
            var requestSolution = _context.RequestSolutions.SingleOrDefault(r => r.SolutionId == key);
            return requestSolution;
        }

        public virtual async Task<IList<RequestSolution>> GetAll()
        {
            return await _context.RequestSolutions.ToListAsync();
        }

        public async Task<RequestSolution> Update(RequestSolution entity)
        {
            var requestSolution = await Get(entity.SolutionId);
            if (requestSolution != null)
            {
                _context.Entry<RequestSolution>(requestSolution).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return entity;
        }
    }
}
