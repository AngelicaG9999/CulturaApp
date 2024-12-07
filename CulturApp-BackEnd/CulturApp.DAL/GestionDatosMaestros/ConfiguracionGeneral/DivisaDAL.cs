
using CulturApp.BDO.GestionDatosMaestros.ConfiguracionGeneral;
using CulturApp.Utility;
using System;
using System.Data;

namespace CulturApp.DAL.GestionDatosMaestros.ConfiguracionGeneral
{

    /// <summary>
    /// Divisa.
    /// </summary>
    public class DivisaDAL
    {
        private DataTable _DataTable = null;

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(DivisaBDO Divisa)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(3);
                dbManager.AddParameters(0, "ClienteID", DbTypeValues.GetValue("Int64", Divisa.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "Codigo", DbTypeValues.GetValue("String", Divisa.Codigo), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(2, "Nombre", DbTypeValues.GetValue("String", Divisa.Nombre), ParameterDirection.Input, DbType.String);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspDivisaFindAll");
            }
            catch (Exception ex)
            {
                string message = "Se ha presentado una excepción inesperada" + Environment.NewLine + "Descripción: " + ex.Message;
                throw new AppException(message, ex);
            }
            finally
            {
                dbManager.Dispose();
            }
            return _DataTable;
        }

        /// <summary>
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public DataTable GetByID(long DivisaID)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "DivisaID", DbTypeValues.GetValue("Int64", DivisaID), ParameterDirection.Input, DbType.Int64);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspDivisaFindById");
            }
            catch (Exception ex)
            {
                string message = "Se ha presentado una excepción inesperada" + Environment.NewLine + "Descripción: " + ex.Message;
                throw new AppException(message, ex);
            }
            finally
            {
                dbManager.Dispose();
            }
            return _DataTable;
        }

        /// <summary>
        ///Agrega un nuevo registro.
        /// </summary>
        /// <returns></returns>
        public int Add(DivisaBDO Divisa)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            object returnValue = 0;
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(6);
                dbManager.AddParameters(0, "DivisaID", DbTypeValues.GetValue("Int64", Divisa.DivisaID), ParameterDirection.InputOutput, DbType.Int64);
                dbManager.AddParameters(1, "ClienteID", DbTypeValues.GetValue("Int64", Divisa.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "Codigo", DbTypeValues.GetValue("String", Divisa.Codigo), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(3, "Nombre", DbTypeValues.GetValue("String", Divisa.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(4, "Predeterminado", DbTypeValues.GetValue("Boolean", Divisa.Predeterminado), ParameterDirection.Input, DbType.Boolean);
                dbManager.AddParameters(5, "Activo", DbTypeValues.GetValue("Boolean", Divisa.Activo), ParameterDirection.Input, DbType.Boolean);
                returnValue = Convert.ToString(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspDivisaAdd", 0));
            }
            catch (Exception ex)
            {
                string message = "No se ha podido crear el registro." + Environment.NewLine + "Descripción: " + ex.Message;
                throw new AppException(message, ex);
            }
            finally
            {
                dbManager.Dispose();
            }
            return Convert.ToInt32(returnValue);
        }

        /// <summary>
        ///Actualiza un registro.
        /// </summary>
        /// <returns></returns>
        public bool Update(DivisaBDO Divisa)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(6);
                dbManager.AddParameters(0, "DivisaID", DbTypeValues.GetValue("Int64", Divisa.DivisaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "ClienteID", DbTypeValues.GetValue("Int64", Divisa.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "Codigo", DbTypeValues.GetValue("String", Divisa.Codigo), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(3, "Nombre", DbTypeValues.GetValue("String", Divisa.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(4, "Predeterminado", DbTypeValues.GetValue("Boolean", Divisa.Predeterminado), ParameterDirection.Input, DbType.Boolean);
                dbManager.AddParameters(5, "Activo", DbTypeValues.GetValue("Boolean", Divisa.Activo), ParameterDirection.Input, DbType.Boolean);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspDivisaEdit");
            }
            catch (Exception ex)
            {
                string message = "No se ha podido actualizar el registro." + Environment.NewLine + "Descripción: " + ex.Message;
                throw new AppException(message, ex);
            }
            finally
            {
                dbManager.Dispose();
            }
            return true;
        }

        /// <summary>
        ///Elimina un registro.
        /// </summary>
        /// <returns></returns>
        public bool Delete(long DivisaID)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "DivisaID", DbTypeValues.GetValue("Int64", DivisaID), ParameterDirection.Input, DbType.Int64);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspDivisaDelete");
            }
            catch (Exception ex)
            {
                string message = "No se ha podido eliminar el registro." + Environment.NewLine + "Descripción: " + ex.Message;
                throw new AppException(message, ex);
            }
            finally
            {
                dbManager.Dispose();
            }
            return true;
        }
    }
}
