
using CulturApp.BDO.GestionDatosMaestros.ConfiguracionTerceros;
using CulturApp.Utility;
using System;
using System.Data;

namespace CulturApp.DAL.GestionDatosMaestros.ConfiguracionTerceros
{

    /// <summary>
    /// Tercero.
    /// </summary>
    public class TerceroDAL
    {
        private DataTable _DataTable = null;

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(TerceroBDO Tercero)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(4);
                dbManager.AddParameters(0, "ClienteID", DbTypeValues.GetValue("Int64", Tercero.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "NumeroIdentificacion", DbTypeValues.GetValue("String", Tercero.NumeroIdentificacion), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(2, "Codigo", DbTypeValues.GetValue("String", Tercero.Codigo), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(3, "Nombre", DbTypeValues.GetValue("String", Tercero.Nombre), ParameterDirection.Input, DbType.String);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspTerceroFindAll");
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

        public DataTable GetClientes(TerceroBDO Tercero)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(4);
                dbManager.AddParameters(0, "ClienteID", DbTypeValues.GetValue("Int64", Tercero.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "NumeroIdentificacion", DbTypeValues.GetValue("String", Tercero.NumeroIdentificacion), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(2, "Codigo", DbTypeValues.GetValue("String", Tercero.Codigo), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(3, "Nombre", DbTypeValues.GetValue("String", Tercero.Nombre), ParameterDirection.Input, DbType.String);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspTerceroFindClientes");
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
        public DataTable GetByID(long TerceroID)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "TerceroID", DbTypeValues.GetValue("Int64", TerceroID), ParameterDirection.Input, DbType.Int64);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspTerceroFindById");
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
        public int Add(TerceroBDO Tercero)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            object returnValue = 0;
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(15);
                dbManager.AddParameters(0, "TerceroID", DbTypeValues.GetValue("Int64", Tercero.TerceroID), ParameterDirection.InputOutput, DbType.Int64);
                dbManager.AddParameters(1, "ClienteID", DbTypeValues.GetValue("Int64", Tercero.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "NumeroIdentificacion", DbTypeValues.GetValue("String", Tercero.NumeroIdentificacion), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(3, "DigitoVerificacion", DbTypeValues.GetValue("String", Tercero.DigitoVerificacion), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(4, "Codigo", DbTypeValues.GetValue("String", Tercero.Codigo), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(5, "Nombre", DbTypeValues.GetValue("String", Tercero.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(6, "Apellido", DbTypeValues.GetValue("String", Tercero.Apellido), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(7, "RazonSocial", DbTypeValues.GetValue("String", Tercero.RazonSocial), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(8, "RazonComercial", DbTypeValues.GetValue("String", Tercero.RazonComercial), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(9, "Cliente", DbTypeValues.GetValue("Boolean", Tercero.Cliente), ParameterDirection.Input, DbType.Boolean);
                dbManager.AddParameters(10, "Empleado", DbTypeValues.GetValue("Boolean", Tercero.Empleado), ParameterDirection.Input, DbType.Boolean);
                dbManager.AddParameters(11, "Proveedor", DbTypeValues.GetValue("Boolean", Tercero.Proveedor), ParameterDirection.Input, DbType.Boolean);
                dbManager.AddParameters(12, "RepComercial", DbTypeValues.GetValue("Boolean", Tercero.RepComercial), ParameterDirection.Input, DbType.Boolean);
                dbManager.AddParameters(13, "Activo", DbTypeValues.GetValue("Boolean", Tercero.Activo), ParameterDirection.Input, DbType.Boolean);
                dbManager.AddParameters(14, "TipoIdentificacionID", DbTypeValues.GetValue("Int64", Tercero.TipoIdentificacionID), ParameterDirection.Input, DbType.Int64);
                returnValue = Convert.ToString(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspTerceroAdd", 0));
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
        public bool Update(TerceroBDO Tercero)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(15);
                dbManager.AddParameters(0, "TerceroID", DbTypeValues.GetValue("Int64", Tercero.TerceroID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "ClienteID", DbTypeValues.GetValue("Int64", Tercero.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "NumeroIdentificacion", DbTypeValues.GetValue("String", Tercero.NumeroIdentificacion), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(3, "DigitoVerificacion", DbTypeValues.GetValue("String", Tercero.DigitoVerificacion), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(4, "Codigo", DbTypeValues.GetValue("String", Tercero.Codigo), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(5, "Nombre", DbTypeValues.GetValue("String", Tercero.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(6, "Apellido", DbTypeValues.GetValue("String", Tercero.Apellido), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(7, "RazonSocial", DbTypeValues.GetValue("String", Tercero.RazonSocial), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(8, "RazonComercial", DbTypeValues.GetValue("String", Tercero.RazonComercial), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(9, "Cliente", DbTypeValues.GetValue("Boolean", Tercero.Cliente), ParameterDirection.Input, DbType.Boolean);
                dbManager.AddParameters(10, "Empleado", DbTypeValues.GetValue("Boolean", Tercero.Empleado), ParameterDirection.Input, DbType.Boolean);
                dbManager.AddParameters(11, "Proveedor", DbTypeValues.GetValue("Boolean", Tercero.Proveedor), ParameterDirection.Input, DbType.Boolean);
                dbManager.AddParameters(12, "RepComercial", DbTypeValues.GetValue("Boolean", Tercero.RepComercial), ParameterDirection.Input, DbType.Boolean);
                dbManager.AddParameters(13, "Activo", DbTypeValues.GetValue("Boolean", Tercero.Activo), ParameterDirection.Input, DbType.Boolean);
                dbManager.AddParameters(14, "TipoIdentificacionID", DbTypeValues.GetValue("Int64", Tercero.TipoIdentificacionID), ParameterDirection.Input, DbType.Int64);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspTerceroEdit");
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
        public bool Delete(long TerceroID)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "TerceroID", DbTypeValues.GetValue("Int64", TerceroID), ParameterDirection.Input, DbType.Int64);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspTerceroDelete");
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
