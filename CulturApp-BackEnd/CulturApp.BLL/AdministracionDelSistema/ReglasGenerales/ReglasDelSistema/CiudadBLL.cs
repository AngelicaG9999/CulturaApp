
using CulturApp.BDO.AdministracionDelSistema.ReglasGenerales.ReglasDelSistema;
using CulturApp.DAL.AdministracionDelSistema.ReglasGenerales.ReglasDelSistema;
using System.Collections.Generic;
using System.Data;

namespace CulturApp.BLL.AdministracionDelSistema.ReglasGenerales.ReglasDelSistema
{

    /// <summary>
    /// Ciudad.
    /// </summary>
    public class CiudadBLL
    {

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public List<CiudadBDO> GetAll(CiudadBDO CiudadBDO)
        {
            CiudadDAL CiudadDAL = new();
            List<CiudadBDO> _List = new();
            DataTable dataTable;
            dataTable = CiudadDAL.GetAll(CiudadBDO);
            foreach (DataRow _DataRows in dataTable.Rows)
            {
                _List.Add(new CiudadBDO(_DataRows));
            }

            return _List;
        }

        /// <summary>
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public DataTable GetByID(int CiudadID)
        {
            CiudadDAL CiudadDAL = new CiudadDAL();
            return CiudadDAL.GetByID(CiudadID);
        }

        /// <summary>
        ///Agrega un nuevo registro.
        /// </summary>
        /// <returns></returns>
        public int Add(CiudadBDO CiudadBDO)
        {
            CiudadDAL CiudadDAL = new CiudadDAL();
            return CiudadDAL.Add(CiudadBDO);
        }

        /// <summary>
        ///Actualiza un registro.
        /// </summary>
        /// <returns></returns>
        public bool Update(CiudadBDO CiudadBDO)
        {
            CiudadDAL CiudadDAL = new CiudadDAL();
            return CiudadDAL.Update(CiudadBDO);
        }

        /// <summary>
        ///Elimina un registro.
        /// </summary>
        /// <returns></returns>
        public bool Delete(int CiudadID)
        {
            CiudadDAL CiudadDAL = new CiudadDAL();
            return CiudadDAL.Delete(CiudadID);
        }
    }
}
