import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, ActivatedRoute } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { MatFormFieldModule } from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';

// Services
import { ComunaService } from '@services/gestion-maestros/config-general/comuna.service';
import { MessageBoxService } from '@services/tools/message-box.service';
import { UsuarioService } from '@services/usuario/usuario.service';

// Models
import { Comuna } from '@models/gestion-maestros/config-general/comuna.model';



@Component({
  selector: 'app-comuna-form',
  standalone: true,
  imports: [CommonModule, NgxSpinnerModule, MatFormFieldModule, FormsModule, MatInputModule, MatButtonModule],
  templateUrl: './comuna-form.component.html'

})
export class ComunaFormComponent implements OnInit{

  //Se inicializan los servicios

  _UsuarioService = inject(UsuarioService);
  _ComunaService = inject(ComunaService);
  _MessageBoxService = inject(MessageBoxService);
  _NgxSpinnerService = inject(NgxSpinnerService);
  _Router = inject(Router);
  _ActivatedRoute = inject(ActivatedRoute);

  //Modelo
  currentComuna: Comuna;

  Id = 0;
  Action: string = null;

  //Se inicializa el constructor
  constructor() {
    this._ActivatedRoute.params.subscribe( params => {

      this.currentComuna = new Comuna();

      this.Id = params.id;
      this.Action = params.action;

      if (this.Id !== 0 && this.Action === 'edit') {
        this.buscarById(this.Id);
      }

    });

  } // constructor

  ngOnInit() {

  } // ngOnInit

  buscarById( ComunaID: number ) {

    this._NgxSpinnerService.show();
    this._ComunaService.buscarById(ComunaID)
                      .subscribe(  async (res: Comuna) => {
                        this.currentComuna = res;

                        this._NgxSpinnerService.hide();
                      }, error => {
                        this._NgxSpinnerService.hide();
                        this._MessageBoxService.Error('Ha ocurrido un error inesperado en el maestro', this._MessageBoxService.getErrorMessage(error));
                    } );
  } // buscarById

  validarGuardar() {

    if (this.validarDato() === false) {
      return;
    }

    this.guardar();
  } // validarGuardar

  
  guardar() {

    const EmpresaID: number = this._UsuarioService._DataSession.EmpresaID;
    this.currentComuna.EmpresaID = EmpresaID;
    this._NgxSpinnerService.show();

    if (this.Action === 'edit') {

      this._ComunaService.Update(this.currentComuna)
                        .subscribe( async () => {

                          this._MessageBoxService.Success('Registro Actualizado', 'El registro ha sido actualizado de correctamente.');
                          this._NgxSpinnerService.hide();

                          }, error => {
                            this._MessageBoxService.Error('Ha ocurrido un error inesperado en el maestro', this._MessageBoxService.getErrorMessage(error));
                            this._NgxSpinnerService.hide();
                      });
    } else {

      this._ComunaService.Add(this.currentComuna)
                      .subscribe( async (resp: Comuna) => {

                        this.currentComuna = resp;
                        this.Id = resp.ComunaID;
                        this.Action = 'edit';

                        this._MessageBoxService.Success('Registro Creado', 'El registro ha sido creado de correctamente.');
                        this._NgxSpinnerService.hide();

                      }, error => {
                        this._NgxSpinnerService.hide();
                        this._MessageBoxService.Error('Ha ocurrido un error inesperado en el maestro', this._MessageBoxService.getErrorMessage(error));
                    });

    }

  } // guardar

  validarDato(): boolean {
    const msg = 'El campo "Nombre" es requerido';
  
    // Validación para valores nulos, vacíos o solo con espacios
    if (!this.currentComuna?.Nombre?.trim()) {
      this._MessageBoxService.Warning('Nombre', msg, true, 3000);
      return false;
    }
  
    return true;
  }

  cancelar() {

    if (this.Id < 0 && this.Action === 'new') {
      this._Router.navigate([ '/comuna-list' ]);
    } else {
      this._Router.navigate([ '/comuna-view', this.Id]);
    }
  
  } // cancelar

  

}
