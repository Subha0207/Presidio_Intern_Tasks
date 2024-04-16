using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementLibrary
{
    public interface IGovtRules
    {

        /// <summary>
        /// EmployeePF
        /// Used to calculate the Pension fund of employee.
        /// Leave Details
        /// Tell us about the leave details of the company
        /// GratuityAmount
        /// Tell us about the amount received for experienced employees
        /// </summary>

        string empid { get; set; }
        string name { get; set; }
        string dept { get; set; }
        string desg { get; set; }
        double basicSalary { get; set; }
        double serviceYears { get; set; }

        double EmployeePF(double basicSalary);
        string LeaveDetails();
        double GratuityAmount(double serviceYears, double basicSalary);
    }
}
