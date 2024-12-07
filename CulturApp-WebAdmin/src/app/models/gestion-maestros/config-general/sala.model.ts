export class Sala {

    public SalaID: number;
    public EmpresaID: number;
    public EdificioID: number;
    public Nombre: string;
    public Capacidad: number;
    public Descripcion: string;
    public Edificio: string;

    constructor() {
    
    this.SalaID = 0;
    this.EmpresaID = 0;
    this.EdificioID = 0;
    this.Nombre = '';
    this.Capacidad = 0;
    this.Descripcion = '';
    this.Edificio = '';
    }
}