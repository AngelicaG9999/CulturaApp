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
import { AreaService } from '@services/gestion-maestros/config-general/area.service';
import { ModalidadService } from '@services/gestion-maestros/config-general/modalidad.service';
import { MessageBoxService } from '@services/tools/message-box.service';
import { UsuarioService } from '@services/usuario/usuario.service';

// Models
import { Area } from '@models/gestion-maestros/config-general/area.model';
import { Modalidad } from '@models/gestion-maestros/config-general/modalidad.model';


@Component({
  selector: 'app-area-form',
  standalone: true,
  imports: [
    CommonModule, NgxSpinnerModule, MatFormFieldModule, FormsModule, MatInputModule, MatButtonModule, MatSelectModule
  ],
  templateUrl: './area-form.component.html',
  styles: ``
})
export class AreaFormComponent implements OnInit {

  _UsuarioService = inject(UsuarioService);
  _AreaService = inject(AreaService);
  _ModalidadService = inject(ModalidadService);
  _MessageBoxService = inject(MessageBoxService);
  _NgxSpinnerService = inject(NgxSpinnerService);
  _Router = inject(Router);
  _ActivatedRoute = inject(ActivatedRoute);
  
  currentArea: Area;
  listaModalidads: Modalidad[] = [];

  Id = 0;
  Action: string = null;

  constructor() {
    this._ActivatedRoute.params.subscribe( params => {

      this.currentArea = new Area();

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

  buscarById( AreaID: number ) {

    this._NgxSpinnerService.show();
    this._AreaService.buscarById(AreaID)
                      .subscribe(  async (res: Area) => {
                        this.currentArea = res;

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
    this.currentArea.EmpresaID = EmpresaID;
    this._NgxSpinnerService.show();

    if (this.Action === 'edit') {

      this._AreaService.Update(this.currentArea)
                        .subscribe( async () => {

                          this._MessageBoxService.Success('Registro Actualizado', 'El registro ha sido actualizado de correctamente.');
                          this._NgxSpinnerService.hide();

                          }, error => {
                            this._MessageBoxService.Error('Error inesperado', this._MessageBoxService.getErrorMessage(error));
                            this._NgxSpinnerService.hide();
                      });
    } else {

      this._AreaService.Add(this.currentArea)
                      .subscribe( async (resp: Area) => {

                        this.currentArea = resp;
                        this.Id = resp.AreaID;
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

    if (this.currentArea.Nombre === null || this.currentArea.Nombre.trim().length === 0) {
      this._MessageBoxService.Warning('Nombre', msg, true, 3000);
      return false;
    }

    return true;
  }

  cancelar() {

    if (this.Id < 0 && this.Action === 'new') {
      this._Router.navigate([ '/area-list' ]);
    } else {
      this._Router.navigate([ '/area-vew', this.Id]);
    }

  } // atras

} // Component
