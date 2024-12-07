
using System.Data;
using System.Collections.Generic;


using CulturApp.BDO.GestionDatosMaestros;
using CulturApp.DAL.GestionDatosMaestros;

namespace CulturApp.BLL.GestionDatosMaestros
{

    /// <summary>
    /// InfoProyecto.
    /// </summary>
    public class InfoProyectoBLL
    {

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public List<InfoProyectoBDO> GetAll(InfoProyectoBDO InfoProyectoBdo)
        {
            InfoProyectoDAL InfoProyectoDal = new();
            List<InfoProyectoBDO> _List = new();

            DataTable _DataTable = InfoProyectoDal.GetAll(InfoProyectoBdo);

            foreach (DataRow _DataRows in _DataTable.Rows)
            {
                _List.Add(new InfoProyectoBDO(_DataRows));
            }

            return _List;
        }

        /// <summary>
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public InfoProyectoBDO GetByID(long InfoProyectoID)
        {
            InfoProyectoBDO InfoProyectoBdo = new();
            InfoProyectoDAL InfoProyectoDal = new();
            DataTable _DataTable = InfoProyectoDal.GetByID(InfoProyectoID);
            if (_DataTable.Rows.Count > 0)
            {
                InfoProyectoBdo = new(_DataTable.Rows[0]);
            }

            return InfoProyectoBdo;
        }

        /// <summary>
        ///Agrega un nuevo registro.
        /// </summary>
        /// <returns></returns>
        public int Add(InfoProyectoBDO InfoProyectoBdo)
        {
            InfoProyectoDAL InfoProyectoDal = new();
            return InfoProyectoDal.Add(InfoProyectoBdo);
        }

        /// <summary>
        ///Actualiza un registro.
        /// </summary>
        /// <returns></returns>
        public bool Update(InfoProyectoBDO InfoProyectoBdo)
        {
            InfoProyectoDAL InfoProyectoDal = new();
            return InfoProyectoDal.Update(InfoProyectoBdo);
        }

        /// <summary>
        ///Elimina un registro.
        /// </summary>
        /// <returns></returns>
        public bool Delete(long InfoProyectoID)
        {
            InfoProyectoDAL InfoProyectoDal = new();
            return InfoProyectoDal.Delete(InfoProyectoID);
        }
    }
}

