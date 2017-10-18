using System;
using System.Configuration;
using Amazon.OpsWorks.Model;
using BlackSholvesModelPricing.Utils;

namespace BlackSholvesModelPricing 
{
 
    class BlackSholvesConsole
    {
        public static WorkManager Work;
        static void Main(string[] args)
        {
            Work = new WorkManager();
            ProcessParameters(args);
            #region webservice intial testing 
            YahooWebservice yw = new YahooWebservice();
            yw.StockName = "MSFT";
            yw.Date = DateTime.Today.ToShortDateString().Replace('/','_');
            yw.Path = ConfigurationManager.AppSettings["path"];
          //  yw.Path = @"C:\Users\Avnit Bambah\Downloads";
            yw.a = "0";
            yw.b = "1";
            yw.c = "2000";
            yw.d = "6";
            yw.e = "17";
            yw.f = "2016";
            yw.DownloadFile();
            #endregion
            #region Parse File 
        //    FileParser fileParser = new FileParser();

            #endregion

            #region Database insert 

            DatabaseConnection dc = new DatabaseConnection
            {
                DatabaseName = ConfigurationManager.AppSettings["DbName"],
                ServerName = ConfigurationManager.AppSettings["serverName"],
                UserName = ConfigurationManager.AppSettings["user"],
                Password = ConfigurationManager.AppSettings["password"]
            };

            #endregion
        }

        private static void ProcessParameters(string[] args)
        {
            var type = -1;
            var pSwitch = false;
            if (args == null) return;
            try
            {
                int i;
                for (i = 0; i <= args.Length; i++)
                {
                    var param = args[i];
                    if ((param.Length == 2) && ('/' == param[0]))
                    {
                        switch (param[i])
                        {
                            case 'a':
                            case 'A':
                                type = 1;
                                pSwitch = true;
                                break;
                            case 'b':
                            case 'B':
                                type = 1;
                                pSwitch = true;
                                break;


                        }

                    }
                    if (pSwitch) pSwitch = false;
                    else
                    {
                        switch (type)
                        {
                            case 1:
                                Work.path = param.Trim();
                                break;
                            case 2:
                                Work.CurrentBusinessDate = param.Trim();
                                break;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Execption caught in process parameter" ,ex.Message);
            }
        
        }
    }
}
