
using System.Data;
using System.Collections.Generic;


using CulturApp.BDO.GestionDatosMaestros;
using CulturApp.DAL.GestionDatosMaestros;

namespace CulturApp.BLL.GestionDatosMaestros
{

    /// <summary>
    /// Inscripcion.
    /// </summary>
    public class InscripcionBLL
    {

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public List<InscripcionBDO> GetAll(InscripcionBDO InscripcionBdo)
        {
            InscripcionDAL InscripcionDal = new();
            List<InscripcionBDO> _List = new();

            DataTable _DataTable = InscripcionDal.GetAll(InscripcionBdo);

            foreach (DataRow _DataRows in _DataTable.Rows)
            {
                _List.Add(new InscripcionBDO(_DataRows));
            }

            return _List;
        }

        /// <summary>
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public InscripcionBDO GetByID(long InscripcionID)
        {
            InscripcionBDO InscripcionBdo = new();
            InscripcionDAL InscripcionDal = new();
            DataTable _DataTable = InscripcionDal.GetByID(InscripcionID);
            if (_DataTable.Rows.Count > 0)
            {
                InscripcionBdo = new(_DataTable.Rows[0]);
            }

            return InscripcionBdo;
        }

        /// <summary>
        ///Agrega un nuevo registro.
        /// </summary>
        /// <returns></returns>
        public int Add(InscripcionBDO InscripcionBdo)
        {
            InscripcionDAL InscripcionDal = new();
            return InscripcionDal.Add(InscripcionBdo);
        }

        /// <summary>
        ///Actualiza un registro.
        /// </summary>
        /// <returns></returns>
        public bool Update(InscripcionBDO InscripcionBdo)
        {
            InscripcionDAL InscripcionDal = new();
            return InscripcionDal.Update(InscripcionBdo);
        }

        /// <summary>
        ///Elimina un registro.
        /// </summary>
        /// <returns></returns>
        public bool Delete(long InscripcionID)
        {
            InscripcionDAL InscripcionDal = new();
            return InscripcionDal.Delete(InscripcionID);
        }
    }
}

