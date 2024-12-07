export class Inscripcion {

  public InscripcionID: number;
  public EmpresaID: number;
  public EstimuloID: number;
  public Codigo: string;
  public Estimulo: string;
  public Radicado: string;
  public TipoID: number;
  public Tipo: string;
  public Nombre: string;
  public TipoDocId: string;
  public DocId: string;
  public TelefonoMovil: string;
  public CorreoElectronico: string;
  public NumIntegrantes: number;
  public FechaHora: string;
  public Titulo: string;


    constructor() {
      this.InscripcionID = 0;
      this.EmpresaID = 0;
      this.EstimuloID = 0;
      this.Codigo = '';
      this.Estimulo = '';
      this.Radicado = '';
      this.TipoID = 0;
      this.Tipo = '';
      this.Nombre = '';
      this.TipoDocId = '';
      this.DocId = '';
      this.TelefonoMovil = '';
      this.CorreoElectronico = '';
      this.NumIntegrantes = 0;
      this.FechaHora = ''
      this.Titulo = '';
    }
  }
