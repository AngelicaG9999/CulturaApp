
export class ClaseTercero {

  public ClaseTerceroID: number;
  public EmpresaID: number;
  public Nombre: string;
  public Descripcion: string;
  public Predeterminado: boolean;
  public Activo: boolean;
  public Empresa: string;

  constructor() {
    this.ClaseTerceroID = 0;
    this.EmpresaID = 0;
    this.Nombre = '';
    this.Descripcion = '';
    this.Predeterminado = true;
    this.Activo = true;
    this.Empresa = '';
  }

}
