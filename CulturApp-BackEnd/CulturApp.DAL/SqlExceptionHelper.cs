using System.Data.SqlClient;

namespace CulturApp.DAL
{
    public static class SqlExceptionHelper
    {

        public static string GetSqlDescription(SqlException sqlException)
        {
            string Message;

            switch (sqlException.Number)
            {
                case -1:
                case 2:
                    Message = "Se ha producido un error al establecer una conexión con el servidor.";
                    break;
                case -2:
                    Message = "El período de tiempo de espera transcurrido antes de la finalización de la operación o el servidor no responde..";
                    break;
                case 21:
                    Message = "Ha ocurrido un error fatal.";
                    break;
                case 53:
                    Message = "Error al establecer una conexión de base de datos.";
                    break;
                case 547:
                    Message = "Violación de ForeignKey.";
                    break;
                case 2601:
                    Message = "El registro ya existe (PRIMARY KEY).";
                    break;
                case 2627:
                    Message = "El registro ya existe (UNIQUE KEY / CONSTRIANT).";
                    break;
                case 4060:
                    Message = "Base de datos invalida.";
                    break;
                case 18456:
                    Message = "Error de inicio de sesión.";
                    break;
                default:
                    Message = sqlException.Message.ToString();
                    break;
            }

            return Message;
        }

    }

}
