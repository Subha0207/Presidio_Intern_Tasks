﻿using RequestTrackerBLLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerFEAPP
{
    public class FeedbackFrontEnd
    {
        public async Task GiveFeedbackDetails()
        {
            IFeedbackBL feedbackBL = new FeedbackBL();

            Console.WriteLine("Enter the Employee ID");
            int empId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Solution ID");
            int solutionId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Rating out of 5");
            float rating = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Enter Feedback");
            string feedback = Console.ReadLine() ?? "";

            // Create a SolutionFeedback instance
            RequestTrackerModelLibrary.SolutionFeedback solutionFeedback = new RequestTrackerModelLibrary.SolutionFeedback
            {
                FeedbackBy = empId,
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
        public async Task GetFeedbackByEmpId()
        {
            Console.Write("Enter Employee ID: ");
            int empId = Convert.ToInt32(Console.ReadLine());
            FeedbackSolutionAdminBL feedbackSolutionAdminBL = new FeedbackSolutionAdminBL();

            IList<RequestTrackerModelLibrary.SolutionFeedback> feedbacks = await feedbackSolutionAdminBL.ViewFeedbacksForEmployee(empId);

            Console.WriteLine($"Feedbacks for Employee ID {empId}:");
            foreach (var feedback in feedbacks)
            {
                Console.WriteLine($"Feedback ID: {feedback.FeedbackId}, Solution ID: {feedback.SolutionId}, Feedback: {feedback.Remarks}");
            }
        }
    }
}