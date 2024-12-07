
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.Serialization;

namespace CulturApp.BDO.GestionDatosMaestros.ConfiguracionTerceros
{

    /// <summary>
    /// Tercero.
    /// </summary>
    [DataContract]
    [Serializable]
    public class TerceroBDO
    {

        #region ".:: PROPIEDADES ::."

        [DataMember]
        public long TerceroID { get; set; }

        [DataMember]
        public long EmpresaID { get; set; }

        [DataMember]
        public string NumeroIdentificacion { get; set; }

        [DataMember]
        public string DigitoVerificacion { get; set; }

        [DataMember]
        public string Codigo { get; set; }

        [DataMember]
        public string Iniciales { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Apellido { get; set; }

        [DataMember]
        public string RazonSocial { get; set; }

        [DataMember]
        public string RazonComercial { get; set; }

        [DataMember]
        public string NombreCompleto { get; set; }

        [DataMember]
        public bool Cliente { get; set; }

        [DataMember]
        public bool Empleado { get; set; }

        [DataMember]
        public bool Proveedor { get; set; }

        [DataMember]
        public bool RepComercial { get; set; }

        [DataMember]
        public bool Activo { get; set; }

        [DataMember]
        public long TipoIdentificacionID { get; set; }


        [DataMember]
        public string Empresa { get; set; }

        [DataMember]
        public string TipoIdentificacion { get; set; }

        [DataMember]
        public string Grupo { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Foto { get; set; }

        #endregion

        #region ".:: CONSTRUCTORES ::."

        public TerceroBDO()
        {
            TerceroID = 0;
            EmpresaID = 0;
            NumeroIdentificacion = null;
            DigitoVerificacion = null;
            Codigo = null;
            Iniciales = null;
            Nombre = null;
            Apellido = null;
            RazonSocial = null;
            RazonComercial = null;
            NombreCompleto = null;
            Cliente = false;
            Empleado = false;
            Proveedor = false;
            RepComercial = false;
            Activo = true;
            TipoIdentificacionID = 0;

            Empresa = null;
            TipoIdentificacion = null;
            Grupo = null;
            Email = null;
            Foto = null;
        }

        public TerceroBDO(DataRow _DataRow)
        {
            TerceroID = Convert.ToInt64((_DataRow["TerceroID"] == System.DBNull.Value ? 0 : _DataRow["TerceroID"]));
            EmpresaID = Convert.ToInt64((_DataRow["ClienteID"] == System.DBNull.Value ? 0 : _DataRow["ClienteID"]));
            NumeroIdentificacion = Convert.ToString((_DataRow["NumeroIdentificacion"] == System.DBNull.Value ? String.Empty : _DataRow["NumeroIdentificacion"]));
            DigitoVerificacion = Convert.ToString((_DataRow["DigitoVerificacion"] == System.DBNull.Value ? String.Empty : _DataRow["DigitoVerificacion"]));
            Codigo = Convert.ToString((_DataRow["Codigo"] == System.DBNull.Value ? String.Empty : _DataRow["Codigo"]));
            Iniciales = Convert.ToString((_DataRow["Iniciales"] == System.DBNull.Value ? String.Empty : _DataRow["Iniciales"]));
            Nombre = Convert.ToString((_DataRow["Nombre"] == System.DBNull.Value ? String.Empty : _DataRow["Nombre"]));
            Apellido = Convert.ToString((_DataRow["Apellido"] == System.DBNull.Value ? String.Empty : _DataRow["Apellido"]));
            RazonSocial = Convert.ToString((_DataRow["RazonSocial"] == System.DBNull.Value ? String.Empty : _DataRow["RazonSocial"]));
            RazonComercial = Convert.ToString((_DataRow["RazonComercial"] == System.DBNull.Value ? String.Empty : _DataRow["RazonComercial"]));
            NombreCompleto = Convert.ToString((_DataRow["NombreCompleto"] == System.DBNull.Value ? String.Empty : _DataRow["NombreCompleto"]));
            Cliente = Convert.ToBoolean((_DataRow["Cliente"]));
            Empleado = Convert.ToBoolean((_DataRow["Empleado"]));
            Proveedor = Convert.ToBoolean((_DataRow["Proveedor"]));
            RepComercial = Convert.ToBoolean((_DataRow["RepComercial"]));
            Activo = Convert.ToBoolean((_DataRow["Activo"]));
            TipoIdentificacionID = Convert.ToInt64((_DataRow["TipoIdentificacionID"] == System.DBNull.Value ? 0 : _DataRow["TipoIdentificacionID"]));

            Empresa = Convert.ToString((_DataRow["Empresa"] == System.DBNull.Value ? String.Empty : _DataRow["Empresa"]));
            TipoIdentificacion = Convert.ToString((_DataRow["TipoIdentificacion"] == System.DBNull.Value ? String.Empty : _DataRow["TipoIdentificacion"]));
            Grupo = Convert.ToString((_DataRow["Grupo"] == System.DBNull.Value ? String.Empty : _DataRow["Grupo"]));
            Email = Convert.ToString((_DataRow["Email"] == System.DBNull.Value ? String.Empty : _DataRow["Email"]));
            Foto = Convert.ToString((_DataRow["Foto"] == System.DBNull.Value ? String.Empty : _DataRow["Foto"]));
        }

        #endregion

    }
}
