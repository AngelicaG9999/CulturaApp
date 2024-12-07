
using System.Data;
using System.Collections.Generic;


using CulturApp.BDO.GestionDatosMaestros;
using CulturApp.DAL.GestionDatosMaestros;

namespace CulturApp.BLL.GestionDatosMaestros
{

    /// <summary>
    /// Linea.
    /// </summary>
    public class LineaBLL
    {

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public List<LineaBDO> GetAll(LineaBDO LineaBdo)
        {
            LineaDAL LineaDal = new();
            List<LineaBDO> _List = new();

            DataTable _DataTable = LineaDal.GetAll(LineaBdo);

            foreach (DataRow _DataRows in _DataTable.Rows)
            {
                _List.Add(new LineaBDO(_DataRows));
            }

            return _List;
        }

        /// <summary>
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public LineaBDO GetByID(long LineaID)
        {
            LineaBDO LineaBdo = new();
            LineaDAL LineaDal = new();
            DataTable _DataTable = LineaDal.GetByID(LineaID);
            if (_DataTable.Rows.Count > 0)
            {
                LineaBdo = new(_DataTable.Rows[0]);
            }

            return LineaBdo;
        }

        /// <summary>
        ///Agrega un nuevo registro.
        /// </summary>
        /// <returns></returns>
        public int Add(LineaBDO LineaBdo)
        {
            LineaDAL LineaDal = new();
            return LineaDal.Add(LineaBdo);
        }

        /// <summary>
        ///Actualiza un registro.
        /// </summary>
        /// <returns></returns>
        public bool Update(LineaBDO LineaBdo)
        {
            LineaDAL LineaDal = new();
            return LineaDal.Update(LineaBdo);
        }

        /// <summary>
        ///Elimina un registro.
        /// </summary>
        /// <returns></returns>
        public bool Delete(long LineaID)
        {
            LineaDAL LineaDal = new();
            return LineaDal.Delete(LineaID);
        }
    }

}

