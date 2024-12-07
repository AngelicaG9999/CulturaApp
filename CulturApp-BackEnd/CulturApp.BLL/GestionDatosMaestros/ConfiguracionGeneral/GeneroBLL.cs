using CulturApp.BDO.GestionDatosMaestros.ConfiguracionGeneral;
using CulturApp.DAL.GestionDatosMaestros.ConfiguracionGeneral;
using System.Collections.Generic;
using System.Data;

namespace CulturApp.BLL.GestionDatosMaestros.ConfiguracionGeneral
{
    /// <summary>
    /// Genero.
    /// </summary>
    public class GeneroBLL
    {

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(GeneroBDO GeneroBDO)
        {
            GeneroDAL GeneroDAL = new GeneroDAL();
            return GeneroDAL.GetAll(GeneroBDO);
        }

        public List<GeneroBDO> GetAllToList(GeneroBDO GeneroBDO)
        {
            List<GeneroBDO> _List = new List<GeneroBDO>();
            DataTable _DataTable = new DataTable();

            _DataTable = GetAll(GeneroBDO);

            foreach (DataRow _DataRows in _DataTable.Rows)
            {
                _List.Add(new GeneroBDO(_DataRows));
            }

            return _List;
        }

        /// <summary>
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public DataTable GetByID(long GeneroID)
        {
            GeneroDAL GeneroDAL = new GeneroDAL();
            return GeneroDAL.GetByID(GeneroID);
        }

        /// <summary>
        ///Agrega un nuevo registro.
        /// </summary>
        /// <returns></returns>
        public int Add(GeneroBDO GeneroBDO)
        {
            GeneroDAL GeneroDAL = new GeneroDAL();
            return GeneroDAL.Add(GeneroBDO);
        }

        /// <summary>
        ///Actualiza un registro.
        /// </summary>
        /// <returns></returns>
        public bool Update(GeneroBDO GeneroBDO)
        {
            GeneroDAL GeneroDAL = new GeneroDAL();
            return GeneroDAL.Update(GeneroBDO);
        }

        /// <summary>
        ///Elimina un registro.
        /// </summary>
        /// <returns></returns>
        public bool Delete(long GeneroID)
        {
            GeneroDAL GeneroDAL = new GeneroDAL();
            return GeneroDAL.Delete(GeneroID);
        }
    }
}
