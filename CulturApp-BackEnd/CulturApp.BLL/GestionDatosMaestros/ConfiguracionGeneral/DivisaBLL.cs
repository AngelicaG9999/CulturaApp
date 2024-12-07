using CulturApp.BDO.GestionDatosMaestros.ConfiguracionGeneral;
using CulturApp.DAL.GestionDatosMaestros.ConfiguracionGeneral;
using System.Collections.Generic;
using System.Data;

namespace CulturApp.BLL.GestionDatosMaestros.ConfiguracionGeneral
{

    /// <summary>
    /// Divisa.
    /// </summary>
    public class DivisaBLL
    {

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(DivisaBDO DivisaBDO)
        {
            DivisaDAL DivisaDAL = new DivisaDAL();
            return DivisaDAL.GetAll(DivisaBDO);
        }

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public List<DivisaBDO> GetAllToList(DivisaBDO DivisaBDO)
        {
            List<DivisaBDO> _List = new List<DivisaBDO>();
            DataTable _DataTable = new DataTable();

            _DataTable = GetAll(DivisaBDO);

            foreach (DataRow _DataRows in _DataTable.Rows)
            {
                _List.Add(new DivisaBDO(_DataRows));
            }

            return _List;
        }

        /// <summary>
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public DataTable GetByID(long DivisaID)
        {
            DivisaDAL DivisaDAL = new DivisaDAL();
            return DivisaDAL.GetByID(DivisaID);
        }

        /// <summary>
        ///Agrega un nuevo registro.
        /// </summary>
        /// <returns></returns>
        public int Add(DivisaBDO DivisaBDO)
        {
            DivisaDAL DivisaDAL = new DivisaDAL();
            return DivisaDAL.Add(DivisaBDO);
        }

        /// <summary>
        ///Actualiza un registro.
        /// </summary>
        /// <returns></returns>
        public bool Update(DivisaBDO DivisaBDO)
        {
            DivisaDAL DivisaDAL = new DivisaDAL();
            return DivisaDAL.Update(DivisaBDO);
        }

        /// <summary>
        ///Elimina un registro.
        /// </summary>
        /// <returns></returns>
        public bool Delete(long DivisaID)
        {
            DivisaDAL DivisaDAL = new DivisaDAL();
            return DivisaDAL.Delete(DivisaID);
        }
    }
}
