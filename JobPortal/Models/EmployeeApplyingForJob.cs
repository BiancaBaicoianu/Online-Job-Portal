using JobPortal.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Models
{
    public class EmployeeApplyingForJob
    {
        public Guid EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public Guid JobId { get; set; }
        public Job? Job { get; set; }

        public EmployeeApplyingForJob()
        {
        }
        public EmployeeApplyingForJob(EmployeeApplyingForJobDTO employeeApplyingForJob)
        {
            this.EmployeeId = employeeApplyingForJob.EmployeeId;
            this.JobId = employeeApplyingForJob.JobId;
        }
    }
}
