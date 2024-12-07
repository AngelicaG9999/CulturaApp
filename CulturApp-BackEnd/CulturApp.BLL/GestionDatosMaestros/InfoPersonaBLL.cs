
using CulturApp.BDO.GestionDatosMaestros;
using CulturApp.DAL.GestionDatosMaestros;
using System.Collections.Generic;
using System.Data;

namespace CulturApp.BLL.GestionDatosMaestros
{

    /// <summary>
    /// InfoPersona.
    /// </summary>
    public class InfoPersonaBLL
    {

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public List<InfoPersonaBDO> GetAll(InfoPersonaBDO InfoPersonaBdo)
        {
            InfoPersonaDAL InfoPersonaDal = new();
            List<InfoPersonaBDO> _List = new();

            DataTable _DataTable = InfoPersonaDal.GetAll(InfoPersonaBdo);

            foreach (DataRow _DataRows in _DataTable.Rows)
            {
                _List.Add(new InfoPersonaBDO(_DataRows));
            }

            return _List;
        }

        /// <summary>
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public InfoPersonaBDO GetByID(long InfoPersonaID)
        {
            InfoPersonaBDO InfoPersonaBdo = new();
            InfoPersonaDAL InfoPersonaDal = new();
            DataTable _DataTable = InfoPersonaDal.GetByID(InfoPersonaID);
            if (_DataTable.Rows.Count > 0)
            {
                InfoPersonaBdo = new(_DataTable.Rows[0]);
            }

            return InfoPersonaBdo;
        }

        /// <summary>
        ///Agrega un nuevo registro.
        /// </summary>
        /// <returns></returns>
        public int Add(InfoPersonaBDO InfoPersonaBdo)
        {
            InfoPersonaDAL InfoPersonaDal = new();
            return InfoPersonaDal.Add(InfoPersonaBdo);
        }

        /// <summary>
        ///Actualiza un registro.
        /// </summary>
        /// <returns></returns>
        public bool Update(InfoPersonaBDO InfoPersonaBdo)
        {
            InfoPersonaDAL InfoPersonaDal = new();
            return InfoPersonaDal.Update(InfoPersonaBdo);
        }

        /// <summary>
        ///Elimina un registro.
        /// </summary>
        /// <returns></returns>
        public bool Delete(long InfoPersonaID)
        {
            InfoPersonaDAL InfoPersonaDal = new();
            return InfoPersonaDal.Delete(InfoPersonaID);
        }
    }
}

