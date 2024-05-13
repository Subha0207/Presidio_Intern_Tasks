using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class FeedbackSolutionAdminBL
    {
        private readonly SolutionBL _solutionBL;
        private readonly RequestBL _requestBL;
        private readonly FeedbackBL _feedbackBL;

        public FeedbackSolutionAdminBL()
        {
            _solutionBL = new SolutionBL();
            _requestBL = new RequestBL();
            _feedbackBL = new FeedbackBL();
        }

        public async Task<IList<SolutionFeedback>> ViewFeedbacksForEmployee(int empId)
        {
            // Get all requests raised by the employee
            var requests = await _requestBL.ViewAllRequests();
            var employeeRequests = requests.Where(r => r.RequestRaisedBy == empId);

            // Get all solutions for the requests
            var solutions = await _solutionBL.ViewAllSolutions();
            var employeeSolutions = solutions.Where(s => employeeRequests.Any(r => r.RequestNumber == s.RequestId));

            // Get all feedbacks for the solutions
            var feedbacks = await _feedbackBL.ViewAllFeedbacks();
            var employeeFeedbacks = feedbacks.Where(f => employeeSolutions.Any(s => s.SolutionId == f.SolutionId));
            return employeeFeedbacks.ToList();
        }
    }
}
