
export class Usuario {

    public UsuarioID: number;
    public EmpresaID: number;
    public OrganizacionID: number;
    public TerceroID: number;
    public ContactoID: number;
    public UserName: string;
    public Password: string;
    public Email: string;
    public Telefono: string;
    public Movil: string;
    public UserPin: string;
    public FechaCreacion: Date;
    public FechaUltimoAcceso: Date;
    public Activo: boolean;
    public PerfilID: number;
    public Organizacion: string;
    public Tercero: string;
    public Contacto: string;
    public Perfil: string;
    public Foto: string;

    constructor() {
        this.UsuarioID = 0;
        this.EmpresaID = 0;
        this.OrganizacionID = 0;
        this.TerceroID = 0;
        this.ContactoID = 0;
        this.UserName = '';
        this.Password = '';
        this.Email = '';
        this.Telefono = '';
        this.Movil = '';
        this.UserPin = '';
        this.FechaCreacion = null;
        this.FechaUltimoAcceso = null;
        this.Activo = true;
        this.PerfilID = 0;
        this.Organizacion = '';
        this.Tercero = '';
        this.Contacto = '';
        this.Perfil = '';
        this.Foto = '';
    }

}
