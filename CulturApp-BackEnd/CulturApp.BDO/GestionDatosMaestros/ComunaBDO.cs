using System;
using System.Data;

namespace CulturApp.BDO.GestionDatosMaestros
{

    /// <summary>
    /// Comuna
    /// </summary>
    public class ComunaBDO
    {
        #region ".:: PROPIEDADES ::."

        public long ComunaID { get; set; }

        public long EmpresaID { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        #endregion

        #region ".:: CONSTRUCTORES ::."

        public ComunaBDO()
        {
            ComunaID = 0;
            EmpresaID = 0;
            Nombre = null;
            Descripcion = null;
        }

        public ComunaBDO(DataRow _DataRow)
        {
            ComunaID = Convert.ToInt64((_DataRow["ComunaID"] == System.DBNull.Value ? 0 : _DataRow["ComunaID"]));
            EmpresaID = Convert.ToInt64((_DataRow["EmpresaID"] == System.DBNull.Value ? 0 : _DataRow["EmpresaID"]));
            Nombre = Convert.ToString((_DataRow["Nombre"] == System.DBNull.Value ? String.Empty : _DataRow["Nombre"]));
            Descripcion = Convert.ToString((_DataRow["Descripcion"] == System.DBNull.Value ? String.Empty : _DataRow["Descripcion"]));
        }

        #endregion
    }


}
