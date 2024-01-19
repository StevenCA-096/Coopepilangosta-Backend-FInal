using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Costumer
    {
        public int id { get; set; }
        public int cedulaJuridica { get; set; }
        public string name { get; set; }
        public string province { get; set; }
        public string canton { get; set; }
        public string district { get; set; }
        public string address { get; set; }
        public int postalCode { get; set; }
        public string bankAccount { get; set; }
        public bool verified { get; set; }


        //relations
        public int userId { get; set; }
        public User user { get; set; }
        public List<CostumersContact>costumersContacts { get; set; }
        public List<CostumerOrder> costumersorders { get; set; }
        public List<ProductCostumer> productscostumers { get; set; }
        public List<Review> reviews { get; set; }




    }
}
