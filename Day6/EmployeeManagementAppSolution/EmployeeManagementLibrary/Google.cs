using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementLibrary
{
    public class Google : IGovtRules
    {

        private string empid, name, dept, desg;
        private double basicSalary;
        private double serviceYears;


        string IGovtRules.empid { get => this.empid; set { empid = value; } }
        string IGovtRules.name { get => this.name; set { name = value; } }
        string IGovtRules.dept { get => this.dept; set { dept = value; } }
        string IGovtRules.desg { get => this.desg; set { desg = value; } }
        double IGovtRules.basicSalary { get => this.basicSalary; set { basicSalary = value; } }
        double IGovtRules.serviceYears { get => this.serviceYears; set { serviceYears = value; } }

        
        public Google(string empid, string name, string dept, string desg, double basicSalary,float serviceYears)
        {
            this.empid = empid;
            this.name = name;
            this.dept = dept;
            this.desg = desg;
            this.basicSalary = basicSalary;
        }

        public double EmployeePF(double basicSalary)
        {
            return 0.12 * basicSalary + 0.12 * basicSalary;
        }

        public string LeaveDetails()
        {
            return "2 day of Casual Leave per month\n5 days of Sick Leave per year\n5 days of Privilege Leave per year";
        }

        public double GratuityAmount(double serviceYears, double basicSalary)
        {
            return 0;
        }
    }
}
