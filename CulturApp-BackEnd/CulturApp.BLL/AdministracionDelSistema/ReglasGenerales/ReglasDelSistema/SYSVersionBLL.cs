
using CulturApp.BDO.AdministracionDelSistema.ReglasGenerales.ReglasDelSistema;
using CulturApp.DAL.AdministracionDelSistema.ReglasGenerales.ReglasDelSistema;
using System.Collections.Generic;
using System.Data;

namespace CulturApp.BLL.AdministracionDelSistema.ReglasGenerales.ReglasDelSistema
{

    /// <summary>
    /// SYSVersion.
    /// </summary>
    public class SYSVersionBLL
    {

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(SYSVersionBDO SYSVersionBDO)
        {
            SYSVersionDAL SYSVersionDAL = new SYSVersionDAL();
            return SYSVersionDAL.GetAll(SYSVersionBDO);
        }

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public List<SYSVersionBDO> GetAllToList(SYSVersionBDO SYSVersionBDO)
        {
            List<SYSVersionBDO> _List = new List<SYSVersionBDO>();
            DataTable _DataTable = new DataTable();

            _DataTable = GetAll(SYSVersionBDO);

            foreach (DataRow _DataRows in _DataTable.Rows)
            {
                _List.Add(new SYSVersionBDO(_DataRows));
            }

            return _List;
        }

        /// <summary>
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public DataTable GetByID(long SYSVersionID)
        {
            SYSVersionDAL SYSVersionDAL = new SYSVersionDAL();
            return SYSVersionDAL.GetByID(SYSVersionID);
        }

        /// <summary>
        ///Agrega un nuevo registro.
        /// </summary>
        /// <returns></returns>
        public int Add(SYSVersionBDO SYSVersionBDO)
        {
            SYSVersionDAL SYSVersionDAL = new SYSVersionDAL();
            return SYSVersionDAL.Add(SYSVersionBDO);
        }

        /// <summary>
        ///Actualiza un registro.
        /// </summary>
        /// <returns></returns>
        public bool Update(SYSVersionBDO SYSVersionBDO)
        {
            SYSVersionDAL SYSVersionDAL = new SYSVersionDAL();
            return SYSVersionDAL.Update(SYSVersionBDO);
        }

        /// <summary>
        ///Elimina un registro.
        /// </summary>
        /// <returns></returns>
        public bool Delete(long SYSVersionID)
        {
            SYSVersionDAL SYSVersionDAL = new SYSVersionDAL();
            return SYSVersionDAL.Delete(SYSVersionID);
        }
    }
}
