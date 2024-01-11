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
    public class CostumerRepository : GenericRepository<Costumer>, ICostumerRepository
    {
        private readonly ApiContext _context;        
        public CostumerRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        //ICostumerRepository methods
        public Task<List<Costumer>> GetAllData()
        {
            return _context.costumers.Include(c => c.costumersContacts).Include(c => c.user).Include(c=>c.user.role).IgnoreAutoIncludes().ToListAsync(); 
        }
        public int createCostumer(Costumer newCostumer)
        {
            var findCostumer = _context.costumers.FirstOrDefault(costumer => costumer.cedulaJuridica == newCostumer.cedulaJuridica);
            if (findCostumer == null)
            {
                try
                {
                    _context.costumers.Add(newCostumer);
                    _context.SaveChanges();
                    return 201;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return 500;
                }
            }
            else {
                return 409;
            }
        }

        public bool checkCedula(int cedula) {
             var costumerFound = _context.costumers.FirstOrDefault(costumer => costumer.cedulaJuridica == cedula);
            if (costumerFound == null)
            {
                return false;
            }
            else { 
                return true;
            }
        }
    }
}
