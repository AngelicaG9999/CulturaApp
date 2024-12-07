
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using CulturApp.Utility;
using CulturApp.BDO.AdministracionDelSistema.ReglasGenerales.Seguridad;

namespace CulturApp.DAL.AdministracionDelSistema.ReglasGenerales.Seguridad
{

      public class UsuarioAutorizacionDAL
      {
          private DataTable _DataTable = null;

          /// <summary>
          /// Retorna todos los registros de la tabla.
          /// </summary>
          /// <returns></returns>
          public DataTable GetAll(UsuarioAutorizacionBDO UsuarioAutorizacion)
          {
              IDBManager dbManager = new DBManager(DataBase.CulturApp);
              DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
              try
              {
                  dbManager.Open();
                  //dbManager.CreateParameters(5);
                  //dbManager.AddParameters(0, "UsuarioAutorizacionID",DbTypeValues.GetValue("Int64",UsuarioAutorizacion.UsuarioAutorizacionID), ParameterDirection.Input, DbType.Int64);
                  //dbManager.AddParameters(1, "ClienteID",DbTypeValues.GetValue("Int64",UsuarioAutorizacion.ClienteID), ParameterDirection.Input, DbType.Int64);
                  //dbManager.AddParameters(2, "UsuarioID",DbTypeValues.GetValue("Int64",UsuarioAutorizacion.UsuarioID), ParameterDirection.Input, DbType.Int64);
                  //dbManager.AddParameters(3, "MenuID",DbTypeValues.GetValue("Int64",UsuarioAutorizacion.MenuID), ParameterDirection.Input, DbType.Int64);
                  //dbManager.AddParameters(4, "AutorizacionID",DbTypeValues.GetValue("Int64",UsuarioAutorizacion.AutorizacionID), ParameterDirection.Input, DbType.Int64);
                  _DataTable = new DataTable();
                  _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspUsuarioAutorizacionFindAll");
              }
              catch (Exception ex)
              {
                  string message = "Se ha presentado una excepción inesperada. Descripción: " +  ex.Message;
                   throw new AppException(message, ex);
              }
              finally
              {
                  dbManager.Dispose();
              }
          return _DataTable;
        }

          public DataTable AutorizacionObjeto(long EmpresaID, long UsuarioID, string ObjetoUrl)
          {
              IDBManager dbManager = new DBManager(DataBase.CulturApp);
              DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
              try
              {
                  dbManager.Open();
                  dbManager.CreateParameters(3);
                  dbManager.AddParameters(0, "ClienteID", DbTypeValues.GetValue("Int64", EmpresaID), ParameterDirection.Input, DbType.Int64);
                  dbManager.AddParameters(1, "UsuarioID", DbTypeValues.GetValue("Int64", UsuarioID), ParameterDirection.Input, DbType.Int64);
                  dbManager.AddParameters(2, "ObjetoUrl", DbTypeValues.GetValue("String", ObjetoUrl), ParameterDirection.Input, DbType.String);
                  _DataTable = new DataTable();
                  _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspAutorizacionObjeto");
              }
              catch (Exception ex)
              {
                  string message = "Se ha presentado una excepción inesperada. " + ex.Message;
                  throw new AppException(message, ex);
              }
              finally
              {
                  dbManager.Dispose();
              }
              return _DataTable;
          }

          /// <summary>
          /// Retorna un registro filtrando por ID.
          /// </summary>
          /// <returns></returns>
          public DataTable GetByID(UsuarioAutorizacionBDO UsuarioAutorizacion)
          {
              IDBManager dbManager = new DBManager(DataBase.CulturApp);
              DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
              try
              {
                  dbManager.Open();
                  dbManager.CreateParameters(1);
                  dbManager.AddParameters(0, "UsuarioAutorizacionID",DbTypeValues.GetValue("Int64",UsuarioAutorizacion.UsuarioAutorizacionID), ParameterDirection.Input, DbType.Int64);
                  _DataTable = new DataTable();
                  _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspUsuarioAutorizacionFindById");
              }
              catch (Exception ex)
              {
                  string message = "Se ha presentado una excepción inesperada. Descripción: " +  ex.Message;
                   throw new AppException(message, ex);
              }
              finally
              {
                  dbManager.Dispose();
              }
          return _DataTable;
        }

