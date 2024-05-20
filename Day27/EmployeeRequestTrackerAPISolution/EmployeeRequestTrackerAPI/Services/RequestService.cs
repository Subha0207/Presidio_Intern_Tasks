using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;
using EmployeeRequestTrackerAPI.Repositories;

namespace EmployeeRequestTrackerAPI.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRepository<int, Request> _requestRepository;
        
        

        public RequestService(IRepository<int, Request> requestRepository)
        {
            _requestRepository = requestRepository;
          
        }

        
        public async Task<List<RequestReturnDTO>> GetAllOpenRequest()
        {
            try
            {
                var allRequestList = await _requestRepository.Get();
                var openRequestList = allRequestList
                                        .Where(request => request.RequestStatus == "open")
                                        .OrderBy(request => request.RequestDate)
                                        .ToList();
                return await RequestToRequestReturnDTO(openRequestList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Error in getting all open request");
            }
        }
        private async Task<List<RequestReturnDTO>> RequestToRequestReturnDTO(List<Request> request)
        {
            List<RequestReturnDTO> RequestReturnDTOList = new List<RequestReturnDTO>();
            foreach (var item in request)
            {
                RequestReturnDTO requestReturnDTO = new RequestReturnDTO()
                {
                    Id = item.RequestNumber,
                    Description = item.RequestMessage,
                    RaisedBy = item.RequestRaisedBy,
                    RaisedDateTime = item.RequestDate,
                    ClosedBy = item.RequestClosedBy,
                    ClosedDateTime = item.ClosedDate,
                    RequestStatus = item.RequestStatus,

                };
                RequestReturnDTOList.Add(requestReturnDTO);
            }
            return RequestReturnDTOList;
        }
        public async Task<int> RaiseRequest(RequestDetailsDTO raiseRequestDTO)
        {
                var request = await MapRaiseRequestDTOtoRequest(raiseRequestDTO);
                var addedRequest = await _requestRepository.Add(request);
                if (addedRequest != null)
                {
                    return addedRequest.RequestNumber;
                }
                throw new Exception("Cannot add Request details");
            
            
        }
        

        private async Task<Request> MapRaiseRequestDTOtoRequest(RequestDetailsDTO requestDetailsDTO)
        {
            Request request = new Request()
            {
               RequestMessage = requestDetailsDTO.RequestMessage,
                RequestStatus = "open",
                RequestDate= requestDetailsDTO.RaisedDateTime,
                RequestRaisedBy = requestDetailsDTO.RequestRaisedBy,

            };
            return request;
        }
        
        public async Task<IList<Request>> GetAllRequestByEmpId(int empId)
        {
            var requests = await _requestRepository.Get();
            List<Request> UserRequest = new List<Request>();
            foreach (var request in requests)
            {
                if (request.RequestRaisedBy == empId)
                {
                    UserRequest.Add(request);
                }
            }
            if(UserRequest.Count>0)
            return UserRequest;
            throw new NoRequestExistsException();

            
        }

    }
}
