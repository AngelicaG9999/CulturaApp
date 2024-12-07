
export class TerceroInfoGeografica {

    public TerceroID: number;
    public PaisID: number;
    public DepartamentoID: number;
    public CiudadID: number;
    public ZonaID: number;
    public CodPostal: string;
    public Direccion: string;
    public Longitud: number;
    public Latitud: number;
    public Pais: string;
    public Departamento: string;
    public Ciudad: string;
    public Zona: string;

    constructor() {
      this.TerceroID = 0;
      this.PaisID = 0;
      this.DepartamentoID = 0;
      this.CiudadID = 0;
      this.ZonaID = 0;
      this.CodPostal = '';
      this.Direccion = '';
      this.Longitud = 0;
      this.Latitud = 0;
      this.Pais = '';
      this.Departamento = '';
      this.Ciudad = '';
      this.Zona = '';
    }

}
