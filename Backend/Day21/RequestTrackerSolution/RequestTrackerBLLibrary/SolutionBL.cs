using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using RequestTrackerModelLibrary.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class SolutionBL : ISolutionBL
    {
        private readonly IRepository<int, RequestSolution> _repository;

        public SolutionBL()
        {
            IRepository<int, RequestSolution> repo = new RequestSolutionRepository(new RequestTrackerContext());
            _repository = repo;
        }
        public async Task<RequestSolution> ProvideSolution(RequestSolution solution)
        {
            var result = await _repository.Add(solution);
            return result;
            throw new NotImplementedException();
        }
        public async Task<RequestSolution> ViewSolutionById(int id)
        {
            var solution = await _repository.Get(id);
            return solution;
            throw new NotImplementedException();
        }
        public async Task<IList<RequestSolution>> ViewAllSolutions()
        {
            var solutions = await _repository.GetAll();
            return solutions;
            throw new NotImplementedException();
        }

        
        public async Task<RequestSolution> ViewAllSolutionByEmpId(int loggedInEmployeeId)
        {
            var solution = await _repository.Get(loggedInEmployeeId);
            return solution;
        }
        public async Task<IEnumerable<RequestSolution>> GetAllSolutionsForRequest(int requestId)
        {
            // Get all solutions from the repository
            var allSolutions = await _repository.GetAll();

            // Filter the solutions for the given request id
            var solutionsForRequest = allSolutions.Where(solution => solution.RequestId == requestId);

            return solutionsForRequest;
        }
        
        public async Task<RequestSolution> UpdateSolutionStatusToDone(int requestId)
        {
            // Get all solutions for the given request id
            var solutionsForRequest = await GetAllSolutionsForRequest(requestId);

            RequestSolution lastUpdatedSolution = null;

            // Iterate over each solution and update the status
            foreach (var solution in solutionsForRequest)
            {
                // Update the SolutionStatus to "Done"
                solution.IsSolved = true;

                // Update the solution in the repository
                lastUpdatedSolution = await _repository.Update(solution);
            }

            // Return the last updated solution
            return lastUpdatedSolution;
        }



        public async Task<RequestSolution> UpdateRespondToSolution( string comment, int solutionId)
        {
            // Get the solution with the given id
            var solution = await _repository.Get(solutionId);

            // Update the RequestRaiserComment
            solution.RequestRaiserComment = comment;

            // Update the solution in the repository
            var updatedSolution = await _repository.Update(solution);

            return updatedSolution;
        }
        

        
    }
}
