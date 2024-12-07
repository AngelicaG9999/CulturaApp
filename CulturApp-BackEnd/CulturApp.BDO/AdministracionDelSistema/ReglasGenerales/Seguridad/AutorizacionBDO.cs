using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.Serialization;

namespace CulturApp.BDO.AdministracionDelSistema.ReglasGenerales.Seguridad
{

    /// <summary>
    /// Autorizacion.
    /// </summary>
    [DataContract]
    [Serializable]
    public class AutorizacionBDO
    {

        #region ".:: PROPIEDADES ::."

        [DataMember]
        public long AutorizacionID { get; set; }

        [DataMember]
        public long EmpresaID { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public bool Leer { get; set; }

        [DataMember]
        public bool Crear { get; set; }

        [DataMember]
        public bool Editar { get; set; }

        [DataMember]
        public bool Eliminar { get; set; }

        [DataMember]
        public string Empresa { get; set; }

        #endregion

        #region ".:: CONSTRUCTORES ::."

        public AutorizacionBDO()
        {
            AutorizacionID = 0;
            EmpresaID = 0;
            Nombre = null;
            Descripcion = null;
            Leer = false;
            Crear = false;
            Editar = false;
            Eliminar = false;

            Empresa = null;

        }

        public AutorizacionBDO(DataRow _DataRow)
        {
            AutorizacionID = Convert.ToInt64((_DataRow["AutorizacionID"] == System.DBNull.Value ? 0 : _DataRow["AutorizacionID"]));
            EmpresaID = Convert.ToInt64((_DataRow["ClienteID"] == System.DBNull.Value ? 0 : _DataRow["ClienteID"]));
            Nombre = Convert.ToString((_DataRow["Nombre"] == System.DBNull.Value ? String.Empty : _DataRow["Nombre"]));
            Descripcion = Convert.ToString((_DataRow["Descripcion"] == System.DBNull.Value ? String.Empty : _DataRow["Descripcion"]));
            Leer = Convert.ToBoolean((_DataRow["Leer"]));
            Crear = Convert.ToBoolean((_DataRow["Crear"]));
            Editar = Convert.ToBoolean((_DataRow["Editar"]));
            Eliminar = Convert.ToBoolean((_DataRow["Eliminar"]));

            Empresa = Convert.ToString((_DataRow["Empresa"] == System.DBNull.Value ? String.Empty : _DataRow["Empresa"]));
        }

        #endregion

    }
}

