import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

// Services
import { ComponenteService } from '../../services/admin-sistema/generales/componente.service';
import { UsuarioService } from '../../services/usuario/usuario.service';
import { MessageBoxService } from '../../services/tools/message-box.service';

// Models
import { Componente } from '../../models/admin-sistema/generales/componente.model';
import { MatButtonModule } from '@angular/material/button';
import { NgIf, NgFor } from '@angular/common';

export interface DialogData {
  EmpresaID: number;
}

@Component({
    selector: 'app-modulos',
    templateUrl: './modulos.component.html',
    styles: [],
    standalone: true,
    imports: [NgIf, NgFor, MatButtonModule]
})
export class ModulosComponent implements OnInit {

  EmpresaID = 0;
  Titulo = 'Modulos';

  ListaComponentes: Componente[] = [];

  constructor(
    public _UsuarioService: UsuarioService,
    private _ComponenteService: ComponenteService,
    private _MessageBoxService: MessageBoxService,
    private dialogRef: MatDialogRef<ModulosComponent>,
    @Inject(MAT_DIALOG_DATA) private data: DialogData
  ) { }

  ngOnInit() {
    this.buscarComponentes();
  }

  buscarComponentes() {

    this._ComponenteService.buscar(this._UsuarioService._DataSession.EmpresaID)
                        .subscribe(  Componentes => {
                          this.ListaComponentes = Componentes;
                        }, error => {
                          this._MessageBoxService.Error('Error inesperado', this._MessageBoxService.getErrorMessage(error));
                      });

  } // buscarComponentes

  save() {
    this.dialogRef.close(this.data);
  }

  close() {
    this.dialogRef.close();
  }

}
