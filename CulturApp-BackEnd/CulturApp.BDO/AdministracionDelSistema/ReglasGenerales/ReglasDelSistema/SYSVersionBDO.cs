
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.Serialization;

namespace CulturApp.BDO.AdministracionDelSistema.ReglasGenerales.ReglasDelSistema
{

    /// <summary>
    /// SYSVersion.
    /// </summary>
    [DataContract]
    [Serializable]
    public class SYSVersionBDO
    {

        #region ".:: PROPIEDADES ::."

        [DataMember]
        public long SYSVersionID { get; set; }

        [DataMember]
        public string Version { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        #endregion

        #region ".:: CONSTRUCTORES ::."

        public SYSVersionBDO()
        {
            SYSVersionID = 0;
            Version = null;
            Descripcion = null;
            Fecha = DateTime.Today;
        }

        public SYSVersionBDO(DataRow _DataRow)
        {
            SYSVersionID = Convert.ToInt64((_DataRow["SYSVersionID"] == System.DBNull.Value ? 0 : _DataRow["SYSVersionID"]));
            Version = Convert.ToString((_DataRow["Version"] == System.DBNull.Value ? String.Empty : _DataRow["Version"]));
            Descripcion = Convert.ToString((_DataRow["Descripcion"] == System.DBNull.Value ? String.Empty : _DataRow["Descripcion"]));
            Fecha = Convert.ToDateTime((_DataRow["Fecha"] == System.DBNull.Value ? null : _DataRow["Fecha"]));
        }

        #endregion

    }
}
