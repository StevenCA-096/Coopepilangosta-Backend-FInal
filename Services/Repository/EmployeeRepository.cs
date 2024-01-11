using DataAccess.Data;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Services.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly ApiContext _apiContext;
        public EmployeeRepository(ApiContext context) : base(context)
        {
            _apiContext = context;
        }

        public async Task<List<Employee>> getAllEmployees() { 
            return await _apiContext.employee.Include(e =>e.user).ThenInclude(u=>u.role).ToListAsync();
        }

        public bool CheckCedulaEmployee(int cedula) {
            var employee = _apiContext.employee.FirstOrDefault(employee => employee.cedula == cedula);
            if (employee == null)
            {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
