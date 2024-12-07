using CulturApp.BDO.AdministracionDelSistema.ReglasGenerales.Seguridad;
using CulturApp.DAL.AdministracionDelSistema.ReglasGenerales.Seguridad;
using System.Data;

namespace CulturApp.BLL.AdministracionDelSistema.ReglasGenerales.Seguridad
{

    /// <summary>
    /// UsuarioAutorizacion.
    /// </summary>
    public class UsuarioAutorizacionBLL
      {

          /// <summary>
          /// Retorna todos los registros de la tabla.
          /// </summary>
          /// <returns></returns>
          public DataTable GetAll(UsuarioAutorizacionBDO UsuarioAutorizacionBDO)
          {
              UsuarioAutorizacionDAL UsuarioAutorizacionDAL = new UsuarioAutorizacionDAL();
              return UsuarioAutorizacionDAL.GetAll(UsuarioAutorizacionBDO);
          }

          public AutorizacionObjetoBDO AutorizacionObjeto(long EmpresaID, long UsuarioID, string ObjetoUrl)
          {
              UsuarioAutorizacionDAL UsuarioAutorizacionDAL = new UsuarioAutorizacionDAL();
              AutorizacionObjetoBDO AutorizacionObjeto = new AutorizacionObjetoBDO();
              DataTable _DataTable = new DataTable();

              _DataTable = UsuarioAutorizacionDAL.AutorizacionObjeto(EmpresaID, UsuarioID, ObjetoUrl);

              if (_DataTable.Rows.Count  > 0)
              {
                  AutorizacionObjeto = new AutorizacionObjetoBDO(_DataTable.Rows[0]);
              }

              return AutorizacionObjeto;
          }

          /// <summary>
          /// Retorna un registro filtrando por ID.
          /// </summary>
          /// <returns></returns>
          public DataTable GetByID(UsuarioAutorizacionBDO UsuarioAutorizacionBDO)
          {
              UsuarioAutorizacionDAL UsuarioAutorizacionDAL = new UsuarioAutorizacionDAL();
              return UsuarioAutorizacionDAL.GetByID(UsuarioAutorizacionBDO);
          }

          /// <summary>
          ///Agrega un nuevo registro.
          /// </summary>
          /// <returns></returns>
          public int Add(UsuarioAutorizacionBDO UsuarioAutorizacionBDO)
          {
              UsuarioAutorizacionDAL UsuarioAutorizacionDAL = new UsuarioAutorizacionDAL();
              return UsuarioAutorizacionDAL.Add(UsuarioAutorizacionBDO);
          }

          /// <summary>
          ///Actualiza un registro.
          /// </summary>
          /// <returns></returns>
          public bool Update(UsuarioAutorizacionBDO UsuarioAutorizacionBDO)
          {
              UsuarioAutorizacionDAL UsuarioAutorizacionDAL = new UsuarioAutorizacionDAL();
              return UsuarioAutorizacionDAL.Update(UsuarioAutorizacionBDO);
           }

          /// <summary>
          ///Elimina un registro.
          /// </summary>
          /// <returns></returns>
          public bool Delete(UsuarioAutorizacionBDO UsuarioAutorizacionBDO)
          {
              UsuarioAutorizacionDAL UsuarioAutorizacionDAL = new UsuarioAutorizacionDAL();
              return UsuarioAutorizacionDAL.Delete(UsuarioAutorizacionBDO);
          }
  }
}
