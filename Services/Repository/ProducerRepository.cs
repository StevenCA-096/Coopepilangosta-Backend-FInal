using DataAccess.Data;
using DataAccess.Models;
using Services.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repository
{
    public class ProducerRepository : GenericRepository<Producer>, IProducerRepository
    {
        private readonly ApiContext _context;
        public ProducerRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
        public bool CheckCedulaAvailability(int cedula) { 
            var producer = _context.Producer.FirstOrDefault(producer => producer.Cedula == cedula);
            if (producer == null)
            {
                return true;
            }
            else{
                return false;
            }
        }
    }
}
