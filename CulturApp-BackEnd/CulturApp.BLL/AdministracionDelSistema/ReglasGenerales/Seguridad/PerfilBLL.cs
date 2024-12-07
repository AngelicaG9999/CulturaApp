
using CulturApp.BDO.AdministracionDelSistema.ReglasGenerales.Seguridad;
using CulturApp.DAL.AdministracionDelSistema.ReglasGenerales.Seguridad;
using System.Collections.Generic;
using System.Data;

namespace CulturApp.BLL.AdministracionDelSistema.ReglasGenerales.Seguridad
{

    /// <summary>
    /// Perfil.
    /// </summary>
    public class PerfilBLL
    {

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(PerfilBDO PerfilBDO)
        {
            PerfilDAL PerfilDAL = new PerfilDAL();
            return PerfilDAL.GetAll(PerfilBDO);
        }

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public List<PerfilBDO> GetAllToList(PerfilBDO PerfilBDO)
        {
            List<PerfilBDO> _List = new List<PerfilBDO>();
            DataTable _DataTable = new DataTable();

            _DataTable = GetAll(PerfilBDO);

            foreach (DataRow _DataRows in _DataTable.Rows)
            {
                _List.Add(new PerfilBDO(_DataRows));
            }

            return _List;
        }

        /// <summary>
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public DataTable GetByID(long PerfilID)
        {
            PerfilDAL PerfilDAL = new PerfilDAL();
            return PerfilDAL.GetByID(PerfilID);
        }

        /// <summary>
        /// Retorna el men�
        /// </summary>
        /// <param name="UserName">Nombre de usuario</param>
        /// <returns></returns>
        public DataTable GetMenu(string UserName)
        {
            PerfilDAL PerfilDAL = new PerfilDAL();
            return PerfilDAL.GetMenu(UserName);
        }

        /// <summary>
        ///Agrega un nuevo registro.
        /// </summary>
        /// <returns></returns>
        public int Add(PerfilBDO PerfilBDO)
        {
            PerfilDAL PerfilDAL = new PerfilDAL();
            return PerfilDAL.Add(PerfilBDO);
        }

        /// <summary>
        ///Actualiza un registro.
        /// </summary>
        /// <returns></returns>
        public bool Update(PerfilBDO PerfilBDO)
        {
            PerfilDAL PerfilDAL = new PerfilDAL();
            return PerfilDAL.Update(PerfilBDO);
        }

        /// <summary>
        ///Elimina un registro.
        /// </summary>
        /// <returns></returns>
        public bool Delete(long PerfilID)
        {
            PerfilDAL PerfilDAL = new PerfilDAL();
            return PerfilDAL.Delete(PerfilID);
        }

        /// <summary>
        ///Asigna los permisos.
        /// </summary>
        /// <returns></returns>
        public bool SetAutorizacion(long PadreID, long EmpresaID, long PerfilID, long AutorizacionID)
        {
            PerfilDAL PerfilDAL = new PerfilDAL();
            return PerfilDAL.SetAutorizacion(PadreID, EmpresaID, PerfilID, AutorizacionID);
        }

    }
}
