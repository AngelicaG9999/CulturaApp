
export class Tercero {

    public TerceroID: number;
    public EmpresaID: number;
    public NumeroIdentificacion: string;
    public DigitoVerificacion: string;
    public Codigo: string;
    public Iniciales: string;
    public Nombre: string;
    public Apellido: string;
    public RazonSocial: string;
    public RazonComercial: string;
    public NombreCompleto: string;
    public Cliente: boolean;
    public Empleado: boolean;
    public Proveedor: boolean;
    public RepComercial: boolean;
    public Activo: boolean;
    public TipoIdentificacionID: number;
    public Empresa: string;
    public TipoIdentificacion: string;
    public Grupo: string;
    public Email: string;
    public Foto: string;

    constructor() {
      this.TerceroID = 0;
      this.EmpresaID = 0;
      this.NumeroIdentificacion = '';
      this.DigitoVerificacion = '';
      this.Codigo = '';
      this.Iniciales = '';
      this.Nombre = '';
      this.Apellido = '';
      this.RazonSocial = '';
      this.RazonComercial = '';
      this.NombreCompleto = '';
      this.Cliente = false;
      this.Empleado = false;
      this.Proveedor = false;
      this.RepComercial = false;
      this.Activo = true;
      this.TipoIdentificacionID = 0;
      this.Empresa = '';
      this.TipoIdentificacion = '';
      this.Grupo = '';
      this.Email = '';
      this.Foto = '';
    }

}
