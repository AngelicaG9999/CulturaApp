
using CulturApp.BDO.AdministracionDelSistema.ReglasGrupoEmpresarial;
using CulturApp.DAL.AdministracionDelSistema.ReglasGrupoEmpresarial;
using System.Collections.Generic;
using System.Data;

namespace CulturApp.BLL.AdministracionDelSistema.ReglasGrupoEmpresarial
{

    /// <summary>
    /// Menu.
    /// </summary>
    public class MenuBLL
    {

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(string UserName, string Codigo)
        {
            MenuDAL MenuDAL = new MenuDAL();
            return MenuDAL.GetAll(UserName, Codigo);
        }

        public DataTable GetByPadre(long PadreID, long EmpresaID, long PerfilID)
        {
            MenuDAL MenuDAL = new MenuDAL();
            return MenuDAL.GetByPadre(PadreID, EmpresaID, PerfilID);
        }

        public List<MenuBDO> GetByPadreToList(long PadreID, long EmpresaID, long PerfilID)
        {
            List<MenuBDO> _List = new List<MenuBDO>();
            DataTable _DataTable = new DataTable();

            _DataTable = GetByPadre(PadreID, EmpresaID, PerfilID);

            foreach (DataRow _DataRows in _DataTable.Rows)
            {
                _List.Add(new MenuBDO(_DataRows));
            }

            return _List;
        }

        /// <summary>
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public DataTable GetByID(MenuBDO MenuBDO)
        {
            MenuDAL MenuDAL = new MenuDAL();
            return MenuDAL.GetByID(MenuBDO);
        }
        
    }
}
