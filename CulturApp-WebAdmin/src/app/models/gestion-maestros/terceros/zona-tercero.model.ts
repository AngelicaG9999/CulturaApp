
export class ZonaTercero {

  public ZonaTerceroID: number;
  public EmpresaID: number;
  public Nombre: string;
  public Descripcion: string;
  public Predeterminado: boolean;
  public Activo: boolean;
  public Empresa: string;

  constructor() {
      this.ZonaTerceroID = 0;
      this.EmpresaID = 0;
      this.Nombre = '';
      this.Descripcion = '';
      this.Predeterminado = false;
      this.Activo = true;
      this.Empresa = '';
  }

}
