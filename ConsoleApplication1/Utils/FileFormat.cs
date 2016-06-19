using System;
using System.IO;

namespace BlackSholvesModelPricing.Utils
{
    public class FileFormat
    {
        public string Date { get; set; }
        public string Open { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string Close { get; set; }
        public string Volume { get; set; }
        public string AdjClose { get; set; }
        public DateTime PricingDate { get; set; }
        public Double PricingOpen { get; set; }
        public Double PricingClose { get; set; }
        public Double TotalVolume { get; set; }

        public FileFormat()
        {
            PricingDate = GetPricingDate();
            PricingOpen = GetPricingOpen();
            PricingClose = GetPricingClose();
            TotalVolume = GetTotalVolume();
        }
        #region Convert the columns into specific type to store values 
        private DateTime GetPricingDate()
        {
            try
            {
                return DateTime.Parse(Date);
            }
            catch (Exception Ex )
            {
                throw (Ex);
            }
        }
        public Double GetPricingOpen()
        {
            try
            {
                return Convert.ToDouble(Open);
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
        }
        public Double GetPricingClose()
        {
            try
            { 
            return Convert.ToDouble(Close);
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
        }
        public Double GetTotalVolume()
        {
            try
            { 
            return Convert.ToDouble(Volume);
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
         }
        #endregion
        //we only need these columns from the file so no need to convert others 
    }
}