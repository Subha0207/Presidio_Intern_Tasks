using RequestTrackerAppModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerAppBLLibrary
{
    public interface IDepartmentService
    {
        public int AddDepartment(Department department);
        public Department ChangeDepartmentName(string departmentOldName, string departmentNewName);
        public Department GetDepartmentById(int id);
        public Department GetDepartmentByName(string departmentName);
        public Department DeleteDepartmentByName(string departmentName);
        public List<Department> GetDepartmentList();
        public bool DepartmentExists(int id);
        public bool DepartmentExistsByName(string name);
      



    }

}
