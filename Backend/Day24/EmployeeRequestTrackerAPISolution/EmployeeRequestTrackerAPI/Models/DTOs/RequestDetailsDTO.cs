
namespace EmployeeRequestTrackerAPI.Models.DTOs
{
    public class RequestDetailsDTO
    {

      public  int RequestRaisedBy { get; set; }
       
        public string RequestMessage { get; set; }

        public DateTime RaisedDateTime { get; set; }

     
    }
}
