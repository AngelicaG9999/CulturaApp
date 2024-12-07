
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.Serialization;

namespace CulturApp.BDO.AdministracionDelSistema.ReglasGenerales.ReglasDelSistema
{

    /// <summary>
    /// Departamento.
    /// </summary>
    [DataContract]
    [Serializable]
    public class DepartamentoBDO
    {

        #region ".:: PROPIEDADES ::."

        [DataMember]
        public int DepartamentoID { get; set; }

        [DataMember]
        public int PaisID { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public bool Activo { get; set; }

        [DataMember]
        public string Pais { get; set; }

        #endregion

        #region ".:: CONSTRUCTORES ::."

        public DepartamentoBDO()
        {
            DepartamentoID = 0;
            PaisID = 0;
            Nombre = null;
            Activo = true;

            Pais = null;
        }

        public DepartamentoBDO(DataRow _DataRow)
        {
            DepartamentoID = Convert.ToInt32((_DataRow["DepartamentoID"] == System.DBNull.Value ? 0 : _DataRow["DepartamentoID"]));
            PaisID = Convert.ToInt32((_DataRow["PaisID"] == System.DBNull.Value ? 0 : _DataRow["PaisID"]));
            Nombre = Convert.ToString((_DataRow["Nombre"] == System.DBNull.Value ? String.Empty : _DataRow["Nombre"]));
            Activo = Convert.ToBoolean((_DataRow["Activo"]));

            Pais = Convert.ToString((_DataRow["Pais"] == System.DBNull.Value ? String.Empty : _DataRow["Pais"]));
        }

        #endregion

    }
}
