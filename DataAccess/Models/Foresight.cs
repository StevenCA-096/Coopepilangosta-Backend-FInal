using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Foresight
    {
        public int Id { get; set; }
        public DateTime initialDate { get; set; }
        public DateTime endDate { get; set; }

        //Relaciones
        public int IdProduct { get; set; }
        public Product product{ get; set;}

        public List<ForesightProducer> Foresightproducers { get; set; }
    }
}
