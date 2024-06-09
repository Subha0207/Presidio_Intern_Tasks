using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerFEAPP
{
    public class RequestFrontEnd
    {
       //public  async Task ViewRequestStatusById(int requestId)
       // {
       //     IRequestBL requestBL = new RequestBL();
       //     var result = await requestBL.ViewRequestById(requestId);
       //     if (result != null)
       //     {
       //         await Console.Out.WriteLineAsync($"Request status: {result.RequestStatus}");
       //     }
       //     else
       //     {
       //         Console.Out.WriteLine("Invalid requestID");
       //     }
       // }

        public async Task ViewRequestStatusById(int requestId)
        {
            try
            {
                IRequestBL requestBL = new RequestBL();
                var result = await requestBL.ViewRequestById(requestId);
                if (result != null)
                {
                    await Console.Out.WriteLineAsync($"Request status: {result.RequestStatus}");
                }
                else
                {
                    Console.Out.WriteLine("Invalid requestID");
                }
            }
            catch (Exception ex)
            {
                throw ;
            }
        }
        public async Task ViewRequestStatus()
        {


            await Console.Out.WriteLineAsync("Please enter Request Id");
            int requestId = Convert.ToInt32(Console.ReadLine());
            await ViewRequestStatusById(requestId);
        }
      public  async Task RaiseRequest(int  loggedInEmployeeId, string requestMessage)
        {
            // Get the current date
            DateTime currentDate = DateTime.Now;

            // Set the initial request status
            string requestStatus = "Not Done";

            Request request = new Request()
            {
                RequestRaisedBy = loggedInEmployeeId,
                RequestMessage = requestMessage,
                RequestDate = currentDate,
                RequestStatus = requestStatus,
                ClosedDate = null,
                RequestClosedBy = null
            };

            IRequestBL requestBL = new RequestBL();
            var result = await requestBL.RaiseRequest(request);
            if (result != null)
            {
                await Console.Out.WriteLineAsync($"Request added successfully with Request Number: {result.RequestNumber}");
            }
            else
            {
                Console.Out.WriteLine("Invalid request");
            }
        }

      public  async Task ViewAllRequests()
        {
            IRequestBL requestBL = new RequestBL();
            var requests = await requestBL.ViewAllRequests();

            foreach (var request in requests)
            {
                Console.WriteLine($"Request Number: {request.RequestNumber}");
                Console.WriteLine($"Request Raised By: {request.RequestRaisedBy}");
                Console.WriteLine($"Request Message: {request.RequestMessage}");
                Console.WriteLine($"Request Date: {request.RequestDate}");
                Console.WriteLine($"Request Status: {request.RequestStatus}");
                Console.WriteLine($"Closed Date: {request.ClosedDate}");
                Console.WriteLine($"Request Closed By: {request.RequestClosedBy}");
                Console.WriteLine("-----------------------------------");
            }
        }
        public async Task RaiseRequestDetails(int loggedInEmployeeId)
        {

            await Console.Out.WriteLineAsync("Please enter your Request message");
            string requestMessage = Console.ReadLine() ?? "";
            await RaiseRequest(loggedInEmployeeId, requestMessage);
        }
        public async Task MarkRequestClosed(int loggedInEmployeeId)
        {
            IRequestBL requestBL = new RequestBL();
            ISolutionBL solutionBL = new SolutionBL();
            Console.WriteLine("Enter the Request ID to be closed:");
            int requestId = Convert.ToInt32(Console.ReadLine());
            var solution = await solutionBL.UpdateSolutionStatusToDone(requestId);
            var request = await requestBL.UpdateRequestClosed(requestId, loggedInEmployeeId);
            if (request != null)
            {
                Console.WriteLine( $"SolutionStatus  { solution.IsSolved}");
                request.RequestStatus = "Done";
                Console.WriteLine($"Request ID: {request.RequestNumber} has been closed.");
                Console.WriteLine($"Employee ID: {loggedInEmployeeId} closed the request.");
            }
            else
            {
                Console.WriteLine("Request not found or could not be closed.");
            }
        }
    }
}
