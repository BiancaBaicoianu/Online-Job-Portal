using JobPortal.Models;
using JobPortal.Repository;

namespace JobPortal.Repositories.EmployeeRepository
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<Employee?> GetEmployeeByFullName(string firstName, string lastName);
    }
}
