
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CulturApp.BDO.AdministracionDelSistema.ReglasGenerales.ReglasDelSistema
{
    [DataContract]
    [Serializable]
    public class LogErrorBDO
    {

        #region ".:: PROPIEDADES ::."

        [DataMember]
        public long LogErrorID { get; set; }

        [DataMember]
        public long EmpresaID { get; set; }

        [DataMember]
        public long TerceroID { get; set; }

        [DataMember]
        public long UsuarioID { get; set; }

        [DataMember]
        public string Ip { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Host { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public string ExceptionMessage { get; set; }

        [DataMember]
        public string ExceptionSource { get; set; }

        [DataMember]
        public string ExceptionStackTrace { get; set; }

        [DataMember]
        public string ExceptionHelpLink { get; set; }

        [DataMember]
        public string ExceptionHResult { get; set; }

        [DataMember]
        public string InnerExceptionMessage { get; set; }

        [DataMember]
        public string InnerExceptionSource { get; set; }

        [DataMember]
        public string InnerExceptionStackTrace { get; set; }

        [DataMember]
        public string InnerExceptionHelpLink { get; set; }

        [DataMember]
        [Display(ShortName = "Inner Exception HResult")]
        public string InnerExceptionHResult { get; set; }


        [DataMember]
        public string Empresa { get; set; }

        [DataMember]
        public string Tercero { get; set; }

        [DataMember]
        public string Usuario { get; set; }

        #endregion

        #region ".:: CONSTRUCTORES ::."
        #endregion



    }
}
