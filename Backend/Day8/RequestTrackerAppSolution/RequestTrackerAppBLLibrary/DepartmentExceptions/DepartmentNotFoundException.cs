
using System;

namespace RequestTrackerAppBLLibrary.DepartmentExceptions
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
