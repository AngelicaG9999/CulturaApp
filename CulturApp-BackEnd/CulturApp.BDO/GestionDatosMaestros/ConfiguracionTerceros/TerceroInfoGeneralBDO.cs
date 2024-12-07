
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.Serialization;

namespace CulturApp.BDO.GestionDatosMaestros.ConfiguracionTerceros
{

    /// <summary>
    /// TerceroInfoGeneral.
    /// </summary>
    [DataContract]
    [Serializable]
    public class TerceroInfoGeneralBDO
    {

        #region ".:: PROPIEDADES ::."

        [DataMember]
        public long TerceroInfoGeneralID { get; set; }

        [DataMember]
        public long TerceroID { get; set; }

        [DataMember]
        public long GrupoTerceroID { get; set; }

        [DataMember]
        public long ZonaTerceroID { get; set; }

        [DataMember]
        public long ClaseTerceroID { get; set; }

        [DataMember]
        public long ClasificacionTerceroID { get; set; }

        [DataMember]
        public long TipoTerceroID { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string WebSite { get; set; }

        [DataMember]
        public string Direccion { get; set; }

        [DataMember]
        public string Telefono { get; set; }

        [DataMember]
        public string Celular { get; set; }

        [DataMember]
        public string Fax { get; set; }

        [DataMember]
        public string LogoUrl { get; set; }

        #endregion

        #region ".:: CONSTRUCTORES ::."

        public TerceroInfoGeneralBDO()
        {
            TerceroInfoGeneralID = 0;
            TerceroID = 0;
            GrupoTerceroID = 0;
            ZonaTerceroID = 0;
            ClaseTerceroID = 0;
            ClasificacionTerceroID = 0;
            TipoTerceroID = 0;
            Email = null;
            WebSite = null;
            Direccion = null;
            Telefono = null;
            Celular = null;
            Fax = null;
            LogoUrl = null;
        }

        public TerceroInfoGeneralBDO(DataRow _DataRow)
        {
            TerceroInfoGeneralID = Convert.ToInt64((_DataRow["TerceroInfoGeneralID"] == System.DBNull.Value ? 0 : _DataRow["TerceroInfoGeneralID"]));
            TerceroID = Convert.ToInt64((_DataRow["TerceroID"] == System.DBNull.Value ? 0 : _DataRow["TerceroID"]));
            GrupoTerceroID = Convert.ToInt64((_DataRow["GrupoTerceroID"] == System.DBNull.Value ? 0 : _DataRow["GrupoTerceroID"]));
            ZonaTerceroID = Convert.ToInt64((_DataRow["ZonaTerceroID"] == System.DBNull.Value ? 0 : _DataRow["ZonaTerceroID"]));
            ClaseTerceroID = Convert.ToInt64((_DataRow["ClaseTerceroID"] == System.DBNull.Value ? 0 : _DataRow["ClaseTerceroID"]));
            ClasificacionTerceroID = Convert.ToInt64((_DataRow["ClasificacionTerceroID"] == System.DBNull.Value ? 0 : _DataRow["ClasificacionTerceroID"]));
            TipoTerceroID = Convert.ToInt64((_DataRow["TipoTerceroID"] == System.DBNull.Value ? 0 : _DataRow["TipoTerceroID"]));
            Email = Convert.ToString((_DataRow["Email"] == System.DBNull.Value ? String.Empty : _DataRow["Email"]));
            WebSite = Convert.ToString((_DataRow["WebSite"] == System.DBNull.Value ? String.Empty : _DataRow["WebSite"]));
            Direccion = Convert.ToString((_DataRow["Direccion"] == System.DBNull.Value ? String.Empty : _DataRow["Direccion"]));
            Telefono = Convert.ToString((_DataRow["Telefono"] == System.DBNull.Value ? String.Empty : _DataRow["Telefono"]));
            Celular = Convert.ToString((_DataRow["Celular"] == System.DBNull.Value ? String.Empty : _DataRow["Celular"]));
            Fax = Convert.ToString((_DataRow["Fax"] == System.DBNull.Value ? String.Empty : _DataRow["Fax"]));
            LogoUrl = Convert.ToString((_DataRow["LogoUrl"] == System.DBNull.Value ? String.Empty : _DataRow["LogoUrl"]));
        }

        #endregion

    }
}
