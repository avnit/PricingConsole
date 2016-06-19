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
        private void SetDefault()
            {
                this.URL =  "http://ichart.yahoo.com/table.csv?s=";
            }
           
        public string StockName { get; set;}
        public string Date { get; set; }
        public string Path { get; set; }
        public string a { get; set; }
        public string b { get; set; }
        public string c { get; set; }
        public string d { get; set; }
        public string e { get; set; }
        public string f { get; set; }


        protected string FileName()
        {
            return this.Path + "/" + Date + "_" + this.StockName + ".csv";
        }


        protected string WebServiceCall()
        {
            //Sample call
            /// http://ichart.yahoo.com/table.csv?s=MSFT&a=0&b=1&c=2000&d=11&e=24&f=2014&g=w&ignore=.csv
            SetDefault();
            return  this.URL  + this.StockName + "&a=" + this.a + "&b=" + this.b + "&c=" + this.c + 
                    "&d=" + this.d + "&e=" + this.e + "&f" + this.f  + "&g=w&ignore=.csv";
        }

        public void DownloadFile ()
        {
            try
            {
                string webserviceUrl = this.WebServiceCall();
                string dayFile = this.FileName();
              //  File.Create(dayFile);
                WebClient WS = new WebClient();
                WS.DownloadFile(webserviceUrl, dayFile);
                Console.WriteLine(this.StockName + " Data downloaded successfully!");
                WS.Dispose();
            }
            catch (Exception Ex)
            {
                Console.WriteLine("error " + Ex.Message);
            }
        }

    }
}
