using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlackSholvesModelPricing.Classes
{
    class YahooWebservice
    {
        public string URL { get; set; }
        public string StockName { get; set;}
        public string Date { get; set; }
        public string Path { get; set; }

        protected string FileName()
        {
            return this.Path + "/" + Date + "_" + this.StockName + ".csv";
        }


        protected string WebServiceCall()
        {
            return "http://" + this.URL + "?stockName = " + this.StockName + "&Date=" + this.Date;
        }

        public void DownloadFile ()
        {
            string webserviceUrl = this.WebServiceCall();
            string dayFile = this.FileName();
            File.Create(dayFile);
            WebClient WS = new WebClient();
            WS.DownloadFile(webserviceUrl, dayFile);
            Console.WriteLine(this.StockName + " Data downloaded successfully!");
            WS.Dispose();
        }

    }
}
