
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.Serialization;

namespace CulturApp.BDO.AdministracionDelSistema.ReglasGenerales.ReglasDelSistema
{

    /// <summary>
    /// Pais.
    /// </summary>
    [DataContract]
    [Serializable]
    public class PaisBDO
    {

        #region ".:: PROPIEDADES ::."

        [DataMember]
        public int PaisID { get; set; }

        [DataMember]
        public string Codigo { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public bool Activo { get; set; }

        #endregion

        #region ".:: CONSTRUCTORES ::."

        public PaisBDO()
        {
            PaisID = 0;
            Codigo = null;
            Nombre = null;
            Activo = true;
        }

        public PaisBDO(DataRow _DataRow)
        {
            PaisID = Convert.ToInt32((_DataRow["PaisID"] == System.DBNull.Value ? 0 : _DataRow["PaisID"]));
            Codigo = Convert.ToString((_DataRow["Codigo"] == System.DBNull.Value ? String.Empty : _DataRow["Codigo"]));
            Nombre = Convert.ToString((_DataRow["Nombre"] == System.DBNull.Value ? String.Empty : _DataRow["Nombre"]));
            Activo = Convert.ToBoolean((_DataRow["Activo"]));
        }

        #endregion

    }
}
