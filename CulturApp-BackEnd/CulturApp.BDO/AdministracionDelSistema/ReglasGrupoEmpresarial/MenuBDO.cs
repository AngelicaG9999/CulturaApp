
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.Serialization;

namespace CulturApp.BDO.AdministracionDelSistema.ReglasGrupoEmpresarial
{

    [DataContract]
    [Serializable]
    public class MenuBDO
    {

        #region ".:: PROPIEDADES ::."

        [DataMember]
        public long MenuID { get; set; }

        [DataMember]
        public long PadreID { get; set; }

        [DataMember]
        public string Tipo { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public string ObjetoUrl { get; set; }

        [DataMember]
        public string Clave { get; set; }

        [DataMember]
        public long Orden { get; set; }

        [DataMember]
        public long Activo { get; set; }

        [DataMember]
        public string Autorizacion { get; set; }

        #endregion

        #region ".:: CONSTRUCTORES ::."

        public MenuBDO()
        {
            MenuID = 0;
            PadreID = 0;
            Tipo = null;
            Nombre = null;
            Descripcion = null;
            ObjetoUrl = null;
            Clave = null;
            Orden = 0;
            Activo = 0;

            Autorizacion = null;
        }

        public MenuBDO(DataRow _DataRow)
        {
            MenuID = Convert.ToInt64((_DataRow["MenuID"] == System.DBNull.Value ? 0 : _DataRow["MenuID"]));
            PadreID = Convert.ToInt64((_DataRow["PadreID"] == System.DBNull.Value ? 0 : _DataRow["PadreID"]));
            Tipo = Convert.ToString((_DataRow["Tipo"] == System.DBNull.Value ? String.Empty : _DataRow["Tipo"]));
            Nombre = Convert.ToString((_DataRow["Nombre"] == System.DBNull.Value ? String.Empty : _DataRow["Nombre"]));
            Descripcion = Convert.ToString((_DataRow["Descripcion"] == System.DBNull.Value ? String.Empty : _DataRow["Descripcion"]));
            ObjetoUrl = Convert.ToString((_DataRow["ObjetoUrl"] == System.DBNull.Value ? String.Empty : _DataRow["ObjetoUrl"]));
            Clave = Convert.ToString((_DataRow["Clave"] == System.DBNull.Value ? String.Empty : _DataRow["Clave"]));
            Orden = Convert.ToInt64((_DataRow["Orden"] == System.DBNull.Value ? 0 : _DataRow["Orden"]));
            Activo = Convert.ToInt64((_DataRow["Activo"] == System.DBNull.Value ? 0 : _DataRow["Activo"]));

            Autorizacion = Convert.ToString((_DataRow["Autorizacion"] == System.DBNull.Value ? String.Empty : _DataRow["Autorizacion"]));

        }

        #endregion
    }
}
