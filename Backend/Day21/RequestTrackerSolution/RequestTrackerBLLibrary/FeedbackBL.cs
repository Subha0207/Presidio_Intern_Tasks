using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class FeedbackBL : IFeedbackBL
    {
        
        private readonly IRepository<int, SolutionFeedback> _repository;

        public FeedbackBL()
        {
            IRepository<int, SolutionFeedback> repo = new SolutionFeedbackRepository(new RequestTrackerContext());
            _repository = repo;
        }
        public async Task<SolutionFeedback> AddFeedback(SolutionFeedback solutionFeedback)
        {
            var result = await _repository.Add(solutionFeedback);
            return result;
        }
        public async Task<SolutionFeedback>ViewFeedback(int feedbackId)
        {
            var result = await _repository.Get(feedbackId);
            return result;
        }
        public async Task<IEnumerable<SolutionFeedback>> ViewAllFeedbacks()
        {
            var result = await _repository.GetAll();
            return result;
        }





    }

}


 

