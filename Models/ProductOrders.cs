using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DD_Admin.Models
{
    internal class ProductOrdersDet
    {
        [Key]
        public int O_ID { get; set; }
        public int P_ID { get; set; }
        public string? ProductName { get; set; }
        public string? Category { get; set; }
        public string? Gender { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
        public int R_quantity { get; set; }
        public string? Image { get; set; }
        public int IsActive { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Price { get; set; }
    }
}
