
using CulturApp.BDO.AdministracionDelSistema.ReglasGenerales.ReglasDelSistema;
using CulturApp.Utility;
using System;
using System.Data;

namespace CulturApp.DAL.AdministracionDelSistema.ReglasGenerales.ReglasDelSistema
{

    /// <summary>
    /// SYSVersion.
    /// </summary>
    public class SYSVersionDAL
    {
        private DataTable _DataTable = null;

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(SYSVersionBDO SYSVersion)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                //dbManager.CreateParameters(4);
                //dbManager.AddParameters(0, "SYSVersionID",DbTypeValues.GetValue("Int64",SYSVersion.SYSVersionID), ParameterDirection.Input, DbType.Int64);
                //dbManager.AddParameters(1, "Version",DbTypeValues.GetValue("String",SYSVersion.Version), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(2, "Descripcion",DbTypeValues.GetValue("String",SYSVersion.Descripcion), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(3, "Fecha",DbTypeValues.GetValue("DateTime",SYSVersion.Fecha), ParameterDirection.Input, DbType.DateTime);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspSYSVersionFindAll");
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
        public DataTable GetByID(long SYSVersionID)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "SYSVersionID", DbTypeValues.GetValue("Int64", SYSVersionID), ParameterDirection.Input, DbType.Int64);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspSYSVersionFindById");
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
        public int Add(SYSVersionBDO SYSVersion)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            object returnValue = 0;
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(4);
                dbManager.AddParameters(0, "SYSVersionID", DbTypeValues.GetValue("Int64", SYSVersion.SYSVersionID), ParameterDirection.InputOutput, DbType.Int64);
                dbManager.AddParameters(1, "Version", DbTypeValues.GetValue("String", SYSVersion.Version), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(2, "Descripcion", DbTypeValues.GetValue("String", SYSVersion.Descripcion), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(3, "Fecha", DbTypeValues.GetValue("DateTime", SYSVersion.Fecha), ParameterDirection.Input, DbType.DateTime);
                returnValue = Convert.ToString(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspSYSVersionAdd", 0));
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
        public bool Update(SYSVersionBDO SYSVersion)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(4);
                dbManager.AddParameters(0, "SYSVersionID", DbTypeValues.GetValue("Int64", SYSVersion.SYSVersionID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "Version", DbTypeValues.GetValue("String", SYSVersion.Version), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(2, "Descripcion", DbTypeValues.GetValue("String", SYSVersion.Descripcion), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(3, "Fecha", DbTypeValues.GetValue("DateTime", SYSVersion.Fecha), ParameterDirection.Input, DbType.DateTime);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspSYSVersionEdit");
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
        public bool Delete(long SYSVersionID)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "SYSVersionID", DbTypeValues.GetValue("Int64", SYSVersionID), ParameterDirection.Input, DbType.Int64);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspSYSVersionDelete");
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
