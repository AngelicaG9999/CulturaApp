
using CulturApp.BDO.AdministracionDelSistema.ReglasGenerales.Seguridad;
using CulturApp.BDO.AdministracionDelSistema.ReglasGrupoEmpresarial;
using CulturApp.BLL.AdministracionDelSistema.ReglasGrupoEmpresarial;
using CulturApp.DAL.AdministracionDelSistema.ReglasGenerales.Seguridad;
using CulturApp.Utility.Seguridad.Criptografia;
using System;
using System.Collections.Generic;
using System.Data;

namespace CulturApp.BLL.AdministracionDelSistema.ReglasGenerales.Seguridad
{

    /// <summary>
    /// Usuario.
    /// </summary>
    public class UsuarioBLL
    {

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public List<UsuarioBDO> GetAll(UsuarioBDO UsuarioBdo)
        {
            UsuarioDAL UsuarioDAL = new();
            List<UsuarioBDO> _List = new();
            DataTable _DataTable;

            _DataTable = UsuarioDAL.GetAll(UsuarioBdo);

            foreach (DataRow _DataRows in _DataTable.Rows)
            {
                _List.Add(new UsuarioBDO(_DataRows));
            }

            return _List;
        }

        /// <summary>
        /// Retorna los datos del usuario por enpresa, username y password
        /// </summary>
        /// <param name="Empresa">C�digo de la empresa</param>
        /// <param name="UserName">Nombre de usuario</param>
        /// <param name="Password">Password</param>
        /// <returns></returns>
        public DataSessionBDO GetByUserNameAndPassword(string Empresa, string UserName, string Password)
        {
            DataTable dataTable;

            EmpresaBLL empresaBll = new();
            EmpresaBDO empresaBdo;

            UsuarioDAL usuarioDal = new();
            UsuarioBDO usuarioBdo;
            DataSessionBDO dataSessionBdo = new();

            DCEncriptar Cripto = new();

            //Se busca la empresa por el codigo
            dataTable = new DataTable();
            dataTable = empresaBll.GetByCodigo(Empresa);

            //Si no se encuentra la empresa se determina acceso denegado
            if (dataTable.Rows.Count == 0)
            {
                dataSessionBdo.Acceso = false;
                return dataSessionBdo;
            }
            empresaBdo = new EmpresaBDO(dataTable.Rows[0]);

            //Codigo de la empresa
            string Key = empresaBdo.Codigo;

            //Creamos el valor SHA512 del Password
            string SHA512 = Cripto.Encriptar(Password, DCEncriptar.AlgoritmoEncriptacion.SHA512, Key);

            //Se busca el usuario
            dataTable = new DataTable();
            dataTable = usuarioDal.GetByUserNameAndPassword(Empresa, UserName, SHA512);

            if (dataTable.Rows.Count == 0)
            {
                dataSessionBdo.Acceso = false;
                return dataSessionBdo;
            }

            usuarioBdo = new UsuarioBDO(dataTable.Rows[0]);
            dataSessionBdo.Acceso = true;

            if (dataSessionBdo.Acceso == true)
            {
                dataSessionBdo.EmpresaID = empresaBdo.EmpresaID;
                dataSessionBdo.Empresa = empresaBdo.Nombre;
                dataSessionBdo.OrganizacionID = usuarioBdo.OrganizacionID;
                dataSessionBdo.Organizacion = usuarioBdo.Organizacion;
                dataSessionBdo.TerceroID = usuarioBdo.TerceroID;
                dataSessionBdo.UsuarioID = usuarioBdo.UsuarioID;
                dataSessionBdo.Ip = "0.0.0.0";
                dataSessionBdo.UserName = UserName;
                dataSessionBdo.CodEmpresa = Empresa;
                dataSessionBdo.Fecha = DateTime.Today;
                dataSessionBdo.Imprerora = string.Empty;
                dataSessionBdo.Activo = usuarioBdo.Activo;
                dataSessionBdo.Skin = string.Empty;
                dataSessionBdo.Abreviatura = string.Empty;
                dataSessionBdo.NombreCompleto = usuarioBdo.Tercero;


            }

            return dataSessionBdo;
        }

        /// <summary>
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public UsuarioBDO GetByID(long UsuarioID)
        {
            UsuarioBDO UsuarioBdo = new();
            UsuarioDAL UsuarioDAL = new();
            DataTable _DataTable;

            _DataTable = UsuarioDAL.GetByID(UsuarioID);
            if (_DataTable.Rows.Count > 0)
            {
                UsuarioBdo = new(_DataTable.Rows[0]);
            }

            return UsuarioBdo;
        }

        /// <summary>
        ///Actualiza un registro.
        /// </summary>
        /// <returns></returns>
        public bool Update(UsuarioBDO UsuarioBDO)
        {
            UsuarioDAL UsuarioDAL = new UsuarioDAL();
            return UsuarioDAL.Update(UsuarioBDO);
        }

    }
}
