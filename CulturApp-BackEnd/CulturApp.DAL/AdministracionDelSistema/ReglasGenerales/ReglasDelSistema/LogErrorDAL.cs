using System;
using System.Data;
using System.Data.SqlTypes;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using CulturApp.Utility;
using CulturApp.BDO.AdministracionDelSistema.ReglasGenerales.ReglasDelSistema;

namespace CulturApp.DAL.AdministracionDelSistema.ReglasGenerales.ReglasDelSistema
{

      public class LogErrorDAL
      {
          private DataTable _DataTable = null;

          /// <summary>
          /// Retorna todos los registros de la tabla.
          /// </summary>
          /// <returns></returns>
          public DataTable GetAll(LogErrorBDO LogError)
          {
              IDBManager dbManager = new DBManager(DataBase.CulturApp);
              DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
              try
              {
                  dbManager.Open();
                  //dbManager.CreateParameters(18);
                  //dbManager.AddParameters(0, "LogErrorID",DbTypeValues.GetValue("Int64",LogError.LogErrorID), ParameterDirection.Input, DbType.Int64);
                  //dbManager.AddParameters(1, "ClienteID",DbTypeValues.GetValue("Int64",LogError.ClienteID), ParameterDirection.Input, DbType.Int64);
                  //dbManager.AddParameters(2, "TerceroID",DbTypeValues.GetValue("Int64",LogError.TerceroID), ParameterDirection.Input, DbType.Int64);
                  //dbManager.AddParameters(3, "UsuarioID",DbTypeValues.GetValue("Int64",LogError.UsuarioID), ParameterDirection.Input, DbType.Int64);
                  //dbManager.AddParameters(4, "Ip",DbTypeValues.GetValue("String",LogError.Ip), ParameterDirection.Input, DbType.String);
                  //dbManager.AddParameters(5, "UserName",DbTypeValues.GetValue("String",LogError.UserName), ParameterDirection.Input, DbType.String);
                  //dbManager.AddParameters(6, "Host",DbTypeValues.GetValue("String",LogError.Host), ParameterDirection.Input, DbType.String);
                  //dbManager.AddParameters(7, "Fecha",DbTypeValues.GetValue("DateTime",LogError.Fecha), ParameterDirection.Input, DbType.DateTime);
                  //dbManager.AddParameters(8, "ExceptionMessage",DbTypeValues.GetValue("String",LogError.ExceptionMessage), ParameterDirection.Input, DbType.String);
                  //dbManager.AddParameters(9, "ExceptionSource",DbTypeValues.GetValue("String",LogError.ExceptionSource), ParameterDirection.Input, DbType.String);
                  //dbManager.AddParameters(10, "ExceptionStackTrace",DbTypeValues.GetValue("String",LogError.ExceptionStackTrace), ParameterDirection.Input, DbType.String);
                  //dbManager.AddParameters(11, "ExceptionHelpLink",DbTypeValues.GetValue("String",LogError.ExceptionHelpLink), ParameterDirection.Input, DbType.String);
                  //dbManager.AddParameters(12, "ExceptionHResult",DbTypeValues.GetValue("String",LogError.ExceptionHResult), ParameterDirection.Input, DbType.String);
                  //dbManager.AddParameters(13, "InnerExceptionMessage",DbTypeValues.GetValue("String",LogError.InnerExceptionMessage), ParameterDirection.Input, DbType.String);
                  //dbManager.AddParameters(14, "InnerExceptionSource",DbTypeValues.GetValue("String",LogError.InnerExceptionSource), ParameterDirection.Input, DbType.String);
                  //dbManager.AddParameters(15, "InnerExceptionStackTrace",DbTypeValues.GetValue("String",LogError.InnerExceptionStackTrace), ParameterDirection.Input, DbType.String);
                  //dbManager.AddParameters(16, "InnerExceptionHelpLink",DbTypeValues.GetValue("String",LogError.InnerExceptionHelpLink), ParameterDirection.Input, DbType.String);
                  //dbManager.AddParameters(17, "InnerExceptionHResult",DbTypeValues.GetValue("String",LogError.InnerExceptionHResult), ParameterDirection.Input, DbType.String);
                  _DataTable = new DataTable();
                  _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspLogErrorFindAll");
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
          /// Retorna un registro filtrando por ID.
          /// </summary>
          /// <returns></returns>
          public DataTable GetByID(LogErrorBDO LogError)
          {
              IDBManager dbManager = new DBManager(DataBase.CulturApp);
              DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
              try
              {
                  dbManager.Open();
                  dbManager.CreateParameters(1);
                  dbManager.AddParameters(0, "LogErrorID",DbTypeValues.GetValue("Int64",LogError.LogErrorID), ParameterDirection.Input, DbType.Int64);                  
                  _DataTable = new DataTable();
                  _DataTable = dbManager.ExecuteDataTable(CommandType.StoredProcedure, "uspLogErrorFindById");
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
          public int Add(LogErrorBDO LogError)
          {
              IDBManager dbManager = new DBManager(DataBase.CulturApp);
              DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
              object returnValue=0;
              try
              {
                  dbManager.Open();
                  dbManager.CreateParameters(18);
                  dbManager.AddParameters(0, "LogErrorID",DbTypeValues.GetValue("Int64",LogError.LogErrorID), ParameterDirection.Input, DbType.Int64);
                  dbManager.AddParameters(1, "ClienteID",DbTypeValues.GetValue("Int64",LogError.EmpresaID), ParameterDirection.Input, DbType.Int64);
                  dbManager.AddParameters(2, "TerceroID",DbTypeValues.GetValue("Int64",LogError.TerceroID), ParameterDirection.Input, DbType.Int64);
                  dbManager.AddParameters(3, "UsuarioID",DbTypeValues.GetValue("Int64",LogError.UsuarioID), ParameterDirection.Input, DbType.Int64);
                  dbManager.AddParameters(4, "Ip",DbTypeValues.GetValue("String",LogError.Ip), ParameterDirection.Input, DbType.String);
                  dbManager.AddParameters(5, "UserName",DbTypeValues.GetValue("String",LogError.UserName), ParameterDirection.Input, DbType.String);
                  dbManager.AddParameters(6, "Host",DbTypeValues.GetValue("String",LogError.Host), ParameterDirection.Input, DbType.String);
                  dbManager.AddParameters(7, "Fecha",DbTypeValues.GetValue("DateTime",LogError.Fecha), ParameterDirection.Input, DbType.DateTime);
                  dbManager.AddParameters(8, "ExceptionMessage",DbTypeValues.GetValue("String",LogError.ExceptionMessage), ParameterDirection.Input, DbType.String);
                  dbManager.AddParameters(9, "ExceptionSource",DbTypeValues.GetValue("String",LogError.ExceptionSource), ParameterDirection.Input, DbType.String);
                  dbManager.AddParameters(10, "ExceptionStackTrace",DbTypeValues.GetValue("String",LogError.ExceptionStackTrace), ParameterDirection.Input, DbType.String);
                  dbManager.AddParameters(11, "ExceptionHelpLink",DbTypeValues.GetValue("String",LogError.ExceptionHelpLink), ParameterDirection.Input, DbType.String);
                  dbManager.AddParameters(12, "ExceptionHResult",DbTypeValues.GetValue("String",LogError.ExceptionHResult), ParameterDirection.Input, DbType.String);
                  dbManager.AddParameters(13, "InnerExceptionMessage",DbTypeValues.GetValue("String",LogError.InnerExceptionMessage), ParameterDirection.Input, DbType.String);
                  dbManager.AddParameters(14, "InnerExceptionSource",DbTypeValues.GetValue("String",LogError.InnerExceptionSource), ParameterDirection.Input, DbType.String);
                  dbManager.AddParameters(15, "InnerExceptionStackTrace",DbTypeValues.GetValue("String",LogError.InnerExceptionStackTrace), ParameterDirection.Input, DbType.String);
                  dbManager.AddParameters(16, "InnerExceptionHelpLink",DbTypeValues.GetValue("String",LogError.InnerExceptionHelpLink), ParameterDirection.Input, DbType.String);
                  dbManager.AddParameters(17, "InnerExceptionHResult",DbTypeValues.GetValue("String",LogError.InnerExceptionHResult), ParameterDirection.Input, DbType.String);
                  returnValue = Convert.ToString(dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspLogErrorAdd",0));
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
              return Convert.ToInt32(returnValue);
            }

          /// <summary>
          ///Actualiza un registro.
          /// </summary>
          /// <returns></returns>
          public bool Update(LogErrorBDO LogError)
          {
              IDBManager dbManager = new DBManager(DataBase.CulturApp);
              DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
          try
          {
              dbManager.Open();
              dbManager.CreateParameters(18);
                  dbManager.AddParameters(0, "LogErrorID",DbTypeValues.GetValue("Int64",LogError.LogErrorID), ParameterDirection.Input, DbType.Int64);
                  dbManager.AddParameters(1, "ClienteID",DbTypeValues.GetValue("Int64",LogError.EmpresaID), ParameterDirection.Input, DbType.Int64);
                  dbManager.AddParameters(2, "TerceroID",DbTypeValues.GetValue("Int64",LogError.TerceroID), ParameterDirection.Input, DbType.Int64);
                  dbManager.AddParameters(3, "UsuarioID",DbTypeValues.GetValue("Int64",LogError.UsuarioID), ParameterDirection.Input, DbType.Int64);
                  dbManager.AddParameters(4, "Ip",DbTypeValues.GetValue("String",LogError.Ip), ParameterDirection.Input, DbType.String);
                  dbManager.AddParameters(5, "UserName",DbTypeValues.GetValue("String",LogError.UserName), ParameterDirection.Input, DbType.String);
                  dbManager.AddParameters(6, "Host",DbTypeValues.GetValue("String",LogError.Host), ParameterDirection.Input, DbType.String);
                  dbManager.AddParameters(7, "Fecha",DbTypeValues.GetValue("DateTime",LogError.Fecha), ParameterDirection.Input, DbType.DateTime);
                  dbManager.AddParameters(8, "ExceptionMessage",DbTypeValues.GetValue("String",LogError.ExceptionMessage), ParameterDirection.Input, DbType.String);
                  dbManager.AddParameters(9, "ExceptionSource",DbTypeValues.GetValue("String",LogError.ExceptionSource), ParameterDirection.Input, DbType.String);
                  dbManager.AddParameters(10, "ExceptionStackTrace",DbTypeValues.GetValue("String",LogError.ExceptionStackTrace), ParameterDirection.Input, DbType.String);
                  dbManager.AddParameters(11, "ExceptionHelpLink",DbTypeValues.GetValue("String",LogError.ExceptionHelpLink), ParameterDirection.Input, DbType.String);
                  dbManager.AddParameters(12, "ExceptionHResult",DbTypeValues.GetValue("String",LogError.ExceptionHResult), ParameterDirection.Input, DbType.String);
                  dbManager.AddParameters(13, "InnerExceptionMessage",DbTypeValues.GetValue("String",LogError.InnerExceptionMessage), ParameterDirection.Input, DbType.String);
                  dbManager.AddParameters(14, "InnerExceptionSource",DbTypeValues.GetValue("String",LogError.InnerExceptionSource), ParameterDirection.Input, DbType.String);
                  dbManager.AddParameters(15, "InnerExceptionStackTrace",DbTypeValues.GetValue("String",LogError.InnerExceptionStackTrace), ParameterDirection.Input, DbType.String);
                  dbManager.AddParameters(16, "InnerExceptionHelpLink",DbTypeValues.GetValue("String",LogError.InnerExceptionHelpLink), ParameterDirection.Input, DbType.String);
                  dbManager.AddParameters(17, "InnerExceptionHResult",DbTypeValues.GetValue("String",LogError.InnerExceptionHResult), ParameterDirection.Input, DbType.String);
              dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspLogErrorEdit");
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
          return true;
        }

          /// <summary>
          ///Elimina un registro.
          /// </summary>
          /// <returns></returns>
          public bool Delete(LogErrorBDO LogError)
          {
              IDBManager dbManager = new DBManager(DataBase.CulturApp);
              DbTypeValues DbTypeValues = new DbTypeValues(DataProvider.SqlServer);
              try
              {
                  dbManager.Open();
                  dbManager.CreateParameters(18);
                  dbManager.AddParameters(0, "LogErrorID",DbTypeValues.GetValue("Int64",LogError.LogErrorID), ParameterDirection.Input, DbType.Int64);
                  dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "uspLogErrorDelete");
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
              return true;
      }
  }
}
