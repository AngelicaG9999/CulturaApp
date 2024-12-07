
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.Serialization;

namespace CulturApp.BDO.AdministracionDelSistema.ReglasGrupoEmpresarial
{

    /// <summary>
    /// EmpresaInfoImagenCorp.
    /// </summary>
    [DataContract]
    [Serializable]
    public class EmpresaInfoImagenCorpBDO
    {

        #region ".:: PROPIEDADES ::."

        [DataMember]
        public long EmpresaID { get; set; }

        [DataMember]
        public string LogoUrl { get; set; }

        [DataMember]
        public string ColorPrincipal { get; set; }

        [DataMember]
        public string ColorSecundario { get; set; }

        [DataMember]
        public string ColorAuxiliar { get; set; }

        #endregion

        #region ".:: CONSTRUCTORES ::."

        public EmpresaInfoImagenCorpBDO()
        {
            EmpresaID = 0;
            LogoUrl = null;
            ColorPrincipal = null;
            ColorSecundario = null;
            ColorAuxiliar = null;
        }

        public EmpresaInfoImagenCorpBDO(DataRow _DataRow)
        {
            EmpresaID = Convert.ToInt64((_DataRow["ClienteID"] == System.DBNull.Value ? 0 : _DataRow["ClienteID"]));
            LogoUrl = Convert.ToString((_DataRow["LogoUrl"] == System.DBNull.Value ? String.Empty : _DataRow["LogoUrl"]));
            ColorPrincipal = Convert.ToString((_DataRow["ColorPrincipal"] == System.DBNull.Value ? String.Empty : _DataRow["ColorPrincipal"]));
            ColorSecundario = Convert.ToString((_DataRow["ColorSecundario"] == System.DBNull.Value ? String.Empty : _DataRow["ColorSecundario"]));
            ColorAuxiliar = Convert.ToString((_DataRow["ColorAuxiliar"] == System.DBNull.Value ? String.Empty : _DataRow["ColorAuxiliar"]));
        }

        #endregion

    }
}
