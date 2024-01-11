using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRepository
{
    public interface IEmployeeRepository:IGenericRepository<Employee>
    {
        public Task<List<Employee>> getAllEmployees();
        public bool CheckCedulaEmployee(int cedula);
    }
}
