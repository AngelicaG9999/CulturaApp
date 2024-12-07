
using System;
using System.Data;
using System.Runtime.Serialization;

namespace CulturApp.BDO.GestionDatosMaestros
{

    /// <summary>
    /// InfoProyecto.
    /// </summary>
    public class InfoProyectoBDO
    {

        #region ".:: PROPIEDADES ::."

        public long InfoProyectoID { get; set; }

        public long EmpresaID { get; set; }

        public long InscripcionID { get; set; }

        public string Titulo { get; set; }

        public long LineaID { get; set; }

        public string ProyectoUrl { get; set; }

        public string CurriculumUrl { get; set; }

        public string CedulaUrl { get; set; }

        public string ServiciosPublicosUrl { get; set; }

        public string RutUrl { get; set; }

        public string CertificadoVencindadUrl { get; set; }

        public string AutorizacionMenoresUrl { get; set; }

        public string DeclaracionJuramentadaUrl { get; set; }

        public string MaquetaUrl { get; set; }

        public string CamaraDeComercioUrl { get; set; }


        //Inscripcion
        public string Radicado { get; set; }
        public string FechaHora { get; set; }


        //Representante
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }


        public string Linea { get; set; }
        public string Area { get; set; }
        public string Modalidad { get; set; }


        public string CertificacionInmuebleUrl { get; set; }
        #endregion

        #region ".:: CONSTRUCTORES ::."

        public InfoProyectoBDO()
        {
            InfoProyectoID = 0;
            EmpresaID = 0;
            InscripcionID = 0;
            Titulo = null;
            LineaID = 0;
            ProyectoUrl = null;
            CurriculumUrl = null;
            CedulaUrl = null;
            ServiciosPublicosUrl = null;
            RutUrl = null;
            CertificadoVencindadUrl = null;
            AutorizacionMenoresUrl = null;
            DeclaracionJuramentadaUrl = null;
            MaquetaUrl = null;
            CamaraDeComercioUrl = null;

            //Inscripción
            Radicado = null;
            FechaHora = null;

            //Representante
            Nombre = null;
            Apellido = null;
            CorreoElectronico = null;

            Linea = null;
            Area = null;
            Modalidad = null;

            CertificacionInmuebleUrl = null;
        }

        public InfoProyectoBDO(DataRow _DataRow)
        {
            InfoProyectoID = Convert.ToInt64((_DataRow["InfoProyectoID"] == System.DBNull.Value ? 0 : _DataRow["InfoProyectoID"]));
            EmpresaID = Convert.ToInt64((_DataRow["EmpresaID"] == System.DBNull.Value ? 0 : _DataRow["EmpresaID"]));
            InscripcionID = Convert.ToInt64((_DataRow["InscripcionID"] == System.DBNull.Value ? 0 : _DataRow["InscripcionID"]));
            Titulo = Convert.ToString((_DataRow["Titulo"] == System.DBNull.Value ? String.Empty : _DataRow["Titulo"]));
            LineaID = Convert.ToInt64((_DataRow["LineaID"] == System.DBNull.Value ? 0 : _DataRow["LineaID"]));
            ProyectoUrl = Convert.ToString((_DataRow["ProyectoUrl"] == System.DBNull.Value ? String.Empty : _DataRow["ProyectoUrl"]));
            CurriculumUrl = Convert.ToString((_DataRow["CurriculumUrl"] == System.DBNull.Value ? String.Empty : _DataRow["CurriculumUrl"]));
            CedulaUrl = Convert.ToString((_DataRow["CedulaUrl"] == System.DBNull.Value ? String.Empty : _DataRow["CedulaUrl"]));
            ServiciosPublicosUrl = Convert.ToString((_DataRow["ServiciosPublicosUrl"] == System.DBNull.Value ? String.Empty : _DataRow["ServiciosPublicosUrl"]));
            RutUrl = Convert.ToString((_DataRow["RutUrl"] == System.DBNull.Value ? String.Empty : _DataRow["RutUrl"]));
            CertificadoVencindadUrl = Convert.ToString((_DataRow["CertificadoVencindadUrl"] == System.DBNull.Value ? String.Empty : _DataRow["CertificadoVencindadUrl"]));
            AutorizacionMenoresUrl = Convert.ToString((_DataRow["AutorizacionMenoresUrl"] == System.DBNull.Value ? String.Empty : _DataRow["AutorizacionMenoresUrl"]));
            DeclaracionJuramentadaUrl = Convert.ToString((_DataRow["DeclaracionJuramentadaUrl"] == System.DBNull.Value ? String.Empty : _DataRow["DeclaracionJuramentadaUrl"]));
            MaquetaUrl = Convert.ToString((_DataRow["MaquetaUrl"] == System.DBNull.Value ? String.Empty : _DataRow["MaquetaUrl"]));
            CamaraDeComercioUrl = Convert.ToString((_DataRow["CamaraDeComercioUrl"] == System.DBNull.Value ? String.Empty : _DataRow["CamaraDeComercioUrl"]));

            //Inscripción
            Radicado = Convert.ToString((_DataRow["Radicado"] == System.DBNull.Value ? String.Empty : _DataRow["Radicado"]));
            FechaHora = Convert.ToString((_DataRow["FechaHora"] == System.DBNull.Value ? String.Empty : _DataRow["FechaHora"]));

            //Representante
            Nombre = Convert.ToString((_DataRow["Nombre"] == System.DBNull.Value ? String.Empty : _DataRow["Nombre"]));
            Apellido = Convert.ToString((_DataRow["Apellido"] == System.DBNull.Value ? String.Empty : _DataRow["Apellido"]));
            CorreoElectronico = Convert.ToString((_DataRow["CorreoElectronico"] == System.DBNull.Value ? String.Empty : _DataRow["CorreoElectronico"]));

            Linea = Convert.ToString((_DataRow["Linea"] == System.DBNull.Value ? String.Empty : _DataRow["Linea"]));
            Area = Convert.ToString((_DataRow["Area"] == System.DBNull.Value ? String.Empty : _DataRow["Area"]));
            Modalidad = Convert.ToString((_DataRow["Modalidad"] == System.DBNull.Value ? String.Empty : _DataRow["Modalidad"]));

            CertificacionInmuebleUrl = Convert.ToString((_DataRow["CertificacionInmuebleUrl"] == System.DBNull.Value ? String.Empty : _DataRow["CertificacionInmuebleUrl"]));
        }

        #endregion

    }
}
