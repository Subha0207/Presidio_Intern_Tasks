using RequestTrackerBLLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerFEAPP
{
    public class FeedbackFrontEnd
    {
        public async Task GiveFeedbackDetails(int loggedInEmployeeId)
        {
            IFeedbackBL feedbackBL = new FeedbackBL();

            Console.WriteLine("Enter the Solution ID");
            int solutionId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Rating out of 5");
            float rating = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Enter Feedback");
            string feedback = Console.ReadLine() ?? "";

            // Create a SolutionFeedback instance
            RequestTrackerModelLibrary.SolutionFeedback solutionFeedback = new RequestTrackerModelLibrary.SolutionFeedback
            {
                FeedbackBy = loggedInEmployeeId,
                SolutionId = solutionId,
                Rating = rating,
                Remarks = feedback,
                FeedbackDate = DateTime.Now
            };

            // Pass the solutionFeedback instance to AddFeedback
            var result = await feedbackBL.AddFeedback(solutionFeedback);
            if (result != null)
            {
                Console.WriteLine($"Feedback for solution is given successfully");
            }
            else
            {
                Console.WriteLine("Unable to add feedback");
            }
        }

        public async Task GiveFeedbackAdmin(int loggedInEmployeeId)
        {
            ISolutionBL solutionBL = new SolutionBL();
            var solution = await solutionBL.ViewSolutionById(loggedInEmployeeId);
            if (solution != null)
            {
                var solutionId = solution.SolutionId;
                IFeedbackBL feedbackBL = new FeedbackBL();
                var feedbacks = await feedbackBL.ViewAllFeedbacks();
                if (feedbacks != null)
                {
                    foreach (var feedback in feedbacks)
                    {
                        if (feedback.SolutionId == solutionId)
                        {
                            try
                            {
                                await GiveFeedbackDetails(loggedInEmployeeId);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"An error occurred: {ex.Message}");
                            }
                        }
                    }
                }
            }
        }



    }
}
