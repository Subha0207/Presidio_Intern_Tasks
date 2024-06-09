using Microsoft.EntityFrameworkCore;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class RequestBL : IRequestBL
    {
        private readonly IRepository<int, Request> _repository;

        public RequestBL()
        {
            IRepository<int, Request> repo = new RequestRepository(new RequestTrackerContext());
            _repository = repo;
        }
        public async Task<Request> RaiseRequest(Request request)
        {
            var result = await _repository.Add(request);
            return result;
        }
        public async Task<IList<Request>> ViewAllRequests()
        {
            var requests = await _repository.GetAll();
            return requests;
        }

        public async Task<Request> ViewRequestById(int id)
        {
            var request = await _repository.Get(id);
            return request;
        }


        public async Task<Request> UpdateRequestClosed(int requestId, int loggedInEmployeeId)
        {
            var request = await _repository.Get(requestId);
            if (request != null)
            {   
                request.ClosedDate = DateTime.Now;
                request.RequestClosedBy = loggedInEmployeeId;
                await _repository.Update(request);
            }
            return request;
        }
        public async Task<Request> UpdateRequestStatus(int requestId)
        {
            var request = await _repository.Get(requestId);
            if (request != null)
            {
                request.RequestStatus = "Done";
               await _repository.Update(request);
            }
            return request;

        }


    }
}
