
using CulturApp.BDO.GestionDatosMaestros.ConfiguracionTerceros;
using CulturApp.Utility;
using System;
using System.Data;

namespace CulturApp.DAL.GestionDatosMaestros.ConfiguracionTerceros
{

    /// <summary>
    /// TerceroInfoGeneral.
    /// </summary>
    public class TerceroInfoGeneralDAL
    {
        private DataTable _DataTable = null;

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(TerceroInfoGeneralBDO TerceroInfoGeneral)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "TerceroID", DbTypeValues.GetValue("Int64", TerceroInfoGeneral.TerceroID), ParameterDirection.Input, DbType.Int64);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspTerceroInfoGeneralFindAll");
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
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspTerceroInfoGeneralFindById");
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
        public int Add(TerceroInfoGeneralBDO TerceroInfoGeneral)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            object returnValue = 0;
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(14);
                dbManager.AddParameters(0, "TerceroInfoGeneralID", DbTypeValues.GetValue("Int64", TerceroInfoGeneral.TerceroInfoGeneralID), ParameterDirection.InputOutput, DbType.Int64);
                dbManager.AddParameters(1, "TerceroID", DbTypeValues.GetValue("Int64", TerceroInfoGeneral.TerceroID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "GrupoTerceroID", DbTypeValues.GetValue("Int64", TerceroInfoGeneral.GrupoTerceroID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(3, "ZonaTerceroID", DbTypeValues.GetValue("Int64", TerceroInfoGeneral.ZonaTerceroID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(4, "ClaseTerceroID", DbTypeValues.GetValue("Int64", TerceroInfoGeneral.ClaseTerceroID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(5, "ClasificacionTerceroID", DbTypeValues.GetValue("Int64", TerceroInfoGeneral.ClasificacionTerceroID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(6, "TipoTerceroID", DbTypeValues.GetValue("Int64", TerceroInfoGeneral.TipoTerceroID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(7, "Email", DbTypeValues.GetValue("String", TerceroInfoGeneral.Email), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(8, "WebSite", DbTypeValues.GetValue("String", TerceroInfoGeneral.WebSite), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(9, "Direccion", DbTypeValues.GetValue("String", TerceroInfoGeneral.Direccion), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(10, "Telefono", DbTypeValues.GetValue("String", TerceroInfoGeneral.Telefono), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(11, "Celular", DbTypeValues.GetValue("String", TerceroInfoGeneral.Celular), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(12, "Fax", DbTypeValues.GetValue("String", TerceroInfoGeneral.Fax), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(13, "LogoUrl", DbTypeValues.GetValue("String", TerceroInfoGeneral.LogoUrl), ParameterDirection.Input, DbType.String);
                returnValue = Convert.ToString(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspTerceroInfoGeneralAdd", 0));
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
        public bool Update(TerceroInfoGeneralBDO TerceroInfoGeneral)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(14);
                dbManager.AddParameters(0, "TerceroInfoGeneralID", DbTypeValues.GetValue("Int64", TerceroInfoGeneral.TerceroInfoGeneralID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "TerceroID", DbTypeValues.GetValue("Int64", TerceroInfoGeneral.TerceroID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "GrupoTerceroID", DbTypeValues.GetValue("Int64", TerceroInfoGeneral.GrupoTerceroID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(3, "ZonaTerceroID", DbTypeValues.GetValue("Int64", TerceroInfoGeneral.ZonaTerceroID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(4, "ClaseTerceroID", DbTypeValues.GetValue("Int64", TerceroInfoGeneral.ClaseTerceroID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(5, "ClasificacionTerceroID", DbTypeValues.GetValue("Int64", TerceroInfoGeneral.ClasificacionTerceroID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(6, "TipoTerceroID", DbTypeValues.GetValue("Int64", TerceroInfoGeneral.TipoTerceroID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(7, "Email", DbTypeValues.GetValue("String", TerceroInfoGeneral.Email), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(8, "WebSite", DbTypeValues.GetValue("String", TerceroInfoGeneral.WebSite), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(9, "Direccion", DbTypeValues.GetValue("String", TerceroInfoGeneral.Direccion), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(10, "Telefono", DbTypeValues.GetValue("String", TerceroInfoGeneral.Telefono), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(11, "Celular", DbTypeValues.GetValue("String", TerceroInfoGeneral.Celular), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(12, "Fax", DbTypeValues.GetValue("String", TerceroInfoGeneral.Fax), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(13, "LogoUrl", DbTypeValues.GetValue("String", TerceroInfoGeneral.LogoUrl), ParameterDirection.Input, DbType.String);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspTerceroInfoGeneralEdit");
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
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspTerceroInfoGeneralDelete");
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
