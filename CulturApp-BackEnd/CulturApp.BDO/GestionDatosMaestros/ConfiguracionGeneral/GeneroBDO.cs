
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.Serialization;

namespace CulturApp.BDO.GestionDatosMaestros.ConfiguracionGeneral
{
    [DataContract]
    [Serializable]
    public class GeneroBDO
    {

        #region ".:: PROPIEDADES ::."

        [DataMember]
        public long GeneroID { get; set; }

        [DataMember]
        public long EmpresaID { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public bool Activo { get; set; }


        [DataMember]
        public string Empresa { get; set; }

        #endregion

        #region ".:: CONSTRUCTORES ::."

        public GeneroBDO()
        {
            GeneroID = 0;
            EmpresaID = 0;
            Nombre = null;
            Descripcion = null;
            Activo = false;

            Empresa = null;
        }

        public GeneroBDO(DataRow _DataRow)
        {
            GeneroID = Convert.ToInt64((_DataRow["GeneroID"] == System.DBNull.Value ? 0 : _DataRow["GeneroID"]));
            EmpresaID = Convert.ToInt64((_DataRow["ClienteID"] == System.DBNull.Value ? 0 : _DataRow["ClienteID"]));
            Nombre = Convert.ToString((_DataRow["Nombre"] == System.DBNull.Value ? String.Empty : _DataRow["Nombre"]));
            Descripcion = Convert.ToString((_DataRow["Descripcion"] == System.DBNull.Value ? String.Empty : _DataRow["Descripcion"]));
            Activo = Convert.ToBoolean((_DataRow["Activo"]));

            Empresa = Convert.ToString((_DataRow["Empresa"] == System.DBNull.Value ? String.Empty : _DataRow["Empresa"]));

        }

        #endregion

    }
}