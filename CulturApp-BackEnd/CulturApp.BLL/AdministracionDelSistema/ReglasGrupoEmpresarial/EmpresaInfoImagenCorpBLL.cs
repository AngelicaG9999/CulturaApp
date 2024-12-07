
using CulturApp.BDO.AdministracionDelSistema.ReglasGrupoEmpresarial;
using CulturApp.DAL.AdministracionDelSistema.ReglasGrupoEmpresarial;
using System.Collections.Generic;
using System.Data;

namespace CulturApp.BLL.AdministracionDelSistema.ReglasGrupoEmpresarial
{

    /// <summary>
    /// EmpresaInfoImagenCorp.
    /// </summary>
    public class EmpresaInfoImagenCorpBLL
    {

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(EmpresaInfoImagenCorpBDO EmpresaInfoImagenCorpBDO)
        {
            EmpresaInfoImagenCorpDAL EmpresaInfoImagenCorpDAL = new EmpresaInfoImagenCorpDAL();
            return EmpresaInfoImagenCorpDAL.GetAll(EmpresaInfoImagenCorpBDO);
        }

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public List<EmpresaInfoImagenCorpBDO> GetAllToList(EmpresaInfoImagenCorpBDO EmpresaInfoImagenCorpBDO)
        {
            List<EmpresaInfoImagenCorpBDO> _List = new List<EmpresaInfoImagenCorpBDO>();
            DataTable _DataTable = new DataTable();

            _DataTable = GetAll(EmpresaInfoImagenCorpBDO);

            foreach (DataRow _DataRows in _DataTable.Rows)
            {
                _List.Add(new EmpresaInfoImagenCorpBDO(_DataRows));
            }

            return _List;
        }

        /// <summary>
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public DataTable GetByID(long EmpresaID)
        {
            EmpresaInfoImagenCorpDAL EmpresaInfoImagenCorpDAL = new EmpresaInfoImagenCorpDAL();
            return EmpresaInfoImagenCorpDAL.GetByID(EmpresaID);
        }

        /// <summary>
        ///Agrega un nuevo registro.
        /// </summary>
        /// <returns></returns>
        public int Add(EmpresaInfoImagenCorpBDO EmpresaInfoImagenCorpBDO)
        {
            EmpresaInfoImagenCorpDAL EmpresaInfoImagenCorpDAL = new EmpresaInfoImagenCorpDAL();
            return EmpresaInfoImagenCorpDAL.Add(EmpresaInfoImagenCorpBDO);
        }

        /// <summary>
        ///Actualiza un registro.
        /// </summary>
        /// <returns></returns>
        public bool Update(EmpresaInfoImagenCorpBDO EmpresaInfoImagenCorpBDO)
        {
            EmpresaInfoImagenCorpDAL EmpresaInfoImagenCorpDAL = new EmpresaInfoImagenCorpDAL();
            return EmpresaInfoImagenCorpDAL.Update(EmpresaInfoImagenCorpBDO);
        }

        /// <summary>
        ///Elimina un registro.
        /// </summary>
        /// <returns></returns>
        public bool Delete(long EmpresaID)
        {
            EmpresaInfoImagenCorpDAL EmpresaInfoImagenCorpDAL = new EmpresaInfoImagenCorpDAL();
            return EmpresaInfoImagenCorpDAL.Delete(EmpresaID);
        }
    }
}
