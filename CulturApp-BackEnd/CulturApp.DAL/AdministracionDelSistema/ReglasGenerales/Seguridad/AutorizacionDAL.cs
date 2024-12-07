
using CulturApp.BDO.AdministracionDelSistema.ReglasGenerales.Seguridad;
using CulturApp.Utility;
using System;
using System.Data;

namespace CulturApp.DAL.AdministracionDelSistema.ReglasGenerales.Seguridad
{

    /// <summary>
    /// Autorizacion.
    /// </summary>
    public class AutorizacionDAL
    {
        private DataTable _DataTable = null;

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(AutorizacionBDO Autorizacion)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "ClienteID", DbTypeValues.GetValue("Int64", Autorizacion.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "Nombre", DbTypeValues.GetValue("String", Autorizacion.Nombre), ParameterDirection.Input, DbType.String);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspAutorizacionFindAll");
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
        public DataTable GetByID(long AutorizacionID)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "AutorizacionID", DbTypeValues.GetValue("Int64", AutorizacionID), ParameterDirection.Input, DbType.Int64);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspAutorizacionFindById");
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
        public int Add(AutorizacionBDO Autorizacion)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            object returnValue = 0;
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(8);
                dbManager.AddParameters(0, "AutorizacionID", DbTypeValues.GetValue("Int64", Autorizacion.AutorizacionID), ParameterDirection.InputOutput, DbType.Int64);
                dbManager.AddParameters(1, "ClienteID", DbTypeValues.GetValue("Int64", Autorizacion.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "Nombre", DbTypeValues.GetValue("String", Autorizacion.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(3, "Descripcion", DbTypeValues.GetValue("String", Autorizacion.Descripcion), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(4, "Leer", DbTypeValues.GetValue("Boolean", Autorizacion.Leer), ParameterDirection.Input, DbType.Boolean);
                dbManager.AddParameters(5, "Crear", DbTypeValues.GetValue("Boolean", Autorizacion.Crear), ParameterDirection.Input, DbType.Boolean);
                dbManager.AddParameters(6, "Editar", DbTypeValues.GetValue("Boolean", Autorizacion.Editar), ParameterDirection.Input, DbType.Boolean);
                dbManager.AddParameters(7, "Eliminar", DbTypeValues.GetValue("Boolean", Autorizacion.Eliminar), ParameterDirection.Input, DbType.Boolean);
                returnValue = Convert.ToString(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspAutorizacionAdd", 0));
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
        public bool Update(AutorizacionBDO Autorizacion)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(8);
                dbManager.AddParameters(0, "AutorizacionID", DbTypeValues.GetValue("Int64", Autorizacion.AutorizacionID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "ClienteID", DbTypeValues.GetValue("Int64", Autorizacion.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "Nombre", DbTypeValues.GetValue("String", Autorizacion.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(3, "Descripcion", DbTypeValues.GetValue("String", Autorizacion.Descripcion), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(4, "Leer", DbTypeValues.GetValue("Boolean", Autorizacion.Leer), ParameterDirection.Input, DbType.Boolean);
                dbManager.AddParameters(5, "Crear", DbTypeValues.GetValue("Boolean", Autorizacion.Crear), ParameterDirection.Input, DbType.Boolean);
                dbManager.AddParameters(6, "Editar", DbTypeValues.GetValue("Boolean", Autorizacion.Editar), ParameterDirection.Input, DbType.Boolean);
                dbManager.AddParameters(7, "Eliminar", DbTypeValues.GetValue("Boolean", Autorizacion.Eliminar), ParameterDirection.Input, DbType.Boolean);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspAutorizacionEdit");
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
        public bool Delete(long AutorizacionID)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "AutorizacionID", DbTypeValues.GetValue("Int64", AutorizacionID), ParameterDirection.Input, DbType.Int64);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspAutorizacionDelete");
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
