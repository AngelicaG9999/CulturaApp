

using CulturApp.BDO.AdministracionDelSistema.ReglasGrupoEmpresarial;
using CulturApp.Utility;
using System;
using System.Data;

namespace CulturApp.DAL.AdministracionDelSistema.ReglasGrupoEmpresarial
{

    public class MenuDAL
    {
        private DataTable _DataTable = null;

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <param name="UserName">Nombre de usuario</param>
        /// <returns></returns>
        public DataTable GetAll(string UserName, string Codigo)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "UserName", DbTypeValues.GetValue("String", UserName), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(1, "Codigo", DbTypeValues.GetValue("String", Codigo), ParameterDirection.Input, DbType.String);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspMenuComponenteFindAll");
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

        public DataTable GetByPadre(long PadreID, long EmpresaID, long PerfilID)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(3);
                dbManager.AddParameters(0, "PadreID", DbTypeValues.GetValue("Int64", PadreID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "ClienteID", DbTypeValues.GetValue("Int64", EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "PerfilID", DbTypeValues.GetValue("Int64", PerfilID), ParameterDirection.Input, DbType.Int64);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspMenuGetByPadre");
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
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public DataTable GetByID(MenuBDO Menu)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "MenuID", DbTypeValues.GetValue("Int64", Menu.MenuID), ParameterDirection.Input, DbType.Int64);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspMenuFindById");
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

        
    }
}
