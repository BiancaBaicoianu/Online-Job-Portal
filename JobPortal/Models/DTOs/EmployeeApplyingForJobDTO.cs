namespace JobPortal.Models.DTOs
{
    public class EmployeeApplyingForJobDTO
    {
        public Guid EmployeeId { get; set; }

        public Guid JobId { get; set; }
        public EmployeeApplyingForJobDTO(EmployeeApplyingForJob employeeApplyingForJob)
        {
            this.EmployeeId = employeeApplyingForJob.EmployeeId;
            this.JobId = employeeApplyingForJob.JobId;
        }
        public EmployeeApplyingForJobDTO()
        {
        }
    }
}
