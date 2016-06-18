using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackSholvesModelPricing.Classes
{
    class Stock
    {
        public string StockSymbol { get; set; }
        public string StockDescription { get; set; }
        public double StockPrice { get; set; }
        public double StockPrice200DayAvg { get; set; }
        public double Beta { get; set;  }
        public double StandardDeviation { get; set; }
        public double InformationRatio { get; set; }
        public double Dividend { get; set; }
        public double HistoricalReturn { get; set; }
        public DateTime PriceDate { get; set; }
    }
}
