﻿using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;

namespace EmployeeRequestTrackerAPI.Interfaces
{
    public interface IRequestService
    {
     public   Task<int> RaiseRequest(RequestDetailsDTO requestDetailsDTO);
      public  Task<List<RequestReturnDTO>> GetAllOpenRequest();


        public  Task<IList<Request>> GetAllRequestByEmpId(int empId);
    }
}
