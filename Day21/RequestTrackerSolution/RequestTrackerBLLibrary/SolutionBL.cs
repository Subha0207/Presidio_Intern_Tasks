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

        public async Task<IList<RequestSolution>> ViewAllSolutions()
        {
            var solutions = await _repository.GetAll();
            return solutions;
            throw new NotImplementedException();
        }

        public async Task<RequestSolution> ViewSolutionById(int id)
        {
            var solution = await _repository.Get(id);
            return solution;
            throw new NotImplementedException();
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
