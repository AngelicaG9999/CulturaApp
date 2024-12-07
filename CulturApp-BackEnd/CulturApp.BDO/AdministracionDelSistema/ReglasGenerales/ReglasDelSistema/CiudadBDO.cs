
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.Serialization;

namespace CulturApp.BDO.AdministracionDelSistema.ReglasGenerales.ReglasDelSistema
{

    /// <summary>
    /// Ciudad.
    /// </summary>
    [DataContract]
    [Serializable]
    public class CiudadBDO
    {

        #region ".:: PROPIEDADES ::."

        [DataMember]
        public int CiudadID { get; set; }

        [DataMember]
        public int DepartamentoID { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public bool Activo { get; set; }

        [DataMember]
        public string Departamento { get; set; }
        #endregion

        #region ".:: CONSTRUCTORES ::."

        public CiudadBDO()
        {
            CiudadID = 0;
            DepartamentoID = 0;
            Nombre = null;
            Activo = true;

            Departamento = null;
        }

        public CiudadBDO(DataRow _DataRow)
        {
            CiudadID = Convert.ToInt32((_DataRow["CiudadID"] == System.DBNull.Value ? 0 : _DataRow["CiudadID"]));
            DepartamentoID = Convert.ToInt32((_DataRow["DepartamentoID"] == System.DBNull.Value ? 0 : _DataRow["DepartamentoID"]));
            Nombre = Convert.ToString((_DataRow["Nombre"] == System.DBNull.Value ? String.Empty : _DataRow["Nombre"]));
            Activo = Convert.ToBoolean((_DataRow["Activo"]));

            Departamento = Convert.ToString((_DataRow["Departamento"] == System.DBNull.Value ? String.Empty : _DataRow["Departamento"]));
        }

        #endregion

    }
}
