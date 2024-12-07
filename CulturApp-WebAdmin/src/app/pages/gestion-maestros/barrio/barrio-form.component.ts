import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, ActivatedRoute } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule} from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';

import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';

// Services
import { BarrioService } from '@services/gestion-maestros/config-general/barrio.service';
import { ComunaService } from '@services/gestion-maestros/config-general/comuna.service';
import { MessageBoxService } from '@services/tools/message-box.service';
import { UsuarioService } from '@services/usuario/usuario.service';

// Models
import { Barrio } from '@models/gestion-maestros/config-general/barrio.model';
import { Comuna } from '@models/gestion-maestros/config-general/comuna.model';

@Component({
  selector: 'app-barrio-form',
  standalone: true,
  imports: [CommonModule, NgxSpinnerModule, MatFormFieldModule, FormsModule, MatInputModule, MatButtonModule, MatSelectModule],
  templateUrl: './barrio-form.component.html',

})
export class BarrioFormComponent implements OnInit {

  //Se inicializan los servicios 
  _UsuarioService = inject(UsuarioService);
  _BarrioService = inject(BarrioService);
  _ComunaService = inject(ComunaService);
  _MessageBoxService = inject(MessageBoxService);
  _NgxSpinnerService = inject(NgxSpinnerService);
  _Router = inject(Router);
  _ActivatedRoute = inject(ActivatedRoute);
  
  //List Objetos
  currentBarrio: Barrio;
  currentComuna: Comuna;
  ComunaList: Comuna[] = [];

  //Actions
  Id = 0;
  Action: string = null;

  //Se inicializa el constructor
  constructor(){
    this._ActivatedRoute.params.subscribe( params => {

      this.currentBarrio = new Barrio();
  
      this.Id = params.id;
      this.Action = params.action;
  
      this.buscarComunas();
  
      if (this.Id !== 0 && this.Action === 'edit') {
        this.buscarBarrioById(this.Id);
      }
  
    });
  }
  

  ngOnInit(): void {
    
  }

  buscarBarrioById( BarrioID: number ) {

    this._NgxSpinnerService.show();
    this._BarrioService.buscarById(BarrioID)
                      .subscribe(  async (res: Barrio) => {
                        this.currentBarrio = res;

                        this._NgxSpinnerService.hide();
                      }, error => {
                        this._NgxSpinnerService.hide();
                        this._MessageBoxService.Error('Ha ocurrido un error inesperado en el módulo.', this._MessageBoxService.getErrorMessage(error));
                    } );
  } // buscarBarrioById

  
buscarComunas() {

  this._ComunaService.buscar(this._UsuarioService._DataSession.EmpresaID, '')
                      .subscribe(  Comunas => {
                        this.ComunaList = Comunas;
                      }, error => {
                        this._MessageBoxService.Error('Ha ocurrido un error inesperado en el módulo.', this._MessageBoxService.getErrorMessage(error));
                    });

} // buscarComunas

validarGuardar() {

  if (this.validarDato() === false) {
    return;
  }

  this.guardar();
} // validarGuardar

guardar() {

  const EmpresaID: number = this._UsuarioService._DataSession.EmpresaID;
  this.currentBarrio.EmpresaID = EmpresaID;
  this._NgxSpinnerService.show();

  if (this.Action === 'edit') {

    this._BarrioService.Update(this.currentBarrio)
                      .subscribe( async () => {

                        this._MessageBoxService.Success('Registro Actualizado', 'El registro ha sido actualizado de correctamente.');
                        this._NgxSpinnerService.hide();

                        }, error => {
                          this._MessageBoxService.Error('Ha ocurrido un error inesperado en el módulo.', this._MessageBoxService.getErrorMessage(error));
                          this._NgxSpinnerService.hide();
                    });
  } else {

    this._BarrioService.Add(this.currentBarrio)
                    .subscribe( async (resp: Barrio) => {

                      this.currentBarrio = resp;
                      this.Id = resp.BarrioID;
                      this.Action = 'edit';

                      this._MessageBoxService.Success('Registro Creado', 'El registro ha sido creado de correctamente.');
                      this._NgxSpinnerService.hide();

                    }, error => {
                      this._NgxSpinnerService.hide();
                      this._MessageBoxService.Error('Error inesperado', this._MessageBoxService.getErrorMessage(error));
                  });

  }

} // guardar

validarDato(): boolean {
  const msg = 'El campo "Nombre" es requerido';

  // Validación para valores nulos, vacíos o solo con espacios
  if (!this.currentBarrio?.Nombre?.trim()) {
    this._MessageBoxService.Warning('Nombre', msg, true, 3000);
    return false;
  }

  return true;
}


cancelar() {

  if (this.Id < 0 && this.Action === 'new') {
    this._Router.navigate([ '/barrio-list' ]);
  } else {
    this._Router.navigate([ '/barrio-view', this.Id]);
  }

} // cancelar
}
