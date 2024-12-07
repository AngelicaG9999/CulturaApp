
export class TipoIdentificacion {

  public TipoIdentificacionID: number;
  public EmpresaID: number;
  public Nombre: string;
  public Descripcion: string;
  public DigitoVerificacion: boolean;
  public CodigoDian: string;
  public Predeterminado: boolean;
  public Activo: boolean;
  public Empresa: string;

  constructor() {
    this.TipoIdentificacionID = 0;
    this.EmpresaID = 0;
    this.Nombre = '';
    this.Descripcion = '';
    this.DigitoVerificacion = false;
    this.CodigoDian = '';
    this.Predeterminado = true;
    this.Activo = true;
    this.Empresa = '';
  }

}
