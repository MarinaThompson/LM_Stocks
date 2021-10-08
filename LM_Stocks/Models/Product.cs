using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LM_Stocks.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public int Quantity { get; set; }
        public string Lot { get; set; }
        public DateTime Validity { get; set; }
        public string Description { get; set; }
    }
}
