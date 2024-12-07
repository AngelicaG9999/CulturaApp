
using CulturApp.BDO.GestionDatosMaestros.ConfiguracionGeneral;
using CulturApp.DAL.GestionDatosMaestros.ConfiguracionGeneral;
using System.Collections.Generic;
using System.Data;

namespace CulturApp.BLL.GestionDatosMaestros.ConfiguracionGeneral
{

    /// <summary>
    /// FormaPago.
    /// </summary>
    public class FormaPagoBLL
    {

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(FormaPagoBDO FormaPagoBDO)
        {
            FormaPagoDAL FormaPagoDAL = new FormaPagoDAL();
            return FormaPagoDAL.GetAll(FormaPagoBDO);
        }

        /// <summary>
        /// Retorna todos los registros de la tabla.
        /// </summary>
        /// <returns></returns>
        public List<FormaPagoBDO> GetAllToList(FormaPagoBDO FormaPagoBDO)
        {
            List<FormaPagoBDO> _List = new List<FormaPagoBDO>();
            DataTable _DataTable = new DataTable();

            _DataTable = GetAll(FormaPagoBDO);

            foreach (DataRow _DataRows in _DataTable.Rows)
            {
                _List.Add(new FormaPagoBDO(_DataRows));
            }

            return _List;
        }

        /// <summary>
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public DataTable GetByID(long FormaPagoID)
        {
            FormaPagoDAL FormaPagoDAL = new FormaPagoDAL();
            return FormaPagoDAL.GetByID(FormaPagoID);
        }

        /// <summary>
        ///Agrega un nuevo registro.
        /// </summary>
        /// <returns></returns>
        public int Add(FormaPagoBDO FormaPagoBDO)
        {
            FormaPagoDAL FormaPagoDAL = new FormaPagoDAL();
            return FormaPagoDAL.Add(FormaPagoBDO);
        }

        /// <summary>
        ///Actualiza un registro.
        /// </summary>
        /// <returns></returns>
        public bool Update(FormaPagoBDO FormaPagoBDO)
        {
            FormaPagoDAL FormaPagoDAL = new FormaPagoDAL();
            return FormaPagoDAL.Update(FormaPagoBDO);
        }

        /// <summary>
        ///Elimina un registro.
        /// </summary>
        /// <returns></returns>
        public bool Delete(long FormaPagoID)
        {
            FormaPagoDAL FormaPagoDAL = new FormaPagoDAL();
            return FormaPagoDAL.Delete(FormaPagoID);
        }
    }
}
