using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System.Threading.Channels;

namespace RequestTrackerFEAPP
{
    internal class Program
    {
        
        async Task EmployeeLoginAsync(int username, string password)
        {
            Employee employee = new Employee()
            {
                Password = password,
                Id = username
            };
            IEmployeeLoginBL employeeLoginBL = new EmployeeLoginBL();
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
        

        public static class RequestNumberGenerator
        {
            private static int _lastRequestNumber = 0;

            public static int GetNextRequestNumber()
            {
                _lastRequestNumber++;
                return _lastRequestNumber;
            }
        }

        async Task RaiseRequest(int requestRaisedBy, string requestMessage)
        {
            // Generate a unique request number
            int requestNumber = RequestNumberGenerator.GetNextRequestNumber();

            // Get the current date
            DateTime currentDate = DateTime.Now;

            // Set the initial request status
            string requestStatus = "Not Done";

            Request request = new Request()
            {
                RequestRaisedBy = requestRaisedBy,
                RequestMessage = requestMessage,
                RequestNumber = requestNumber,
                RequestDate = currentDate,
                RequestStatus = requestStatus
            };

            IRequestBL requestBL = new RequestBL();
            var result = await requestBL.RaiseRequest(request);
            if (result != null)
            {
                await Console.Out.WriteLineAsync($"Request added successfully");
            }
            else
            {
                Console.Out.WriteLine("Invalid request");
            }
        }

        async Task DisplayMenu(string role)
        {
            int choice;
            switch (role)
            {
                case "User":
                    await Console.Out.WriteLineAsync("Please choose an option:");
                    await Console.Out.WriteLineAsync("1. Raise Request");
                    await Console.Out.WriteLineAsync("2. View Request Status");
                    await Console.Out.WriteLineAsync("3. View Solutions");
                    await Console.Out.WriteLineAsync("4. Give Feedback");
                    await Console.Out.WriteLineAsync("5. Respond to Solution");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            await new Program().RaiseRequestDetails();
                            break;
                        case 2:
                            // Call the method for "View Request Status"
                            break;
                        case 3:
                            // Call the method for "View Solutions"
                            break;
                        case 4:
                            // Call the method for "Give Feedback"
                            break;
                        case 5:
                            // Call the method for "Respond to Solution"
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
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            // Call the method for "Raise Request"
                            break;
                        case 2:
                            // Call the method for "View Request Status (All Requests)"
                            break;
                        case 3:
                            // Call the method for "View Solutions (All Solutions)"
                            break;
                        case 4:
                            // Call the method for "Give Feedback (Only for request raised by them)"
                            break;
                        case 5:
                            // Call the method for "Respond to Solution (Only for request raised by them)"
                            break;
                        case 6:
                            // Call the method for "Provide Solution"
                            break;
                        case 7:
                            // Call the method for "Mark Request as Closed"
                            break;
                        case 8:
                            // Call the method for "View Feedbacks (Only feedbacks given to them)"
                            break;
                        default:
                            await Console.Out.WriteLineAsync("Invalid choice. Please choose a valid option.");
                            break;
                    }
                    break;
            }
        }
        async Task RaiseRequestDetails() {

            await Console.Out.WriteLineAsync("Please enter Employee Id");
            int requestRaisedBy = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Please enter your Request message");
            string requestMessage = Console.ReadLine() ?? "";
            await RaiseRequest(requestRaisedBy,requestMessage);
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
