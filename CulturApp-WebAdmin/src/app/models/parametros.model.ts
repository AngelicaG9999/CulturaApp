
export class Parametros {
  public Pantalla: string;
  public Maestro: Maestro[];
  constructor() {
    this.Pantalla = '';
    this.Maestro = [];
  }
}

export class Maestro {
  public Campo: string;
  public Valor: string;
  constructor() {
    this.Campo = '';
    this.Valor = '';
  }
}
