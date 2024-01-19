using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; } 
        public string Unit { get; set; }
        //public double Price { get; set; }
        public double Margin { get; set; }
        public double Iva { get; set; }
        public bool State { get; set; } 

        //Relaciones

        public int CategoryId { get; set; }
        public string image { get; set; }
        public Category Category { get; set; }
        public List<ProductProducer> productsproducers { get; set; }
        public List<ProductCostumer> productscostumers { get; set; }
        public List<Entry> entries { get; set; }
        public List<Purchase> purchases { get; set; }
        public List<Foresight> foresights { get; set; }
        public List<Sale> sales { get; set; }
        public List<StockReport> stocks { get; set; }
        public List<Review> reviews { get; set; }


    }
}
