using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class SolutionRequestBL
    {
        private readonly IRepository<int, RequestSolution> _solutionRepository;
        private readonly IRepository<int, Request> _requestRepository;

        public SolutionRequestBL()
        {
            _solutionRepository = new RequestSolutionRepository(new RequestTrackerContext());
            _requestRepository = new RequestRepository(new RequestTrackerContext());
        }

        public async Task<RequestSolution> UpdateRespondToSolution(int solutionId, int empId, string comment)
        {
            // Get the solution with the given id
            var solution = await _solutionRepository.Get(solutionId);

            // Get the request associated with the solution
            var request = await _requestRepository.Get(solution.RequestId);

            // Check if the request was raised by the given employee
            if (request.RequestRaisedBy == empId)
            {
                // Update the RequestRaiserComment
                solution.RequestRaiserComment = comment;

                // Update the solution in the repository
                var updatedSolution = await _solutionRepository.Update(solution);

                return updatedSolution;
            }
            else
            {
                throw new Exception("The request associated with the solution was not raised by the employee with the given id.");
            }
        }
    }
}
