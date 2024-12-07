
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.Serialization;

namespace CulturApp.BDO.AdministracionDelSistema.ReglasGenerales.Seguridad
{
    [DataContract]
    [Serializable]
    public class AutorizacionObjetoBDO
    {

        #region ".:: PROPIEDADES ::."

        [DataMember]
        public long PerfilAutorizacionID { get; set; }

        [DataMember]
        public long EmpresaID { get; set; }

        [DataMember]
        public long UsuarioID { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public long MenuID { get; set; }

        [DataMember]
        public string Menu { get; set; }

        [DataMember]
        public long AutorizacionID { get; set; }

        [DataMember]
        public string Autorizacion { get; set; }

        [DataMember]
        public bool Leer { get; set; }

        [DataMember]
        public bool Crear { get; set; }

        [DataMember]
        public bool Editar { get; set; }

        [DataMember]
        public bool Eliminar { get; set; }
        #endregion

        #region ".:: CONSTRUCTORES ::."

        public AutorizacionObjetoBDO()
        {
            PerfilAutorizacionID = 0;
            EmpresaID = 0;
            UsuarioID = 0;
            UserName = null;
            MenuID = 0;
            Menu = null;
            AutorizacionID = 0;
            Autorizacion = null;
            Leer = false;
            Crear = false;
            Editar = false;
            Eliminar = false;
        }

        public AutorizacionObjetoBDO(DataRow _DataRow)
        {
            PerfilAutorizacionID = Convert.ToInt64((_DataRow["PerfilAutorizacionID"] == System.DBNull.Value ? 0 : _DataRow["PerfilAutorizacionID"]));
            EmpresaID = Convert.ToInt64((_DataRow["ClienteID"] == System.DBNull.Value ? 0 : _DataRow["ClienteID"]));
            UsuarioID = Convert.ToInt64((_DataRow["UsuarioID"] == System.DBNull.Value ? 0 : _DataRow["UsuarioID"]));
            UserName = Convert.ToString((_DataRow["UserName"] == System.DBNull.Value ? String.Empty : _DataRow["UserName"]));
            MenuID = Convert.ToInt64((_DataRow["MenuID"] == System.DBNull.Value ? 0 : _DataRow["MenuID"]));
            Menu = Convert.ToString((_DataRow["Menu"] == System.DBNull.Value ? String.Empty : _DataRow["Menu"]));
            AutorizacionID = Convert.ToInt64((_DataRow["AutorizacionID"] == System.DBNull.Value ? 0 : _DataRow["AutorizacionID"]));
            Autorizacion = Convert.ToString((_DataRow["Autorizacion"] == System.DBNull.Value ? String.Empty : _DataRow["Autorizacion"]));
            Leer = Convert.ToBoolean((_DataRow["Leer"]));
            Crear = Convert.ToBoolean((_DataRow["Crear"]));
            Editar = Convert.ToBoolean((_DataRow["Editar"]));
            Eliminar = Convert.ToBoolean((_DataRow["Eliminar"]));
        }

        #endregion

    }
}
