using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackSholvesModelPricing.Utils;
using System.IO;
using System.Globalization;

namespace BlackSholvesModelPricing 
{
    class BlackSholvesConsole
    {
        static void Main(string[] args)
        {
            #region webservice intial testing 
            YahooWebservice Yw = new YahooWebservice();
            Yw.StockName = "MSFT";
            Yw.Date = DateTime.Today.ToShortDateString().Replace('/','_');
           // Yw.Date = DateTime.ParseExact(Today, "MM/dd/yyyy",CultureInfo.InvariantCulture).ToString(); ;
            //  Yw.Path = Directory.GetCurrentDirectory();
            Yw.Path = @"C:\Users\Avnit Bambah\Downloads";
            Yw.a = "0";
            Yw.b = "1";
            Yw.c = "2000";
            Yw.d = "6";
            Yw.e = "17";
            Yw.f = "2016";
            Yw.DownloadFile();
            #endregion
            #region Parse File 
            FileParser FileParser = new FileParser();

            #endregion

            #region Database insert 
            DatabaseConnection DC = new DatabaseConnection();
            DC.DatabaseName = "model";
            DC.ServerName = @"(localdb)\MSSQLLocalDB";
            DC.UserName = @"XXXXX";
            DC.Password = @"XXXX";

            #endregion
        }
    }
}
