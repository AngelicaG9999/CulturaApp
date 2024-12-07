
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.Serialization;

namespace CulturApp.BDO.GestionDatosMaestros.ConfiguracionGeneral
{

    /// <summary>
    /// Divisa.
    /// </summary>
    [DataContract]
    [Serializable]
    public class DivisaBDO
    {

        #region ".:: PROPIEDADES ::."

        [DataMember]
        public long DivisaID { get; set; }

        [DataMember]
        public long EmpresaID { get; set; }

        [DataMember]
        public string Codigo { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public bool Predeterminado { get; set; }

        [DataMember]
        public bool Activo { get; set; }


        [DataMember]
        public string Empresa { get; set; }

        #endregion

        #region ".:: CONSTRUCTORES ::."

        public DivisaBDO()
        {
            DivisaID = 0;
            EmpresaID = 0;
            Codigo = null;
            Nombre = null;
            Predeterminado = false;
            Activo = true;

            Empresa = null;
        }

        public DivisaBDO(DataRow _DataRow)
        {
            DivisaID = Convert.ToInt64((_DataRow["DivisaID"] == System.DBNull.Value ? 0 : _DataRow["DivisaID"]));
            EmpresaID = Convert.ToInt64((_DataRow["ClienteID"] == System.DBNull.Value ? 0 : _DataRow["ClienteID"]));
            Codigo = Convert.ToString((_DataRow["Codigo"] == System.DBNull.Value ? String.Empty : _DataRow["Codigo"]));
            Nombre = Convert.ToString((_DataRow["Nombre"] == System.DBNull.Value ? String.Empty : _DataRow["Nombre"]));
            Predeterminado = Convert.ToBoolean((_DataRow["Predeterminado"]));
            Activo = Convert.ToBoolean((_DataRow["Activo"]));

            Empresa = Convert.ToString((_DataRow["Empresa"] == System.DBNull.Value ? String.Empty : _DataRow["Empresa"]));

        }

        #endregion

    }
}
