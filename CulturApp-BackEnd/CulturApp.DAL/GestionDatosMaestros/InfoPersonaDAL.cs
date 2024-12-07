
using CulturApp.BDO.GestionDatosMaestros;
using CulturApp.Utility;
using System;
using System.Data;

namespace CulturApp.DAL.GestionDatosMaestros
{

    /// <summary>
    /// InfoPersona.
    /// </summary>
    public class InfoPersonaDAL
    {
        private DataTable _DataTable = null;

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(InfoPersonaBDO InfoPersona)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                //dbManager.CreateParameters(16);
                //dbManager.AddParameters(0, "InfoPersonaID",DbTypeValues.GetValue("Int64",InfoPersona.InfoPersonaID), ParameterDirection.Input, DbType.Int64);
                //dbManager.AddParameters(1, "EmpresaID",DbTypeValues.GetValue("Int64",InfoPersona.EmpresaID), ParameterDirection.Input, DbType.Int64);
                //dbManager.AddParameters(2, "InscripcionID",DbTypeValues.GetValue("Int64",InfoPersona.InscripcionID), ParameterDirection.Input, DbType.Int64);
                //dbManager.AddParameters(3, "Nombre",DbTypeValues.GetValue("String",InfoPersona.Nombre), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(4, "Apellido",DbTypeValues.GetValue("String",InfoPersona.Apellido), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(5, "TipoDocId",DbTypeValues.GetValue("String",InfoPersona.TipoDocId), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(6, "DocId",DbTypeValues.GetValue("String",InfoPersona.DocId), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(7, "DigVerificacion",DbTypeValues.GetValue("String",InfoPersona.DigVerificacion), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(8, "FechaNacimiento",DbTypeValues.GetValue("String",InfoPersona.FechaNacimiento), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(9, "TelefonoFijo",DbTypeValues.GetValue("String",InfoPersona.TelefonoFijo), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(10, "TelefonoMovil",DbTypeValues.GetValue("String",InfoPersona.TelefonoMovil), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(11, "CorreoElectronico",DbTypeValues.GetValue("String",InfoPersona.CorreoElectronico), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(12, "Genero",DbTypeValues.GetValue("String",InfoPersona.Genero), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(13, "Sector",DbTypeValues.GetValue("String",InfoPersona.Sector), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(14, "Comuna",DbTypeValues.GetValue("String",InfoPersona.Comuna), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(15, "Direccion",DbTypeValues.GetValue("String",InfoPersona.Direccion), ParameterDirection.Input, DbType.String);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspInfoPersonaFindAll");
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
        public DataTable GetByID(long InfoPersonaID)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "InfoPersonaID", DbTypeValues.GetValue("Int64", InfoPersonaID), ParameterDirection.Input, DbType.Int64);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspInfoPersonaFindById");
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
        public int Add(InfoPersonaBDO InfoPersona)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            object returnValue = 0;
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(16);
                dbManager.AddParameters(0, "InfoPersonaID", DbTypeValues.GetValue("Int64", InfoPersona.InfoPersonaID), ParameterDirection.InputOutput, DbType.Int64);
                dbManager.AddParameters(1, "EmpresaID", DbTypeValues.GetValue("Int64", InfoPersona.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "InscripcionID", DbTypeValues.GetValue("Int64", InfoPersona.InscripcionID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(3, "Nombre", DbTypeValues.GetValue("String", InfoPersona.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(4, "Apellido", DbTypeValues.GetValue("String", InfoPersona.Apellido), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(5, "TipoDocId", DbTypeValues.GetValue("String", InfoPersona.TipoDocId), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(6, "DocId", DbTypeValues.GetValue("String", InfoPersona.DocId), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(7, "DigVerificacion", DbTypeValues.GetValue("String", InfoPersona.DigVerificacion), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(8, "FechaNacimiento", DbTypeValues.GetValue("String", InfoPersona.FechaNacimiento), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(9, "TelefonoFijo", DbTypeValues.GetValue("String", InfoPersona.TelefonoFijo), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(10, "TelefonoMovil", DbTypeValues.GetValue("String", InfoPersona.TelefonoMovil), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(11, "CorreoElectronico", DbTypeValues.GetValue("String", InfoPersona.CorreoElectronico), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(12, "Genero", DbTypeValues.GetValue("String", InfoPersona.Genero), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(13, "Sector", DbTypeValues.GetValue("String", InfoPersona.Sector), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(14, "Comuna", DbTypeValues.GetValue("String", InfoPersona.Comuna), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(15, "Direccion", DbTypeValues.GetValue("String", InfoPersona.Direccion), ParameterDirection.Input, DbType.String);
                returnValue = Convert.ToString(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspInfoPersonaAdd", 0));
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
        public bool Update(InfoPersonaBDO InfoPersona)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(16);
                dbManager.AddParameters(0, "InfoPersonaID", DbTypeValues.GetValue("Int64", InfoPersona.InfoPersonaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "EmpresaID", DbTypeValues.GetValue("Int64", InfoPersona.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "InscripcionID", DbTypeValues.GetValue("Int64", InfoPersona.InscripcionID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(3, "Nombre", DbTypeValues.GetValue("String", InfoPersona.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(4, "Apellido", DbTypeValues.GetValue("String", InfoPersona.Apellido), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(5, "TipoDocId", DbTypeValues.GetValue("String", InfoPersona.TipoDocId), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(6, "DocId", DbTypeValues.GetValue("String", InfoPersona.DocId), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(7, "DigVerificacion", DbTypeValues.GetValue("String", InfoPersona.DigVerificacion), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(8, "FechaNacimiento", DbTypeValues.GetValue("String", InfoPersona.FechaNacimiento), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(9, "TelefonoFijo", DbTypeValues.GetValue("String", InfoPersona.TelefonoFijo), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(10, "TelefonoMovil", DbTypeValues.GetValue("String", InfoPersona.TelefonoMovil), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(11, "CorreoElectronico", DbTypeValues.GetValue("String", InfoPersona.CorreoElectronico), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(12, "Genero", DbTypeValues.GetValue("String", InfoPersona.Genero), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(13, "Sector", DbTypeValues.GetValue("String", InfoPersona.Sector), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(14, "Comuna", DbTypeValues.GetValue("String", InfoPersona.Comuna), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(15, "Direccion", DbTypeValues.GetValue("String", InfoPersona.Direccion), ParameterDirection.Input, DbType.String);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspInfoPersonaEdit");
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
        public bool Delete(long InfoPersonaID)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "InfoPersonaID", DbTypeValues.GetValue("Int64", InfoPersonaID), ParameterDirection.Input, DbType.Int64);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspInfoPersonaDelete");
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

