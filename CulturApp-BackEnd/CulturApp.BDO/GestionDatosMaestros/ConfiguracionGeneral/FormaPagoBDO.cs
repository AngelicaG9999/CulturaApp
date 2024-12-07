
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.Serialization;

namespace CulturApp.BDO.GestionDatosMaestros.ConfiguracionGeneral
{

    /// <summary>
    /// FormaPago.
    /// </summary>
    [DataContract]
    [Serializable]
    public class FormaPagoBDO
    {

        #region ".:: PROPIEDADES ::."

        [DataMember]
        public long FormaPagoID { get; set; }

        [DataMember]
        public long EmpresaID { get; set; }

        [DataMember]
        public string Codigo { get; set; }

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

        public FormaPagoBDO()
        {
            FormaPagoID = 0;
            EmpresaID = 0;
            Codigo = null;
            Nombre = null;
            Descripcion = null;
            Activo = true;

            Empresa = null;
        }

        public FormaPagoBDO(DataRow _DataRow)
        {
            FormaPagoID = Convert.ToInt64((_DataRow["FormaPagoID"] == System.DBNull.Value ? 0 : _DataRow["FormaPagoID"]));
            EmpresaID = Convert.ToInt64((_DataRow["ClienteID"] == System.DBNull.Value ? 0 : _DataRow["ClienteID"]));
            Codigo = Convert.ToString((_DataRow["Codigo"] == System.DBNull.Value ? String.Empty : _DataRow["Codigo"]));
            Nombre = Convert.ToString((_DataRow["Nombre"] == System.DBNull.Value ? String.Empty : _DataRow["Nombre"]));
            Descripcion = Convert.ToString((_DataRow["Descripcion"] == System.DBNull.Value ? String.Empty : _DataRow["Descripcion"]));
            Activo = Convert.ToBoolean((_DataRow["Activo"]));

            Empresa = Convert.ToString((_DataRow["Empresa"] == System.DBNull.Value ? String.Empty : _DataRow["Empresa"]));
        }

        #endregion

    }
}
