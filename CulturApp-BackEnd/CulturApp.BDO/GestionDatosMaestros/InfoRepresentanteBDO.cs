
using System;
using System.Data;
using System.Runtime.Serialization;

namespace CulturApp.BDO.GestionDatosMaestros
{

    /// <summary>
    /// InfoRepresentante.
    /// </summary>
    public class InfoRepresentanteBDO
    {

        #region ".:: PROPIEDADES ::."

        public long InfoRepresentanteID { get; set; }

        public long EmpresaID { get; set; }

        public long InscripcionID { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string TipoDocId { get; set; }

        public string DocId { get; set; }

        public string FechaNacimiento { get; set; }

        public string TelefonoFijo { get; set; }

        public string TelefonoMovil { get; set; }

        public string Ciudad { get; set; }

        public string Comuna { get; set; }

        public string Barrio { get; set; }

        public string Direccion { get; set; }

        public string Genero { get; set; }

        public string Sector { get; set; }

        public string GrupoPoblacional { get; set; }

        public string Discapacidades { get; set; }

        public string CorreoElectronico { get; set; }

        public string RedesSociales { get; set; }

        public string NivelEducativo { get; set; }

        public string NivelFormacionAC { get; set; }

        public string AreasAC { get; set; }

        public string LineaMasTrayectoria { get; set; }

        public string AniosExperiencia { get; set; }

        public string ActividadEconomica { get; set; }

        public string LaboraActualmente { get; set; }

        public string DepencenciaEconomica { get; set; }

        public string RangoSalarial { get; set; }

        public string PoseeRut { get; set; }

        public string AfiliadoSegSocial { get; set; }

        public string Eps { get; set; }

        public string ProgramaEstado { get; set; }

        #endregion

        #region ".:: CONSTRUCTORES ::."

        public InfoRepresentanteBDO()
        {
            InfoRepresentanteID = 0;
            EmpresaID = 0;
            InscripcionID = 0;
            Nombre = null;
            Apellido = null;
            TipoDocId = null;
            DocId = null;
            FechaNacimiento = null;
            TelefonoFijo = null;
            TelefonoMovil = null;
            Ciudad = null;
            Comuna = null;
            Barrio = null;
            Direccion = null;
            Genero = null;
            Sector = null;
            GrupoPoblacional = null;
            Discapacidades = null;
            CorreoElectronico = null;
            RedesSociales = null;
            NivelEducativo = null;
            NivelFormacionAC = null;
            AreasAC = null;
            LineaMasTrayectoria = null;
            AniosExperiencia = null;
            ActividadEconomica = null;
            LaboraActualmente = null;
            DepencenciaEconomica = null;
            RangoSalarial = null;
            PoseeRut = null;
            AfiliadoSegSocial = null;
            Eps = null;
            ProgramaEstado = null;
        }

        public InfoRepresentanteBDO(DataRow _DataRow)
        {
            InfoRepresentanteID = Convert.ToInt64((_DataRow["InfoRepresentanteID"] == System.DBNull.Value ? 0 : _DataRow["InfoRepresentanteID"]));
            EmpresaID = Convert.ToInt64((_DataRow["EmpresaID"] == System.DBNull.Value ? 0 : _DataRow["EmpresaID"]));
            InscripcionID = Convert.ToInt64((_DataRow["InscripcionID"] == System.DBNull.Value ? 0 : _DataRow["InscripcionID"]));
            Nombre = Convert.ToString((_DataRow["Nombre"] == System.DBNull.Value ? String.Empty : _DataRow["Nombre"]));
            Apellido = Convert.ToString((_DataRow["Apellido"] == System.DBNull.Value ? String.Empty : _DataRow["Apellido"]));
            TipoDocId = Convert.ToString((_DataRow["TipoDocId"] == System.DBNull.Value ? String.Empty : _DataRow["TipoDocId"]));
            DocId = Convert.ToString((_DataRow["DocId"] == System.DBNull.Value ? String.Empty : _DataRow["DocId"]));
            FechaNacimiento = Convert.ToString((_DataRow["FechaNacimiento"] == System.DBNull.Value ? String.Empty : _DataRow["FechaNacimiento"]));
            TelefonoFijo = Convert.ToString((_DataRow["TelefonoFijo"] == System.DBNull.Value ? String.Empty : _DataRow["TelefonoFijo"]));
            TelefonoMovil = Convert.ToString((_DataRow["TelefonoMovil"] == System.DBNull.Value ? String.Empty : _DataRow["TelefonoMovil"]));
            Ciudad = Convert.ToString((_DataRow["Ciudad"] == System.DBNull.Value ? String.Empty : _DataRow["Ciudad"]));
            Comuna = Convert.ToString((_DataRow["Comuna"] == System.DBNull.Value ? String.Empty : _DataRow["Comuna"]));
            Barrio = Convert.ToString((_DataRow["Barrio"] == System.DBNull.Value ? String.Empty : _DataRow["Barrio"]));
            Direccion = Convert.ToString((_DataRow["Direccion"] == System.DBNull.Value ? String.Empty : _DataRow["Direccion"]));
            Genero = Convert.ToString((_DataRow["Genero"] == System.DBNull.Value ? String.Empty : _DataRow["Genero"]));
            Sector = Convert.ToString((_DataRow["Sector"] == System.DBNull.Value ? String.Empty : _DataRow["Sector"]));
            GrupoPoblacional = Convert.ToString((_DataRow["GrupoPoblacional"] == System.DBNull.Value ? String.Empty : _DataRow["GrupoPoblacional"]));
            Discapacidades = Convert.ToString((_DataRow["Discapacidades"] == System.DBNull.Value ? String.Empty : _DataRow["Discapacidades"]));
            CorreoElectronico = Convert.ToString((_DataRow["CorreoElectronico"] == System.DBNull.Value ? String.Empty : _DataRow["CorreoElectronico"]));
            RedesSociales = Convert.ToString((_DataRow["RedesSociales"] == System.DBNull.Value ? String.Empty : _DataRow["RedesSociales"]));
            NivelEducativo = Convert.ToString((_DataRow["NivelEducativo"] == System.DBNull.Value ? String.Empty : _DataRow["NivelEducativo"]));
            NivelFormacionAC = Convert.ToString((_DataRow["NivelFormacionAC"] == System.DBNull.Value ? String.Empty : _DataRow["NivelFormacionAC"]));
            AreasAC = Convert.ToString((_DataRow["AreasAC"] == System.DBNull.Value ? String.Empty : _DataRow["AreasAC"]));
            LineaMasTrayectoria = Convert.ToString((_DataRow["LineaMasTrayectoria"] == System.DBNull.Value ? String.Empty : _DataRow["LineaMasTrayectoria"]));
            AniosExperiencia = Convert.ToString((_DataRow["AniosExperiencia"] == System.DBNull.Value ? String.Empty : _DataRow["AniosExperiencia"]));
            ActividadEconomica = Convert.ToString((_DataRow["ActividadEconomica"] == System.DBNull.Value ? String.Empty : _DataRow["ActividadEconomica"]));
            LaboraActualmente = Convert.ToString((_DataRow["LaboraActualmente"] == System.DBNull.Value ? String.Empty : _DataRow["LaboraActualmente"]));
            DepencenciaEconomica = Convert.ToString((_DataRow["DepencenciaEconomica"] == System.DBNull.Value ? String.Empty : _DataRow["DepencenciaEconomica"]));
            RangoSalarial = Convert.ToString((_DataRow["RangoSalarial"] == System.DBNull.Value ? String.Empty : _DataRow["RangoSalarial"]));
            PoseeRut = Convert.ToString((_DataRow["PoseeRut"] == System.DBNull.Value ? String.Empty : _DataRow["PoseeRut"]));
            AfiliadoSegSocial = Convert.ToString((_DataRow["AfiliadoSegSocial"] == System.DBNull.Value ? String.Empty : _DataRow["AfiliadoSegSocial"]));
            Eps = Convert.ToString((_DataRow["Eps"] == System.DBNull.Value ? String.Empty : _DataRow["Eps"]));
            ProgramaEstado = Convert.ToString((_DataRow["ProgramaEstado"] == System.DBNull.Value ? String.Empty : _DataRow["ProgramaEstado"]));
        }

        #endregion

    }
}
