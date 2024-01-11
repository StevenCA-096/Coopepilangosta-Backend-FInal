using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class ProducerOrder
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public DateTime ConfirmedDate { get; set; }
        //public bool Paid { get; set; } = false;
        public DateTime PaidDate { get; set; }
        //public bool Delivered { get; set; } = false;
        public DateTime DeliveredDate { get; set; }
        public string Detail { get; set; }



        //Relaciones

        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
        public List<Purchase> purchases { get; set; }
        public List<Entry> entries { get; set; }

    }
}
