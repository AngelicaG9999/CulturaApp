using System.Data;

namespace CulturApp.DAL
{
    /// <summary>
    /// Proveedor de datos.
    /// </summary>
    public enum DataProvider
    {
        SqlServer
    }

    public enum DataBase
    {
        SyscorpCloud, CulturApp
    }

    public interface IDBManager
    {
        //http://aspalliance.com/837       

        DataProvider ProviderType
        {
            get;
            set;
        }

        string ConnectionString { get; set; }

        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }

        IDataReader DataReader { get; }
        IDbCommand Command { get; }

        IDbDataParameter[] Parameters { get; }

        void Open();

        void BeginTransaction();

        void CommitTransaction();

        void CreateParameters(int paramsCount);

        void AddParameters(int index, string stringparamName, object objValue);

        void AddParameters(int index, string stringparamName, object objValue, ParameterDirection paramDirection);

        void AddParameters(int index, string stringparamName, object objValue, ParameterDirection paramDirection, DbType paramDbType);

        IDataReader ExecuteReader(CommandType CommandTypecommandType, string commandText);

        DataSet ExecuteDataSet(CommandType CommandTypecommandType, string commandText);

        DataTable ExecuteDataTable(CommandType CommandTypecommandType, string commandText);

        object ExecuteScalar(CommandType CommandTypecommandType, string commandText);

        int ExecuteNonQuery(CommandType commandType, string commandText);

        object ExecuteNonQuery(CommandType commandType, string commandText, int paramIndex);

        void CloseReader();

        void Close();

        void Dispose();
    }
}
