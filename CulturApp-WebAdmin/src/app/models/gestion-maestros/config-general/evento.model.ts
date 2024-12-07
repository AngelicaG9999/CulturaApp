export class Evento {
    
    public EventoID: number;
    public EmpresaID: number;
    public SalaID: number;
    public Nombre: string;
    public FechaHora: string;
    public Lugar: string;
    public Direccion: string; 
    public Sala: string;

    constructor() { 
    this.EventoID = 0;
    this.EmpresaID = 0;
    this.SalaID = 0;
    this.Nombre = '';
    this.FechaHora = '';
    this.Lugar = '';
    this.Direccion = '';
    this.Sala = '';
    }
}