
using CulturApp.BDO.GestionDatosMaestros.ConfiguracionGeneral;
using CulturApp.Utility;
using System;
using System.Data;

namespace CulturApp.DAL.GestionDatosMaestros.ConfiguracionGeneral
{

    /// <summary>
    /// DiaNoHabil.
    /// </summary>
    public class DiaNoHabilDAL
    {
        private DataTable _DataTable = null;

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(DiaNoHabilBDO DiaNoHabil)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(3);
                dbManager.AddParameters(0, "ClienteID", DbTypeValues.GetValue("Int64", DiaNoHabil.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "Fecha", DbTypeValues.GetValue("DateTime", DiaNoHabil.Fecha), ParameterDirection.Input, DbType.DateTime);
                dbManager.AddParameters(2, "Nombre", DbTypeValues.GetValue("String", DiaNoHabil.Nombre), ParameterDirection.Input, DbType.String);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspDiaNoHabilFindAll");
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
        public DataTable GetByID(long DiaNoHabilID)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "DiaNoHabilID", DbTypeValues.GetValue("Int64", DiaNoHabilID), ParameterDirection.Input, DbType.Int64);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspDiaNoHabilFindById");
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
        public int Add(DiaNoHabilBDO DiaNoHabil)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            object returnValue = 0;
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(5);
                dbManager.AddParameters(0, "DiaNoHabilID", DbTypeValues.GetValue("Int64", DiaNoHabil.DiaNoHabilID), ParameterDirection.InputOutput, DbType.Int64);
                dbManager.AddParameters(1, "ClienteID", DbTypeValues.GetValue("Int64", DiaNoHabil.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "Fecha", DbTypeValues.GetValue("DateTime", DiaNoHabil.Fecha), ParameterDirection.Input, DbType.DateTime);
                dbManager.AddParameters(3, "Nombre", DbTypeValues.GetValue("String", DiaNoHabil.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(4, "Descripcion", DbTypeValues.GetValue("String", DiaNoHabil.Descripcion), ParameterDirection.Input, DbType.String);
                returnValue = Convert.ToString(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspDiaNoHabilAdd", 0));
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
        public bool Update(DiaNoHabilBDO DiaNoHabil)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(5);
                dbManager.AddParameters(0, "DiaNoHabilID", DbTypeValues.GetValue("Int64", DiaNoHabil.DiaNoHabilID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "ClienteID", DbTypeValues.GetValue("Int64", DiaNoHabil.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "Fecha", DbTypeValues.GetValue("DateTime", DiaNoHabil.Fecha), ParameterDirection.Input, DbType.DateTime);
                dbManager.AddParameters(3, "Nombre", DbTypeValues.GetValue("String", DiaNoHabil.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(4, "Descripcion", DbTypeValues.GetValue("String", DiaNoHabil.Descripcion), ParameterDirection.Input, DbType.String);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspDiaNoHabilEdit");
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
        public bool Delete(long DiaNoHabilID)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "DiaNoHabilID", DbTypeValues.GetValue("Int64", DiaNoHabilID), ParameterDirection.Input, DbType.Int64);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspDiaNoHabilDelete");
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
