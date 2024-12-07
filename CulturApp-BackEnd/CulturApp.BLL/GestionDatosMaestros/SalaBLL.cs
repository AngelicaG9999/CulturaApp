using System.Data;
using System.Collections.Generic;

using CulturApp.BDO.GestionDatosMaestros;
using CulturApp.DAL.GestionDatosMaestros;

namespace CulturApp.BLL.GestionDatosMaestros
{

    /// <summary>
    /// Retorna todos los registros de la tabla.
    /// </summary>
    /// <returns></returns>
    public class SalaBLL
    {
        public List<SalaBDO> GetAll(SalaBDO SalaBdo)
        {
            SalaDAL SalaDal = new();
            List<SalaBDO> _List = new();

            DataTable _DataTable = SalaDal.GetAll(SalaBdo);

            foreach (DataRow _DataRows in _DataTable.Rows)
            {
                _List.Add(new SalaBDO(_DataRows));
            }

            return _List;
        }

        /// <summary>
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public SalaBDO GetByID(long SalaID)
        {
            SalaBDO SalaBdo = new();
            SalaDAL SalaDal = new();
            DataTable _DataTable = SalaDal.GetByID(SalaID);
            if (_DataTable.Rows.Count > 0)
            {
                SalaBdo = new(_DataTable.Rows[0]);
            }

            return SalaBdo;
        }

        /// <summary>
        ///Agrega un nuevo registro.
        /// </summary>
        /// <returns></returns>
        public int Add(SalaBDO SalaBdo)
        {
            SalaDAL SalaDal = new();
            return SalaDal.Add(SalaBdo);
        }

        /// <summary>
        ///Actualiza un registro.
        /// </summary>
        /// <returns></returns>
        public bool Update(SalaBDO SalaBdo)
        {
            SalaDAL SalaDal = new();
            return SalaDal.Update(SalaBdo);
        }

        /// <summary>
        ///Elimina un registro.
        /// </summary>
        /// <returns></returns>
        public bool Delete(long SalaID)
        {
            SalaDAL SalaDal = new();
            return SalaDal.Delete(SalaID);
        }
    }


}
