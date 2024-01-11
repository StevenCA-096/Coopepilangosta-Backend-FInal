using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email{ get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

        //relations
        public Costumer costumer { get; set; }
        public Employee employee { get; set; }
        public int idRole { get; set; }
        public Role role { get; set; }
    }
}
