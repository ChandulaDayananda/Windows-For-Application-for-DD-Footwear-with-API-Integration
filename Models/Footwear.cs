using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DD_Admin.Models;


namespace DD_Admin.Models
{
    public class FootwearDet
    {
        public int p_ID { get; set; }
        public string productName { get; set; }
        public string category { get; set; }
        public string gender { get; set; }
        public string size { get; set; }
        public string color { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public string image { get; set; }
        public int isActive { get; set; }
    }
}
