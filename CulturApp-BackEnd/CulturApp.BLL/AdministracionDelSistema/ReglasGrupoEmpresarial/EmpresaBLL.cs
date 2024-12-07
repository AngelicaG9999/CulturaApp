using CulturApp.BDO.AdministracionDelSistema.ReglasGrupoEmpresarial;
using CulturApp.DAL.AdministracionDelSistema.ReglasGrupoEmpresarial;
using System.Data;

namespace CulturApp.BLL.AdministracionDelSistema.ReglasGrupoEmpresarial
{

    /// <summary>
    /// Empresa.
    /// </summary>
    public class EmpresaBLL
    {

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(EmpresaBDO EmpresaBDO)
        {
            EmpresaDAL EmpresaDAL = new EmpresaDAL();
            return EmpresaDAL.GetAll(EmpresaBDO);
        }

        /// <summary>
        /// Busca la empresa por c�digo
        /// </summary>
        /// <param name="Codigo">C�digo</param>
        /// <returns>Lista de empresas</returns>
        public DataTable GetByCodigo(string Codigo)
        {
            EmpresaDAL EmpresaDAL = new EmpresaDAL();
            return EmpresaDAL.GetByCodigo(Codigo);
        }

        /// <summary>
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public DataTable GetByID(EmpresaBDO EmpresaBDO)
        {
            EmpresaDAL EmpresaDAL = new EmpresaDAL();
            return EmpresaDAL.GetByID(EmpresaBDO);
        }

    }
}
