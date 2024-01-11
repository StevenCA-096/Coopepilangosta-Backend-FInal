using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Producer
    {
        public int Id { get; set; }
        public int Cedula { get; set; }
        public string Name { get; set; }
        public string Lastname1 { get; set; }
        public string Lastname2 { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Province { get; set; }
        public string Canton { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public int BankAccount { get; set; }

        //relaciones
        public List<ProductProducer> productsproducers { get; set; }
        public List<ProducerOrder> producersorders { get; set; }
        public List<ForesightProducer> foresightProducers { get; set; }



    }
}
