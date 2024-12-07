
using CulturApp.BDO.GestionDatosMaestros;
using CulturApp.Utility;
using System;
using System.Data;

namespace CulturApp.DAL.GestionDatosMaestros
{

    /// <summary>
    /// InfoIntegrante.
    /// </summary>
    public class InfoIntegranteDAL
    {
        private DataTable _DataTable = null;

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(InfoIntegranteBDO InfoIntegrante)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(3);
                dbManager.AddParameters(0, "EmpresaID",DbTypeValues.GetValue("Int64",InfoIntegrante.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "Nombre", DbTypeValues.GetValue("String", InfoIntegrante.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(2, "InscripcionID",DbTypeValues.GetValue("Int64",InfoIntegrante.InscripcionID), ParameterDirection.Input, DbType.Int64);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspInfoIntegranteFindAll");
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
        public DataTable GetByID(long InfoIntegranteID)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "InfoIntegranteID", DbTypeValues.GetValue("Int64", InfoIntegranteID), ParameterDirection.Input, DbType.Int64);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspInfoIntegranteFindById");
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
        public int Add(InfoIntegranteBDO InfoIntegrante)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            object returnValue = 0;
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(14);
                dbManager.AddParameters(0, "InfoIntegranteID", DbTypeValues.GetValue("Int64", InfoIntegrante.InfoIntegranteID), ParameterDirection.InputOutput, DbType.Int64);
                dbManager.AddParameters(1, "EmpresaID", DbTypeValues.GetValue("Int64", InfoIntegrante.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "InscripcionID", DbTypeValues.GetValue("Int64", InfoIntegrante.InscripcionID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(3, "Numero", DbTypeValues.GetValue("Int32", InfoIntegrante.Numero), ParameterDirection.Input, DbType.Int32);
                dbManager.AddParameters(4, "Nombre", DbTypeValues.GetValue("String", InfoIntegrante.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(5, "Apellido", DbTypeValues.GetValue("String", InfoIntegrante.Apellido), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(6, "TipoDocId", DbTypeValues.GetValue("String", InfoIntegrante.TipoDocId), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(7, "DocId", DbTypeValues.GetValue("String", InfoIntegrante.DocId), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(8, "TelefonoMovil", DbTypeValues.GetValue("String", InfoIntegrante.TelefonoMovil), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(9, "CorreoElectronico", DbTypeValues.GetValue("String", InfoIntegrante.CorreoElectronico), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(10, "Genero", DbTypeValues.GetValue("String", InfoIntegrante.Genero), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(11, "DocIdUrl", DbTypeValues.GetValue("String", InfoIntegrante.DocIdUrl), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(12, "ServiciosPublicosUrl", DbTypeValues.GetValue("String", InfoIntegrante.ServiciosPublicosUrl), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(13, "CertificadoVencindadUrl", DbTypeValues.GetValue("String", InfoIntegrante.CertificadoVencindadUrl), ParameterDirection.Input, DbType.String);
                returnValue = Convert.ToString(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspInfoIntegranteAdd", 0));
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
        public bool Update(InfoIntegranteBDO InfoIntegrante)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(14);
                dbManager.AddParameters(0, "InfoIntegranteID", DbTypeValues.GetValue("Int64", InfoIntegrante.InfoIntegranteID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "EmpresaID", DbTypeValues.GetValue("Int64", InfoIntegrante.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "InscripcionID", DbTypeValues.GetValue("Int64", InfoIntegrante.InscripcionID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(3, "Numero", DbTypeValues.GetValue("Int32", InfoIntegrante.Numero), ParameterDirection.Input, DbType.Int32);
                dbManager.AddParameters(4, "Nombre", DbTypeValues.GetValue("String", InfoIntegrante.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(5, "Apellido", DbTypeValues.GetValue("String", InfoIntegrante.Apellido), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(6, "TipoDocId", DbTypeValues.GetValue("String", InfoIntegrante.TipoDocId), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(7, "DocId", DbTypeValues.GetValue("String", InfoIntegrante.DocId), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(8, "TelefonoMovil", DbTypeValues.GetValue("String", InfoIntegrante.TelefonoMovil), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(9, "CorreoElectronico", DbTypeValues.GetValue("String", InfoIntegrante.CorreoElectronico), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(10, "Genero", DbTypeValues.GetValue("String", InfoIntegrante.Genero), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(11, "DocIdUrl", DbTypeValues.GetValue("String", InfoIntegrante.DocIdUrl), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(12, "ServiciosPublicosUrl", DbTypeValues.GetValue("String", InfoIntegrante.ServiciosPublicosUrl), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(13, "CertificadoVencindadUrl", DbTypeValues.GetValue("String", InfoIntegrante.CertificadoVencindadUrl), ParameterDirection.Input, DbType.String);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspInfoIntegranteEdit");
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
        public bool Delete(long InfoIntegranteID)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "InfoIntegranteID", DbTypeValues.GetValue("Int64", InfoIntegranteID), ParameterDirection.Input, DbType.Int64);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspInfoIntegranteDelete");
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

