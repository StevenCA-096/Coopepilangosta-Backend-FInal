using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class ProductCostumer
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CostumerId { get; set; }
        public Costumer Costumer { get; set; }
        public double PurchasePrice { get; set; }
        public string Description { get; set; }
        public double Margin { get; set; }

    }
}
