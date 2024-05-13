using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerFEAPP
{
    public class SolutionFrontEnd
    {
        public async Task ViewAllSolutions()
        {
            ISolutionBL solutionBL = new SolutionBL();
            var solutions = await solutionBL.ViewAllSolutions();

            foreach (var solution in solutions)
            {
                Console.WriteLine($"Solution ID: {solution.SolutionId}");
                Console.WriteLine($"Request ID: {solution.RequestId}");
                Console.WriteLine($"Solution Description: {solution.SolutionDescription}");
                Console.WriteLine($"Solved Employee ID: {solution.SolvedBy}");
                Console.WriteLine($"Solved Date: {solution.SolvedDate}");
                Console.WriteLine($"Solved Status: {solution.IsSolved}");
                Console.WriteLine($"Request Raiser Comment: {solution.RequestRaiserComment}");
                Console.WriteLine("-----------------------------------");
            }
        }

        public async Task ViewSolutionByIdDetails()
        {

            await Console.Out.WriteLineAsync("Please enter Solution Id");
            int solutionId = Convert.ToInt32(Console.ReadLine());
            await ViewSolutionById(solutionId);
        }

        public async Task ProvideSolutionDetails()
        {
            await Console.Out.WriteLineAsync("Please enter Employee Id");
            int empId = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Please enter Request Id");
            int requestId = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Please enter Solution message");
            string solutionDescription = Console.ReadLine() ?? "";
            await ProvideSolution(solutionDescription, requestId, empId);

        }
        public async Task ViewSolutionById(int solutionId)
        {
            ISolutionBL solutionBL = new SolutionBL();
            var result = await solutionBL.ViewSolutionById(solutionId);
            if (result != null)
            {
                Console.WriteLine($"Solution ID: {result.SolutionId}");
                Console.WriteLine($"Request ID: {result.RequestId}");
                Console.WriteLine($"Solution Description: {result.SolutionDescription}");
                Console.WriteLine($"Solved Employee ID: {result.SolvedBy}");
                Console.WriteLine($"Solved Date: {result.SolvedDate}");
                Console.WriteLine($"Solved Status: {result.IsSolved}");
                Console.WriteLine($"Request Raiser Comment: {result.RequestRaiserComment}");
                Console.WriteLine("-----------------------------------");
            }
            else
            {
                Console.Out.WriteLine("Invalid requestID");
            }
        }


        public async Task ProvideSolution(string solutionDescription, int requestId, int empId)
        {
            // Get the current date
            DateTime currentDate = DateTime.Now;

            // Set the initial solution status
            bool isSolved = false;

            // Create a new RequestSolution object
            RequestSolution requestSolution = new RequestSolution()
            {
                RequestId = requestId,
                SolutionDescription = solutionDescription,
                SolvedBy = empId,
                SolvedDate = currentDate,
                IsSolved = isSolved,
                RequestRaiserComment = null
            };

            // Create a new instance of the business logic class
            ISolutionBL requestSolutionBL = new SolutionBL();

            // Call the ProvideSolution method of the business logic class
            var result = await requestSolutionBL.ProvideSolution(requestSolution);

            // Check the result and display appropriate message
            if (result != null)
            {
                await Console.Out.WriteLineAsync($"Solution added successfully with Solution Id: {result.SolutionId}");
            }
            else
            {
                Console.Out.WriteLine("Invalid solution");
            }
        }
        public async Task GetUserInputAndUpdateSolution()
        {

            Console.WriteLine("Please enter the employee id:");
            int empId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the solution id:");
            int solutionId = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Please enter your comment:");
            string comment = Console.ReadLine();


            var solutionRequestBL = new SolutionRequestBL();


            try
            {
                var updatedSolution = await solutionRequestBL.UpdateRespondToSolution(solutionId, empId, comment);
                Console.WriteLine("Solution updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public async Task RespondToSolution()
        {
            ISolutionBL solutionBL = new SolutionBL();

            Console.WriteLine("Enter the Solution ID");
            int solutionId = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Enter Comment For Solution");
            string comment = Console.ReadLine() ?? "";
            var request = await solutionBL.UpdateRespondToSolution(comment, solutionId);
            if (request != null)
            {
                Console.WriteLine($"Response Comment for Solution has been added Successfully");
            }
            else
            {
                Console.WriteLine("Request not found or could not be closed.");
            }
        }

    }
}
