
using System;
using System.Data;

using CulturApp.Utility;
using CulturApp.BDO.GestionDatosMaestros;

namespace CulturApp.DAL.GestionDatosMaestros
{

    /// <summary>
    /// Area.
    /// </summary>
    public class AreaDAL
    {
        private DataTable _DataTable = null;

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(AreaBDO Area)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(3);
                dbManager.AddParameters(0, "EmpresaID", DbTypeValues.GetValue("Int64", Area.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "Nombre", DbTypeValues.GetValue("String", Area.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(2, "ModalidadID", DbTypeValues.GetValue("Int64", Area.ModalidadID), ParameterDirection.Input, DbType.Int64);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspAreaFindAll");
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
        public DataTable GetByID(long AreaID)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "AreaID", DbTypeValues.GetValue("Int64", AreaID), ParameterDirection.Input, DbType.Int64);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspAreaFindById");
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
        public int Add(AreaBDO Area)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            object returnValue = 0;
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(5);
                dbManager.AddParameters(0, "AreaID", DbTypeValues.GetValue("Int64", Area.AreaID), ParameterDirection.InputOutput, DbType.Int64);
                dbManager.AddParameters(1, "EmpresaID", DbTypeValues.GetValue("Int64", Area.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "ModalidadID", DbTypeValues.GetValue("Int64", Area.ModalidadID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(3, "Nombre", DbTypeValues.GetValue("String", Area.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(4, "Descripcion", DbTypeValues.GetValue("String", Area.Descripcion), ParameterDirection.Input, DbType.String);
                returnValue = Convert.ToString(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspAreaAdd", 0));
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
        public bool Update(AreaBDO Area)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(5);
                dbManager.AddParameters(0, "AreaID", DbTypeValues.GetValue("Int64", Area.AreaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "EmpresaID", DbTypeValues.GetValue("Int64", Area.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "ModalidadID", DbTypeValues.GetValue("Int64", Area.ModalidadID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(3, "Nombre", DbTypeValues.GetValue("String", Area.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(4, "Descripcion", DbTypeValues.GetValue("String", Area.Descripcion), ParameterDirection.Input, DbType.String);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspAreaEdit");
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
        public bool Delete(long AreaID)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "AreaID", DbTypeValues.GetValue("Int64", AreaID), ParameterDirection.Input, DbType.Int64);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspAreaDelete");
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

