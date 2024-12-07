
using CulturApp.BDO.AdministracionDelSistema.ReglasGrupoEmpresarial;
using CulturApp.Utility;
using System;
using System.Data;

namespace CulturApp.DAL.AdministracionDelSistema.ReglasGrupoEmpresarial
{

    /// <summary>
    /// EmpresaInfoConsecutivo.
    /// </summary>
    public class EmpresaInfoConsecutivoDAL
    {
        private DataTable _DataTable = null;

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(long EmpresaID)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "ClienteID", DbTypeValues.GetValue("Int64", EmpresaID), ParameterDirection.Input, DbType.Int64);
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspEmpresaInfoConsecutivoFindAll");
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
        public DataTable GetByID(long EmpresaID)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "ClienteID", DbTypeValues.GetValue("Int64", EmpresaID), ParameterDirection.Input, DbType.Int64);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspEmpresaInfoConsecutivoFindById");
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
        public int Add(EmpresaInfoConsecutivoBDO EmpresaInfoConsecutivo)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            object returnValue = 0;
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(4);
                dbManager.AddParameters(0, "ClienteID", DbTypeValues.GetValue("Int64", EmpresaInfoConsecutivo.EmpresaID), ParameterDirection.InputOutput, DbType.Int64);
                dbManager.AddParameters(1, "FacturaCompra", DbTypeValues.GetValue("Int64", EmpresaInfoConsecutivo.FacturaCompra), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "FacturaVenta", DbTypeValues.GetValue("Int64", EmpresaInfoConsecutivo.FacturaVenta), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(3, "Contrato", DbTypeValues.GetValue("Int64", EmpresaInfoConsecutivo.Contrato), ParameterDirection.Input, DbType.Int64);
                returnValue = Convert.ToString(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspEmpresaInfoConsecutivoAdd", 0));
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
        public bool Update(EmpresaInfoConsecutivoBDO EmpresaInfoConsecutivo)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(4);
                dbManager.AddParameters(0, "ClienteID", DbTypeValues.GetValue("Int64", EmpresaInfoConsecutivo.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "FacturaCompra", DbTypeValues.GetValue("Int64", EmpresaInfoConsecutivo.FacturaCompra), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "FacturaVenta", DbTypeValues.GetValue("Int64", EmpresaInfoConsecutivo.FacturaVenta), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(3, "Contrato", DbTypeValues.GetValue("Int64", EmpresaInfoConsecutivo.Contrato), ParameterDirection.Input, DbType.Int64);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspEmpresaInfoConsecutivoEdit");
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
        public bool Delete(long EmpresaID)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "ClienteID", DbTypeValues.GetValue("Int64", EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspEmpresaInfoConsecutivoDelete");
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
