
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.Serialization;

namespace CulturApp.BDO.AdministracionDelSistema.ReglasGenerales.Seguridad
{

    [DataContract]
    [Serializable]
    public class UsuarioAutorizacionBDO
    {

        #region ".:: PROPIEDADES ::."

        [DataMember]
        public long UsuarioAutorizacionID { get; set; }

        [DataMember]
        public long EmpresaID { get; set; }

        [DataMember]
        public long UsuarioID { get; set; }

        [DataMember]
        public long MenuID { get; set; }

        [DataMember]
        public long AutorizacionID { get; set; }

        #endregion

        #region ".:: CONSTRUCTORES ::."

        public UsuarioAutorizacionBDO()
        {
            UsuarioAutorizacionID = 0;
            EmpresaID = 0;
            UsuarioID = 0;
            MenuID = 0;
            AutorizacionID = 0;
        }

        public UsuarioAutorizacionBDO(IDictionary _IDictionary)
        {
            UsuarioAutorizacionID = Convert.ToInt64((_IDictionary["UsuarioAutorizacionID"] == System.DBNull.Value ? 0 : _IDictionary["UsuarioAutorizacionID"]));
            EmpresaID = Convert.ToInt64((_IDictionary["ClienteID"] == System.DBNull.Value ? 0 : _IDictionary["ClienteID"]));
            UsuarioID = Convert.ToInt64((_IDictionary["UsuarioID"] == System.DBNull.Value ? 0 : _IDictionary["UsuarioID"]));
            MenuID = Convert.ToInt64((_IDictionary["MenuID"] == System.DBNull.Value ? 0 : _IDictionary["MenuID"]));
            AutorizacionID = Convert.ToInt64((_IDictionary["AutorizacionID"] == System.DBNull.Value ? 0 : _IDictionary["AutorizacionID"]));
        }

        public UsuarioAutorizacionBDO(DataRow _DataRow)
        {
            UsuarioAutorizacionID = Convert.ToInt64((_DataRow["UsuarioAutorizacionID"] == System.DBNull.Value ? 0 : _DataRow["UsuarioAutorizacionID"]));
            EmpresaID = Convert.ToInt64((_DataRow["ClienteID"] == System.DBNull.Value ? 0 : _DataRow["ClienteID"]));
            UsuarioID = Convert.ToInt64((_DataRow["UsuarioID"] == System.DBNull.Value ? 0 : _DataRow["UsuarioID"]));
            MenuID = Convert.ToInt64((_DataRow["MenuID"] == System.DBNull.Value ? 0 : _DataRow["MenuID"]));
            AutorizacionID = Convert.ToInt64((_DataRow["AutorizacionID"] == System.DBNull.Value ? 0 : _DataRow["AutorizacionID"]));
        }

        #endregion

    }
}
