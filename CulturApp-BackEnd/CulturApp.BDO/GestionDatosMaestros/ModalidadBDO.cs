
using System;
using System.Data;

namespace CulturApp.BDO.GestionDatosMaestros
{

    /// <summary>
    /// Modalidad.
    /// </summary>
    public class ModalidadBDO
    {

        #region ".:: PROPIEDADES ::."

        public long ModalidadID { get; set; }

        public long EmpresaID { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        #endregion

        #region ".:: CONSTRUCTORES ::."

        public ModalidadBDO()
        {
            ModalidadID = 0;
            EmpresaID = 0;
            Nombre = null;
            Descripcion = null;
        }

        public ModalidadBDO(DataRow _DataRow)
        {
            ModalidadID = Convert.ToInt64((_DataRow["ModalidadID"] == System.DBNull.Value ? 0 : _DataRow["ModalidadID"]));
            EmpresaID = Convert.ToInt64((_DataRow["EmpresaID"] == System.DBNull.Value ? 0 : _DataRow["EmpresaID"]));
            Nombre = Convert.ToString((_DataRow["Nombre"] == System.DBNull.Value ? String.Empty : _DataRow["Nombre"]));
            Descripcion = Convert.ToString((_DataRow["Descripcion"] == System.DBNull.Value ? String.Empty : _DataRow["Descripcion"]));
        }

        #endregion

    }

}
