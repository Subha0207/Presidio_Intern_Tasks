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
    }
}
