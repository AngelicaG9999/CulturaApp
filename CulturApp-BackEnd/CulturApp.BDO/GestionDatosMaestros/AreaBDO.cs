
using System;
using System.Data;
using System.Runtime.Serialization;

namespace CulturApp.BDO.GestionDatosMaestros
{

    /// <summary>
    /// Area.
    /// </summary>
    public class AreaBDO
    {

        #region ".:: PROPIEDADES ::."

        public long AreaID { get; set; }

        public long EmpresaID { get; set; }

        public long ModalidadID { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string Modalidad { get; set; }
        #endregion

        #region ".:: CONSTRUCTORES ::."

        public AreaBDO()
        {
            AreaID = 0;
            EmpresaID = 0;
            ModalidadID = 0;
            Nombre = null;
            Descripcion = null;

            Modalidad = null;
        }

        public AreaBDO(DataRow _DataRow)
        {
            AreaID = Convert.ToInt64((_DataRow["AreaID"] == System.DBNull.Value ? 0 : _DataRow["AreaID"]));
            EmpresaID = Convert.ToInt64((_DataRow["EmpresaID"] == System.DBNull.Value ? 0 : _DataRow["EmpresaID"]));
            ModalidadID = Convert.ToInt64((_DataRow["ModalidadID"] == System.DBNull.Value ? 0 : _DataRow["ModalidadID"]));
            Nombre = Convert.ToString((_DataRow["Nombre"] == System.DBNull.Value ? String.Empty : _DataRow["Nombre"]));
            Descripcion = Convert.ToString((_DataRow["Descripcion"] == System.DBNull.Value ? String.Empty : _DataRow["Descripcion"]));

            Modalidad = Convert.ToString((_DataRow["Modalidad"] == System.DBNull.Value ? String.Empty : _DataRow["Modalidad"]));
        }

        #endregion

    }

}
