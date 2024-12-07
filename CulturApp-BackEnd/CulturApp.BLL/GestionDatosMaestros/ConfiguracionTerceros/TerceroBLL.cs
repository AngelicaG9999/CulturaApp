using CulturApp.BDO.GestionDatosMaestros.ConfiguracionTerceros;
using CulturApp.DAL.GestionDatosMaestros.ConfiguracionTerceros;
using System.Collections.Generic;
using System.Data;

namespace CulturApp.BLL.GestionDatosMaestros.ConfiguracionTerceros
{

    /// <summary>
    /// Tercero.
    /// </summary>
    public class TerceroBLL
    {

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(TerceroBDO TerceroBDO)
        {
            TerceroDAL TerceroDAL = new TerceroDAL();
            return TerceroDAL.GetAll(TerceroBDO);
        }

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public List<TerceroBDO> GetAllToList(TerceroBDO TerceroBDO)
        {
            List<TerceroBDO> _List = new List<TerceroBDO>();
            DataTable _DataTable = new DataTable();

            _DataTable = GetAll(TerceroBDO);

            foreach (DataRow _DataRows in _DataTable.Rows)
            {
                _List.Add(new TerceroBDO(_DataRows));
            }

            return _List;
        }

        /// <summary>
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public DataTable GetByID(long TerceroID)
        {
            TerceroDAL TerceroDAL = new TerceroDAL();
            return TerceroDAL.GetByID(TerceroID);
        }

        /// <summary>
        ///Agrega un nuevo registro.
        /// </summary>
        /// <returns></returns>
        public int Add(TerceroBDO TerceroBDO)
        {
            TerceroDAL TerceroDAL = new TerceroDAL();
            return TerceroDAL.Add(TerceroBDO);
        }

        /// <summary>
        ///Actualiza un registro.
        /// </summary>
        /// <returns></returns>
        public bool Update(TerceroBDO TerceroBDO)
        {
            TerceroDAL TerceroDAL = new TerceroDAL();
            return TerceroDAL.Update(TerceroBDO);
        }

        /// <summary>
        ///Elimina un registro.
        /// </summary>
        /// <returns></returns>
        public bool Delete(long TerceroID)
        {
            TerceroDAL TerceroDAL = new TerceroDAL();
            return TerceroDAL.Delete(TerceroID);
        }
    }
}
