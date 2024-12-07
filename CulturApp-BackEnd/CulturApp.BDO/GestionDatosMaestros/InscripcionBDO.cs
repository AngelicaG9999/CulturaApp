
using System;
using System.Data;
using System.Runtime.Serialization;

namespace CulturApp.BDO.GestionDatosMaestros
{

    /// <summary>
    /// Inscripcion.
    /// </summary>
    public class InscripcionBDO
    {

        #region ".:: PROPIEDADES ::."

        public long InscripcionID { get; set; }

        public long EmpresaID { get; set; }

        public long EstimuloID { get; set; }

        public string Codigo { get; set; }

        public string Estimulo { get; set; }

        public string Radicado { get; set; }

        public long TipoID { get; set; }

        public string Tipo { get; set; }

        public string Nombre { get; set; }

        public string TipoDocId { get; set; }

        public string DocId { get; set; }

        public string TelefonoMovil { get; set; }

        public string CorreoElectronico { get; set; }

        public long NumIntegrantes { get; set; }

        public DateTime FechaHora { get; set; }

        public string Titulo { get; set; }
        #endregion

        #region ".:: CONSTRUCTORES ::."

        public InscripcionBDO()
        {
            InscripcionID = 0;
            EmpresaID = 0;
            EstimuloID = 0;
            Codigo = string.Empty;
            Estimulo = string.Empty;
            Radicado = string.Empty;
            TipoID = 0;
            Tipo = string.Empty;
            Nombre = string.Empty;
            TipoDocId = string.Empty;
            DocId = string.Empty;
            TelefonoMovil = string.Empty;
            CorreoElectronico = string.Empty;
            NumIntegrantes = 0;
            FechaHora = DateTime.Today;
            Titulo = string.Empty;
        }

        public InscripcionBDO(DataRow _DataRow)
        {
            InscripcionID = Convert.ToInt64((_DataRow["InscripcionID"] == DBNull.Value ? 0 : _DataRow["InscripcionID"]));
            EmpresaID = Convert.ToInt64((_DataRow["EmpresaID"] == DBNull.Value ? 0 : _DataRow["EmpresaID"]));
            EstimuloID = Convert.ToInt64((_DataRow["EstimuloID"] == DBNull.Value ? 0 : _DataRow["EstimuloID"]));
            Codigo = Convert.ToString((_DataRow["Codigo"] == DBNull.Value ? string.Empty : _DataRow["Codigo"]));
            Estimulo = Convert.ToString((_DataRow["Estimulo"] == DBNull.Value ? string.Empty : _DataRow["Estimulo"]));
            Radicado = Convert.ToString((_DataRow["Radicado"] == DBNull.Value ? string.Empty : _DataRow["Radicado"]));
            TipoID = Convert.ToInt64((_DataRow["TipoID"] == DBNull.Value ? 0 : _DataRow["TipoID"]));
            Tipo = Convert.ToString((_DataRow["Tipo"] == DBNull.Value ? string.Empty : _DataRow["Tipo"]));
            Nombre = Convert.ToString((_DataRow["Nombre"] == DBNull.Value ? string.Empty : _DataRow["Nombre"]));
            TipoDocId = Convert.ToString((_DataRow["TipoDocId"] == DBNull.Value ? string.Empty : _DataRow["TipoDocId"]));
            DocId = Convert.ToString((_DataRow["DocId"] == DBNull.Value ? string.Empty : _DataRow["DocId"]));
            TelefonoMovil = Convert.ToString((_DataRow["TelefonoMovil"] == DBNull.Value ? string.Empty : _DataRow["TelefonoMovil"]));
            CorreoElectronico = Convert.ToString((_DataRow["CorreoElectronico"] == DBNull.Value ? string.Empty : _DataRow["CorreoElectronico"]));
            NumIntegrantes = Convert.ToInt64((_DataRow["NumIntegrantes"] == DBNull.Value ? 0 : _DataRow["NumIntegrantes"]));
            FechaHora = Convert.ToDateTime((_DataRow["FechaHora"] == DBNull.Value ? DateTime.Today : _DataRow["FechaHora"]));
            Titulo = Convert.ToString((_DataRow["Titulo"] == DBNull.Value ? string.Empty : _DataRow["Titulo"]));
        }

        #endregion

    }
}
