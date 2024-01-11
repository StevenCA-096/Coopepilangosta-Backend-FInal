using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public bool State { get; set; }

        //Relaciones
        public List<Entry> entries { get; set; }

    }
}
