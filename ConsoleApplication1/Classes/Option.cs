using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackSholvesModelPricing.Classes
{
    class Option
    {
        public Stock UnderlyingStock { get; set; }
        public string BuySell { get; set; }
        public DateTime MaturityDate { get; set; }
        public double InterestRate { get; set; }
        public double OptionPrice { get; set; }
        public string CallPut { get; set; }
        // Derivatives 
        public double Delta { get; set; }
        public double Gamma { get; set; }
        public double Theta { get; set; }
        public double Rho { get; set; }

    }
}
