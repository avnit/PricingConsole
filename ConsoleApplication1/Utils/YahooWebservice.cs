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
                URL =  "http://ichart.yahoo.com/table.csv?s";
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
            return Path + "/" + Date + "_" + StockName + ".csv";
        }
        #endregion
        #region calling Webservice 
        protected string WebServiceCall()
        {
            //Sample call
            /// http://ichart.yahoo.com/table.csv?s=MSFT&a=0&b=1&c=2000&d=11&e=24&f=2014&g=w&ignore=.csv
            SetDefault();
            return
                $"{URL}={StockName}&a={a}&b={b}&c={c}&d={d}&e={e}&f={f}&g=w&ignore=.csv";
        }
        #endregion
        #region Download File 
        public void DownloadFile ()
        {
            try
            {
                var webserviceUrl = WebServiceCall();
                var dayFile = FileName();
              
                var ws = new WebClient();
                ws.DownloadFile(webserviceUrl, dayFile);
                Console.WriteLine(StockName + " Data downloaded successfully!");
                ws.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error " + ex.Message);
            }
        }
        #endregion

    }
}
