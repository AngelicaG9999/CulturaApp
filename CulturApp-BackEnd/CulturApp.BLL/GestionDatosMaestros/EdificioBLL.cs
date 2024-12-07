using System.Data;
using System.Collections.Generic;
using CulturApp.BDO.GestionDatosMaestros;
using CulturApp.DAL.GestionDatosMaestros;

namespace CulturApp.BLL.GestionDatosMaestros
{
    /// <summary>
    /// Edificio.
    /// </summary>
    /// 
    public class EdificioBLL
    {

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public List<EdificioBDO> GetAll(EdificioBDO EdificioBdo)
        {
            EdificioDAL EdificioDal = new();
            List<EdificioBDO> _List = new();

            DataTable _DataTable = EdificioDal.GetAll(EdificioBdo);

            foreach (DataRow _DataRows in _DataTable.Rows)
            {
                _List.Add(new EdificioBDO(_DataRows));
            }

            return _List;
        }

        /// <summary>
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public EdificioBDO GetByID(long EdificioID)
        {
            EdificioBDO EdificioBdo = new();
            EdificioDAL EdificioDal = new();
            DataTable _DataTable = EdificioDal.GetByID(EdificioID);
            if (_DataTable.Rows.Count > 0)
            {
                EdificioBdo = new(_DataTable.Rows[0]);
            }

            return EdificioBdo;
        }

        /// <summary>
        ///Agrega un nuevo registro.
        /// </summary>
        /// <returns></returns>
        public int Add(EdificioBDO EdificioBdo)
        {
            EdificioDAL EdificioDal = new();
            return EdificioDal.Add(EdificioBdo);
        }

        /// <summary>
        ///Actualiza un registro.
        /// </summary>
        /// <returns></returns>
        public bool Update(EdificioBDO EdificioBdo)
        {
            EdificioDAL EdificioDal = new();
            return EdificioDal.Update(EdificioBdo);
        }

        /// <summary>
        ///Elimina un registro.
        /// </summary>
        /// <returns></returns>
        public bool Delete(long EdificioID)
        {
            EdificioDAL EdificioDal = new();
            return EdificioDal.Delete(EdificioID);
        }
    }

}
