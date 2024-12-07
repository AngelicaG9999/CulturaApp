
using System;
using System.Data;

using CulturApp.Utility;
using CulturApp.BDO.GestionDatosMaestros;

namespace CulturApp.DAL.GestionDatosMaestros
{

    /// <summary>
    /// Linea.
    /// </summary>
    public class LineaDAL
    {
        private DataTable _DataTable = null;

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(LineaBDO Linea)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(4);
                dbManager.AddParameters(0, "EmpresaID", DbTypeValues.GetValue("Int64", Linea.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "Nombre", DbTypeValues.GetValue("String", Linea.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(2, "AreaID", DbTypeValues.GetValue("Int64", Linea.AreaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(3, "Tipo", DbTypeValues.GetValue("String", Linea.Tipo), ParameterDirection.Input, DbType.String);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspLineaFindAll");
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
        public DataTable GetByID(long LineaID)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "LineaID", DbTypeValues.GetValue("Int64", LineaID), ParameterDirection.Input, DbType.Int64);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspLineaFindById");
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
        public int Add(LineaBDO Linea)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            object returnValue = 0;
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(6);
                dbManager.AddParameters(0, "LineaID", DbTypeValues.GetValue("Int64", Linea.LineaID), ParameterDirection.InputOutput, DbType.Int64);
                dbManager.AddParameters(1, "EmpresaID", DbTypeValues.GetValue("Int64", Linea.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "AreaID", DbTypeValues.GetValue("Int64", Linea.AreaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(3, "Nombre", DbTypeValues.GetValue("String", Linea.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(4, "Tipo", DbTypeValues.GetValue("String", Linea.Tipo), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(5, "Descripcion", DbTypeValues.GetValue("String", Linea.Descripcion), ParameterDirection.Input, DbType.String);
                returnValue = Convert.ToString(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspLineaAdd", 0));
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
        public bool Update(LineaBDO Linea)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(6);
                dbManager.AddParameters(0, "LineaID", DbTypeValues.GetValue("Int64", Linea.LineaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "EmpresaID", DbTypeValues.GetValue("Int64", Linea.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "AreaID", DbTypeValues.GetValue("Int64", Linea.AreaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(3, "Nombre", DbTypeValues.GetValue("String", Linea.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(4, "Tipo", DbTypeValues.GetValue("String", Linea.Tipo), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(5, "Descripcion", DbTypeValues.GetValue("String", Linea.Descripcion), ParameterDirection.Input, DbType.String);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspLineaEdit");
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
        public bool Delete(long LineaID)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "LineaID", DbTypeValues.GetValue("Int64", LineaID), ParameterDirection.Input, DbType.Int64);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspLineaDelete");
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

