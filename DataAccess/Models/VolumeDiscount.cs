using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class VolumeDiscount
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public double Volume { get; set; }

        //Relaciones
        public int ProductCostumerId { get; set; }
        public ProductCostumer ProductCostumer { get; set; }

    }
}
