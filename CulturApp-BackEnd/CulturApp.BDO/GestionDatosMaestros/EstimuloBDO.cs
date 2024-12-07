
using System;
using System.Data;
using System.Runtime.Serialization;

namespace CulturApp.BDO.GestionDatosMaestros
{

    /// <summary>
    /// Estimulo.
    /// </summary>
    public class EstimuloBDO
    {

        #region ".:: PROPIEDADES ::."

        public long EstimuloID { get; set; }

        public long EmpresaID { get; set; }

        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public DateTime? FechaApertura { get; set; }

        public DateTime? FechaCierre { get; set; }

        public string Descripcion { get; set; }

        public bool Cerrado { get; set; }

        #endregion

        #region ".:: CONSTRUCTORES ::."

        public EstimuloBDO()
        {
            EstimuloID = 0;
            EmpresaID = 0;
            Codigo = null;
            Nombre = null;
            FechaApertura = null;
            FechaCierre = null;
            Descripcion = null;
            Cerrado = false;
        }

        public EstimuloBDO(DataRow _DataRow)
        {
            EstimuloID = Convert.ToInt64((_DataRow["EstimuloID"] == System.DBNull.Value ? 0 : _DataRow["EstimuloID"]));
            EmpresaID = Convert.ToInt64((_DataRow["EmpresaID"] == System.DBNull.Value ? 0 : _DataRow["EmpresaID"]));
            Codigo = Convert.ToString((_DataRow["Codigo"] == System.DBNull.Value ? String.Empty : _DataRow["Codigo"]));
            Nombre = Convert.ToString((_DataRow["Nombre"] == System.DBNull.Value ? String.Empty : _DataRow["Nombre"]));
            FechaApertura = Convert.ToDateTime((_DataRow["FechaApertura"] == System.DBNull.Value ? null : _DataRow["FechaApertura"]));
            FechaCierre = Convert.ToDateTime((_DataRow["FechaCierre"] == System.DBNull.Value ? null : _DataRow["FechaCierre"]));
            Descripcion = Convert.ToString((_DataRow["Descripcion"] == System.DBNull.Value ? String.Empty : _DataRow["Descripcion"]));
            Cerrado = Convert.ToBoolean((_DataRow["Cerrado"]));
        }

        #endregion

    }
}
