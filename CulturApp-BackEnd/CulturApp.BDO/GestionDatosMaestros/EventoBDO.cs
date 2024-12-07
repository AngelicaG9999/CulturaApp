using System;
using System.Data;

namespace CulturApp.BDO.GestionDatosMaestros
{
    /// <summary>
    /// Evento
    /// </summary>
    /// 
    public class EventoBDO
    {
        #region ".:: PROPIEDADES ::."

        public long EventoID { get; set; }

        public long EmpresaID { get; set; }

        public long SalaID { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaHora { get; set; }

        public string Lugar { get; set; }

        public string Direccion { get; set; }

        public string Sala { get; set; }

        #endregion

        #region ".:: CONSTRUCTORES ::."

        public EventoBDO()
        {
            EventoID = 0;
            EmpresaID = 0;
            SalaID = 0;
            Nombre = null;
            FechaHora = DateTime.Today;
            Lugar = null;
            Direccion = null;
        }

        public EventoBDO(DataRow _DataRow)
        {
            EventoID = Convert.ToInt64((_DataRow["EventoID"] == System.DBNull.Value ? 0 : _DataRow["EventoID"]));
            EmpresaID = Convert.ToInt64((_DataRow["EmpresaID"] == System.DBNull.Value ? 0 : _DataRow["EmpresaID"]));
            SalaID = Convert.ToInt64((_DataRow["SalaID"] == System.DBNull.Value ? 0 : _DataRow["SalaID"]));
            Nombre = Convert.ToString((_DataRow["Nombre"] == System.DBNull.Value ? String.Empty : _DataRow["Nombre"]));
            FechaHora = Convert.ToDateTime((_DataRow["FechaHora"] == DBNull.Value ? DateTime.Today : _DataRow["FechaHora"]));
            Lugar = Convert.ToString((_DataRow["Lugar"] == System.DBNull.Value ? String.Empty : _DataRow["Lugar"]));
            Direccion = Convert.ToString((_DataRow["Direccion"] == System.DBNull.Value ? String.Empty : _DataRow["Direccion"]));

            Sala = Convert.ToString((_DataRow["Sala"] == System.DBNull.Value ? String.Empty : _DataRow["Sala"]));
        }
        #endregion
    }
}
