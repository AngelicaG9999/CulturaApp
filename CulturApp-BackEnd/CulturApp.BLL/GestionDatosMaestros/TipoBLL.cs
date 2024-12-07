
using System.Data;
using System.Collections.Generic;


using CulturApp.BDO.GestionDatosMaestros;
using CulturApp.DAL.GestionDatosMaestros;

namespace CulturApp.BLL.GestionDatosMaestros
{

    /// <summary>
    /// Tipo.
    /// </summary>
    public class TipoBLL
    {

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public List<TipoBDO> GetAll(TipoBDO TipoBdo)
        {
            TipoDAL TipoDal = new();
            List<TipoBDO> _List = new();

            DataTable _DataTable = TipoDal.GetAll(TipoBdo);

            foreach (DataRow _DataRows in _DataTable.Rows)
            {
                _List.Add(new TipoBDO(_DataRows));
            }

            return _List;
        }

        /// <summary>
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public TipoBDO GetByID(long TipoID)
        {
            TipoBDO TipoBdo = new();
            TipoDAL TipoDal = new();
            DataTable _DataTable = TipoDal.GetByID(TipoID);
            if (_DataTable.Rows.Count > 0)
            {
                TipoBdo = new(_DataTable.Rows[0]);
            }

            return TipoBdo;
        }

        /// <summary>
        ///Agrega un nuevo registro.
        /// </summary>
        /// <returns></returns>
        public int Add(TipoBDO TipoBdo)
        {
            TipoDAL TipoDal = new();
            return TipoDal.Add(TipoBdo);
        }

        /// <summary>
        ///Actualiza un registro.
        /// </summary>
        /// <returns></returns>
        public bool Update(TipoBDO TipoBdo)
        {
            TipoDAL TipoDal = new();
            return TipoDal.Update(TipoBdo);
        }

        /// <summary>
        ///Elimina un registro.
        /// </summary>
        /// <returns></returns>
        public bool Delete(long TipoID)
        {
            TipoDAL TipoDal = new();
            return TipoDal.Delete(TipoID);
        }
    }

}

