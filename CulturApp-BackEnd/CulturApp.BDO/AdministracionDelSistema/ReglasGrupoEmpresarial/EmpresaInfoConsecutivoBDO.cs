
using System;
using System.Data;
using System.Runtime.Serialization;

namespace CulturApp.BDO.AdministracionDelSistema.ReglasGrupoEmpresarial
{

    /// <summary>
    /// EmpresaInfoConsecutivo.
    /// </summary>
    [DataContract]
    [Serializable]
    public class EmpresaInfoConsecutivoBDO
    {

        #region ".:: PROPIEDADES ::."

        [DataMember]
        public long EmpresaID { get; set; }

        [DataMember]
        public long FacturaCompra { get; set; }

        [DataMember]
        public long FacturaVenta { get; set; }

        [DataMember]
        public long Contrato { get; set; }


        [DataMember]
        public string Empresa { get; set; }

        #endregion

        #region ".:: CONSTRUCTORES ::."

        public EmpresaInfoConsecutivoBDO()
        {
            EmpresaID = 0;
            FacturaCompra = 0;
            FacturaVenta = 0;
            Contrato = 0;

            Empresa = null;
        }

        public EmpresaInfoConsecutivoBDO(DataRow _DataRow)
        {
            EmpresaID = Convert.ToInt64((_DataRow["ClienteID"] == System.DBNull.Value ? 0 : _DataRow["ClienteID"]));
            FacturaCompra = Convert.ToInt64((_DataRow["FacturaCompra"] == System.DBNull.Value ? 0 : _DataRow["FacturaCompra"]));
            FacturaVenta = Convert.ToInt64((_DataRow["FacturaVenta"] == System.DBNull.Value ? 0 : _DataRow["FacturaVenta"]));
            Contrato = Convert.ToInt64((_DataRow["Contrato"] == System.DBNull.Value ? 0 : _DataRow["Contrato"]));

            Empresa = Convert.ToString((_DataRow["Empresa"] == System.DBNull.Value ? String.Empty : _DataRow["Empresa"]));
        }

        #endregion

    }
}
