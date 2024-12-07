
using System.Data;
using System.Collections.Generic;

using CulturApp.BDO.GestionDatosMaestros;
using CulturApp.DAL.GestionDatosMaestros;

namespace CulturApp.BLL.GestionDatosMaestros
{
    /// <summary>
    /// Comuna.
    /// </summary>
    /// 
    public class ComunaBLL
    {
        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public List<ComunaBDO> GetAll(ComunaBDO ComunaBdo)
        {
            ComunaDAL ComunaDal = new();
            List<ComunaBDO> _List = new();

            DataTable _DataTable = ComunaDal.GetAll(ComunaBdo);

            foreach (DataRow _DataRows in _DataTable.Rows)
            {
                _List.Add(new ComunaBDO(_DataRows));
            }

            return _List;
        }

        /// <summary>
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public ComunaBDO GetByID(long ComunaID)
        {
            ComunaBDO ComunaBdo = new();
            ComunaDAL ComunaDal = new();
            DataTable _DataTable = ComunaDal.GetByID(ComunaID);
            if (_DataTable.Rows.Count > 0)
            {
                ComunaBdo = new(_DataTable.Rows[0]);
            }

            return ComunaBdo;
        }

        /// <summary>
        ///Agrega un nuevo registro.
        /// </summary>
        /// <returns></returns>
        public int Add(ComunaBDO ComunaBdo)
        {
            ComunaDAL ComunaDal = new();
            return ComunaDal.Add(ComunaBdo);
        }

        /// <summary>
        ///Actualiza un registro.
        /// </summary>
        /// <returns></returns>
        public bool Update(ComunaBDO ComunaBdo)
        {
            ComunaDAL ComunaDal = new();
            return ComunaDal.Update(ComunaBdo);
        }

        /// <summary>
        ///Elimina un registro.
        /// </summary>
        /// <returns></returns>
        public bool Delete(long ComunaID)
        {
            ComunaDAL ComunaDal = new();
            return ComunaDal.Delete(ComunaID);
        }
    }
}



