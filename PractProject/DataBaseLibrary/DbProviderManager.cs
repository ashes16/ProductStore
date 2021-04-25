using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLibrary
{
   public class DbProviderManager
    {
        #region Constructor
        public DbProviderManager()
        {
            ProviderName = DBConfigurationPropeties.GetProviderName(DBConfigurationPropeties.strDefaultConnection);
        }
        public DbProviderManager(string providername)
        {
            ProviderName = providername;
        }
        #endregion
        #region Properties

        public string ProviderName { get; set; }
        public DbProviderFactory Factory
        {
            get
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory(ProviderName);
                return factory;
            }
        }

        #endregion
     
    }
}
