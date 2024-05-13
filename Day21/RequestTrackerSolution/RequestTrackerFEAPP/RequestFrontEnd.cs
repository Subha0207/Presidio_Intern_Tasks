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
       public  async Task ViewRequestStatusById(int requestId)
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
       public async Task ViewRequestStatus()
        {

            await Console.Out.WriteLineAsync("Please enter Employee Id");
            int requestRaisedBy = Convert.ToInt32(Console.ReadLine());

            await Console.Out.WriteLineAsync("Please enter Request Id");
            int requestId = Convert.ToInt32(Console.ReadLine());
            await ViewRequestStatusById(requestId);
        }
      public  async Task RaiseRequest(int requestRaisedBy, string requestMessage)
        {
            // Get the current date
            DateTime currentDate = DateTime.Now;

            // Set the initial request status
            string requestStatus = "Not Done";

            Request request = new Request()
            {
                RequestRaisedBy = requestRaisedBy,
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
        public async Task RaiseRequestDetails()
        {

            await Console.Out.WriteLineAsync("Please enter Employee Id");
            int requestRaisedBy = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Please enter your Request message");
            string requestMessage = Console.ReadLine() ?? "";
            await RaiseRequest(requestRaisedBy, requestMessage);
        }
        public async Task MarkRequestClosed()
        {
            IRequestBL requestBL = new RequestBL();
            Console.WriteLine("Enter the Request ID to be closed:");
            int requestId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Employee ID who is closing the request:");
            int closedById = Convert.ToInt32(Console.ReadLine());
            var request = await requestBL.UpdateRequestClosed(requestId, closedById);
            if (request != null)
            {
                Console.WriteLine($"Request ID: {request.RequestNumber} has been closed.");
                Console.WriteLine($"Employee ID: {request.RequestClosedBy} closed the request.");
            }
            else
            {
                Console.WriteLine("Request not found or could not be closed.");
            }
        }
    }
}
