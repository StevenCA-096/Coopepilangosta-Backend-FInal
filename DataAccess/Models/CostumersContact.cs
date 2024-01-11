using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class CostumersContact
    {
        public int id { get; set; }
        public string name { get; set; }
        public string department { get; set; }
        public string contact { get; set; }

        //relation
        public int costumerId { get; set; }
        public Costumer costumer { get; set; }
    }
}
