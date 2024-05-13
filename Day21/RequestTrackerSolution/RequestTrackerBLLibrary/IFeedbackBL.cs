using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IFeedbackBL
    {
      public  Task <SolutionFeedback>AddFeedback(SolutionFeedback solutionFeedback);
        public  Task<IEnumerable<SolutionFeedback>> ViewAllFeedbacks();


    }
}
