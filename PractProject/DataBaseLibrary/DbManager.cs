using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLibrary
{
   public class DbManager
   {
        #region Variables
        private DbHelper objdatabase;
        #endregion
        #region Constructor
        public DbManager(string ConnectionString)
        {
            objdatabase = new DbHelper(ConnectionString);
        }
        #endregion
        #region Methods
        public IDbConnection GetConnection()
        {
          return  objdatabase.GetConnection();
        }

        public void CloseConnection(IDbConnection conn)
        {
            objdatabase.CloseConnection(conn);
        }

        public IDbDataParameter CreateParameter(string name,object value,DbType dbtype)
        {
            return objdatabase.GetParameter(name, value, dbtype,ParameterDirection.Input);
        }

        public IDbDataParameter CreateParameter(string name,object value,DbType dbtype,int size)
        {
            return objdatabase.GetParameter(name, value,dbtype,size,ParameterDirection.Input);
        }

        public IDbDataParameter CreateParameter(string name,object value,DbType dbtype,int size,ParameterDirection option)
        {
            return objdatabase.GetParameter(name, value, dbtype, size, option);
        }

        public DataTable GetDataTable(string commandText,CommandType commandType,IDbDataParameter[] parameters=null)
        {
            using(var connection = objdatabase.GetConnection())
            {
                using(var command= objdatabase.GetCommand(commandText,connection,commandType))
                {
                    if(parameters!=null)
                    {
                        foreach (var para in parameters)
                        {
                            command.Parameters.Add(para);
                        }
                    }
                    var dataset = new DataSet();
                    var datAdapter = objdatabase.GetDbDataAdapter(command);
                    datAdapter.Fill(dataset);
                    return dataset.Tables[0];
                }
            }
        }

        public DataSet GetDataSet(string commandText, CommandType commandType, IDbDataParameter[] parameters = null)
        {
            using (var connection = objdatabase.GetConnection())
            {
                using (var command = objdatabase.GetCommand(commandText, connection, commandType))
                {
                    if (parameters != null)
                    {
                        foreach (var para in parameters)
                        {
                            command.Parameters.Add(para);
                        }
                    }
                    var dataset = new DataSet();
                    var datAdapter = objdatabase.GetDbDataAdapter(command);
                    datAdapter.Fill(dataset);
                    return dataset;
                }
            }
        }

        public IDataReader GetDataReader(string commandText,CommandType commandType,IDbDataParameter[] parameters=null,out IDbConnection connection)
        {
            IDataReader reader=null;
            using(connection=objdatabase.GetConnection())
            {
                using (var command = objdatabase.GetCommand(commandText, connection, commandType))
                {
                    if(parameters!=null)
                    {
                        foreach (var item in parameters)
                        {
                            command.Parameters.Add(item);
                        }
                    }
                    reader =command.ExecuteReader();
                }
            }
            return reader;
        }

        public void Delete(string commandText,CommandType commandType,IDataParameter[] parameters=null)
        {
            using(var connection = objdatabase.GetConnection())
            {
                using(var command = objdatabase.GetCommand(commandText,connection, commandType))
                {
                    if(parameters!=null)
                    {
                        foreach (var item in parameters)
                        {
                            command.Parameters.Add(item);
                        }
                    }
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Insert(string commandText, CommandType commandType, IDataParameter[] parameters = null)
        {
            using (var connection = objdatabase.GetConnection())
            {
                using (var command = objdatabase.GetCommand(commandText, connection, commandType))
                {
                    if (parameters != null)
                    {
                        foreach (var item in parameters)
                        {
                            command.Parameters.Add(item);
                        }
                    }
                    command.ExecuteNonQuery();
                }
            }
        }
        public void InsertWithTransaction(string commandText, CommandType commandType, IDataParameter[] parameters = null)
        {
            IDbTransaction transactionScope = null;
            using (var connection = objdatabase.GetConnection())
            {
                transactionScope = connection.BeginTransaction();
                using (var command = objdatabase.GetCommand(commandText, connection, commandType))
                {
                    if (parameters != null)
                    {
                        foreach (var item in parameters)
                        {
                            command.Parameters.Add(item);
                        }
                    }
                    try
                    {
                        command.ExecuteNonQuery();
                        transactionScope.Commit();
                    }
                    catch (Exception)
                    {
                        transactionScope.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Update(string commandText, CommandType commandType, IDataParameter[] parameters = null)
        {
            using (var connection = objdatabase.GetConnection())
            {
                using (var command = objdatabase.GetCommand(commandText, connection, commandType))
                {
                    if (parameters != null)
                    {
                        foreach (var item in parameters)
                        {
                            command.Parameters.Add(item);
                        }
                    }
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateWithTransaction(string commandText, CommandType commandType, IDataParameter[] parameters = null)
        {
            IDbTransaction transactionScope = null;
            using (var connection = objdatabase.GetConnection())
            {
                transactionScope = connection.BeginTransaction();
                using (var command = objdatabase.GetCommand(commandText, connection, commandType))
                {
                    if (parameters != null)
                    {
                        foreach (var item in parameters)
                        {
                            command.Parameters.Add(item);
                        }
                    }
                    try
                    {
                        command.ExecuteNonQuery();
                        transactionScope.Commit();
                    }
                    catch (Exception)
                    {
                        transactionScope.Rollback();
                        throw;
                    }
                }
            }
        }

        public object GetScalarValue(string commandText, CommandType commandType, IDataParameter[] parameters = null)
        {
            using (var connection = objdatabase.GetConnection())
            {
                using (var command = objdatabase.GetCommand(commandText, connection, commandType))
                {
                    if (parameters != null)
                    {
                        foreach (var item in parameters)
                        {
                            command.Parameters.Add(item);
                        }
                    }
                  return command.ExecuteScalar();
                }
            }
        }
        #endregion

    }
}
