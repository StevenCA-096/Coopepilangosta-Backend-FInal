using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRepository
{
    public interface ICostumerRepository:IGenericRepository<Costumer>
    {
        public Task<List<Costumer>> GetAllData();
        public int createCostumer(Costumer newCostumer);
        public bool checkCedula(int cedula);
    }
}
