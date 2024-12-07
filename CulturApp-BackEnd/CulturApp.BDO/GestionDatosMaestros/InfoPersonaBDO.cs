
using System;
using System.Data;

namespace CulturApp.BDO.GestionDatosMaestros
{

    /// <summary>
    /// InfoPersona.
    /// </summary>
    public class InfoPersonaBDO
    {

        #region ".:: PROPIEDADES ::."

        public long InfoPersonaID { get; set; }

        public long EmpresaID { get; set; }

        public long InscripcionID { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string TipoDocId { get; set; }

        public string DocId { get; set; }

        public string DigVerificacion { get; set; }

        public string FechaNacimiento { get; set; }

        public string TelefonoFijo { get; set; }

        public string TelefonoMovil { get; set; }

        public string CorreoElectronico { get; set; }

        public string Genero { get; set; }

        public string Sector { get; set; }

        public string Comuna { get; set; }

        public string Direccion { get; set; }

        #endregion

        #region ".:: CONSTRUCTORES ::."

        public InfoPersonaBDO()
        {
            InfoPersonaID = 0;
            EmpresaID = 0;
            InscripcionID = 0;
            Nombre = null;
            Apellido = null;
            TipoDocId = null;
            DocId = null;
            DigVerificacion = null;
            FechaNacimiento = null;
            TelefonoFijo = null;
            TelefonoMovil = null;
            CorreoElectronico = null;
            Genero = null;
            Sector = null;
            Comuna = null;
            Direccion = null;
        }

        public InfoPersonaBDO(DataRow _DataRow)
        {
            InfoPersonaID = Convert.ToInt64((_DataRow["InfoPersonaID"] == System.DBNull.Value ? 0 : _DataRow["InfoPersonaID"]));
            EmpresaID = Convert.ToInt64((_DataRow["EmpresaID"] == System.DBNull.Value ? 0 : _DataRow["EmpresaID"]));
            InscripcionID = Convert.ToInt64((_DataRow["InscripcionID"] == System.DBNull.Value ? 0 : _DataRow["InscripcionID"]));
            Nombre = Convert.ToString((_DataRow["Nombre"] == System.DBNull.Value ? String.Empty : _DataRow["Nombre"]));
            Apellido = Convert.ToString((_DataRow["Apellido"] == System.DBNull.Value ? String.Empty : _DataRow["Apellido"]));
            TipoDocId = Convert.ToString((_DataRow["TipoDocId"] == System.DBNull.Value ? String.Empty : _DataRow["TipoDocId"]));
            DocId = Convert.ToString((_DataRow["DocId"] == System.DBNull.Value ? String.Empty : _DataRow["DocId"]));
            DigVerificacion = Convert.ToString((_DataRow["DigVerificacion"] == System.DBNull.Value ? String.Empty : _DataRow["DigVerificacion"]));
            FechaNacimiento = Convert.ToString((_DataRow["FechaNacimiento"] == System.DBNull.Value ? String.Empty : _DataRow["FechaNacimiento"]));
            TelefonoFijo = Convert.ToString((_DataRow["TelefonoFijo"] == System.DBNull.Value ? String.Empty : _DataRow["TelefonoFijo"]));
            TelefonoMovil = Convert.ToString((_DataRow["TelefonoMovil"] == System.DBNull.Value ? String.Empty : _DataRow["TelefonoMovil"]));
            CorreoElectronico = Convert.ToString((_DataRow["CorreoElectronico"] == System.DBNull.Value ? String.Empty : _DataRow["CorreoElectronico"]));
            Genero = Convert.ToString((_DataRow["Genero"] == System.DBNull.Value ? String.Empty : _DataRow["Genero"]));
            Sector = Convert.ToString((_DataRow["Sector"] == System.DBNull.Value ? String.Empty : _DataRow["Sector"]));
            Comuna = Convert.ToString((_DataRow["Comuna"] == System.DBNull.Value ? String.Empty : _DataRow["Comuna"]));
            Direccion = Convert.ToString((_DataRow["Direccion"] == System.DBNull.Value ? String.Empty : _DataRow["Direccion"]));
        }

        #endregion

    }
}
