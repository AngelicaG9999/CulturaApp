
using System;
using System.Data;

using CulturApp.Utility;
using CulturApp.BDO.GestionDatosMaestros;

namespace CulturApp.DAL.GestionDatosMaestros
{

    /// <summary>
    /// InfoProyecto.
    /// </summary>
    public class InfoProyectoDAL
    {
        private DataTable _DataTable = null;

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(InfoProyectoBDO InfoProyecto)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "EmpresaID", DbTypeValues.GetValue("Int64", InfoProyecto.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "InscripcionID", DbTypeValues.GetValue("Int64", InfoProyecto.InscripcionID), ParameterDirection.Input, DbType.Int64);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspInfoProyectoFindAll");
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
        public DataTable GetByID(long InfoProyectoID)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "InfoProyectoID", DbTypeValues.GetValue("Int64", InfoProyectoID), ParameterDirection.Input, DbType.Int64);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspInfoProyectoFindById");
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
        public int Add(InfoProyectoBDO InfoProyecto)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            object returnValue = 0;
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(16);
                dbManager.AddParameters(0, "InfoProyectoID", DbTypeValues.GetValue("Int64", InfoProyecto.InfoProyectoID), ParameterDirection.InputOutput, DbType.Int64);
                dbManager.AddParameters(1, "EmpresaID", DbTypeValues.GetValue("Int64", InfoProyecto.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "InscripcionID", DbTypeValues.GetValue("Int64", InfoProyecto.InscripcionID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(3, "Titulo", DbTypeValues.GetValue("String", InfoProyecto.Titulo), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(4, "LineaID", DbTypeValues.GetValue("Int64", InfoProyecto.LineaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(5, "ProyectoUrl", DbTypeValues.GetValue("String", InfoProyecto.ProyectoUrl), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(6, "CurriculumUrl", DbTypeValues.GetValue("String", InfoProyecto.CurriculumUrl), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(7, "CedulaUrl", DbTypeValues.GetValue("String", InfoProyecto.CedulaUrl), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(8, "ServiciosPublicosUrl", DbTypeValues.GetValue("String", InfoProyecto.ServiciosPublicosUrl), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(9, "RutUrl", DbTypeValues.GetValue("String", InfoProyecto.RutUrl), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(10, "CertificadoVencindadUrl", DbTypeValues.GetValue("String", InfoProyecto.CertificadoVencindadUrl), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(11, "AutorizacionMenoresUrl", DbTypeValues.GetValue("String", InfoProyecto.AutorizacionMenoresUrl), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(12, "DeclaracionJuramentadaUrl", DbTypeValues.GetValue("String", InfoProyecto.DeclaracionJuramentadaUrl), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(13, "MaquetaUrl", DbTypeValues.GetValue("String", InfoProyecto.MaquetaUrl), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(14, "CamaraDeComercioUrl", DbTypeValues.GetValue("String", InfoProyecto.CamaraDeComercioUrl), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(15, "CertificacionInmuebleUrl", DbTypeValues.GetValue("String", InfoProyecto.CertificacionInmuebleUrl), ParameterDirection.Input, DbType.String);
                returnValue = Convert.ToString(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspInfoProyectoAdd", 0));
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
        public bool Update(InfoProyectoBDO InfoProyecto)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(16);
                dbManager.AddParameters(0, "InfoProyectoID", DbTypeValues.GetValue("Int64", InfoProyecto.InfoProyectoID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "EmpresaID", DbTypeValues.GetValue("Int64", InfoProyecto.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "InscripcionID", DbTypeValues.GetValue("Int64", InfoProyecto.InscripcionID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(3, "Titulo", DbTypeValues.GetValue("String", InfoProyecto.Titulo), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(4, "LineaID", DbTypeValues.GetValue("Int64", InfoProyecto.LineaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(5, "ProyectoUrl", DbTypeValues.GetValue("String", InfoProyecto.ProyectoUrl), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(6, "CurriculumUrl", DbTypeValues.GetValue("String", InfoProyecto.CurriculumUrl), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(7, "CedulaUrl", DbTypeValues.GetValue("String", InfoProyecto.CedulaUrl), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(8, "ServiciosPublicosUrl", DbTypeValues.GetValue("String", InfoProyecto.ServiciosPublicosUrl), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(9, "RutUrl", DbTypeValues.GetValue("String", InfoProyecto.RutUrl), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(10, "CertificadoVencindadUrl", DbTypeValues.GetValue("String", InfoProyecto.CertificadoVencindadUrl), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(11, "AutorizacionMenoresUrl", DbTypeValues.GetValue("String", InfoProyecto.AutorizacionMenoresUrl), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(12, "DeclaracionJuramentadaUrl", DbTypeValues.GetValue("String", InfoProyecto.DeclaracionJuramentadaUrl), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(13, "MaquetaUrl", DbTypeValues.GetValue("String", InfoProyecto.MaquetaUrl), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(14, "CamaraDeComercioUrl", DbTypeValues.GetValue("String", InfoProyecto.CamaraDeComercioUrl), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(15, "CertificacionInmuebleUrl", DbTypeValues.GetValue("String", InfoProyecto.CertificacionInmuebleUrl), ParameterDirection.Input, DbType.String);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspInfoProyectoEdit");
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
        public bool Delete(long InfoProyectoID)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "InfoProyectoID", DbTypeValues.GetValue("Int64", InfoProyectoID), ParameterDirection.Input, DbType.Int64);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspInfoProyectoDelete");
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

