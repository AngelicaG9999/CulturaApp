
using CulturApp.BDO.GestionDatosMaestros.ConfiguracionGeneral;
using CulturApp.DAL.GestionDatosMaestros.ConfiguracionGeneral;
using System.Collections.Generic;
using System.Data;

namespace CulturApp.BLL.GestionDatosMaestros.ConfiguracionGeneral
{

    /// <summary>
    /// DiaNoHabil.
    /// </summary>
    public class DiaNoHabilBLL
    {

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(DiaNoHabilBDO DiaNoHabilBDO)
        {
            DiaNoHabilDAL DiaNoHabilDAL = new DiaNoHabilDAL();
            return DiaNoHabilDAL.GetAll(DiaNoHabilBDO);
        }

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public List<DiaNoHabilBDO> GetAllToList(DiaNoHabilBDO DiaNoHabilBDO)
        {
            List<DiaNoHabilBDO> _List = new List<DiaNoHabilBDO>();
            DataTable _DataTable = new DataTable();

            _DataTable = GetAll(DiaNoHabilBDO);

            foreach (DataRow _DataRows in _DataTable.Rows)
            {
                _List.Add(new DiaNoHabilBDO(_DataRows));
            }

            return _List;
        }

        /// <summary>
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public DataTable GetByID(long DiaNoHabilID)
        {
            DiaNoHabilDAL DiaNoHabilDAL = new DiaNoHabilDAL();
            return DiaNoHabilDAL.GetByID(DiaNoHabilID);
        }

        /// <summary>
        ///Agrega un nuevo registro.
        /// </summary>
        /// <returns></returns>
        public int Add(DiaNoHabilBDO DiaNoHabilBDO)
        {
            DiaNoHabilDAL DiaNoHabilDAL = new DiaNoHabilDAL();
            return DiaNoHabilDAL.Add(DiaNoHabilBDO);
        }

        /// <summary>
        ///Actualiza un registro.
        /// </summary>
        /// <returns></returns>
        public bool Update(DiaNoHabilBDO DiaNoHabilBDO)
        {
            DiaNoHabilDAL DiaNoHabilDAL = new DiaNoHabilDAL();
            return DiaNoHabilDAL.Update(DiaNoHabilBDO);
        }

        /// <summary>
        ///Elimina un registro.
        /// </summary>
        /// <returns></returns>
        public bool Delete(long DiaNoHabilID)
        {
            DiaNoHabilDAL DiaNoHabilDAL = new DiaNoHabilDAL();
            return DiaNoHabilDAL.Delete(DiaNoHabilID);
        }
    }
}
