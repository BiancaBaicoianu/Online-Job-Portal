﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public IEnumerable<EmployeeApplyingForJob> EmployeesApplyingForJobs { get; set; } = new HashSet<EmployeeApplyingForJob>();
        public User? User { get; set; }
        public Employee()
        {

        }

        public Employee(EmployeeDTO employee)
        {
            this.FirstName = employee.FirstName;
            this.LastName = employee.LastName;
            this.EmailAddress = employee.EmailAddress;
        }
    }

}



