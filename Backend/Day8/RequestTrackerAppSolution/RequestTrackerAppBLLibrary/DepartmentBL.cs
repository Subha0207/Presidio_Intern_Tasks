
using RequestTrackerAppBLLibrary.DepartmentExceptions;
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
            var result = _departmentRepository.Add(department);

            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicateDepartmentNameException();
        }
        
        public Department ChangeDepartmentName(string departmentOldName, string departmentNewName)
        {
            var departments = _departmentRepository.GetAll();
            if (departments != null)
            {
                foreach (var department in departments)
                {
                    if (department.Name == departmentOldName)
                    {
                        department.Name = departmentNewName;
                        _departmentRepository.Update(department);
                    }
                }
            }
            throw new DepartmentNotFoundException();
        }

        

        public bool DepartmentExists(int id)
        {
            throw new NotImplementedException();
        }

        public bool DepartmentExistsByName(string name)
        {
            throw new NotImplementedException();
        }

        public Department GetDepartmentById(int id)
        {
            var department = _departmentRepository.Get(id);
            if (department != null)
            {
                return department;
            }
            throw new DepartmentNotFoundException();
        }



        public Department GetDepartmentByName(string departmentName)
        {
            var departments = _departmentRepository.GetAll();
            if (departments != null)
            {
                foreach (var department in departments)
                {
                    if (department.Name == departmentName) { return department; }
                }
            }
            throw new DepartmentNotFoundException();
        }

        

        

        public List<Department> GetDepartmentList()
        {
            var departments = _departmentRepository.GetAll();
            if (departments != null)
            {
                return new List<Department>(departments);
            }
            throw new NoDataAvailableException();
        }

        
        public Department DeleteDepartmentByName(string name)
        {

            var departments = _departmentRepository.GetAll();
            if (departments != null)
            {
                foreach (var department in departments)
                {
                    if (department.Name == name)
                    {
                        return _departmentRepository.Delete(department.Id);
                    }
                }
            }
            throw new DepartmentNotFoundException();
        }

    }



}

