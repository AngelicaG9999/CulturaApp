
using CulturApp.BDO.AdministracionDelSistema.ReglasGrupoEmpresarial;
using CulturApp.Utility;
using System;
using System.Data;

namespace CulturApp.DAL.AdministracionDelSistema.ReglasGrupoEmpresarial
{

    public class EmpresaDAL
    {
        private DataTable _DataTable = null;

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(EmpresaBDO Empresa)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "Codigo", DbTypeValues.GetValue("String", Empresa.Codigo), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(1, "Nombre", DbTypeValues.GetValue("String", Empresa.Nombre), ParameterDirection.Input, DbType.String);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspEmpresaFindAll");
            }
            catch (Exception ex)
            {
                string message = "Se ha presentado una excepción inesperada. Descripción: " + ex.Message;
                throw new AppException(message, ex);
            }
            finally
            {
                dbManager.Dispose();
            }
            return _DataTable;
        }

        /// <summary>
        /// Retorna todos los registros de la tabla filtrando por código.
        /// </summary>
        /// <returns></returns>
        public DataTable GetByCodigo(string Codigo)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "Codigo", DbTypeValues.GetValue("String", Codigo), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(1, "Nombre", DbTypeValues.GetValue("String", DBNull.Value), ParameterDirection.Input, DbType.String);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspEmpresaFindAll");
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
        public DataTable GetByID(EmpresaBDO Empresa)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "ClienteID", DbTypeValues.GetValue("Int64", Empresa.EmpresaID), ParameterDirection.Input, DbType.Int64);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspEmpresaFindById");
            }
            catch (Exception ex)
            {
                string message = "Se ha presentado una excepción inesperada. Descripción: " + ex.Message;
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
        
    }
}
