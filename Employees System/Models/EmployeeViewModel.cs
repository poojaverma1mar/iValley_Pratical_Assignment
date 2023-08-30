using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employees_System.Models
{
    public class EmployeeViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public Employee Employee { get; set; }
        public EmployeeSalary EmployeeSalary { get; set; }

        
    }
}