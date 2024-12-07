
using System.Data;
using System.Collections.Generic;


using CulturApp.BDO.GestionDatosMaestros;
using CulturApp.DAL.GestionDatosMaestros;

namespace CulturApp.BLL.GestionDatosMaestros
{

    /// <summary>
    /// InfoRepresentante.
    /// </summary>
    public class InfoRepresentanteBLL
    {

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public List<InfoRepresentanteBDO> GetAll(InfoRepresentanteBDO InfoRepresentanteBdo)
        {
            InfoRepresentanteDAL InfoRepresentanteDal = new();
            List<InfoRepresentanteBDO> _List = new();

            DataTable _DataTable = InfoRepresentanteDal.GetAll(InfoRepresentanteBdo);

            foreach (DataRow _DataRows in _DataTable.Rows)
            {
                _List.Add(new InfoRepresentanteBDO(_DataRows));
            }

            return _List;
        }

        /// <summary>
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public InfoRepresentanteBDO GetByID(long InfoRepresentanteID)
        {
            InfoRepresentanteBDO InfoRepresentanteBdo = new();
            InfoRepresentanteDAL InfoRepresentanteDal = new();
            DataTable _DataTable = InfoRepresentanteDal.GetByID(InfoRepresentanteID);
            if (_DataTable.Rows.Count > 0)
            {
                InfoRepresentanteBdo = new(_DataTable.Rows[0]);
            }

            return InfoRepresentanteBdo;
        }

        /// <summary>
        ///Agrega un nuevo registro.
        /// </summary>
        /// <returns></returns>
        public int Add(InfoRepresentanteBDO InfoRepresentanteBdo)
        {
            InfoRepresentanteDAL InfoRepresentanteDal = new();
            return InfoRepresentanteDal.Add(InfoRepresentanteBdo);
        }

        /// <summary>
        ///Actualiza un registro.
        /// </summary>
        /// <returns></returns>
        public bool Update(InfoRepresentanteBDO InfoRepresentanteBdo)
        {
            InfoRepresentanteDAL InfoRepresentanteDal = new();
            return InfoRepresentanteDal.Update(InfoRepresentanteBdo);
        }

        /// <summary>
        ///Elimina un registro.
        /// </summary>
        /// <returns></returns>
        public bool Delete(long InfoRepresentanteID)
        {
            InfoRepresentanteDAL InfoRepresentanteDal = new();
            return InfoRepresentanteDal.Delete(InfoRepresentanteID);
        }
    }
}

