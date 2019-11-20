using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIInMemoryDBSeededIRepository.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDBContext _context;

        public EmployeeRepository(EmployeeDBContext ctx)
        {
            _context = ctx;
        }

        public IEnumerable<Employee> GetEmployee()
        {
            return _context.Employees;
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            Employee employee = await _context.Employees.FindAsync(id);

            return employee;
        }

        public async Task AddEmployeeAsync(Employee emp)
        {
            _context.Employees.Add(emp);
            await _context.SaveChangesAsync();
        }
    }
}
