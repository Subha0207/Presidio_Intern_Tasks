using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IRequestBL
    {
        Task<Request> RaiseRequest(Request request);
        Task<IList<Request>> ViewAllRequests();
        Task<Request> ViewRequestById(int id);


    }
}
