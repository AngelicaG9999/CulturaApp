using System;
using System.Data;

namespace CulturApp.BDO.GestionDatosMaestros
{

    /// <summary>
    /// Barrio
    /// </summary>
    public class BarrioBDO
    {
        #region ".:: PROPIEDADES ::."

        public long BarrioID { get; set; }

        public long EmpresaID { get; set; }

        public long ComunaID { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string Comuna { get; set; }

        #endregion

        #region ".:: CONSTRUCTORES ::."

        public BarrioBDO()
        {
            BarrioID = 0;
            EmpresaID = 0;
            ComunaID = 0;
            Nombre = null;
            Descripcion = null;
        }

        public BarrioBDO(DataRow _DataRow)
        {
            BarrioID = Convert.ToInt64((_DataRow["BarrioID"] == System.DBNull.Value ? 0 : _DataRow["BarrioID"]));
            EmpresaID = Convert.ToInt64((_DataRow["EmpresaID"] == System.DBNull.Value ? 0 : _DataRow["EmpresaID"]));
            ComunaID = Convert.ToInt64((_DataRow["ComunaID"] == System.DBNull.Value ? 0 : _DataRow["ComunaID"]));
            Nombre = Convert.ToString((_DataRow["Nombre"] == System.DBNull.Value ? String.Empty : _DataRow["Nombre"]));
            Descripcion = Convert.ToString((_DataRow["Descripcion"] == System.DBNull.Value ? String.Empty : _DataRow["Descripcion"]));

            Comuna = Convert.ToString((_DataRow["Comuna"] == System.DBNull.Value ? String.Empty : _DataRow["Comuna"]));
        }

        #endregion
    }
}
