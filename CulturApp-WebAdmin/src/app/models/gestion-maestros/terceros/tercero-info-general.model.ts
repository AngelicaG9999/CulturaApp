
export class TerceroInfoGeneral {

    public TerceroInfoGeneralID: number;
    public TerceroID: number;
    public GrupoTerceroID: number;
    public ZonaTerceroID: number;
    public ClaseTerceroID: number;
    public ClasificacionTerceroID: number;
    public TipoTerceroID: number;
    public Email: string;
    public WebSite: string;
    public Direccion: string;
    public Telefono: string;
    public Celular: string;
    public Fax: string;
    public LogoUrl: string;
    public FechaNacimiento: Date;
    public DiaNacimiento: number;
    public MesNacimiento: number;
    public AnoNacimiento: string;
    public Grupo: string;
    public Zona: string;
    public Clase: string;
    public Clasificacion: string;
    public Tipo: string;

    constructor() {
      this.TerceroInfoGeneralID = 0;
      this.TerceroID = 0;
      this.GrupoTerceroID = 0;
      this.ZonaTerceroID = 0;
      this.ClaseTerceroID = 0;
      this.ClasificacionTerceroID = 0;
      this.TipoTerceroID = 0;
      this.Email = '';
      this.WebSite = '';
      this.Direccion = '';
      this.Telefono = '';
      this.Celular = '';
      this.Fax = '';
      this.LogoUrl = '';
      this.FechaNacimiento = new Date();
      this.DiaNacimiento = 0;
      this.MesNacimiento = 0;
      this.AnoNacimiento = '';
      this.Grupo = '';
      this.Zona = '';
      this.Clase = '';
      this.Clasificacion = '';
      this.Tipo = '';

    }

}
