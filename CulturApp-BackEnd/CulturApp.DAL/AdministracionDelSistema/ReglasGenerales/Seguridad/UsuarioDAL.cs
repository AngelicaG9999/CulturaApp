
using CulturApp.BDO.AdministracionDelSistema.ReglasGenerales.Seguridad;
using CulturApp.Utility;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CulturApp.DAL.AdministracionDelSistema.ReglasGenerales.Seguridad
{

    public class UsuarioDAL
    {
        private DataTable _DataTable = null;

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(UsuarioBDO Usuario)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(3);
                dbManager.AddParameters(0, "ClienteID", DbTypeValues.GetValue("Int64", Usuario.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "TerceroID", DbTypeValues.GetValue("Int64", Usuario.TerceroID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "UserName", DbTypeValues.GetValue("String", Usuario.UserName), ParameterDirection.Input, DbType.String);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspUsuarioFindAll");
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
        /// Busca un usuario
        /// </summary>
        /// <param name="Empresa">Codigo empresa</param>
        /// <param name="UserName">Nombre de usuario (email)</param>
        /// <param name="Password">Password</param>
        /// <returns></returns>
        public DataTable GetByUserNameAndPassword(string Empresa, string UserName, string Password)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(3);
                dbManager.AddParameters(0, "Codigo", DbTypeValues.GetValue("String", Empresa), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(1, "UserName", DbTypeValues.GetValue("String", UserName), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(2, "Password", DbTypeValues.GetValue("String", Password), ParameterDirection.Input, DbType.String);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspUsuarioFindByUserNameAndPassword");
            }
            catch (Exception ex)
            {
                string message = "Se ha presentado una excepción inesperada. " + ex.Message;
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
        public DataTable GetByID(long UsuarioID)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "UsuarioID", DbTypeValues.GetValue("Int64", UsuarioID), ParameterDirection.Input, DbType.Int64);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspUsuarioFindById");
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
        ///Actualiza un registro.
        /// </summary>
        /// <returns></returns>
        public bool Update(UsuarioBDO Usuario)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(15);
                dbManager.AddParameters(0, "UsuarioID", DbTypeValues.GetValue("Int64", Usuario.UsuarioID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "ClienteID", DbTypeValues.GetValue("Int64", Usuario.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "OrganizacionID", DbTypeValues.GetValue("Int64", Usuario.OrganizacionID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(3, "TerceroID", DbTypeValues.GetValue("Int64", Usuario.TerceroID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(4, "ContactoID", DbTypeValues.GetValue("Int64", Usuario.ContactoID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(5, "UserName", DbTypeValues.GetValue("String", Usuario.UserName), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(6, "Password", DbTypeValues.GetValue("String", Usuario.Password), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(7, "Email", DbTypeValues.GetValue("String", Usuario.Email), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(8, "Telefono", DbTypeValues.GetValue("String", Usuario.Telefono), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(9, "Movil", DbTypeValues.GetValue("String", Usuario.Movil), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(10, "UserPin", DbTypeValues.GetValue("String", Usuario.UserPin), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(11, "FechaCreacion", DbTypeValues.GetValue("DateTime", Usuario.FechaCreacion), ParameterDirection.Input, DbType.DateTime);
                dbManager.AddParameters(12, "FechaUltimoAcceso", DbTypeValues.GetValue("DateTime", Usuario.FechaUltimoAcceso), ParameterDirection.Input, DbType.DateTime);
                dbManager.AddParameters(13, "Activo", DbTypeValues.GetValue("Boolean", Usuario.Activo), ParameterDirection.Input, DbType.Boolean);
                dbManager.AddParameters(14, "PerfilID", DbTypeValues.GetValue("Int64", Usuario.PerfilID), ParameterDirection.Input, DbType.Int64);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspUsuarioEdit");
            }
            catch (SqlException sqlException)
            {
                string message = SqlExceptionHelper.GetSqlDescription(sqlException);
                throw new AppException(message, sqlException);
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

    }
}
