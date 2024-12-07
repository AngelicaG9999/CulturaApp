using System;
using System.Data;


namespace CulturApp.BDO.GestionDatosMaestros
{
    /// <summary>
    /// Sala
    /// </summary>
    /// 
    public class SalaBDO
    {
        #region ".:: PROPIEDADES ::."

        public long SalaID { get; set; }

        public long EmpresaID { get; set; }

        public long EdificioID { get; set; }

        public string Nombre { get; set; }

        public int Capacidad { get; set; }

        public string Descripcion { get; set; }

        public string Edificio { get; set; }

        #endregion

        #region ".:: CONSTRUCTORES ::."

        public SalaBDO()
        {
            SalaID = 0;
            EmpresaID = 0;
            EdificioID = 0;
            Nombre = null;
            Capacidad = 0;
            Descripcion = null;
        }

        public SalaBDO(DataRow _DataRow)
        {
            SalaID = Convert.ToInt64((_DataRow["SalaID"] == System.DBNull.Value ? 0 : _DataRow["SalaID"]));
            EmpresaID = Convert.ToInt64((_DataRow["EmpresaID"] == System.DBNull.Value ? 0 : _DataRow["EmpresaID"]));
            EdificioID = Convert.ToInt64((_DataRow["EdificioID"] == System.DBNull.Value ? 0 : _DataRow["EdificioID"]));
            Nombre = Convert.ToString((_DataRow["Nombre"] == System.DBNull.Value ? String.Empty : _DataRow["Nombre"]));
            Capacidad = Convert.ToInt32((_DataRow["Capacidad"] == System.DBNull.Value ? 0 : _DataRow["Capacidad"]));
            Descripcion = Convert.ToString((_DataRow["Descripcion"] == System.DBNull.Value ? String.Empty : _DataRow["Descripcion"]));

            Edificio = Convert.ToString((_DataRow["Edificio"] == System.DBNull.Value ? String.Empty : _DataRow["Edificio"]));
        }
        #endregion
    }
}
