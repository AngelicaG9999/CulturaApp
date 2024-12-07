using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.IO;

namespace CulturApp.DAL
{
    public sealed class DBManager : IDBManager, IDisposable
    {
        private IDbConnection idbConnection;
        private IDataReader idataReader;
        private IDbCommand idbCommand;
        private DataProvider providerType;
        private IDbTransaction idbTransaction = null;
        private IDbDataParameter[] idbParameters = null;
        private string strConnection;
        //private cAppConfig appCfg = new cAppConfig();


        public DBManager(DataBase dataBase = DataBase.CulturApp)
        {
            // https: // corderoski.wordpress.com/2017/09/18/how-to-read-appsettings-json-from-class-library-in-asp-net-core/

            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var configuration = configurationBuilder.Build();

            if (dataBase == DataBase.CulturApp)
            {
                this.ConnectionString = configuration.GetConnectionString("CulturAppDBConnectionString");
            }
            else
            {
                this.ConnectionString = configuration.GetConnectionString("DBConnectionString");
            }

            this.providerType = DataProvider.SqlServer;
        }

        public IDbConnection Connection
        {
            get
            {
                return idbConnection;
            }
        }

        public IDataReader DataReader
        {
            get
            {
                return idataReader;
            }
            set
            {
                idataReader = value;
            }
        }

        public DataProvider ProviderType
        {
            get
            {
                return providerType;
            }
            set
            {
                providerType = value;
            }
        }

        public string ConnectionString
        {
            get
            {
                return strConnection;
            }
            set
            {
                strConnection = value;
            }
        }

        public IDbCommand Command
        {
            get
            {
                return idbCommand;
            }
        }

        public IDbTransaction Transaction
        {
            get
            {
                return idbTransaction;
            }
        }

        public IDbDataParameter[] Parameters
        {
            get
            {
                return idbParameters;
            }
        }

        public void Open()
        {
            idbConnection = DBManagerFactory.GetConnection(this.providerType);
            idbConnection.ConnectionString = this.ConnectionString;
            if (idbConnection.State != ConnectionState.Open)
                idbConnection.Open();
            this.idbCommand = DBManagerFactory.GetCommand(this.ProviderType);
        }

        public void Close()
        {
            if (idbConnection.State != ConnectionState.Closed)
                idbConnection.Close();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Close();
            this.idbCommand = null;
            this.idbTransaction = null;
            this.idbConnection = null;
        }

        public void CreateParameters(int paramsCount)
        {
            idbParameters = new IDbDataParameter[paramsCount];
            idbParameters = DBManagerFactory.GetParameters(this.ProviderType, paramsCount);
        }

        public void AddParameters(int index, string paramName, object objValue)
        {
            if (index < idbParameters.Length)
            {
                switch (providerType)
                {
                    case DataProvider.SqlServer:
                        paramName = (string)"@" + paramName;
                        break;
                }
                idbParameters[index].ParameterName = paramName;
                idbParameters[index].Value = objValue;
            }
        }

        public void AddParameters(int index, string paramName, object objValue, ParameterDirection paramDirection)
        {
            if (index < idbParameters.Length)
            {
                switch (providerType)
                {
                    case DataProvider.SqlServer:
                        paramName = (string)"@" + paramName;
                        break;
                }

                idbParameters[index].ParameterName = paramName;
                idbParameters[index].Value = objValue;
                idbParameters[index].Direction = paramDirection;
            }
        }

        public void AddParameters(int index, string paramName, object objValue, ParameterDirection paramDirection, DbType paramDbType)
        {
            if (index < idbParameters.Length)
            {
                switch (providerType)
                {
                    case DataProvider.SqlServer:
                        paramName = (string)"@" + paramName;
                        break;
                }

                idbParameters[index].ParameterName = paramName;
                idbParameters[index].Value = objValue;
                idbParameters[index].Direction = paramDirection;
                idbParameters[index].DbType = paramDbType;
            }
        }

        /// <summary>
        /// Retorna el valor de un patametro
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private object ParameterGetValue(int index)
        {
            return idbParameters[index].Value;
        }

        public void BeginTransaction()
        {
            if (this.idbTransaction == null)
                idbTransaction =
                DBManagerFactory.GetTransaction(this.ProviderType);
            this.idbCommand.Transaction = idbTransaction;
        }

