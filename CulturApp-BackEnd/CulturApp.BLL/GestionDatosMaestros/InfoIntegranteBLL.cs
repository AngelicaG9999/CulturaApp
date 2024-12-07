
using CulturApp.BDO.GestionDatosMaestros;
using CulturApp.DAL.GestionDatosMaestros;
using System.Collections.Generic;
using System.Data;

namespace CulturApp.BLL.GestionDatosMaestros
{

    /// <summary>
    /// InfoIntegrante.
    /// </summary>
    public class InfoIntegranteBLL
    {

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public List<InfoIntegranteBDO> GetAll(InfoIntegranteBDO InfoIntegranteBdo)
        {
            InfoIntegranteDAL InfoIntegranteDal = new();
            List<InfoIntegranteBDO> _List = new();

            DataTable _DataTable = InfoIntegranteDal.GetAll(InfoIntegranteBdo);

            foreach (DataRow _DataRows in _DataTable.Rows)
            {
                _List.Add(new InfoIntegranteBDO(_DataRows));
            }

            return _List;
        }

        /// <summary>
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public InfoIntegranteBDO GetByID(long InfoIntegranteID)
        {
            InfoIntegranteBDO InfoIntegranteBdo = new();
            InfoIntegranteDAL InfoIntegranteDal = new();
            DataTable _DataTable = InfoIntegranteDal.GetByID(InfoIntegranteID);
            if (_DataTable.Rows.Count > 0)
            {
                InfoIntegranteBdo = new(_DataTable.Rows[0]);
            }

            return InfoIntegranteBdo;
        }

        /// <summary>
        ///Agrega un nuevo registro.
        /// </summary>
        /// <returns></returns>
        public int Add(InfoIntegranteBDO InfoIntegranteBdo)
        {
            InfoIntegranteDAL InfoIntegranteDal = new();
            return InfoIntegranteDal.Add(InfoIntegranteBdo);
        }

        /// <summary>
        ///Actualiza un registro.
        /// </summary>
        /// <returns></returns>
        public bool Update(InfoIntegranteBDO InfoIntegranteBdo)
        {
            InfoIntegranteDAL InfoIntegranteDal = new();
            return InfoIntegranteDal.Update(InfoIntegranteBdo);
        }

        /// <summary>
        ///Elimina un registro.
        /// </summary>
        /// <returns></returns>
        public bool Delete(long InfoIntegranteID)
        {
            InfoIntegranteDAL InfoIntegranteDal = new();
            return InfoIntegranteDal.Delete(InfoIntegranteID);
        }
    }
}

