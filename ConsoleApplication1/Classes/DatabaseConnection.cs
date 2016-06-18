using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace BlackSholvesModelPricing.Classes
{
    class DatabaseConnection
    {
        public string DatabaseName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ServerName { get; set; }

        //Singleton 
        private string ConnectionString()
        {
            return "Initial Catalog=" + DatabaseName + ";username=" + UserName + ";password=" + Password + ";DataSource = " + ServerName + ";";
        }
        //Singleton
        private SqlConnection SqlConnection()
        {
            
            try
            {
                SqlConnection sq = new SqlConnection(ConnectionString());
                return sq;

            }
            catch (SqlException Ex)
            {
                Console.WriteLine("Error in connecting to sql server" + Ex.ToString());
                throw (Ex);
                //return null;
            }
        }
        public int ExecuteStoredProcedure(string StoredProcedureName, Dictionary<string,string> Parameter)
        {
            try
            {
                SqlCommand SC = new SqlCommand();
                SC.CommandTimeout = 0;
                foreach (KeyValuePair<string, string> KT in Parameter)
                {
                    SC.Parameters.AddWithValue(KT.Key, KT.Value);
                }
                SC.Connection = SqlConnection();
                SC.CommandText = StoredProcedureName;
                return SC.ExecuteNonQuery();
            }
            catch (SqlException Ex)
            {
                Console.Write("Sql Exception" + Ex.ToString());
                throw (Ex);
            //    return Ex.Number; //Error Code 
            }
        }

    }
}
