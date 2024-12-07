
using System;
using System.Data;

using CulturApp.Utility;
using CulturApp.BDO.GestionDatosMaestros;

namespace CulturApp.DAL.GestionDatosMaestros
{

    /// <summary>
    /// Inscripcion.
    /// </summary>
    public class InscripcionDAL
    {
        private DataTable _DataTable = null;

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(InscripcionBDO Inscripcion)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(4);
                dbManager.AddParameters(0, "EmpresaID", DbTypeValues.GetValue("Int64", Inscripcion.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "EstimuloID", DbTypeValues.GetValue("Int64", Inscripcion.EstimuloID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "Radicado", DbTypeValues.GetValue("String", Inscripcion.Radicado), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(3, "TipoID", DbTypeValues.GetValue("Int64", Inscripcion.TipoID), ParameterDirection.Input, DbType.Int64);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspInscripcionFindAll");
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
        public DataTable GetByID(long InscripcionID)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "InscripcionID", DbTypeValues.GetValue("Int64", InscripcionID), ParameterDirection.Input, DbType.Int64);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspInscripcionFindById");
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
        public int Add(InscripcionBDO Inscripcion)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            object returnValue = 0;
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(7);
                dbManager.AddParameters(0, "InscripcionID", DbTypeValues.GetValue("Int64", Inscripcion.InscripcionID), ParameterDirection.InputOutput, DbType.Int64);
                dbManager.AddParameters(1, "EmpresaID", DbTypeValues.GetValue("Int64", Inscripcion.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "EstimuloID", DbTypeValues.GetValue("Int64", Inscripcion.EstimuloID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(3, "Radicado", DbTypeValues.GetValue("String", Inscripcion.Radicado), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(4, "TipoID", DbTypeValues.GetValue("Int64", Inscripcion.TipoID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(5, "NumIntegrantes", DbTypeValues.GetValue("Int64", Inscripcion.NumIntegrantes), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(6, "FechaHora", DbTypeValues.GetValue("DateTime", Inscripcion.FechaHora), ParameterDirection.Input, DbType.DateTime);
                returnValue = Convert.ToString(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspInscripcionAdd", 0));
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
        public bool Update(InscripcionBDO Inscripcion)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(7);
                dbManager.AddParameters(0, "InscripcionID", DbTypeValues.GetValue("Int64", Inscripcion.InscripcionID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "EmpresaID", DbTypeValues.GetValue("Int64", Inscripcion.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "EstimuloID", DbTypeValues.GetValue("Int64", Inscripcion.EstimuloID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(3, "Radicado", DbTypeValues.GetValue("String", Inscripcion.Radicado), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(4, "TipoID", DbTypeValues.GetValue("Int64", Inscripcion.TipoID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(5, "NumIntegrantes", DbTypeValues.GetValue("Int64", Inscripcion.NumIntegrantes), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(6, "FechaHora", DbTypeValues.GetValue("DateTime", Inscripcion.FechaHora), ParameterDirection.Input, DbType.DateTime);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspInscripcionEdit");
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
        public bool Delete(long InscripcionID)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "InscripcionID", DbTypeValues.GetValue("Int64", InscripcionID), ParameterDirection.Input, DbType.Int64);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspInscripcionDelete");
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

