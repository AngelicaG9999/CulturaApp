
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.Serialization;

namespace CulturApp.BDO.AdministracionDelSistema.ReglasGenerales.Seguridad
{

    /// <summary>
    /// Perfil.
    /// </summary>
    [DataContract]
    [Serializable]
    public class PerfilBDO
    {

        #region ".:: PROPIEDADES ::."

        [DataMember]
        public long PerfilID { get; set; }

        [DataMember]
        public long EmpresaID { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public bool Activo { get; set; }


        [DataMember]
        public string Empresa { get; set; }
        #endregion

        #region ".:: CONSTRUCTORES ::."

        public PerfilBDO()
        {
            PerfilID = 0;
            EmpresaID = 0;
            Nombre = null;
            Descripcion = null;
            Activo = true;
        }

        public PerfilBDO(DataRow _DataRow)
        {
            PerfilID = Convert.ToInt64((_DataRow["PerfilID"] == System.DBNull.Value ? 0 : _DataRow["PerfilID"]));
            EmpresaID = Convert.ToInt64((_DataRow["ClienteID"] == System.DBNull.Value ? 0 : _DataRow["ClienteID"]));
            Nombre = Convert.ToString((_DataRow["Nombre"] == System.DBNull.Value ? String.Empty : _DataRow["Nombre"]));
            Descripcion = Convert.ToString((_DataRow["Descripcion"] == System.DBNull.Value ? String.Empty : _DataRow["Descripcion"]));
            Activo = Convert.ToBoolean((_DataRow["Activo"]));

            Empresa = Convert.ToString((_DataRow["Empresa"] == System.DBNull.Value ? String.Empty : _DataRow["Empresa"]));
        }

        #endregion

    }
}
