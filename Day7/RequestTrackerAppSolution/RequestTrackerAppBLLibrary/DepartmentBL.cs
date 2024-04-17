using RequestTrackerAppModelLib;
using RequestTrackerDALLibrary;

namespace RequestTrackerAppBLLibrary
{
    public class DepartmentBL
    {
        readonly IRepository<int, Department> _departmentRepository;
        public DepartmentBL()
        {
            _departmentRepository = new DepartmentRepository();
        }

    }
}
