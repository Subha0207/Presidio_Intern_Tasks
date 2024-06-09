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
        private readonly EmployeeRequestRaisedRepository _employeeRequestRaisedRepository;
        

        public RequestService(IRepository<int, Request> requestRepository,EmployeeRequestRaisedRepository employeeRequestRaisedRepository)
        {
            _requestRepository = requestRepository;
          _employeeRequestRaisedRepository = employeeRequestRaisedRepository;
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

      public async Task  <List<RequestReturnDTO>> GetAllRequestByUser(int empId)
        {

            try
            {
                var employee = await _employeeRequestRaisedRepository.Get(empId);
                if (employee != null)
                {
                    var result = new List<RequestReturnDTO>();

                    // Add request raised items
                    if (employee.RequestsRaised != null)
                    {
                        var requestRaisedList = await RequestToRequestReturnDTO(employee.RequestsRaised.ToList());
                        result.AddRange(requestRaisedList);
                    }

                    // Add request closed items
                    if (employee.RequestsClosed != null)
                    {
                        var requestClosedList = await RequestToRequestReturnDTO(employee.RequestsClosed.ToList());
                        result.AddRange(requestClosedList);
                    }

                    return result;
                }
                throw new Exception("Cannot get the employee details");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Error in getting request list");
            }
        }

        
    }
}
