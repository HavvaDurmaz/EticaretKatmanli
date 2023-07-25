using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Customers
    {
        public int Id { get; set; }

        public string NameSurName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }   

        public string Passwords { get; set; }

        public bool Status { get; set; }

        public DateTime RegisterDate { get; set; }

        public List<OrderAddress> OrderAdress { get; set; }

        public string Roles { get; set; } = "user";
    }
}
