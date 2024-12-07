
using System.Data;
using System.Collections.Generic;


using CulturApp.BDO.GestionDatosMaestros;
using CulturApp.DAL.GestionDatosMaestros;

namespace CulturApp.BLL.GestionDatosMaestros
{

    /// <summary>
    /// Modalidad.
    /// </summary>
    public class ModalidadBLL
    {

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public List<ModalidadBDO> GetAll(ModalidadBDO ModalidadBdo)
        {
            ModalidadDAL ModalidadDal = new();
            List<ModalidadBDO> _List = new();

            DataTable _DataTable = ModalidadDal.GetAll(ModalidadBdo);

            foreach (DataRow _DataRows in _DataTable.Rows)
            {
                _List.Add(new ModalidadBDO(_DataRows));
            }

            return _List;
        }

        /// <summary>
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public ModalidadBDO GetByID(long ModalidadID)
        {
            ModalidadBDO ModalidadBdo = new();
            ModalidadDAL ModalidadDal = new();
            DataTable _DataTable = ModalidadDal.GetByID(ModalidadID);
            if (_DataTable.Rows.Count > 0)
            {
                ModalidadBdo = new(_DataTable.Rows[0]);
            }

            return ModalidadBdo;
        }

        /// <summary>
        ///Agrega un nuevo registro.
        /// </summary>
        /// <returns></returns>
        public int Add(ModalidadBDO ModalidadBdo)
        {
            ModalidadDAL ModalidadDal = new();
            return ModalidadDal.Add(ModalidadBdo);
        }

        /// <summary>
        ///Actualiza un registro.
        /// </summary>
        /// <returns></returns>
        public bool Update(ModalidadBDO ModalidadBdo)
        {
            ModalidadDAL ModalidadDal = new();
            return ModalidadDal.Update(ModalidadBdo);
        }

        /// <summary>
        ///Elimina un registro.
        /// </summary>
        /// <returns></returns>
        public bool Delete(long ModalidadID)
        {
            ModalidadDAL ModalidadDal = new();
            return ModalidadDal.Delete(ModalidadID);
        }
    }

}

