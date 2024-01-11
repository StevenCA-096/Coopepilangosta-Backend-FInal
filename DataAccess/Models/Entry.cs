using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public double Quantity { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ExpireDate { get; set; }

        //Relaciones

        public int ProducerOrderId { get; set; }
        public ProducerOrder ProducerOrder { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }

    }
}
