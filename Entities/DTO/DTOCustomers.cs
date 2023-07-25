using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class DTOCustomers
    {
        public int Id { get; set; }

        public string NameSurName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Passwords { get; set; }
    }
}
