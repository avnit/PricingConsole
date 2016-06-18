using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackSholvesModelPricing.Classes
{
    class Pricing
    {
        public DateTime PricingDate { get; set; }
        public Stock Stock { get; set; }
        public double Price { get; set; }
        public double OpeningPrice { get; set; }
        public double ClosingPrice { get; set; }
        public double AveragePrice { get; set; }
    }
}
