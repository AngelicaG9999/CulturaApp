export class Linea {

    public LineaID: number;
    public EmpresaID: number;
    public ModalidadID: number;
    public AreaID: number;
    public Nombre: string;
    public Tipo: string;
    public Descripcion: string;
    public Modalidad: string;
    public Area: string;


    constructor() {
      this.LineaID = 0;
      this.EmpresaID = 0;
      this.ModalidadID = 0;
      this.AreaID = 0;
      this.Nombre = '';
      this.Tipo = '';
      this.Descripcion = '';
      this.Modalidad = '';
      this.Area = '';
    }
  }
