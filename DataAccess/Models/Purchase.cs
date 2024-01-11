using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public double Quantity { get; set; }
        public double PurchaseTotal { get; set; }
        


        //Relaciones

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ProducerOrderId { get; set; }
        public ProducerOrder ProducerOrder { get; set; }
    }
}
