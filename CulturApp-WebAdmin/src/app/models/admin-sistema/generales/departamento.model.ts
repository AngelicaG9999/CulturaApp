
export class Departamento {

    public DepartamentoID: number;
    public PaisID: number;
    public Nombre: string;
    public Activo: boolean;

    constructor() {
        this.DepartamentoID = 0;
        this.PaisID = 0;
        this.Nombre = '';
        this.Activo = false;
    }

}
