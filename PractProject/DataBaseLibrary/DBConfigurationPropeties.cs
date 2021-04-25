using System;
using System.Configuration;

namespace DataBaseLibrary
{
    public static class DBConfigurationPropeties
    {
        #region Properties
        //get Default connection of string
        public static string strDefaultConnection
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["MySqlConnection"].ToString();
            }
        }
        //get provider name from given connection string.
        public static string strProviderName
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[strDefaultConnection].ProviderName;
            }
        }
        // get ConnectionString based on strDefaultConnection.
        public static string strConnectionString
        {
            get
            {
                try
                {
                    return ConfigurationManager.ConnectionStrings[strDefaultConnection].ConnectionString;
                }
                catch (Exception)
                {

                    throw new Exception(string.Format("Connection String '{0}' not found....", strDefaultConnection));
                }
            }
        }
        #endregion

        #region public methods
            //get Connection string based on user input.
            public static string GetConnectionString(string ConnectionName)
            {
                 try
                 {
                     return ConfigurationManager.ConnectionStrings[ConnectionName].ConnectionString;
                 }
                 catch (Exception)
                 {

                     throw new Exception(string.Format("Connection string {0} not found...",ConnectionName));
                 }
            }
            //get provide name based on user input.
            public static string GetProviderName(string ConnectionName)
            {
            try
            {
                return ConfigurationManager.ConnectionStrings[ConnectionName].ProviderName;
            }
            catch (Exception)
            {

                throw new Exception(string.Format("Provider Name not found for '{0}' ",ConnectionName));
            }
            }
        
        #endregion

    }
}
