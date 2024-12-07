
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.Serialization;

namespace CulturApp.BDO.AdministracionDelSistema.ReglasGrupoEmpresarial
{

    [DataContract]
    [Serializable]
    public class EmpresaBDO
    {

        #region ".:: PROPIEDADES ::."

        [DataMember]
        public long EmpresaID { get; set; }

        [DataMember]
        public long PoliticaMaterialesID { get; set; }

        [DataMember]
        public string Codigo { get; set; }

        [DataMember]
        public string NumeroIdentificacion { get; set; }

        [DataMember]
        public string DigitoVerificacion { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string SyscorpID { get; set; }

        [DataMember]
        public string TelefonoFijo { get; set; }

        [DataMember]
        public string TelefonoMovil { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string DominioWeb { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public DateTime FechaRegistro { get; set; }

        [DataMember]
        public bool Activo { get; set; }

        [DataMember]
        public string Direccion { get; set; }

        #endregion

        #region ".:: CONSTRUCTORES ::."

        public EmpresaBDO()
        {
            EmpresaID = 0;
            PoliticaMaterialesID = 0;
            Codigo = null;
            NumeroIdentificacion = null;
            DigitoVerificacion = null;
            Nombre = null;
            SyscorpID = null;
            TelefonoFijo = null;
            TelefonoMovil = null;
            Email = null;
            DominioWeb = null;
            Descripcion = null;
            FechaRegistro = DateTime.Today;
            Activo = true;
            Direccion = null;
        }

        public EmpresaBDO(DataRow _DataRow)
        {
            EmpresaID = Convert.ToInt64((_DataRow["ClienteID"] == System.DBNull.Value ? 0 : _DataRow["ClienteID"]));
            PoliticaMaterialesID = Convert.ToInt64((_DataRow["PoliticaMaterialesID"] == System.DBNull.Value ? 0 : _DataRow["PoliticaMaterialesID"]));
            Codigo = Convert.ToString((_DataRow["Codigo"] == System.DBNull.Value ? String.Empty : _DataRow["Codigo"]));
            NumeroIdentificacion = Convert.ToString((_DataRow["NumeroIdentificacion"] == System.DBNull.Value ? String.Empty : _DataRow["NumeroIdentificacion"]));
            DigitoVerificacion = Convert.ToString((_DataRow["DigitoVerificacion"] == System.DBNull.Value ? String.Empty : _DataRow["DigitoVerificacion"]));
            Nombre = Convert.ToString((_DataRow["Nombre"] == System.DBNull.Value ? String.Empty : _DataRow["Nombre"]));
            SyscorpID = Convert.ToString((_DataRow["SyscorpID"] == System.DBNull.Value ? String.Empty : _DataRow["SyscorpID"]));
            TelefonoFijo = Convert.ToString((_DataRow["TelefonoFijo"] == System.DBNull.Value ? String.Empty : _DataRow["TelefonoFijo"]));
            TelefonoMovil = Convert.ToString((_DataRow["TelefonoMovil"] == System.DBNull.Value ? String.Empty : _DataRow["TelefonoMovil"]));
            Email = Convert.ToString((_DataRow["Email"] == System.DBNull.Value ? String.Empty : _DataRow["Email"]));
            DominioWeb = Convert.ToString((_DataRow["DominioWeb"] == System.DBNull.Value ? String.Empty : _DataRow["DominioWeb"]));
            Descripcion = Convert.ToString((_DataRow["Descripcion"] == System.DBNull.Value ? String.Empty : _DataRow["Descripcion"]));
            FechaRegistro = Convert.ToDateTime((_DataRow["FechaRegistro"] == System.DBNull.Value ? new DateTime() : _DataRow["FechaRegistro"]));
            Activo = Convert.ToBoolean((_DataRow["Activo"]));
            Direccion = Convert.ToString((_DataRow["Direccion"] == System.DBNull.Value ? String.Empty : _DataRow["Direccion"]));
        }

        #endregion
    }
}
