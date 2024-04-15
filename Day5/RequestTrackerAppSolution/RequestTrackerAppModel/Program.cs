using RequestTrackerModelLib;
using System.Globalization;
namespace RequestTrackerApp
{
    internal class Program
    {
        
        private List<Employee> employees = new List<Employee>();

        public Employee BuildEmployee(int id, string name, DateTime dob, double salary)
        {
            return new Employee(id, name, dob, salary);
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public void PrintEmployee(Employee employee)
        {
            Console.WriteLine($"ID: {employee.Id}, Name: {employee.Name}, Age: {employee.Age}, Salary: {employee.Salary}");
        }

        public void PrintAllEmployees()
        {
            foreach (var employee in employees)
            {
                PrintEmployee(employee);
            }
        }

        public int GetEmployeeId(Employee employee)
        {
            return employee.Id;
        }

        public Employee SearchEmployee(int id)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Id == id)
                {
                    return employees[i];
                }
            }
            return null; // Return null if no employee with the given ID is found
        }

        public void PrintEmployeeDetails(int id)
        {
            var employee = SearchEmployee(id);
            if (employee != null)
            {
                PrintEmployee(employee);
            }
            else
            {
                Console.WriteLine("Employee not found");
            }
        }

        public void UpdateName(int id, string newName)
        {
            var employee = SearchEmployee(id);
            if (employee != null)
            {
                employee.Name = newName;
            }
            else
            {
                Console.WriteLine("Employee not found");
            }
        }

        public void DeleteEmployee(int id)
        {
            if (employees == null)
            {
                Console.WriteLine("Employees list is not initialized");
                return;
            }

            var employee = SearchEmployee(id);
            if (employee != null)
            {
                int index = employees.IndexOf(employee);
                if (index != -1)
                {
                    employees.RemoveAt(index);
                }
            }
            else
            {
                Console.WriteLine("Employee not found");
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();

            Console.WriteLine("Enter the number of employees you want to add:");
            int numEmployees = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numEmployees; i++)
            {
                Console.WriteLine($"Enter details for employee {i + 1}:");

                Console.WriteLine("Enter ID:");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Date of Birth (yyyy/mm/dd):");
                DateTime dob = DateTime.ParseExact(Console.ReadLine(), "yyyy/MM/dd", CultureInfo.InvariantCulture);

                Console.WriteLine("Enter Salary:");
                double salary = Convert.ToDouble(Console.ReadLine());

                Employee emp = program.BuildEmployee(id, name, dob, salary);
                program.AddEmployee(emp);
            }

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Print all employees");
                Console.WriteLine("2. Print details of an employee");
                Console.WriteLine("3. Update the name of an employee");
                Console.WriteLine("4. Delete an employee");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Enter your choice:");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        program.PrintAllEmployees();
                        break;
                    case 2:
                        Console.WriteLine("Enter the ID of the employee:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        program.PrintEmployeeDetails(id);
                        break;
                    case 3:
                        Console.WriteLine("Enter the ID of the employee:");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the new name of the employee:");
                        string newName = Console.ReadLine();
                        program.UpdateName(id, newName);
                        break;
                    case 4:
                        Console.WriteLine("Enter the ID of the employee:");
                        id = Convert.ToInt32(Console.ReadLine());
                        program.DeleteEmployee(id);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
        }
    }
}
