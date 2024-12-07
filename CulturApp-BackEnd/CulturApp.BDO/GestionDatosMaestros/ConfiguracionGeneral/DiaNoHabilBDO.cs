
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.Serialization;


namespace CulturApp.BDO.GestionDatosMaestros.ConfiguracionGeneral
{

    /// <summary>
    /// DiaNoHabil.
    /// </summary>
    [DataContract]
    [Serializable]
    public class DiaNoHabilBDO
    {

        #region ".:: PROPIEDADES ::."

        [DataMember]
        public long DiaNoHabilID { get; set; }

        [DataMember]
        public long EmpresaID { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Descripcion { get; set; }


        [DataMember]
        public string Empresa { get; set; }

        #endregion

        #region ".:: CONSTRUCTORES ::."

        public DiaNoHabilBDO()
        {
            DiaNoHabilID = 0;
            EmpresaID = 0;
            Fecha = DateTime.Today;
            Nombre = null;
            Descripcion = null;

            Empresa = null;
        }

        public DiaNoHabilBDO(DataRow _DataRow)
        {
            DiaNoHabilID = Convert.ToInt64((_DataRow["DiaNoHabilID"] == System.DBNull.Value ? 0 : _DataRow["DiaNoHabilID"]));
            EmpresaID = Convert.ToInt64((_DataRow["ClienteID"] == System.DBNull.Value ? 0 : _DataRow["ClienteID"]));
            Fecha = Convert.ToDateTime((_DataRow["Fecha"] == System.DBNull.Value ? null : _DataRow["Fecha"]));
            Nombre = Convert.ToString((_DataRow["Nombre"] == System.DBNull.Value ? String.Empty : _DataRow["Nombre"]));
            Descripcion = Convert.ToString((_DataRow["Descripcion"] == System.DBNull.Value ? String.Empty : _DataRow["Descripcion"]));

            Empresa = Convert.ToString((_DataRow["Empresa"] == System.DBNull.Value ? String.Empty : _DataRow["Empresa"]));
        }

        #endregion

    }
}
