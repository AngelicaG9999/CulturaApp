export class InfoProyecto {

    public InfoProyectoID: number;
    public EmpresaID: number;
    public InscripcionID: number;
    public Titulo: string;
    public LineaID: number;
    public ProyectoUrl: string;
    public CurriculumUrl: string;
    public CedulaUrl: string;
    public ServiciosPublicosUrl: string;
    public RutUrl: string;
    public CertificadoVencindadUrl: string;
    public AutorizacionMenoresUrl: string;
    public DeclaracionJuramentadaUrl: string;
    public MaquetaUrl: string;
    public CamaraDeComercioUrl: string;

    //Inscripcion
    public Radicado: string;
    public FechaHora: string;

    //Representante
    public Nombre: string;
    public Apellido: string;
    public CorreoElectronico: string;

    public Linea: string;
    public Area: string;
    public Modalidad: string;

    constructor() {
      this.InfoProyectoID = 0;
      this.EmpresaID = 0;
      this.InscripcionID = 0;
      this.Titulo = '';
      this.LineaID = 0;
      this.ProyectoUrl = '';
      this.CurriculumUrl = '';
      this.CedulaUrl = '';
      this.ServiciosPublicosUrl = '';
      this.RutUrl = '';
      this.CertificadoVencindadUrl = '';
      this.AutorizacionMenoresUrl = '';
      this.DeclaracionJuramentadaUrl = '';
      this.MaquetaUrl = '';
      this.CamaraDeComercioUrl = '';

      //Inscripción
      this.Radicado = '';
      this.FechaHora = '';

      //Representante
      this.Nombre = '';
      this.Apellido = '';
      this.CorreoElectronico = '';

      this.Linea = '';
      this.Area = '';
      this.Modalidad = '';
    }
  
  }
