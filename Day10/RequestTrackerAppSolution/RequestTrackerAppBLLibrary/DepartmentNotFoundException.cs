
using System;

namespace RequestTrackerAppBLLibrary
{
    public class DepartmentNotFoundException : Exception
    {
        string msg;
        public DepartmentNotFoundException()
        {
            msg = "Department not found";
        }
        public override string Message => msg;
    }
}
