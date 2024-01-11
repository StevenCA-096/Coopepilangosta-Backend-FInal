using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class StockReport
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public DateTime CambioFecha { get; set; }
        public int OldStock { get; set; }
        public int NewStock { get; set; }
        public string motive { get; set; }
        public string Email { get; set; }

        //relaciones

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
