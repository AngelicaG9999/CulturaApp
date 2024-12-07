
using CulturApp.BDO.AdministracionDelSistema.ReglasGenerales.ReglasDelSistema;
using CulturApp.Utility;
using System;
using System.Data;

namespace CulturApp.DAL.AdministracionDelSistema.ReglasGenerales.ReglasDelSistema
{

    /// <summary>
    /// Ciudad.
    /// </summary>
    public class CiudadDAL
    {
        private DataTable _DataTable = null;

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(CiudadBDO Ciudad)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "DepartamentoID", DbTypeValues.GetValue("Int32", Ciudad.DepartamentoID), ParameterDirection.Input, DbType.Int32);
                dbManager.AddParameters(1, "Nombre", DbTypeValues.GetValue("String", Ciudad.Nombre), ParameterDirection.Input, DbType.String);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspCiudadFindAll");
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
        public DataTable GetByID(int CiudadID)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "CiudadID", DbTypeValues.GetValue("Int32", CiudadID), ParameterDirection.Input, DbType.Int32);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspCiudadFindById");
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
        public int Add(CiudadBDO Ciudad)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            object returnValue = 0;
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(4);
                dbManager.AddParameters(0, "CiudadID", DbTypeValues.GetValue("Int32", Ciudad.CiudadID), ParameterDirection.InputOutput, DbType.Int32);
                dbManager.AddParameters(1, "DepartamentoID", DbTypeValues.GetValue("Int32", Ciudad.DepartamentoID), ParameterDirection.Input, DbType.Int32);
                dbManager.AddParameters(2, "Nombre", DbTypeValues.GetValue("String", Ciudad.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(3, "Activo", DbTypeValues.GetValue("Boolean", Ciudad.Activo), ParameterDirection.Input, DbType.Boolean);
                returnValue = Convert.ToString(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspCiudadAdd", 0));
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
        public bool Update(CiudadBDO Ciudad)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(4);
                dbManager.AddParameters(0, "CiudadID", DbTypeValues.GetValue("Int32", Ciudad.CiudadID), ParameterDirection.Input, DbType.Int32);
                dbManager.AddParameters(1, "DepartamentoID", DbTypeValues.GetValue("Int32", Ciudad.DepartamentoID), ParameterDirection.Input, DbType.Int32);
                dbManager.AddParameters(2, "Nombre", DbTypeValues.GetValue("String", Ciudad.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(3, "Activo", DbTypeValues.GetValue("Boolean", Ciudad.Activo), ParameterDirection.Input, DbType.Boolean);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspCiudadEdit");
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
        public bool Delete(int CiudadID)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "CiudadID", DbTypeValues.GetValue("Int32", CiudadID), ParameterDirection.Input, DbType.Int32);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspCiudadDelete");
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
