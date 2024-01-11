using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class ProductProducer
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
        public double PurchasePrice { get; set; }
}
}
