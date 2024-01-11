using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int cedula { get; set; }
        public string Name { get; set; }
        public string lastName1 { get; set; }
        public string lastName2 { get; set; }
        public string department { get; set;}
  
        //relations
        public int idUser { get; set; }
        public User user { get; set; }

    }
}
