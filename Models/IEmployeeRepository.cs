using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIInMemoryDBSeededIRepository.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployee();

        Task<Employee> GetEmployeeAsync(int id);

        Task AddEmployeeAsync(Employee emp);
    }
}
