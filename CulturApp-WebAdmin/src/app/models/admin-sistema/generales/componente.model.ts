
export class Componente {

    public ComponenteID: number;
    public MenuID: number;
    public Nombre: string;
    public Acceso: boolean;
    public Activo: boolean;
    public Url: string;

    constructor() {
        this.ComponenteID = 0;
        this.MenuID = 0;
        this.Nombre = '';
        this.Acceso = false;
        this.Activo = false;
        this.Url = '';
    }

}
