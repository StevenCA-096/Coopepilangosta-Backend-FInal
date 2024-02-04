using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class CostumerOrder
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public DateTime ConfirmedDate { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime DeliveredDate { get; set; }
        public string Detail { get; set; }
        public string Stage { get; set; }
        public string Address { get; set; }


        //Relaciones

        public int CostumerId { get; set; }
        public Costumer Costumer { get; set; }
        public List<Sale> sales { get; set; }

    }
}

