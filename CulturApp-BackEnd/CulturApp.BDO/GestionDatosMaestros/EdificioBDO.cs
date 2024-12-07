using System;
using System.Data;

namespace CulturApp.BDO.GestionDatosMaestros
{
    /// <summary>
    /// Edificio
    /// </summary>
    public class EdificioBDO
    {
        #region ".:: PROPIEDADES ::."

        public long EdificioID { get; set; }

        public long EmpresaID { get; set; }

        public long BarrioID { get; set; }

        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Barrio { get; set; }

        #endregion

        #region ".:: CONSTRUCTORES ::."

        public EdificioBDO()
        {
            EdificioID = 0;
            EmpresaID = 0;
            BarrioID = 0;
            Nombre = null;
            Direccion = null;
        }

        public EdificioBDO(DataRow _DataRow)
        {
            EdificioID = Convert.ToInt64((_DataRow["EdificioID"] == System.DBNull.Value ? 0 : _DataRow["EdificioID"]));
            EmpresaID = Convert.ToInt64((_DataRow["EmpresaID"] == System.DBNull.Value ? 0 : _DataRow["EmpresaID"]));
            BarrioID = Convert.ToInt64((_DataRow["BarrioID"] == System.DBNull.Value ? 0 : _DataRow["BarrioID"]));
            Nombre = Convert.ToString((_DataRow["Nombre"] == System.DBNull.Value ? String.Empty : _DataRow["Nombre"]));
            Direccion = Convert.ToString((_DataRow["Direccion"] == System.DBNull.Value ? String.Empty : _DataRow["Direccion"]));

            Barrio = Convert.ToString((_DataRow["Barrio"] == System.DBNull.Value ? String.Empty : _DataRow["Barrio"]));
        }

        #endregion

    }
}
