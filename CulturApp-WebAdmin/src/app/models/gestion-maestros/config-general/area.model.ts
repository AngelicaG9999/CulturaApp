export class Area {

    public AreaID: number;
    public EmpresaID: number;
    public ModalidadID: number;
    public Nombre: string;
    public Descripcion: string;
    public Modalidad: string;


    constructor() {
      this.AreaID = 0;
      this.EmpresaID = 0;
      this.ModalidadID = 0;

      this.Nombre = '';
      this.Descripcion = '';
      this.Modalidad = '';
    }
  }
