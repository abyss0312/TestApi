using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Contracts.Request
{
    public class CustomerRequest
    {
        [Key]
        public string Name { get; set; }
        public string LastName { get; set; }
        public decimal Age { get; set; }
        public string Email { get; set; }
        [Phone]
        public char PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
