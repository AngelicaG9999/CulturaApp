
export class DataSession {

    public DataSessionID: number;
    public EmpresaID: number;
    public OrganizacionID: number;
    public TerceroID: number;
    public UsuarioID: number;
    public Ip: string;
    public UserName: string;
    public Host: string;
    public Fecha: Date;
    public Activo: boolean;
    public Acceso: boolean;
    public Organizacion: string;
    public Empresa: string;
    public CodEmpresa: string;
    public Nombre: string;
    public Apellido: string;
    public NombreCompleto: string;
    public Imprerora: string;
    public Skin: string;
    public Abreviatura: string;
    public LocalApplicationFolder: string;
    public MyDocumentsFolder: string;
    public Foto: string;

    constructor() {
        this.DataSessionID = 0;
        this.EmpresaID = 0;
        this.OrganizacionID = 0;
        this.TerceroID = 0;
        this.UsuarioID = 0;
        this.Ip = '';
        this.UserName = '';
        this.Host = '';
        this.Fecha = null;
        this.Activo = false;
        this.Acceso = false;
        this.Organizacion = '';
        this.Empresa = '';
        this.CodEmpresa = '';
        this.Nombre = '';
        this.Apellido = '';
        this.NombreCompleto = '';
        this.Imprerora = '';
        this.Skin = '';
        this.Abreviatura = '';
        this.LocalApplicationFolder = '';
        this.MyDocumentsFolder = '';
        this.Foto = '';
    }

}
