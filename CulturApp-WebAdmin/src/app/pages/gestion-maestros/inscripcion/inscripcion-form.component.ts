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
import { InscripcionService } from '@services/gestion-maestros/config-general/inscripcion.service';
import { ModalidadService } from '@services/gestion-maestros/config-general/modalidad.service';
import { MessageBoxService } from '@services/tools/message-box.service';
import { UsuarioService } from '@services/usuario/usuario.service';

// Models
import { Inscripcion } from '@models/gestion-maestros/config-general/inscripcion.model';
import { Modalidad } from '@models/gestion-maestros/config-general/modalidad.model';


@Component({
  selector: 'app-inscripcion-form',
  standalone: true,
  imports: [
    CommonModule, NgxSpinnerModule, MatFormFieldModule, FormsModule, MatInputModule, MatButtonModule, MatSelectModule
  ],
  templateUrl: './inscripcion-form.component.html',
  styles: ``
})
export class InscripcionFormComponent implements OnInit {

  _UsuarioService = inject(UsuarioService);
  _InscripcionService = inject(InscripcionService);
  _ModalidadService = inject(ModalidadService);
  _MessageBoxService = inject(MessageBoxService);
  _NgxSpinnerService = inject(NgxSpinnerService);
  _Router = inject(Router);
  _ActivatedRoute = inject(ActivatedRoute);
  
  currentInscripcion: Inscripcion;
  listaModalidads: Modalidad[] = [];

  Id = 0;
  Action: string = null;

  constructor() {
    this._ActivatedRoute.params.subscribe( params => {

      this.currentInscripcion = new Inscripcion();

      this.Id = params.id;
      this.Action = params.action;

      this.buscarCumunas();

      if (this.Id !== 0 && this.Action === 'edit') {
        this.buscarById(this.Id);
      }

    });

  } // constructor

  ngOnInit() {

  } // ngOnInit

  buscarById( InscripcionID: number ) {

    this._NgxSpinnerService.show();
    this._InscripcionService.buscarById(InscripcionID)
                      .subscribe(  async (res: Inscripcion) => {
                        this.currentInscripcion = res;

                        this._NgxSpinnerService.hide();
                      }, error => {
                        this._NgxSpinnerService.hide();
                        this._MessageBoxService.Error('Error inesperado', this._MessageBoxService.getErrorMessage(error));
                    } );
  } // buscarById

  buscarCumunas() {

    this._ModalidadService.buscar(this._UsuarioService._DataSession.EmpresaID, '')
                        .subscribe(  Modalidads => {
                          this.listaModalidads = Modalidads;
                        }, error => {
                          this._MessageBoxService.Error('Error inesperado', this._MessageBoxService.getErrorMessage(error));
                      });

  } // buscarModalidad

  validarGuardar() {

    if (this.validarDato() === false) {
      return;
    }

    this.guardar();
  } // validarGuardar

  guardar() {

    const EmpresaID: number = this._UsuarioService._DataSession.EmpresaID;
    this.currentInscripcion.EmpresaID = EmpresaID;
    this._NgxSpinnerService.show();

    if (this.Action === 'edit') {

      this._InscripcionService.Update(this.currentInscripcion)
                        .subscribe( async () => {

                          this._MessageBoxService.Success('Registro Actualizado', 'El registro ha sido actualizado de correctamente.');
                          this._NgxSpinnerService.hide();

                          }, error => {
                            this._MessageBoxService.Error('Error inesperado', this._MessageBoxService.getErrorMessage(error));
                            this._NgxSpinnerService.hide();
                      });
    } else {

      this._InscripcionService.Add(this.currentInscripcion)
                      .subscribe( async (resp: Inscripcion) => {

                        this.currentInscripcion = resp;
                        this.Id = resp.InscripcionID;
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

    if (this.currentInscripcion.Nombre === null || this.currentInscripcion.Nombre.trim().length === 0) {
      this._MessageBoxService.Warning('Nombre', msg, true, 3000);
      return false;
    }

    return true;
  }

  cancelar() {

    if (this.Id < 0 && this.Action === 'new') {
      this._Router.navigate([ '/inscripcion-list' ]);
    } else {
      this._Router.navigate([ '/inscripcion-vew', this.Id]);
    }

  } // atras

} // Component
