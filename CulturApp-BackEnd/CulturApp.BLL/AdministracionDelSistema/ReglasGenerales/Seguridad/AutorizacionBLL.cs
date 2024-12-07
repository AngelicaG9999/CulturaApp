
using System.Collections.Generic;
using System.Data;
using CulturApp.BDO.AdministracionDelSistema.ReglasGenerales.Seguridad;
using CulturApp.DAL.AdministracionDelSistema.ReglasGenerales.Seguridad;

namespace CulturApp.BLL.AdministracionDelSistema.ReglasGenerales.Seguridad
{

    /// <summary>
    /// Autorizacion.
    /// </summary>
    public class AutorizacionBLL
    {

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(AutorizacionBDO AutorizacionBDO)
        {
            AutorizacionDAL AutorizacionDAL = new AutorizacionDAL();
            return AutorizacionDAL.GetAll(AutorizacionBDO);
        }

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public List<AutorizacionBDO> GetAllToList(AutorizacionBDO AutorizacionBDO)
        {
            List<AutorizacionBDO> _List = new List<AutorizacionBDO>();
            DataTable _DataTable = new DataTable();

            _DataTable = GetAll(AutorizacionBDO);

            foreach (DataRow _DataRows in _DataTable.Rows)
            {
                _List.Add(new AutorizacionBDO(_DataRows));
            }

            return _List;
        }

        /// <summary>
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public DataTable GetByID(long AutorizacionID)
        {
            AutorizacionDAL AutorizacionDAL = new AutorizacionDAL();
            return AutorizacionDAL.GetByID(AutorizacionID);
        }

        /// <summary>
        ///Agrega un nuevo registro.
        /// </summary>
        /// <returns></returns>
        public int Add(AutorizacionBDO AutorizacionBDO)
        {
            AutorizacionDAL AutorizacionDAL = new AutorizacionDAL();
            return AutorizacionDAL.Add(AutorizacionBDO);
        }

        /// <summary>
        ///Actualiza un registro.
        /// </summary>
        /// <returns></returns>
        public bool Update(AutorizacionBDO AutorizacionBDO)
        {
            AutorizacionDAL AutorizacionDAL = new AutorizacionDAL();
            return AutorizacionDAL.Update(AutorizacionBDO);
        }

        /// <summary>
        ///Elimina un registro.
        /// </summary>
        /// <returns></returns>
        public bool Delete(long AutorizacionID)
        {
            AutorizacionDAL AutorizacionDAL = new AutorizacionDAL();
            return AutorizacionDAL.Delete(AutorizacionID);
        }
    }
}

