
using CulturApp.BDO.AdministracionDelSistema.ReglasGrupoEmpresarial;
using CulturApp.Utility;
using System;
using System.Data;

namespace CulturApp.DAL.AdministracionDelSistema.ReglasGrupoEmpresarial
{

    /// <summary>
    /// EmpresaInfoImagenCorp.
    /// </summary>
    public class EmpresaInfoImagenCorpDAL
    {
        private DataTable _DataTable = null;

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(EmpresaInfoImagenCorpBDO EmpresaInfoImagenCorp)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "ClienteID", DbTypeValues.GetValue("Int64", EmpresaInfoImagenCorp.EmpresaID), ParameterDirection.Input, DbType.Int64);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspEmpresaInfoImagenCorpFindAll");
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
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspEmpresaInfoImagenCorpFindById");
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
        public int Add(EmpresaInfoImagenCorpBDO EmpresaInfoImagenCorp)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            object returnValue = 0;
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(5);
                dbManager.AddParameters(0, "ClienteID", DbTypeValues.GetValue("Int64", EmpresaInfoImagenCorp.EmpresaID), ParameterDirection.InputOutput, DbType.Int64);
                dbManager.AddParameters(1, "LogoUrl", DbTypeValues.GetValue("String", EmpresaInfoImagenCorp.LogoUrl), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(2, "ColorPrincipal", DbTypeValues.GetValue("String", EmpresaInfoImagenCorp.ColorPrincipal), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(3, "ColorSecundario", DbTypeValues.GetValue("String", EmpresaInfoImagenCorp.ColorSecundario), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(4, "ColorAuxiliar", DbTypeValues.GetValue("String", EmpresaInfoImagenCorp.ColorAuxiliar), ParameterDirection.Input, DbType.String);
                returnValue = Convert.ToString(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspEmpresaInfoImagenCorpAdd", 0));
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
        public bool Update(EmpresaInfoImagenCorpBDO EmpresaInfoImagenCorp)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(5);
                dbManager.AddParameters(0, "ClienteID", DbTypeValues.GetValue("Int64", EmpresaInfoImagenCorp.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "LogoUrl", DbTypeValues.GetValue("String", EmpresaInfoImagenCorp.LogoUrl), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(2, "ColorPrincipal", DbTypeValues.GetValue("String", EmpresaInfoImagenCorp.ColorPrincipal), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(3, "ColorSecundario", DbTypeValues.GetValue("String", EmpresaInfoImagenCorp.ColorSecundario), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(4, "ColorAuxiliar", DbTypeValues.GetValue("String", EmpresaInfoImagenCorp.ColorAuxiliar), ParameterDirection.Input, DbType.String);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspEmpresaInfoImagenCorpEdit");
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
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspEmpresaInfoImagenCorpDelete");
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
