
using CulturApp.BDO.GestionDatosMaestros.ConfiguracionGeneral;
using CulturApp.Utility;
using System;
using System.Data;

namespace CulturApp.DAL.GestionDatosMaestros.ConfiguracionGeneral
{

    /// <summary>
    /// FormaPago.
    /// </summary>
    public class FormaPagoDAL
    {
        private DataTable _DataTable = null;

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(FormaPagoBDO FormaPago)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(3);
                dbManager.AddParameters(0, "ClienteID", DbTypeValues.GetValue("Int64", FormaPago.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "Codigo", DbTypeValues.GetValue("String", FormaPago.Codigo), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(2, "Nombre", DbTypeValues.GetValue("String", FormaPago.Nombre), ParameterDirection.Input, DbType.String);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspFormaPagoFindAll");
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
        public DataTable GetByID(long FormaPagoID)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "FormaPagoID", DbTypeValues.GetValue("Int64", FormaPagoID), ParameterDirection.Input, DbType.Int64);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspFormaPagoFindById");
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
        public int Add(FormaPagoBDO FormaPago)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            object returnValue = 0;
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(6);
                dbManager.AddParameters(0, "FormaPagoID", DbTypeValues.GetValue("Int64", FormaPago.FormaPagoID), ParameterDirection.InputOutput, DbType.Int64);
                dbManager.AddParameters(1, "ClienteID", DbTypeValues.GetValue("Int64", FormaPago.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "Codigo", DbTypeValues.GetValue("String", FormaPago.Codigo), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(3, "Nombre", DbTypeValues.GetValue("String", FormaPago.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(4, "Descripcion", DbTypeValues.GetValue("String", FormaPago.Descripcion), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(5, "Activo", DbTypeValues.GetValue("Boolean", FormaPago.Activo), ParameterDirection.Input, DbType.Boolean);
                returnValue = Convert.ToString(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspFormaPagoAdd", 0));
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
        public bool Update(FormaPagoBDO FormaPago)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(6);
                dbManager.AddParameters(0, "FormaPagoID", DbTypeValues.GetValue("Int64", FormaPago.FormaPagoID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "ClienteID", DbTypeValues.GetValue("Int64", FormaPago.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "Codigo", DbTypeValues.GetValue("String", FormaPago.Codigo), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(3, "Nombre", DbTypeValues.GetValue("String", FormaPago.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(4, "Descripcion", DbTypeValues.GetValue("String", FormaPago.Descripcion), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(5, "Activo", DbTypeValues.GetValue("Boolean", FormaPago.Activo), ParameterDirection.Input, DbType.Boolean);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspFormaPagoEdit");
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
        public bool Delete(long FormaPagoID)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "FormaPagoID", DbTypeValues.GetValue("Int64", FormaPagoID), ParameterDirection.Input, DbType.Int64);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspFormaPagoDelete");
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
