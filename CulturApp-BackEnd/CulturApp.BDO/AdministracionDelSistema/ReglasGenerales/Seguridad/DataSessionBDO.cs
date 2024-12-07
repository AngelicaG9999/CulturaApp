
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.Serialization;

namespace CulturApp.BDO.AdministracionDelSistema.ReglasGenerales.Seguridad
{

    [DataContract]
    [Serializable]
    public class DataSessionBDO
    {

        #region ".:: PROPIEDADES ::."

        [DataMember]
        public long DataSessionID { get; set; }

        [DataMember]
        public long EmpresaID { get; set; }

        [DataMember]
        public long OrganizacionID { get; set; }

        [DataMember]
        public long TerceroID { get; set; }

        [DataMember]
        public long UsuarioID { get; set; }

        [DataMember]
        public string Ip { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Host { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public bool Activo { get; set; }

        [DataMember]
        public bool Acceso { get; set; }

        [DataMember]
        public string Organizacion { get; set; }

        [DataMember]
        public string Empresa { get; set; }

        [DataMember]
        public string CodEmpresa { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Apellido { get; set; }

        [DataMember]
        public string NombreCompleto { get; set; }

        [DataMember]
        public string Imprerora { get; set; }

        [DataMember]
        public string Skin { get; set; }

        [DataMember]
        public string Abreviatura { get; set; }

        [DataMember]
        public string LocalApplicationFolder { get; set; }

        [DataMember]
        public string MyDocumentsFolder { get; set; }

        #endregion

        #region ".:: CONSTRUCTORES ::."

        public DataSessionBDO()
        {
            DataSessionID = 0;
            EmpresaID = 0;
            OrganizacionID = 0;
            TerceroID = 0;
            UsuarioID = 0;
            Ip = null;
            UserName = null;
            Host = null;
            Fecha = new DateTime();
            Activo = false;
            Acceso = false;
        }

        public DataSessionBDO(DataRow _DataRow)
        {
            DataSessionID = Convert.ToInt64((_DataRow["DataSessionID"] == System.DBNull.Value ? 0 : _DataRow["DataSessionID"]));
            EmpresaID = Convert.ToInt64((_DataRow["ClienteID"] == System.DBNull.Value ? 0 : _DataRow["ClienteID"]));
            OrganizacionID = Convert.ToInt64((_DataRow["OrganizacionID"] == System.DBNull.Value ? 0 : _DataRow["OrganizacionID"]));
            TerceroID = Convert.ToInt64((_DataRow["TerceroID"] == System.DBNull.Value ? 0 : _DataRow["TerceroID"]));
            UsuarioID = Convert.ToInt64((_DataRow["UsuarioID"] == System.DBNull.Value ? 0 : _DataRow["UsuarioID"]));
            Ip = Convert.ToString((_DataRow["Ip"] == System.DBNull.Value ? String.Empty : _DataRow["Ip"]));
            UserName = Convert.ToString((_DataRow["UserName"] == System.DBNull.Value ? String.Empty : _DataRow["UserName"]));
            Host = Convert.ToString((_DataRow["Host"] == System.DBNull.Value ? String.Empty : _DataRow["Host"]));
            Fecha = Convert.ToDateTime((_DataRow["Fecha"] == System.DBNull.Value ? new DateTime() : _DataRow["Fecha"]));
            Activo = Convert.ToBoolean((_DataRow["Activo"]));
        }

        #endregion

    }
}
