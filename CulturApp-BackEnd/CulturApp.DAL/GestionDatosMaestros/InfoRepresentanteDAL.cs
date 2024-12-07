
using System;
using System.Data;

using CulturApp.Utility;
using CulturApp.BDO.GestionDatosMaestros;

namespace CulturApp.DAL.GestionDatosMaestros
{

    /// <summary>
    /// InfoRepresentante.
    /// </summary>
    public class InfoRepresentanteDAL
    {
        private DataTable _DataTable = null;

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(InfoRepresentanteBDO InfoRepresentante)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                //dbManager.CreateParameters(33);
                //dbManager.AddParameters(0, "InfoRepresentanteID",DbTypeValues.GetValue("Int64",InfoRepresentante.InfoRepresentanteID), ParameterDirection.Input, DbType.Int64);
                //dbManager.AddParameters(1, "EmpresaID",DbTypeValues.GetValue("Int64",InfoRepresentante.EmpresaID), ParameterDirection.Input, DbType.Int64);
                //dbManager.AddParameters(2, "InscripcionID",DbTypeValues.GetValue("Int64",InfoRepresentante.InscripcionID), ParameterDirection.Input, DbType.Int64);
                //dbManager.AddParameters(3, "Nombre",DbTypeValues.GetValue("String",InfoRepresentante.Nombre), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(4, "Apellido",DbTypeValues.GetValue("String",InfoRepresentante.Apellido), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(5, "TipoDocId",DbTypeValues.GetValue("String",InfoRepresentante.TipoDocId), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(6, "DocId",DbTypeValues.GetValue("String",InfoRepresentante.DocId), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(7, "FechaNacimiento",DbTypeValues.GetValue("String",InfoRepresentante.FechaNacimiento), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(8, "TelefonoFijo",DbTypeValues.GetValue("String",InfoRepresentante.TelefonoFijo), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(9, "TelefonoMovil",DbTypeValues.GetValue("String",InfoRepresentante.TelefonoMovil), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(10, "Ciudad",DbTypeValues.GetValue("String",InfoRepresentante.Ciudad), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(11, "Comuna",DbTypeValues.GetValue("String",InfoRepresentante.Comuna), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(12, "Barrio",DbTypeValues.GetValue("String",InfoRepresentante.Barrio), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(13, "Direccion",DbTypeValues.GetValue("String",InfoRepresentante.Direccion), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(14, "Genero",DbTypeValues.GetValue("String",InfoRepresentante.Genero), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(15, "Sector",DbTypeValues.GetValue("String",InfoRepresentante.Sector), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(16, "GrupoPoblacional",DbTypeValues.GetValue("String",InfoRepresentante.GrupoPoblacional), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(17, "Discapacidades",DbTypeValues.GetValue("String",InfoRepresentante.Discapacidades), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(18, "CorreoElectronico",DbTypeValues.GetValue("String",InfoRepresentante.CorreoElectronico), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(19, "RedesSociales",DbTypeValues.GetValue("String",InfoRepresentante.RedesSociales), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(20, "NivelEducativo",DbTypeValues.GetValue("String",InfoRepresentante.NivelEducativo), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(21, "NivelFormacionAC",DbTypeValues.GetValue("String",InfoRepresentante.NivelFormacionAC), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(22, "AreasAC",DbTypeValues.GetValue("String",InfoRepresentante.AreasAC), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(23, "LineaMasTrayectoria",DbTypeValues.GetValue("String",InfoRepresentante.LineaMasTrayectoria), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(24, "AniosExperiencia",DbTypeValues.GetValue("String",InfoRepresentante.AniosExperiencia), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(25, "ActividadEconomica",DbTypeValues.GetValue("String",InfoRepresentante.ActividadEconomica), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(26, "LaboraActualmente",DbTypeValues.GetValue("String",InfoRepresentante.LaboraActualmente), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(27, "DepencenciaEconomica",DbTypeValues.GetValue("String",InfoRepresentante.DepencenciaEconomica), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(28, "RangoSalarial",DbTypeValues.GetValue("String",InfoRepresentante.RangoSalarial), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(29, "PoseeRut",DbTypeValues.GetValue("String",InfoRepresentante.PoseeRut), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(30, "AfiliadoSegSocial",DbTypeValues.GetValue("String",InfoRepresentante.AfiliadoSegSocial), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(31, "Eps",DbTypeValues.GetValue("String",InfoRepresentante.Eps), ParameterDirection.Input, DbType.String);
                //dbManager.AddParameters(32, "ProgramaEstado",DbTypeValues.GetValue("String",InfoRepresentante.ProgramaEstado), ParameterDirection.Input, DbType.String);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspInfoRepresentanteFindAll");
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
        public DataTable GetByID(long InfoRepresentanteID)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "InfoRepresentanteID", DbTypeValues.GetValue("Int64", InfoRepresentanteID), ParameterDirection.Input, DbType.Int64);
                _DataTable = new DataTable();
                _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspInfoRepresentanteFindById");
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
        public int Add(InfoRepresentanteBDO InfoRepresentante)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            object returnValue = 0;
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(33);
                dbManager.AddParameters(0, "InfoRepresentanteID", DbTypeValues.GetValue("Int64", InfoRepresentante.InfoRepresentanteID), ParameterDirection.InputOutput, DbType.Int64);
                dbManager.AddParameters(1, "EmpresaID", DbTypeValues.GetValue("Int64", InfoRepresentante.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "InscripcionID", DbTypeValues.GetValue("Int64", InfoRepresentante.InscripcionID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(3, "Nombre", DbTypeValues.GetValue("String", InfoRepresentante.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(4, "Apellido", DbTypeValues.GetValue("String", InfoRepresentante.Apellido), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(5, "TipoDocId", DbTypeValues.GetValue("String", InfoRepresentante.TipoDocId), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(6, "DocId", DbTypeValues.GetValue("String", InfoRepresentante.DocId), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(7, "FechaNacimiento", DbTypeValues.GetValue("String", InfoRepresentante.FechaNacimiento), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(8, "TelefonoFijo", DbTypeValues.GetValue("String", InfoRepresentante.TelefonoFijo), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(9, "TelefonoMovil", DbTypeValues.GetValue("String", InfoRepresentante.TelefonoMovil), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(10, "Ciudad", DbTypeValues.GetValue("String", InfoRepresentante.Ciudad), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(11, "Comuna", DbTypeValues.GetValue("String", InfoRepresentante.Comuna), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(12, "Barrio", DbTypeValues.GetValue("String", InfoRepresentante.Barrio), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(13, "Direccion", DbTypeValues.GetValue("String", InfoRepresentante.Direccion), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(14, "Genero", DbTypeValues.GetValue("String", InfoRepresentante.Genero), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(15, "Sector", DbTypeValues.GetValue("String", InfoRepresentante.Sector), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(16, "GrupoPoblacional", DbTypeValues.GetValue("String", InfoRepresentante.GrupoPoblacional), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(17, "Discapacidades", DbTypeValues.GetValue("String", InfoRepresentante.Discapacidades), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(18, "CorreoElectronico", DbTypeValues.GetValue("String", InfoRepresentante.CorreoElectronico), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(19, "RedesSociales", DbTypeValues.GetValue("String", InfoRepresentante.RedesSociales), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(20, "NivelEducativo", DbTypeValues.GetValue("String", InfoRepresentante.NivelEducativo), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(21, "NivelFormacionAC", DbTypeValues.GetValue("String", InfoRepresentante.NivelFormacionAC), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(22, "AreasAC", DbTypeValues.GetValue("String", InfoRepresentante.AreasAC), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(23, "LineaMasTrayectoria", DbTypeValues.GetValue("String", InfoRepresentante.LineaMasTrayectoria), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(24, "AniosExperiencia", DbTypeValues.GetValue("String", InfoRepresentante.AniosExperiencia), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(25, "ActividadEconomica", DbTypeValues.GetValue("String", InfoRepresentante.ActividadEconomica), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(26, "LaboraActualmente", DbTypeValues.GetValue("String", InfoRepresentante.LaboraActualmente), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(27, "DepencenciaEconomica", DbTypeValues.GetValue("String", InfoRepresentante.DepencenciaEconomica), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(28, "RangoSalarial", DbTypeValues.GetValue("String", InfoRepresentante.RangoSalarial), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(29, "PoseeRut", DbTypeValues.GetValue("String", InfoRepresentante.PoseeRut), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(30, "AfiliadoSegSocial", DbTypeValues.GetValue("String", InfoRepresentante.AfiliadoSegSocial), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(31, "Eps", DbTypeValues.GetValue("String", InfoRepresentante.Eps), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(32, "ProgramaEstado", DbTypeValues.GetValue("String", InfoRepresentante.ProgramaEstado), ParameterDirection.Input, DbType.String);
                returnValue = Convert.ToString(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspInfoRepresentanteAdd", 0));
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
        public bool Update(InfoRepresentanteBDO InfoRepresentante)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(33);
                dbManager.AddParameters(0, "InfoRepresentanteID", DbTypeValues.GetValue("Int64", InfoRepresentante.InfoRepresentanteID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "EmpresaID", DbTypeValues.GetValue("Int64", InfoRepresentante.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "InscripcionID", DbTypeValues.GetValue("Int64", InfoRepresentante.InscripcionID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(3, "Nombre", DbTypeValues.GetValue("String", InfoRepresentante.Nombre), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(4, "Apellido", DbTypeValues.GetValue("String", InfoRepresentante.Apellido), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(5, "TipoDocId", DbTypeValues.GetValue("String", InfoRepresentante.TipoDocId), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(6, "DocId", DbTypeValues.GetValue("String", InfoRepresentante.DocId), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(7, "FechaNacimiento", DbTypeValues.GetValue("String", InfoRepresentante.FechaNacimiento), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(8, "TelefonoFijo", DbTypeValues.GetValue("String", InfoRepresentante.TelefonoFijo), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(9, "TelefonoMovil", DbTypeValues.GetValue("String", InfoRepresentante.TelefonoMovil), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(10, "Ciudad", DbTypeValues.GetValue("String", InfoRepresentante.Ciudad), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(11, "Comuna", DbTypeValues.GetValue("String", InfoRepresentante.Comuna), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(12, "Barrio", DbTypeValues.GetValue("String", InfoRepresentante.Barrio), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(13, "Direccion", DbTypeValues.GetValue("String", InfoRepresentante.Direccion), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(14, "Genero", DbTypeValues.GetValue("String", InfoRepresentante.Genero), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(15, "Sector", DbTypeValues.GetValue("String", InfoRepresentante.Sector), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(16, "GrupoPoblacional", DbTypeValues.GetValue("String", InfoRepresentante.GrupoPoblacional), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(17, "Discapacidades", DbTypeValues.GetValue("String", InfoRepresentante.Discapacidades), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(18, "CorreoElectronico", DbTypeValues.GetValue("String", InfoRepresentante.CorreoElectronico), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(19, "RedesSociales", DbTypeValues.GetValue("String", InfoRepresentante.RedesSociales), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(20, "NivelEducativo", DbTypeValues.GetValue("String", InfoRepresentante.NivelEducativo), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(21, "NivelFormacionAC", DbTypeValues.GetValue("String", InfoRepresentante.NivelFormacionAC), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(22, "AreasAC", DbTypeValues.GetValue("String", InfoRepresentante.AreasAC), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(23, "LineaMasTrayectoria", DbTypeValues.GetValue("String", InfoRepresentante.LineaMasTrayectoria), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(24, "AniosExperiencia", DbTypeValues.GetValue("String", InfoRepresentante.AniosExperiencia), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(25, "ActividadEconomica", DbTypeValues.GetValue("String", InfoRepresentante.ActividadEconomica), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(26, "LaboraActualmente", DbTypeValues.GetValue("String", InfoRepresentante.LaboraActualmente), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(27, "DepencenciaEconomica", DbTypeValues.GetValue("String", InfoRepresentante.DepencenciaEconomica), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(28, "RangoSalarial", DbTypeValues.GetValue("String", InfoRepresentante.RangoSalarial), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(29, "PoseeRut", DbTypeValues.GetValue("String", InfoRepresentante.PoseeRut), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(30, "AfiliadoSegSocial", DbTypeValues.GetValue("String", InfoRepresentante.AfiliadoSegSocial), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(31, "Eps", DbTypeValues.GetValue("String", InfoRepresentante.Eps), ParameterDirection.Input, DbType.String);
                dbManager.AddParameters(32, "ProgramaEstado", DbTypeValues.GetValue("String", InfoRepresentante.ProgramaEstado), ParameterDirection.Input, DbType.String);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspInfoRepresentanteEdit");
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
        public bool Delete(long InfoRepresentanteID)
        {
            IDBManager dbManager = new DBManager();
            DbTypeValues DbTypeValues = new(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "InfoRepresentanteID", DbTypeValues.GetValue("Int64", InfoRepresentanteID), ParameterDirection.Input, DbType.Int64);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspInfoRepresentanteDelete");
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

