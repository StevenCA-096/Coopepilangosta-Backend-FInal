using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class ForesightProducer
    {
        public int Id { get; set; }

        //Relaciones
        public int ProducerId { get; set; }
        public Producer producer { get; set; }
        public Foresight foresight { get; set; }
        public int ForesightId { get; set; }
    }
}
