using RequestTrackerAppBLLibrary;
using RequestTrackerAppModelLib;
using System.Collections;

namespace RequestTrackerApp
{
    internal class Program
    {
        private DepartmentBL departmentBL = new DepartmentBL();

        
        void AddDepartment()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter the department name or 'stop' to exit");
                    string name = Console.ReadLine();

                    // Exit the loop if the user enters 'stop'
                    if (name.ToLower() == "stop")
                    {
                        break;
                    }

                    // Check if department with the same name already exists
                    if (departmentBL.DepartmentExistsByName(name))
                    {
                        Console.WriteLine("A department with this name already exists. Please enter a unique name.");
                    }

                    else
                    {
                        Department department = new Department() { Name = name };
                        int id = departmentBL.AddDepartment(department);
                        Console.WriteLine("Congrats. We have created the department for you and the Id is " + id);
                    }
                }
                catch (DuplicateDepartmentNameException ddne)
                {
                    Console.WriteLine(ddne.Message);
                }
            }
        }



        void UpdateDepartment()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter the department name you want to update or 'stop' to exit");
                    string oldName = Console.ReadLine();

                    // Exit the loop if the user enters 'stop'
                    if (oldName.ToLower() == "stop")
                    {
                        break;
                    }

                    // Check if department with the old name exists
                    if (departmentBL.DepartmentExistsByName(oldName))
                    {
                        Console.WriteLine("Please enter the new department name");
                        string newName = Console.ReadLine();

                        Department department = departmentBL.ChangeDepartmentName(oldName, newName);
                        Console.WriteLine("The department name has been updated successfully to " + department.Name);
                    }

                    else
                    {
                        Console.WriteLine("A department with this name does not exist. Please enter a valid department name.");
                    }
                }
                catch (DepartmentNotFoundException dnfe)
                {
                    Console.WriteLine(dnfe.Message);
                }
            }
        }
        void DeleteDepartmentByName()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter the department name to delete or 'stop' to exit");
                    string name = Console.ReadLine();

                    // Exit the loop if the user enters 'stop'
                    if (name.ToLower() == "stop")
                    {
                        break;
                    }

                    // Check if department with the same name exists
                    if (departmentBL.DepartmentExistsByName(name))
                    {
                        Department department = departmentBL.DeleteDepartmentByName(name);
                        Console.WriteLine("The department " + department.Name + " has been deleted successfully.");
                    }

                    else
                    {
                        Console.WriteLine("A department with this name does not exist. Please enter a valid department name.");
                    }
                }
                catch (DepartmentNotFoundException dnfe)
                {
                    Console.WriteLine(dnfe.Message);
                }
            }
        }
        
        void GetAllDepartments()
        {
            try
            {
                List<Department> departments = departmentBL.GetDepartmentList();

                if (departments.Count == 0)
                {
                    Console.WriteLine("No departments found.");
                }
                else
                {
                    Console.WriteLine("Here are all the departments:");
                    foreach (var department in departments)
                    {
                        Console.WriteLine("Id: " + department.Id + ", Name: " + department.Name);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            bool running = true;
            while (running)
            {
                Console.WriteLine("Please enter your choice:");
                Console.WriteLine("1. Add Department");
                Console.WriteLine("2. Delete Department");
                Console.WriteLine("3. Get All Department");
                Console.WriteLine("4. Update Department");
                Console.WriteLine("5. Exit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        program.AddDepartment();
                        break;
                    case "2":
                        
                        program.DeleteDepartmentByName();
                        break;
                    case "3":
                        program.GetAllDepartments(); 
                        break;

                    case "4":
                        program.UpdateDepartment();
                       
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
        }

    }
}

