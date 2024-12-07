
using System;
using System.Data;
using System.Runtime.Serialization;

namespace CulturApp.BDO.GestionDatosMaestros
{

    /// <summary>
    /// Tipo.
    /// </summary>
    public class TipoBDO
    {

        #region ".:: PROPIEDADES ::."

        public long TipoID { get; set; }

        public long EmpresaID { get; set; }


        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }
        #endregion

        #region ".:: CONSTRUCTORES ::."

        public TipoBDO()
        {
            TipoID = 0;
            EmpresaID = 0;
            Codigo = null;
            Nombre = null;
            Descripcion = null;
        }

        public TipoBDO(DataRow _DataRow)
        {
            TipoID = Convert.ToInt64((_DataRow["TipoID"] == System.DBNull.Value ? 0 : _DataRow["TipoID"]));
            EmpresaID = Convert.ToInt64((_DataRow["EmpresaID"] == System.DBNull.Value ? 0 : _DataRow["EmpresaID"]));
            Codigo = Convert.ToString((_DataRow["Codigo"] == System.DBNull.Value ? String.Empty : _DataRow["Codigo"]));
            Nombre = Convert.ToString((_DataRow["Nombre"] == System.DBNull.Value ? String.Empty : _DataRow["Nombre"]));
            Descripcion = Convert.ToString((_DataRow["Descripcion"] == System.DBNull.Value ? String.Empty : _DataRow["Descripcion"]));
        }

        #endregion

    }

}
