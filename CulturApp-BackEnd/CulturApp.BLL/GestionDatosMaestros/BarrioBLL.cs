using System.Data;
using System.Collections.Generic;
using CulturApp.BDO.GestionDatosMaestros;
using CulturApp.DAL.GestionDatosMaestros;

namespace CulturApp.BLL.GestionDatosMaestros
{
    /// <summary>
    /// Barrio.
    /// </summary>
    /// 
    public class BarrioBLL
    {
        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>

        public List<BarrioBDO> GetAll(BarrioBDO BarrioBdo)
        {
            BarrioDAL BarrioDal = new();
            List<BarrioBDO> _List = new();

            DataTable _DataTable = BarrioDal.GetAll(BarrioBdo);

            foreach (DataRow _DataRows in _DataTable.Rows)
            {
                _List.Add(new BarrioBDO(_DataRows));
            }

            return _List;
        }

        /// <summary>
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public BarrioBDO GetByID(long BarrioID)
        {
            BarrioBDO BarrioBdo = new();
            BarrioDAL BarrioDal = new();
            DataTable _DataTable = BarrioDal.GetByID(BarrioID);
            if (_DataTable.Rows.Count > 0)
            {
                BarrioBdo = new(_DataTable.Rows[0]);
            }

            return BarrioBdo;
        }

        /// <summary>
        ///Agrega un nuevo registro.
        /// </summary>
        /// <returns></returns>
        public int Add(BarrioBDO BarrioBdo)
        {
            BarrioDAL BarrioDal = new();
            return BarrioDal.Add(BarrioBdo);
        }

        /// <summary>
        ///Actualiza un registro.
        /// </summary>
        /// <returns></returns>
        public bool Update(BarrioBDO BarrioBdo)
        {
            BarrioDAL BarrioDal = new();
            return BarrioDal.Update(BarrioBdo);
        }

        /// <summary>
        ///Elimina un registro.
        /// </summary>
        /// <returns></returns>
        public bool Delete(long BarrioID)
        {
            BarrioDAL BarrioDal = new();
            return BarrioDal.Delete(BarrioID);
        }
    }
}
