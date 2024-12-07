
using System;
using System.Data;

using CulturApp.Utility;
using CulturApp.BDO.GestionDatosMaestros;

namespace CulturApp.DAL.GestionDatosMaestros
{

    /// <summary>
    /// Tipo.
    /// </summary>
    public class TipoDAL
    {
        private DataTable _DataTable = null;

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(TipoBDO Tipo)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "EmpresaID", DbTypeValues.GetValue("Int64", Tipo.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "Nombre", DbTypeValues.GetValue("String", Tipo.Nombre), ParameterDirection.Input, DbType.String);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspTipoFindAll");
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
        public DataTable GetByID(long TipoID)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "TipoID", DbTypeValues.GetValue("Int64", TipoID), ParameterDirection.Input, DbType.Int64);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspTipoFindById");
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
        public int Add(TipoBDO Tipo)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            object returnValue = 0;
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(4);
                dbManager.AddParameters(0, "TipoID", DbTypeValues.GetValue("Int64", Tipo.TipoID), ParameterDirection.InputOutput, DbType.Int64);
                dbManager.AddParameters(1, "EmpresaID", DbTypeValues.GetValue("Int64", Tipo.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "Nombre", DbTypeValues.GetValue("String", Tipo.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(3, "Descripcion", DbTypeValues.GetValue("String", Tipo.Descripcion), ParameterDirection.Input, DbType.String);
                returnValue = Convert.ToString(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspTipoAdd", 0));
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
        public bool Update(TipoBDO Tipo)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(4);
                dbManager.AddParameters(0, "TipoID", DbTypeValues.GetValue("Int64", Tipo.TipoID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "EmpresaID", DbTypeValues.GetValue("Int64", Tipo.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "Nombre", DbTypeValues.GetValue("String", Tipo.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(3, "Descripcion", DbTypeValues.GetValue("String", Tipo.Descripcion), ParameterDirection.Input, DbType.String);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspTipoEdit");
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
        public bool Delete(long TipoID)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "TipoID", DbTypeValues.GetValue("Int64", TipoID), ParameterDirection.Input, DbType.Int64);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspTipoDelete");
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

