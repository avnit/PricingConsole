using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlackSholvesModelPricing.Utils
{
    class YahooWebservice
    {
        public string URL { get; set; }
        private void SetDefault()
            {
                this.URL =  "http://ichart.yahoo.com/table.csv?s";
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

        #region get file name 
        protected string FileName()
        {
            return this.Path + "/" + Date + "_" + this.StockName + ".csv";
        }
        #endregion
        #region calling Webservice 
        protected string WebServiceCall()
        {
            //Sample call
            /// http://ichart.yahoo.com/table.csv?s=MSFT&a=0&b=1&c=2000&d=11&e=24&f=2014&g=w&ignore=.csv
            SetDefault();
            return string.Format("{0}={1}&a={2}&b={3}&c={4}&d={5}&e={6}&f={7}&g=w&ignore=.csv", this.URL, this.StockName,
                this.a, this.b, this.c, this.d, this.e, this.f);
        }
        #endregion
        #region Download File 
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
        #endregion

    }
}
