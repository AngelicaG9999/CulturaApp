
using System.Data;
using System.Collections.Generic;


using CulturApp.BDO.GestionDatosMaestros;
using CulturApp.DAL.GestionDatosMaestros;

namespace CulturApp.BLL.GestionDatosMaestros
{

    /// <summary>
    /// Area.
    /// </summary>
    public class AreaBLL
    {

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public List<AreaBDO> GetAll(AreaBDO AreaBdo)
        {
            AreaDAL AreaDal = new();
            List<AreaBDO> _List = new();

            DataTable _DataTable = AreaDal.GetAll(AreaBdo);

            foreach (DataRow _DataRows in _DataTable.Rows)
            {
                _List.Add(new AreaBDO(_DataRows));
            }

            return _List;
        }

        /// <summary>
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public AreaBDO GetByID(long AreaID)
        {
            AreaBDO AreaBdo = new();
            AreaDAL AreaDal = new();
            DataTable _DataTable = AreaDal.GetByID(AreaID);
            if (_DataTable.Rows.Count > 0)
            {
                AreaBdo = new(_DataTable.Rows[0]);
            }

            return AreaBdo;
        }

        /// <summary>
        ///Agrega un nuevo registro.
        /// </summary>
        /// <returns></returns>
        public int Add(AreaBDO AreaBdo)
        {
            AreaDAL AreaDal = new();
            return AreaDal.Add(AreaBdo);
        }

        /// <summary>
        ///Actualiza un registro.
        /// </summary>
        /// <returns></returns>
        public bool Update(AreaBDO AreaBdo)
        {
            AreaDAL AreaDal = new();
            return AreaDal.Update(AreaBdo);
        }

        /// <summary>
        ///Elimina un registro.
        /// </summary>
        /// <returns></returns>
        public bool Delete(long AreaID)
        {
            AreaDAL AreaDal = new();
            return AreaDal.Delete(AreaID);
        }
    }
}

