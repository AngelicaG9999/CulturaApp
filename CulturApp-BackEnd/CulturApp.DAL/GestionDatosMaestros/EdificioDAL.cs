using System;
using System.Data;

using CulturApp.Utility;
using CulturApp.BDO.GestionDatosMaestros;

namespace CulturApp.DAL.GestionDatosMaestros
{
    public class EdificioDAL
    {
        private DataTable _DataTable = null;

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(EdificioBDO EdificioBdo)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(3);
                dbManager.AddParameters(0, "EmpresaID", DbTypeValues.GetValue("Int64", EdificioBdo.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "BarrioID", DbTypeValues.GetValue("Int64", EdificioBdo.BarrioID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "Nombre", DbTypeValues.GetValue("String", EdificioBdo.Nombre), ParameterDirection.Input, DbType.String);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspEdificioFindAll");
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
        public DataTable GetByID(long EdificioID)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "EdificioID", DbTypeValues.GetValue("Int64", EdificioID), ParameterDirection.Input, DbType.Int64);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspEdificioFindById");
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
        public int Add(EdificioBDO EdificioBdo)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            object returnValue = 0;
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(5);
                dbManager.AddParameters(0, "EdificioID", DbTypeValues.GetValue("Int64", EdificioBdo.EdificioID), ParameterDirection.InputOutput, DbType.Int64);
                dbManager.AddParameters(1, "EmpresaID", DbTypeValues.GetValue("Int64", EdificioBdo.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "BarrioID", DbTypeValues.GetValue("Int64", EdificioBdo.BarrioID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(3, "Nombre", DbTypeValues.GetValue("String", EdificioBdo.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(4, "Direccion", DbTypeValues.GetValue("String", EdificioBdo.Direccion), ParameterDirection.Input, DbType.String);
                returnValue = Convert.ToString(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspEdificioAdd", 0));
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
        public bool Update(EdificioBDO EdificioBdo)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(5);
                dbManager.AddParameters(0, "EdificioID", DbTypeValues.GetValue("Int64", EdificioBdo.EdificioID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "EmpresaID", DbTypeValues.GetValue("Int64", EdificioBdo.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "BarrioID", DbTypeValues.GetValue("Int64", EdificioBdo.BarrioID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(3, "Nombre", DbTypeValues.GetValue("String", EdificioBdo.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(4, "Direccion", DbTypeValues.GetValue("String", EdificioBdo.Direccion), ParameterDirection.Input, DbType.String);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspEdificioEdit");
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
        public bool Delete(long EdificioID)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "EdificioID", DbTypeValues.GetValue("Int64", EdificioID), ParameterDirection.Input, DbType.Int64);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspEdificioDelete");
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
