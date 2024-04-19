using RequestTrackerAppModelLib;
using RequestTrackerDALLibrary;

namespace RequestTrackerAppBLLibrary
{
    public class DepartmentBL : IDepartmentService
    {
        readonly IRepository<int, Department> _departmentRepository;
        public DepartmentBL()
        {
            _departmentRepository = new DepartmentRepository();
        }

        public int AddDepartment(Department department)
        {
            // Check if department with the same name already exists
            if (_departmentRepository.DepartmentExistsByName(department.Name))
            {
                throw new DuplicateDepartmentNameException();
            }

            var result = _departmentRepository.Add(department);

            if (result != null)
            {
                return result.Id;
            }
            else
            {
                throw new Exception("An error occurred while adding the department.");
            }
        }


        public Department ChangeDepartmentName(string departmentOldName, string departmentNewName)
        {
            var department = _departmentRepository.GetDepartmentByName(departmentOldName);
            if (department != null)
            {
                department.Name = departmentNewName;
                _departmentRepository.Update(department);
                return department;
            }
            throw new DepartmentNotFoundException();
        }

        public Department GetDepartmentById(int id)
        {
            var department = _departmentRepository.GetDepartmentById(id);
            if (department != null)
            {
                return department;
            }
            throw new DepartmentNotFoundException();
        }

        public Department GetDepartmentByName(string departmentName)
        {
            var department = _departmentRepository.GetDepartmentByName(departmentName);
            if (department != null)
            {
                return department;
            }
            throw new DepartmentNotFoundException();
        }

        
        public Department DeleteDepartmentByName(string departmentName)
        {
            // Get the department by name
            var department = _departmentRepository.GetDepartmentByName(departmentName);
            if (department != null)
            {
                // Delete the department
                return _departmentRepository.Delete(department.Id);
            }
            else
            {
                throw new DepartmentNotFoundException();
            }
        }

        
        public List<Department> GetDepartmentList()
        {
            return _departmentRepository.GetAll();
        }
        public bool DepartmentExists(int id)
        {
            var department = _departmentRepository.GetDepartmentById(id);
            return department != null;
        }
        public bool DepartmentExistsByName(string name)
        {
            var department = _departmentRepository.GetDepartmentByName(name);
            return department != null;
        }

        public int GetDepartmentHeadId(int departmentId)
        {
            throw new NotImplementedException();
        }
    }

}
