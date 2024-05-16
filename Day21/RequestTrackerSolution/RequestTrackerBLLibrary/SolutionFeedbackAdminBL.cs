using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class SolutionFeedbackAdminBL
    {
        private readonly IRepository<int, RequestSolution> _solutionRepository;
        private readonly IRepository<int, SolutionFeedback> _feedbackRepository;

        public SolutionFeedbackAdminBL()
        {
            _solutionRepository = new RequestSolutionRepository(new RequestTrackerContext());
            _feedbackRepository = new SolutionFeedbackRepository(new RequestTrackerContext());
        }

        public async Task<IEnumerable<SolutionFeedback>> GetFeedbacksByEmployeeId(int employeeId)
        {
            // Get all solutions provided by the employee
            var solutions = await _solutionRepository.GetAll();
            var employeeSolutions = solutions.Where(s => s.SolvedBy == employeeId);

            // Get all feedbacks for the solutions provided by the employee
            var feedbacks = await _feedbackRepository.GetAll();
            var employeeFeedbacks = feedbacks.Where(f => employeeSolutions.Any(s => s.SolutionId == f.SolutionId));

            return employeeFeedbacks;
        }
    }
}

