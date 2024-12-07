
using CulturApp.BDO.AdministracionDelSistema.ReglasGenerales.ReglasDelSistema;
using CulturApp.DAL.AdministracionDelSistema.ReglasGenerales.ReglasDelSistema;
using System.Collections.Generic;
using System.Data;

namespace CulturApp.BLL.AdministracionDelSistema.ReglasGenerales.ReglasDelSistema
{

    /// <summary>
    /// Departamento.
    /// </summary>
    public class DepartamentoBLL
    {

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(DepartamentoBDO DepartamentoBDO)
        {
            DepartamentoDAL DepartamentoDAL = new DepartamentoDAL();
            return DepartamentoDAL.GetAll(DepartamentoBDO);
        }

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public List<DepartamentoBDO> GetAllToList(DepartamentoBDO DepartamentoBDO)
        {
            List<DepartamentoBDO> _List = new List<DepartamentoBDO>();
            DataTable _DataTable = new DataTable();

            _DataTable = GetAll(DepartamentoBDO);

            foreach (DataRow _DataRows in _DataTable.Rows)
            {
                _List.Add(new DepartamentoBDO(_DataRows));
            }

            return _List;
        }

        /// <summary>
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public DataTable GetByID(int DepartamentoID)
        {
            DepartamentoDAL DepartamentoDAL = new DepartamentoDAL();
            return DepartamentoDAL.GetByID(DepartamentoID);
        }

        /// <summary>
        ///Agrega un nuevo registro.
        /// </summary>
        /// <returns></returns>
        public int Add(DepartamentoBDO DepartamentoBDO)
        {
            DepartamentoDAL DepartamentoDAL = new DepartamentoDAL();
            return DepartamentoDAL.Add(DepartamentoBDO);
        }

        /// <summary>
        ///Actualiza un registro.
        /// </summary>
        /// <returns></returns>
        public bool Update(DepartamentoBDO DepartamentoBDO)
        {
            DepartamentoDAL DepartamentoDAL = new DepartamentoDAL();
            return DepartamentoDAL.Update(DepartamentoBDO);
        }

        /// <summary>
        ///Elimina un registro.
        /// </summary>
        /// <returns></returns>
        public bool Delete(int DepartamentoID)
        {
            DepartamentoDAL DepartamentoDAL = new DepartamentoDAL();
            return DepartamentoDAL.Delete(DepartamentoID);
        }
    }
}
