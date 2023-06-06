using JobPortal.Models;

namespace JobPortal.Repositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<Employee?> GetEmployeeByFullName(string firstName, string lastName);
        Task Update(Company companyInDb);
    }
}
