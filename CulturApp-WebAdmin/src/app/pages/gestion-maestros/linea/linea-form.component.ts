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
import { LineaService } from '@services/gestion-maestros/config-general/linea.service';
import { ModalidadService } from '@services/gestion-maestros/config-general/modalidad.service';
import { AreaService } from '@services/gestion-maestros/config-general/area.service';
import { MessageBoxService } from '@services/tools/message-box.service';
import { UsuarioService } from '@services/usuario/usuario.service';

// Models
import { Linea } from '@models/gestion-maestros/config-general/linea.model';
import { Modalidad } from '@models/gestion-maestros/config-general/modalidad.model';
import { Area } from '@models/gestion-maestros/config-general/area.model';


@Component({
  selector: 'app-linea-form',
  standalone: true,
  imports: [
    CommonModule, NgxSpinnerModule, MatFormFieldModule, FormsModule, MatInputModule, MatButtonModule, MatSelectModule
  ],
  templateUrl: './linea-form.component.html',
  styles: ``
})
export class LineaFormComponent implements OnInit {

  _UsuarioService = inject(UsuarioService);
  _LineaService = inject(LineaService);
  _ModalidadService = inject(ModalidadService);
  _AreaService = inject(AreaService);
  _MessageBoxService = inject(MessageBoxService);
  _NgxSpinnerService = inject(NgxSpinnerService);
  _Router = inject(Router);
  _ActivatedRoute = inject(ActivatedRoute);
  
  currentLinea: Linea;
  listaModalidads: Modalidad[] = [];
  listaAreas: Area[] = [];

  Id = 0;
  Action: string = null;

  constructor() {
    this._ActivatedRoute.params.subscribe( params => {

      this.currentLinea = new Linea();

      this.Id = params.id;
      this.Action = params.action;

      this.buscarCumunas();
      this.buscarAreas();

      if (this.Id !== 0 && this.Action === 'edit') {
        this.buscarById(this.Id);
      }

    });

  } // constructor

  ngOnInit() {

  } // ngOnInit

  buscarById( LineaID: number ) {

    this._NgxSpinnerService.show();
    this._LineaService.buscarById(LineaID)
                      .subscribe(  async (res: Linea) => {
                        this.currentLinea = res;

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

  } // buscarCumuna

  buscarAreas(ModalidadID: number = 0) {

    this._AreaService.buscar(this._UsuarioService._DataSession.EmpresaID, '', ModalidadID)
                        .subscribe(  Areas => {
                          this.listaAreas = Areas;
                        }, error => {
                          this._MessageBoxService.Error('Error inesperado', this._MessageBoxService.getErrorMessage(error));
                      });

  } // buscarAreas

  modalidad_selectionChange(ModalidadSelected: any) {
    this.buscarAreas(ModalidadSelected.value);
  }

  validarGuardar() {

    if (this.validarDato() === false) {
      return;
    }

    this.guardar();
  } // validarGuardar

  guardar() {

    const EmpresaID: number = this._UsuarioService._DataSession.EmpresaID;
    this.currentLinea.EmpresaID = EmpresaID;
    this._NgxSpinnerService.show();

    if (this.Action === 'edit') {

      this._LineaService.Update(this.currentLinea)
                        .subscribe( async () => {

                          this._MessageBoxService.Success('Registro Actualizado', 'El registro ha sido actualizado de correctamente.');
                          this._NgxSpinnerService.hide();

                          }, error => {
                            this._MessageBoxService.Error('Error inesperado', this._MessageBoxService.getErrorMessage(error));
                            this._NgxSpinnerService.hide();
                      });
    } else {

      this._LineaService.Add(this.currentLinea)
                      .subscribe( async (resp: Linea) => {

                        this.currentLinea = resp;
                        this.Id = resp.LineaID;
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

    if (this.currentLinea.Nombre === null || this.currentLinea.Nombre.trim().length === 0) {
      this._MessageBoxService.Warning('Nombre', msg, true, 3000);
      return false;
    }

    return true;
  }

  cancelar() {

    if (this.Id < 0 && this.Action === 'new') {
      this._Router.navigate([ '/linea-list' ]);
    } else {
      this._Router.navigate([ '/linea-vew', this.Id]);
    }

  } // atras

} // Component
