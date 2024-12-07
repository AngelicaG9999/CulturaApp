using CulturApp.BDO.AdministracionDelSistema.ReglasGrupoEmpresarial;
using CulturApp.DAL.AdministracionDelSistema.ReglasGrupoEmpresarial;
using System.Collections.Generic;
using System.Data;

namespace CulturApp.BLL.AdministracionDelSistema.ReglasGrupoEmpresarial
{

    /// <summary>
    /// EmpresaInfoConsecutivo.
    /// </summary>
    public class EmpresaInfoConsecutivoBLL
    {

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(long EmpresaID)
        {
            EmpresaInfoConsecutivoDAL EmpresaInfoConsecutivoDAL = new EmpresaInfoConsecutivoDAL();
            return EmpresaInfoConsecutivoDAL.GetAll(EmpresaID);
        }

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public List<EmpresaInfoConsecutivoBDO> GetAllToList(long EmpresaID)
        {
            List<EmpresaInfoConsecutivoBDO> _List = new List<EmpresaInfoConsecutivoBDO>();
            DataTable _DataTable = new DataTable();

            _DataTable = GetAll(EmpresaID);

            foreach (DataRow _DataRows in _DataTable.Rows)
            {
                _List.Add(new EmpresaInfoConsecutivoBDO(_DataRows));
            }

            return _List;
        }

        /// <summary>
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public DataTable GetByID(long EmpresaID)
        {
            EmpresaInfoConsecutivoDAL EmpresaInfoConsecutivoDAL = new EmpresaInfoConsecutivoDAL();
            return EmpresaInfoConsecutivoDAL.GetByID(EmpresaID);
        }

        /// <summary>
        ///Agrega un nuevo registro.
        /// </summary>
        /// <returns></returns>
        public int Add(EmpresaInfoConsecutivoBDO EmpresaInfoConsecutivoBDO)
        {
            EmpresaInfoConsecutivoDAL EmpresaInfoConsecutivoDAL = new EmpresaInfoConsecutivoDAL();
            return EmpresaInfoConsecutivoDAL.Add(EmpresaInfoConsecutivoBDO);
        }

        /// <summary>
        ///Actualiza un registro.
        /// </summary>
        /// <returns></returns>
        public bool Update(EmpresaInfoConsecutivoBDO EmpresaInfoConsecutivoBDO)
        {
            EmpresaInfoConsecutivoDAL EmpresaInfoConsecutivoDAL = new EmpresaInfoConsecutivoDAL();
            return EmpresaInfoConsecutivoDAL.Update(EmpresaInfoConsecutivoBDO);
        }

        /// <summary>
        ///Elimina un registro.
        /// </summary>
        /// <returns></returns>
        public bool Delete(long EmpresaID)
        {
            EmpresaInfoConsecutivoDAL EmpresaInfoConsecutivoDAL = new EmpresaInfoConsecutivoDAL();
            return EmpresaInfoConsecutivoDAL.Delete(EmpresaID);
        }
    }
}
