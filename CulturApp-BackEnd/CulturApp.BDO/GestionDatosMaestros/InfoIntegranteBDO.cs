
using System;
using System.Data;

namespace CulturApp.BDO.GestionDatosMaestros
{

    /// <summary>
    /// InfoIntegrante.
    /// </summary>
    public class InfoIntegranteBDO
    {

        #region ".:: PROPIEDADES ::."

        public long InfoIntegranteID { get; set; }

        public long EmpresaID { get; set; }

        public long InscripcionID { get; set; }

        public int Numero { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string TipoDocId { get; set; }

        public string DocId { get; set; }

        public string TelefonoMovil { get; set; }

        public string CorreoElectronico { get; set; }

        public string Genero { get; set; }


        public string DocIdUrl { get; set; }

        public string ServiciosPublicosUrl { get; set; }

        public string CertificadoVencindadUrl { get; set; }

        #endregion

        #region ".:: CONSTRUCTORES ::."

        public InfoIntegranteBDO()
        {
            InfoIntegranteID = 0;
            EmpresaID = 0;
            InscripcionID = 0;
            Numero = 0;
            Nombre = null;
            Apellido = null;
            TipoDocId = null;
            DocId = null;
            TelefonoMovil = null;
            CorreoElectronico = null;
            Genero = null;

            DocIdUrl = null;
            ServiciosPublicosUrl = null;
            CertificadoVencindadUrl = null;
        }

        public InfoIntegranteBDO(DataRow _DataRow)
        {
            InfoIntegranteID = Convert.ToInt64((_DataRow["InfoIntegranteID"] == System.DBNull.Value ? 0 : _DataRow["InfoIntegranteID"]));
            EmpresaID = Convert.ToInt64((_DataRow["EmpresaID"] == System.DBNull.Value ? 0 : _DataRow["EmpresaID"]));
            InscripcionID = Convert.ToInt64((_DataRow["InscripcionID"] == System.DBNull.Value ? 0 : _DataRow["InscripcionID"]));
            Numero = Convert.ToInt32((_DataRow["Numero"] == System.DBNull.Value ? 0 : _DataRow["Numero"]));
            Nombre = Convert.ToString((_DataRow["Nombre"] == System.DBNull.Value ? String.Empty : _DataRow["Nombre"]));
            Apellido = Convert.ToString((_DataRow["Apellido"] == System.DBNull.Value ? String.Empty : _DataRow["Apellido"]));
            TipoDocId = Convert.ToString((_DataRow["TipoDocId"] == System.DBNull.Value ? String.Empty : _DataRow["TipoDocId"]));
            DocId = Convert.ToString((_DataRow["DocId"] == System.DBNull.Value ? String.Empty : _DataRow["DocId"]));
            TelefonoMovil = Convert.ToString((_DataRow["TelefonoMovil"] == System.DBNull.Value ? String.Empty : _DataRow["TelefonoMovil"]));
            CorreoElectronico = Convert.ToString((_DataRow["CorreoElectronico"] == System.DBNull.Value ? String.Empty : _DataRow["CorreoElectronico"]));
            Genero = Convert.ToString((_DataRow["Genero"] == System.DBNull.Value ? String.Empty : _DataRow["Genero"]));

            DocIdUrl = Convert.ToString((_DataRow["DocIdUrl"] == System.DBNull.Value ? String.Empty : _DataRow["DocIdUrl"]));
            ServiciosPublicosUrl = Convert.ToString((_DataRow["ServiciosPublicosUrl"] == System.DBNull.Value ? String.Empty : _DataRow["ServiciosPublicosUrl"]));
            CertificadoVencindadUrl = Convert.ToString((_DataRow["CertificadoVencindadUrl"] == System.DBNull.Value ? String.Empty : _DataRow["CertificadoVencindadUrl"]));
        }

        #endregion

    }
}
