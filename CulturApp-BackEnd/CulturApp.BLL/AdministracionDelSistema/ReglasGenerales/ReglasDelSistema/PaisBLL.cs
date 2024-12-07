
using CulturApp.BDO.AdministracionDelSistema.ReglasGenerales.ReglasDelSistema;
using CulturApp.DAL.AdministracionDelSistema.ReglasGenerales.ReglasDelSistema;
using System.Collections.Generic;
using System.Data;

namespace CulturApp.BLL.AdministracionDelSistema.ReglasGenerales.ReglasDelSistema
{

    /// <summary>
    /// Pais.
    /// </summary>
    public class PaisBLL
      {

          /// <summary>
          /// Retorna todos los registros de la tabla.
          /// </summary>
          /// <returns></returns>
          public DataTable GetAll(PaisBDO PaisBDO)
          {
              PaisDAL PaisDAL = new PaisDAL();
              return PaisDAL.GetAll(PaisBDO);
          }

          /// <summary>
          /// Retorna todos los registros de la tabla.
          /// </summary>
          /// <returns></returns>
          public List<PaisBDO> GetAllToList(PaisBDO PaisBDO)
          {
              List<PaisBDO> _List = new List<PaisBDO>();
              DataTable _DataTable = new DataTable();
              
              _DataTable = GetAll(PaisBDO);
              
              foreach (DataRow _DataRows in _DataTable.Rows)
              {
                  _List.Add(new PaisBDO(_DataRows));
              }
              
              return _List;
          }

          /// <summary>
          /// Retorna un registro filtrando por ID.
          /// </summary>
          /// <returns></returns>
          public DataTable GetByID(int PaisID)
          {
              PaisDAL PaisDAL = new PaisDAL();
              return PaisDAL.GetByID(PaisID);
          }

          /// <summary>
          ///Agrega un nuevo registro.
          /// </summary>
          /// <returns></returns>
          public int Add(PaisBDO PaisBDO)
          {
              PaisDAL PaisDAL = new PaisDAL();
              return PaisDAL.Add(PaisBDO);
          }

          /// <summary>
          ///Actualiza un registro.
          /// </summary>
          /// <returns></returns>
          public bool Update(PaisBDO PaisBDO)
          {
              PaisDAL PaisDAL = new PaisDAL();
              return PaisDAL.Update(PaisBDO);
           }

          /// <summary>
          ///Elimina un registro.
          /// </summary>
          /// <returns></returns>
          public bool Delete(int PaisID)
          {
              PaisDAL PaisDAL = new PaisDAL();
              return PaisDAL.Delete(PaisID);
          }
  }
}
