using EmployeeManagementLibrary;

namespace EmployeeManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IGovtRules accentureEmployee = new Accenture("001", "John Doe", "IT", "Developer", 1000,9);
            IGovtRules googleEmployee = new Google("002", "Jane Doe", "HR", "Manager", 1000,5);

            Console.WriteLine("Accenture Employee Details:");
            Console.WriteLine($"Employee ID: {accentureEmployee.empid}");
            Console.WriteLine($"Name: {accentureEmployee.name}");
            Console.WriteLine($"Department: {accentureEmployee.dept}");
            Console.WriteLine($"Designation: {accentureEmployee.desg}");
            Console.WriteLine($"Basic Salary: {accentureEmployee.basicSalary}");
            Console.WriteLine();
            Console.WriteLine($"Employee PF: {accentureEmployee.EmployeePF(accentureEmployee.basicSalary)}");
            Console.WriteLine($"Net Salary:{accentureEmployee.basicSalary - accentureEmployee.EmployeePF(accentureEmployee.basicSalary)}");
            Console.WriteLine($"Leave Details: {accentureEmployee.LeaveDetails()}");
            Console.WriteLine($"Gratuity Amount: {accentureEmployee.GratuityAmount(15, accentureEmployee.basicSalary)}");

            Console.WriteLine("\nGoogle Employee Details:");
            Console.WriteLine($"Employee ID: {googleEmployee.empid}");
            Console.WriteLine($"Name: {googleEmployee.name}");
            Console.WriteLine($"Department: {googleEmployee.dept}");
            Console.WriteLine($"Designation: {googleEmployee.desg}");
            Console.WriteLine($"Basic Salary: {googleEmployee.basicSalary}");
            Console.WriteLine();
            Console.WriteLine($"Employee PF: {googleEmployee.EmployeePF(googleEmployee.basicSalary)}");
            Console.WriteLine($"Net Salary:{googleEmployee.basicSalary- googleEmployee.EmployeePF(googleEmployee.basicSalary)}");
            Console.WriteLine($"Leave Details: {googleEmployee.LeaveDetails()}");
            Console.WriteLine($"Gratuity Amount: {googleEmployee.GratuityAmount(9, googleEmployee.basicSalary)}");
        }
    }

}