        public void CommitTransaction()
        {
            if (this.idbTransaction != null)
                this.idbTransaction.Commit();
            idbTransaction = null;
        }

        public IDataReader ExecuteReader(CommandType commandType, string commandText)
        {
            this.idbCommand = DBManagerFactory.GetCommand(this.ProviderType);
            idbCommand.Connection = this.Connection;
            PrepareCommand(idbCommand, this.Connection, this.Transaction, commandType, commandText, this.Parameters);
            this.DataReader = idbCommand.ExecuteReader();
            idbCommand.Parameters.Clear();
            return this.DataReader;
        }

        public void CloseReader()
        {
            if (this.DataReader != null)
                this.DataReader.Close();
        }

        private void AttachParameters(IDbCommand command, IDbDataParameter[] commandParameters)
        {
            foreach (IDbDataParameter idbParameter in commandParameters)
            {
                if ((idbParameter.Direction == ParameterDirection.InputOutput) && (idbParameter.Value == null))
                {
                    idbParameter.Value = DBNull.Value;
                }
                command.Parameters.Add(idbParameter);
            }
        }

        private void PrepareCommand(IDbCommand command, IDbConnection connection, IDbTransaction transaction, CommandType commandType, string commandText, IDbDataParameter[] commandParameters)
        {
            command.Connection = connection;
            command.CommandText = commandText;
            command.CommandType = commandType;

            if (transaction != null)
            {
                command.Transaction = transaction;
            }

            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
        }

        public int ExecuteNonQuery(CommandType commandType, string commandText)
        {
            this.idbCommand = DBManagerFactory.GetCommand(this.ProviderType);
            PrepareCommand(idbCommand, this.Connection, this.Transaction, commandType, commandText, this.Parameters);
            int returnValue = idbCommand.ExecuteNonQuery();
            idbCommand.Parameters.Clear();
            return returnValue;
        }

        public object ExecuteNonQuery(CommandType commandType, string commandText, int paramIndex)
        {
            this.idbCommand = DBManagerFactory.GetCommand(this.ProviderType);
            PrepareCommand(idbCommand, this.Connection, this.Transaction, commandType, commandText, this.Parameters);
            idbCommand.ExecuteNonQuery();
            object returnValue = ParameterGetValue(paramIndex);
            idbCommand.Parameters.Clear();
            return returnValue;
        }

        public object ExecuteScalar(CommandType commandType, string commandText)
        {
            this.idbCommand = DBManagerFactory.GetCommand(this.ProviderType);
            PrepareCommand(idbCommand, this.Connection, this.Transaction, commandType, commandText, this.Parameters);
            object returnValue = idbCommand.ExecuteScalar();
            idbCommand.Parameters.Clear();
            return returnValue;
        }

        /// <summary>
        /// Return a DataSet Object
        /// </summary>
        /// <param name="commandType">Command Type</param>
        /// <param name="commandText">Command Text</param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(CommandType commandType, string commandText)
        {
            this.idbCommand = DBManagerFactory.GetCommand(this.ProviderType);
            PrepareCommand(idbCommand, this.Connection, this.Transaction, commandType, commandText, this.Parameters);
            IDbDataAdapter dataAdapter = DBManagerFactory.GetDataAdapter(this.ProviderType);
            dataAdapter.SelectCommand = idbCommand;
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            idbCommand.Parameters.Clear();
            return dataSet;
        }

        /// <summary>
        /// Return a DataTable Object
        /// </summary>
        /// <param name="commandType">Command Type</param>
        /// <param name="commandText">Command Text</param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(CommandType commandType, string commandText)
        {
            this.idbCommand = DBManagerFactory.GetCommand(this.ProviderType);
            PrepareCommand(idbCommand, this.Connection, this.Transaction, commandType, commandText, this.Parameters);
            IDbDataAdapter dataAdapter = DBManagerFactory.GetDataAdapter(this.ProviderType);
            dataAdapter.SelectCommand = idbCommand;
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            DataTable dataTable = new DataTable();
            dataTable = dataSet.Tables[0];
            idbCommand.Parameters.Clear();
            return dataTable;
        }

    }

}
