using System;
using System.Collections.Generic;

namespace SampleEFApp.Model
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? EmployeeArea { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; } = null!;

        public virtual Area? EmployeeAreaNavigation { get; set; }
    }
}