          /// <summary>
          ///Agrega un nuevo registro.
          /// </summary>
          /// <returns></returns>
          public int Add(UsuarioAutorizacionBDO UsuarioAutorizacion)
          {
              IDBManager dbManager = new DBManager(DataBase.CulturApp);
              DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
              object returnValue=0;
              try
              {
                  dbManager.Open();
                  dbManager.CreateParameters(5);
                  dbManager.AddParameters(0, "UsuarioAutorizacionID",DbTypeValues.GetValue("Int64",UsuarioAutorizacion.UsuarioAutorizacionID), ParameterDirection.Input, DbType.Int64);
                  dbManager.AddParameters(1, "ClienteID",DbTypeValues.GetValue("Int64",UsuarioAutorizacion.EmpresaID), ParameterDirection.Input, DbType.Int64);
                  dbManager.AddParameters(2, "UsuarioID",DbTypeValues.GetValue("Int64",UsuarioAutorizacion.UsuarioID), ParameterDirection.Input, DbType.Int64);
                  dbManager.AddParameters(3, "MenuID",DbTypeValues.GetValue("Int64",UsuarioAutorizacion.MenuID), ParameterDirection.Input, DbType.Int64);
                  dbManager.AddParameters(4, "AutorizacionID",DbTypeValues.GetValue("Int64",UsuarioAutorizacion.AutorizacionID), ParameterDirection.Input, DbType.Int64);
                  returnValue = Convert.ToString(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspUsuarioAutorizacionAdd",0));
              }
              catch (Exception ex)
              {
                  string message = "No se ha podido crear el registro. Descripción: " +  ex.Message;
                   throw new AppException(message, ex);
              }
              finally
              {
                  dbManager.Dispose();
              }
              return Convert.ToInt32(returnValue);
            }

          /// <summary>
          ///Actualiza un registro.
          /// </summary>
          /// <returns></returns>
        public bool Update(UsuarioAutorizacionBDO UsuarioAutorizacion)
        {
            IDBManager dbManager = new DBManager(DataBase.CulturApp);
            DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(5);
                dbManager.AddParameters(0, "UsuarioAutorizacionID",DbTypeValues.GetValue("Int64",UsuarioAutorizacion.UsuarioAutorizacionID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(1, "ClienteID",DbTypeValues.GetValue("Int64",UsuarioAutorizacion.EmpresaID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(2, "UsuarioID",DbTypeValues.GetValue("Int64",UsuarioAutorizacion.UsuarioID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(3, "MenuID",DbTypeValues.GetValue("Int64",UsuarioAutorizacion.MenuID), ParameterDirection.Input, DbType.Int64);
                dbManager.AddParameters(4, "AutorizacionID",DbTypeValues.GetValue("Int64",UsuarioAutorizacion.AutorizacionID), ParameterDirection.Input, DbType.Int64);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspUsuarioAutorizacionEdit");
            }
            catch (Exception ex)
            {
                string message = "No se ha podido actualizar el registro. Descripción: " +  ex.Message;
                throw new AppException(message, ex);
            }
            finally
            {
                dbManager.Dispose();
            }
            return true;
        }

          /// <summary>
          ///Elimina un registro.
          /// </summary>
          /// <returns></returns>
          public bool Delete(UsuarioAutorizacionBDO UsuarioAutorizacion)
          {
              IDBManager dbManager = new DBManager(DataBase.CulturApp);
              DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
              try
              {
                  dbManager.Open();
                  dbManager.CreateParameters(1);
                  dbManager.AddParameters(0, "UsuarioAutorizacionID",DbTypeValues.GetValue("Int64",UsuarioAutorizacion.UsuarioAutorizacionID), ParameterDirection.Input, DbType.Int64);
                  dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspUsuarioAutorizacionDelete");
              }
              catch (Exception ex)
              {
                      string message = "No se ha podido eliminar el registro. Descripción: " +  ex.Message;
                       throw new AppException(message, ex);
              }
              finally
              {
                  dbManager.Dispose();
              }
              return true;
      }
  }
}
