using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Stars { get; set; }
        public DateTime ReviewDate { get; set; }

        //Relaciones
        public int ProductId { get; set; }
        public Product product { get; set; }
        public int CostumerId { get; set; }
        public Costumer costumer { get; set; }    }
}
