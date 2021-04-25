using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLibrary
{
  public class DbHelper
    {
        #region Properties
        public DbProviderManager objProviderManager { get; set; }
        public string strConnectionString { get; set; }
        #endregion
        #region Construtor
        //get the connection string from Configuraion properties class and create an object of provider manager to
        //get the Factory and providername values.
        public DbHelper()
        {
            strConnectionString = DBConfigurationPropeties.strConnectionString;
            objProviderManager = new DbProviderManager();
        }
        /// <summary>
        /// get the connection string and provider name based on ConnectionName Provided
        /// </summary>
        /// <param name="ConnectionName"></param>
        public DbHelper(string ConnectionName)
        {
            strConnectionString = DBConfigurationPropeties.GetConnectionString(ConnectionName);
            objProviderManager =new  DbProviderManager(DBConfigurationPropeties.GetProviderName(ConnectionName));
        }
        /// <summary>
        /// get the connection string and provider name based on user input.
        /// </summary>
        /// <param name="ConnectionString"></param>
        /// <param name="Providername"></param>
        public DbHelper(string ConnectionString,string Providername)
        {
            strConnectionString = ConnectionString;
            objProviderManager = new DbProviderManager(Providername);
        }
        #endregion
        #region Data Objects
        /// <summary>
        /// Get the connection string based on Connection String.
        /// </summary>
        /// <returns></returns>
          public IDbConnection GetConnection()
          {
            try
            {
                var Connection = objProviderManager.Factory.CreateConnection();
                Connection.ConnectionString = strConnectionString;
                Connection.Open();

                return Connection;
            }
            catch (Exception)
            {

                throw new Exception(string.Format("Error occured while creating connection. please provide proper Connection String or Provider Name."));
            }
          }
        /// <summary>
        /// Close Connection 
        /// </summary>
        /// <param name="connection"></param>
          public void CloseConnection(IDbConnection connection)
          {
            connection.Close();
          }
            /// <summary>
            /// get 
            /// </summary>
            /// <param name="commandText"></param>
            /// <param name="connection"></param>
            /// <param name="commandType"></param>
            /// <returns></returns>
          public IDbCommand GetCommand(string commandText,IDbConnection connection,CommandType commandType)
          {
            try
            {
                IDbCommand command = objProviderManager.Factory.CreateCommand();
                command.CommandText = commandText;
                command.Connection = connection;
                command.CommandType = commandType;
                return command;
            }
            catch (Exception)
            {

                throw new Exception(string.Format("one of the parameter 'CommandText':{0} or 'Connection':{1} or 'CommandType':{2} are wrong",commandText,connection,commandType));
            }  
          }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="command"></param>
            /// <returns></returns>
            public DbDataAdapter GetDbDataAdapter(IDbCommand command)
            {
            DbDataAdapter adapter = objProviderManager.Factory.CreateDataAdapter();
            adapter.SelectCommand =(DbCommand)command;
            adapter.InsertCommand =(DbCommand)command;
            adapter.UpdateCommand = (DbCommand)command;
            adapter.DeleteCommand = (DbCommand)command;
            return adapter;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="name"></param>
            /// <param name="value"></param>
            /// <param name="dbType"></param>
            /// <returns></returns>
            public DbParameter GetParameter(string name,object value,DbType dbType)
            {
                try
                {
                DbParameter param = objProviderManager.Factory.CreateParameter();
                param.ParameterName = name;
                param.Value = value;
                param.Direction = ParameterDirection.Input;
                param.DbType = dbType;
                return param;
                }
                catch (Exception)
                {

                throw new Exception(string.Format("Invalid input parameters"));
                }
            }
              public DbParameter GetParameter(string name, object value, DbType dbType, ParameterDirection direction)
              {
                  try
                  {
                      DbParameter param = objProviderManager.Factory.CreateParameter();
                      param.ParameterName = name;
                      param.Value = value;
                      param.Direction = direction;
                      param.DbType = dbType;
                      return param;
                  }
                  catch (Exception)
                  {

                      throw new Exception(string.Format("Invalid input parameters"));
                  }
              }
              public DbParameter GetParameter(string name, object value, DbType dbType,int size,ParameterDirection direction)
              {
                  try
                  {
                      DbParameter param = objProviderManager.Factory.CreateParameter();
                      param.ParameterName = name;
                      param.Value = value;
                      param.Size = size;
                      param.Direction = direction;
                      param.DbType = dbType;
                      return param;
                  }
                  catch (Exception)
                  {

                      throw new Exception(string.Format("Invalid input parameters"));
                  }
              }

        #endregion
    }
}
