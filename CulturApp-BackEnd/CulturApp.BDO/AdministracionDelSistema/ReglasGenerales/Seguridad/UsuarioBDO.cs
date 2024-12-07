
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.Serialization;

namespace CulturApp.BDO.AdministracionDelSistema.ReglasGenerales.Seguridad
{

    [DataContract]
    [Serializable]
    public class UsuarioBDO
    {

        #region ".:: PROPIEDADES ::."

        [DataMember]
        public long UsuarioID { get; set; }

        [DataMember]
        public long EmpresaID { get; set; }

        [DataMember]
        public long OrganizacionID { get; set; }

        [DataMember]
        public long TerceroID { get; set; }

        [DataMember]
        public long ContactoID { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Telefono { get; set; }

        [DataMember]
        public string Movil { get; set; }

        [DataMember]
        public string UserPin { get; set; }

        [DataMember]
        public DateTime FechaCreacion { get; set; }

        [DataMember]
        public DateTime FechaUltimoAcceso { get; set; }

        [DataMember]
        public bool Activo { get; set; }

        [DataMember]
        public long PerfilID { get; set; }


        [DataMember]
        public string Organizacion { get; set; }

        [DataMember]
        public string Tercero { get; set; }

        [DataMember]
        public string Contacto { get; set; }

        [DataMember]
        public string Perfil { get; set; }

        #endregion

        #region ".:: CONSTRUCTORES ::."

        public UsuarioBDO()
        {
            UsuarioID = 0;
            EmpresaID = 0;
            OrganizacionID = 0;
            TerceroID = 0;
            ContactoID = 0;
            UserName = null;
            Password = null;
            Email = null;
            Telefono = null;
            Movil = null;
            UserPin = null;
            FechaCreacion = new DateTime();
            FechaUltimoAcceso = new DateTime();
            Activo = true;
            PerfilID = 0;

            Organizacion = null;
            Tercero = null;
            Contacto = null;
            Perfil = null;
        }

        public UsuarioBDO(DataRow _DataRow)
        {
            UsuarioID = Convert.ToInt64((_DataRow["UsuarioID"] == System.DBNull.Value ? 0 : _DataRow["UsuarioID"]));
            EmpresaID = Convert.ToInt64((_DataRow["ClienteID"] == System.DBNull.Value ? 0 : _DataRow["ClienteID"]));

            OrganizacionID = Convert.ToInt64((_DataRow["OrganizacionID"] == System.DBNull.Value ? 0 : _DataRow["OrganizacionID"]));
            Organizacion = Convert.ToString((_DataRow["Organizacion"] == System.DBNull.Value ? 0 : _DataRow["Organizacion"]));

            TerceroID = Convert.ToInt64((_DataRow["TerceroID"] == System.DBNull.Value ? 0 : _DataRow["TerceroID"]));
            Tercero = Convert.ToString((_DataRow["Tercero"] == System.DBNull.Value ? 0 : _DataRow["Tercero"]));

            ContactoID = Convert.ToInt64((_DataRow["ContactoID"] == System.DBNull.Value ? 0 : _DataRow["ContactoID"]));
            Contacto = Convert.ToString((_DataRow["Contacto"] == System.DBNull.Value ? 0 : _DataRow["Contacto"]));

            UserName = Convert.ToString((_DataRow["UserName"] == System.DBNull.Value ? String.Empty : _DataRow["UserName"]));
            Password = Convert.ToString((_DataRow["Password"] == System.DBNull.Value ? String.Empty : _DataRow["Password"]));
            Email = Convert.ToString((_DataRow["Email"] == System.DBNull.Value ? String.Empty : _DataRow["Email"]));
            Telefono = Convert.ToString((_DataRow["Telefono"] == System.DBNull.Value ? String.Empty : _DataRow["Telefono"]));
            Movil = Convert.ToString((_DataRow["Movil"] == System.DBNull.Value ? String.Empty : _DataRow["Movil"]));
            UserPin = Convert.ToString((_DataRow["UserPin"] == System.DBNull.Value ? String.Empty : _DataRow["UserPin"]));
            FechaCreacion = Convert.ToDateTime((_DataRow["FechaCreacion"] == System.DBNull.Value ? new DateTime() : _DataRow["FechaCreacion"]));
            FechaUltimoAcceso = Convert.ToDateTime((_DataRow["FechaUltimoAcceso"] == System.DBNull.Value ? new DateTime() : _DataRow["FechaUltimoAcceso"]));
            Activo = Convert.ToBoolean((_DataRow["Activo"]));

            PerfilID = Convert.ToInt64((_DataRow["PerfilID"] == System.DBNull.Value ? 0 : _DataRow["PerfilID"]));
            Perfil = Convert.ToString((_DataRow["Perfil"] == System.DBNull.Value ? 0 : _DataRow["Perfil"]));

        }

        #endregion

    }
}
