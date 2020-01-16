using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Domain
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public decimal Age { get; set; }
        public string Email { get; set; }
        [StringLength(10)]
        public char PhoneNumber { get; set; }
        public string Address { get; set; }

    }
}
