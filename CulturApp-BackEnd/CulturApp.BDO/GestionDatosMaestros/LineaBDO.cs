
using System;
using System.Data;
using System.Runtime.Serialization;

namespace CulturApp.BDO.GestionDatosMaestros
{

    /// <summary>
    /// Linea.
    /// </summary>
    public class LineaBDO
    {

        #region ".:: PROPIEDADES ::."

        public long LineaID { get; set; }

        public long EmpresaID { get; set; }

        public long ModalidadID { get; set; }

        public long AreaID { get; set; }

        public string Nombre { get; set; }

        public string Tipo { get; set; }

        public string Descripcion { get; set; }

        public string Modalidad { get; set; }

        public string Area { get; set; }

        #endregion

        #region ".:: CONSTRUCTORES ::."

        public LineaBDO()
        {
            LineaID = 0;
            EmpresaID = 0;
            ModalidadID = 0;
            AreaID = 0;
            Nombre = null;
            Tipo = null;
            Descripcion = null;

            Modalidad = null;
            Area = null;
        }

        public LineaBDO(DataRow _DataRow)
        {
            LineaID = Convert.ToInt64((_DataRow["LineaID"] == System.DBNull.Value ? 0 : _DataRow["LineaID"]));
            EmpresaID = Convert.ToInt64((_DataRow["EmpresaID"] == System.DBNull.Value ? 0 : _DataRow["EmpresaID"]));
            ModalidadID = Convert.ToInt64((_DataRow["ModalidadID"] == System.DBNull.Value ? 0 : _DataRow["ModalidadID"]));
            AreaID = Convert.ToInt64((_DataRow["AreaID"] == System.DBNull.Value ? 0 : _DataRow["AreaID"]));
            Nombre = Convert.ToString((_DataRow["Nombre"] == System.DBNull.Value ? String.Empty : _DataRow["Nombre"]));
            Tipo = Convert.ToString((_DataRow["Tipo"] == System.DBNull.Value ? String.Empty : _DataRow["Tipo"]));
            Descripcion = Convert.ToString((_DataRow["Descripcion"] == System.DBNull.Value ? String.Empty : _DataRow["Descripcion"]));

            Modalidad = Convert.ToString((_DataRow["Modalidad"] == System.DBNull.Value ? String.Empty : _DataRow["Modalidad"]));
            Area = Convert.ToString((_DataRow["Area"] == System.DBNull.Value ? String.Empty : _DataRow["Area"]));
        }

        #endregion

    }

}
