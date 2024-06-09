using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface ISolutionBL
    {
        Task<RequestSolution> ProvideSolution(RequestSolution solution);
        Task<IList<RequestSolution>> ViewAllSolutions();
        Task<RequestSolution> ViewSolutionById(int id);
        Task<RequestSolution> UpdateRespondToSolution(string comment, int solutionId);
         Task<IEnumerable<RequestSolution>> GetAllSolutionsForRequest(int requestId);
         Task<RequestSolution> UpdateSolutionStatusToDone(int requestId);

    }
}
