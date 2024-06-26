﻿using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using RequestTrackerModelLibrary.Migrations;
using System.Threading.Channels;


namespace RequestTrackerFEAPP
{
    public class Program
    {
        RequestFrontEnd requestFrontEnd = new RequestFrontEnd();
        SolutionFrontEnd solutionFrontEnd = new SolutionFrontEnd();
        FeedbackFrontEnd feedBackFrontEnd = new FeedbackFrontEnd();
        SolutionFeedbackAdminBL solutionFeedbackAdminBL = new SolutionFeedbackAdminBL();

        public int loggedInEmployeeId;

        async Task EmployeeLoginAsync(int username, string password)
        {
            Employee employee = new Employee()
            {
                Password = password,
                Id = username
            };
            IEmployeeLoginBL employeeLoginBL = new EmployeeLoginBL();
            loggedInEmployeeId = employee.Id;
            var result = await employeeLoginBL.Login(employee);
            if (result != null)
            {
                employee = result;
                await Console.Out.WriteLineAsync($"Login Success as  {employee.Role}");
                await DisplayMenu(employee.Role);
            }
            else
            {
                Console.Out.WriteLine("Invalid username or password");
            }
        }


        async Task DisplayMenu(string role)
        {
            int choice=0;
            do
            {
                switch (role)
                {
                    case "User":
                        await Console.Out.WriteLineAsync("Please choose an option:");
                        await Console.Out.WriteLineAsync("1. Raise Request");
                        await Console.Out.WriteLineAsync("2. View Request Status");
                        await Console.Out.WriteLineAsync("3. View Solutions");
                        await Console.Out.WriteLineAsync("4. Give Feedback");
                        await Console.Out.WriteLineAsync("5. Respond to Solution");
                        await Console.Out.WriteLineAsync("Enter -1 to EXIT");
                        choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case -1:
                                await Console.Out.WriteLineAsync("Logged out successfully");
                                Console.Out.WriteLine("-------------------------");
                                await new Program().GetLoginDeatils();
                                break;
                            case 1:
                                await requestFrontEnd.RaiseRequestDetails(loggedInEmployeeId);
                                break;
                            case 2:
                                await requestFrontEnd.ViewRequestStatus();
                                break;
                            case 3:
                                await solutionFrontEnd.ViewSolutionByIdDetails();
                                break;
                            case 4:
                                await feedBackFrontEnd.GiveFeedbackDetails(loggedInEmployeeId);

                                break;
                            case 5:
                                await solutionFrontEnd.RespondToSolution();

                                break;
                            default:
                                await Console.Out.WriteLineAsync("Invalid choice. Please choose a valid option.");
                                break;
                        }
                        break;
                    case "Admin":
                        await Console.Out.WriteLineAsync("Please choose an option:");
                        await Console.Out.WriteLineAsync("1. Raise Request");
                        await Console.Out.WriteLineAsync("2. View Request Status (All Requests)");
                        await Console.Out.WriteLineAsync("3. View Solutions (All Solutions)");
                        await Console.Out.WriteLineAsync("4. Give Feedback (Only for request raised by them)");
                        await Console.Out.WriteLineAsync("5. Respond to Solution (Only for request raised by them)");
                        await Console.Out.WriteLineAsync("6. Provide Solution");
                        await Console.Out.WriteLineAsync("7. Mark Request as Closed");
                        await Console.Out.WriteLineAsync("8. View Feedbacks (Only feedbacks given to them)");
                        await Console.Out.WriteLineAsync("Enter -1 to EXIT");
                        choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case -1:
                                await Console.Out.WriteLineAsync("Logged out successfully");
                                Console.Out.WriteLine("-------------------------");
                                await new Program().GetLoginDeatils();
                                break;
                            case 1:
                                await requestFrontEnd.RaiseRequestDetails(loggedInEmployeeId);
                                break;
                            case 2:

                                await requestFrontEnd.ViewAllRequests();
                                break;
                            case 3:
                                await solutionFrontEnd.ViewAllSolutions();
                                break;
                            case 4:
                                await feedBackFrontEnd.GiveFeedbackAdmin(loggedInEmployeeId);

                                break;
                            case 5:
                                await solutionFrontEnd.GetUserInputAndUpdateSolution(loggedInEmployeeId);

                                break;
                            case 6:

                                await solutionFrontEnd.ProvideSolutionDetails(loggedInEmployeeId);
                                break;
                            case 7:
                                await requestFrontEnd.MarkRequestClosed(loggedInEmployeeId);
                                break;
                            case 8:
                                var feedbacks = await solutionFeedbackAdminBL.GetFeedbacksByEmployeeId(loggedInEmployeeId);
                                foreach (var feedback in feedbacks)
                                {
                                    // Display the feedback details
                                    Console.Out.WriteLine($"Feedback ID: {feedback.FeedbackId}, Solution ID: {feedback.SolutionId}, Feedback: {feedback.Remarks}");
                                }
                                break;
                            default:
                                await Console.Out.WriteLineAsync("Invalid choice. Please choose a valid option.");
                                break;
                        }
                        break;
                }
            } while (choice != -1);
         
        }
        
        
        

        async Task GetLoginDeatils()
        {
            await Console.Out.WriteLineAsync("Please enter Employee Id");
            int id = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Please enter your password");
            string password = Console.ReadLine() ?? "";
            await EmployeeLoginAsync(id,password);
        }
        static async Task Main(string[] args)
        {
            await new Program().GetLoginDeatils();
        }
    }
}
