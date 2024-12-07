
using CulturApp.BDO.AdministracionDelSistema.ReglasGenerales.ReglasDelSistema;
using CulturApp.Utility;
using System;
using System.Data;

namespace CulturApp.DAL.AdministracionDelSistema.ReglasGenerales.ReglasDelSistema
{

    /// <summary>
    /// Pais.
    /// </summary>
    public class PaisDAL
    {
        private DataTable _DataTable = null;

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(PaisBDO Pais)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "Codigo", DbTypeValues.GetValue("String", Pais.Codigo), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(1, "Nombre", DbTypeValues.GetValue("String", Pais.Nombre), ParameterDirection.Input, DbType.String);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspPaisFindAll");
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
        public DataTable GetByID(int PaisID)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "PaisID", DbTypeValues.GetValue("Int32", PaisID), ParameterDirection.Input, DbType.Int32);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspPaisFindById");
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
        public int Add(PaisBDO Pais)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            object returnValue = 0;
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(4);
                dbManager.AddParameters(0, "PaisID", DbTypeValues.GetValue("Int32", Pais.PaisID), ParameterDirection.InputOutput, DbType.Int32);
                dbManager.AddParameters(1, "Codigo", DbTypeValues.GetValue("String", Pais.Codigo), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(2, "Nombre", DbTypeValues.GetValue("String", Pais.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(3, "Activo", DbTypeValues.GetValue("Boolean", Pais.Activo), ParameterDirection.Input, DbType.Boolean);
                returnValue = Convert.ToString(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspPaisAdd", 0));
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
        public bool Update(PaisBDO Pais)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(4);
                dbManager.AddParameters(0, "PaisID", DbTypeValues.GetValue("Int32", Pais.PaisID), ParameterDirection.Input, DbType.Int32);
                dbManager.AddParameters(1, "Codigo", DbTypeValues.GetValue("String", Pais.Codigo), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(2, "Nombre", DbTypeValues.GetValue("String", Pais.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(3, "Activo", DbTypeValues.GetValue("Boolean", Pais.Activo), ParameterDirection.Input, DbType.Boolean);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspPaisEdit");
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
        public bool Delete(int PaisID)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "PaisID", DbTypeValues.GetValue("Int32", PaisID), ParameterDirection.Input, DbType.Int32);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspPaisDelete");
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
