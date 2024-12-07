
using CulturApp.BDO.GestionDatosMaestros.ConfiguracionTerceros;
using CulturApp.DAL.GestionDatosMaestros.ConfiguracionTerceros;
using System.Collections.Generic;
using System.Data;

namespace CulturApp.BLL.GestionDatosMaestros.ConfiguracionTerceros
{

    /// <summary>
    /// TerceroInfoGeneral.
    /// </summary>
    public class TerceroInfoGeneralBLL
    {

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(TerceroInfoGeneralBDO TerceroInfoGeneralBDO)
        {
            TerceroInfoGeneralDAL TerceroInfoGeneralDAL = new TerceroInfoGeneralDAL();
            return TerceroInfoGeneralDAL.GetAll(TerceroInfoGeneralBDO);
        }

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public List<TerceroInfoGeneralBDO> GetAllToList(TerceroInfoGeneralBDO TerceroInfoGeneralBDO)
        {
            List<TerceroInfoGeneralBDO> _List = new List<TerceroInfoGeneralBDO>();
            DataTable _DataTable = new DataTable();

            _DataTable = GetAll(TerceroInfoGeneralBDO);

            foreach (DataRow _DataRows in _DataTable.Rows)
            {
                _List.Add(new TerceroInfoGeneralBDO(_DataRows));
            }

            return _List;
        }

        /// <summary>
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public DataTable GetByID(long TerceroID)
        {
            TerceroInfoGeneralDAL TerceroInfoGeneralDAL = new TerceroInfoGeneralDAL();
            return TerceroInfoGeneralDAL.GetByID(TerceroID);
        }

        /// <summary>
        ///Agrega un nuevo registro.
        /// </summary>
        /// <returns></returns>
        public int Add(TerceroInfoGeneralBDO TerceroInfoGeneralBDO)
        {
            TerceroInfoGeneralDAL TerceroInfoGeneralDAL = new TerceroInfoGeneralDAL();
            return TerceroInfoGeneralDAL.Add(TerceroInfoGeneralBDO);
        }

        /// <summary>
        ///Actualiza un registro.
        /// </summary>
        /// <returns></returns>
        public bool Update(TerceroInfoGeneralBDO TerceroInfoGeneralBDO)
        {
            TerceroInfoGeneralDAL TerceroInfoGeneralDAL = new TerceroInfoGeneralDAL();
            return TerceroInfoGeneralDAL.Update(TerceroInfoGeneralBDO);
        }

        /// <summary>
        ///Elimina un registro.
        /// </summary>
        /// <returns></returns>
        public bool Delete(long TerceroID)
        {
            TerceroInfoGeneralDAL TerceroInfoGeneralDAL = new TerceroInfoGeneralDAL();
            return TerceroInfoGeneralDAL.Delete(TerceroID);
        }

    }
}
