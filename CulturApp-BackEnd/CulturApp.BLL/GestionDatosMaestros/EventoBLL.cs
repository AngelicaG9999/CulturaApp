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
    /// 
    public class EventoBLL
    {
        public List<EventoBDO> GetAll(long EmpresaID, long SalaID, string Nombre, string FechaHora)
        {
            EventoDAL EventoDal = new();
            List<EventoBDO> _List = new();

            DataTable _DataTable = EventoDal.GetAll( EmpresaID, SalaID,Nombre, FechaHora);

            foreach (DataRow _DataRows in _DataTable.Rows)
            {
                _List.Add(new EventoBDO(_DataRows));
            }

            return _List;
        }

        /// <summary>
        /// Retorna un registro filtrando por ID.
        /// </summary>
        /// <returns></returns>
        public EventoBDO GetByID(long EventoID)
        {
            EventoBDO EventoBdo = new();
            EventoDAL EventoDal = new();
            DataTable _DataTable = EventoDal.GetByID(EventoID);
            if (_DataTable.Rows.Count > 0)
            {
                EventoBdo = new(_DataTable.Rows[0]);
            }

            return EventoBdo;
        }

        /// <summary>
        ///Agrega un nuevo registro.
        /// </summary>
        /// <returns></returns>
        public int Add(EventoBDO EventoBdo)
        {
            EventoDAL EventoDal = new();
            return EventoDal.Add(EventoBdo);
        }

        /// <summary>
        ///Actualiza un registro.
        /// </summary>
        /// <returns></returns>
        public bool Update(EventoBDO EventoBdo)
        {
            EventoDAL EventoDal = new();
            return EventoDal.Update(EventoBdo);
        }

        /// <summary>
        ///Elimina un registro.
        /// </summary>
        /// <returns></returns>
        public bool Delete(long EventoID)
        {
            EventoDAL EventoDal = new();
            return EventoDal.Delete(EventoID);
        }
    }
}
