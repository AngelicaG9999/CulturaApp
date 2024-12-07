import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, ActivatedRoute } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { MatFormFieldModule } from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';

// Services
import { ModalidadService } from '@services/gestion-maestros/config-general/modalidad.service';
import { MessageBoxService } from '@services/tools/message-box.service';
import { UsuarioService } from '@services/usuario/usuario.service';

// Models
import { Modalidad } from '@models/gestion-maestros/config-general/modalidad.model';



@Component({
  selector: 'app-modalidad-form',
  standalone: true,
  imports: [
    CommonModule, NgxSpinnerModule, MatFormFieldModule, FormsModule, MatInputModule, MatButtonModule
  ],
  templateUrl: './modalidad-form.component.html',
  styles: ``
})
export class ModalidadFormComponent implements OnInit {

  _UsuarioService = inject(UsuarioService);
  _ModalidadService = inject(ModalidadService);
  _MessageBoxService = inject(MessageBoxService);
  _NgxSpinnerService = inject(NgxSpinnerService);
  _Router = inject(Router);
  _ActivatedRoute = inject(ActivatedRoute);
  
  currentModalidad: Modalidad;

  Id = 0;
  Action: string = null;

  constructor() {
    this._ActivatedRoute.params.subscribe( params => {

      this.currentModalidad = new Modalidad();

      this.Id = params.id;
      this.Action = params.action;

      if (this.Id !== 0 && this.Action === 'edit') {
        this.buscarById(this.Id);
      }

    });

  } // constructor

  ngOnInit() {

  } // ngOnInit

  buscarById( ModalidadID: number ) {

    this._NgxSpinnerService.show();
    this._ModalidadService.buscarById(ModalidadID)
                      .subscribe(  async (res: Modalidad) => {
                        this.currentModalidad = res;

                        this._NgxSpinnerService.hide();
                      }, error => {
                        this._NgxSpinnerService.hide();
                        this._MessageBoxService.Error('Error inesperado', this._MessageBoxService.getErrorMessage(error));
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
    this.currentModalidad.EmpresaID = EmpresaID;
    this._NgxSpinnerService.show();

    if (this.Action === 'edit') {

      this._ModalidadService.Update(this.currentModalidad)
                        .subscribe( async () => {

                          this._MessageBoxService.Success('Registro Actualizado', 'El registro ha sido actualizado de correctamente.');
                          this._NgxSpinnerService.hide();

                          }, error => {
                            this._MessageBoxService.Error('Error inesperado', this._MessageBoxService.getErrorMessage(error));
                            this._NgxSpinnerService.hide();
                      });
    } else {

      this._ModalidadService.Add(this.currentModalidad)
                      .subscribe( async (resp: Modalidad) => {

                        this.currentModalidad = resp;
                        this.Id = resp.ModalidadID;
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
    const msg = 'El campo es requerido';

    if (this.currentModalidad.Nombre === null || this.currentModalidad.Nombre.trim().length === 0) {
      this._MessageBoxService.Warning('Nombre', msg, true, 3000);
      return false;
    }

    return true;
  }

  cancelar() {

    if (this.Id < 0 && this.Action === 'new') {
      this._Router.navigate([ '/modalidad-list' ]);
    } else {
      this._Router.navigate([ '/modalidad-vew', this.Id]);
    }

  } // atras

} // Component
