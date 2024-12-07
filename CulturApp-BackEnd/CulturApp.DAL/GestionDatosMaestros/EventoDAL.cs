
using System;
using System.Data;

using CulturApp.Utility;
using CulturApp.BDO.GestionDatosMaestros;

namespace CulturApp.DAL.GestionDatosMaestros
{
    public class EventoDAL
    {
        private DataTable _DataTable = null;

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(long EmpresaID, long SalaID, string Nombre, string FechaHora)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(4);
                dbManager.AddParameters(0, "EmpresaID", DbTypeValues.GetValue("Int64", EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "SalaID", DbTypeValues.GetValue("Int64", EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "Nombre", DbTypeValues.GetValue("String", Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(3, "FechaHora", DbTypeValues.GetValue("DateTime", FechaHora), ParameterDirection.Input, DbType.DateTime);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspEventoFindAll");
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
        public DataTable GetByID(long EventoID)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "EventoID", DbTypeValues.GetValue("Int64", EventoID), ParameterDirection.Input, DbType.Int64);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspEventoFindById");
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
        public int Add(EventoBDO EventoBdo)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            object returnValue = 0;
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(5);
                dbManager.AddParameters(0, "EventoID", DbTypeValues.GetValue("Int64", EventoBdo.EventoID), ParameterDirection.InputOutput, DbType.Int64);
                dbManager.AddParameters(1, "EmpresaID", DbTypeValues.GetValue("Int64", EventoBdo.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "SalaID", DbTypeValues.GetValue("Int64", EventoBdo.SalaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(3, "Nombre", DbTypeValues.GetValue("String", EventoBdo.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(4, "FechaHora", DbTypeValues.GetValue("DateTime", EventoBdo.FechaHora), ParameterDirection.Input, DbType.DateTime);
                dbManager.AddParameters(5, "Lugar", DbTypeValues.GetValue("String", EventoBdo.Lugar), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(6, "Direccion", DbTypeValues.GetValue("String", EventoBdo.Direccion), ParameterDirection.Input, DbType.String);
                returnValue = Convert.ToString(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspEventoAdd", 0));
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
        public bool Update(EventoBDO EventoBdo)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(7);
                dbManager.AddParameters(0, "EventoID", DbTypeValues.GetValue("Int64", EventoBdo.EventoID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "EmpresaID", DbTypeValues.GetValue("Int64", EventoBdo.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "SalaID", DbTypeValues.GetValue("Int64", EventoBdo.SalaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(3, "Nombre", DbTypeValues.GetValue("String", EventoBdo.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(4, "FechaHora", DbTypeValues.GetValue("DateTime", EventoBdo.FechaHora), ParameterDirection.Input, DbType.DateTime);
                dbManager.AddParameters(5, "Lugar", DbTypeValues.GetValue("String", EventoBdo.Lugar), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(6, "Direccion", DbTypeValues.GetValue("String", EventoBdo.Direccion), ParameterDirection.Input, DbType.String);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspEventoEdit");
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
        public bool Delete(long EventoID)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "EventoID", DbTypeValues.GetValue("Int64", EventoID), ParameterDirection.Input, DbType.Int64);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspEventoDelete");
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
