using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DD_Admin.Models
{
    internal class CustomerOrdersDet
    {
        [Key]
        public int C_ID { get; set; }
        public int P_ID { get; set; }
        public string? FristName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int Phonenumber { get; set; }
        public string? Address { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
