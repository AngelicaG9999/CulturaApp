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
import { EdificioService } from '@services/gestion-maestros/config-general/edificio.service';
import { BarrioService } from '@services/gestion-maestros/config-general/barrio.service';
import { ComunaService } from '@services/gestion-maestros/config-general/comuna.service';
import { MessageBoxService } from '@services/tools/message-box.service';
import { UsuarioService } from '@services/usuario/usuario.service';

// Models
import { Edificio } from '@models/gestion-maestros/config-general/edificio.model';
import { Barrio } from '@models/gestion-maestros/config-general/barrio.model';
import { Comuna } from '@models/gestion-maestros/config-general/comuna.model';


@Component({
  selector: 'app-edificio-form',
  standalone: true,
  imports: [CommonModule, NgxSpinnerModule, MatFormFieldModule, FormsModule, MatInputModule, MatButtonModule, MatSelectModule],
  templateUrl: './edificio-form.component.html'
})
export class EdificioFormComponent implements OnInit {

  _EdificioService = inject(EdificioService);
  _UsuarioService = inject(UsuarioService);
  _BarrioService = inject(BarrioService);
  _ComunaService = inject(ComunaService);
  _MessageBoxService = inject(MessageBoxService);
  _NgxSpinnerService = inject(NgxSpinnerService);
  _Router = inject(Router);
  _ActivatedRoute = inject(ActivatedRoute);

  //List Objetos 
  currentEdificio: Edificio;
  listaBarrio: Barrio[] = [];

  Id = 0;
  Action: string = null;

  //Se inicializa el constructor
  constructor() {
    this._ActivatedRoute.params.subscribe( params => {

      this.currentEdificio = new Edificio();

      this.Id = params.id;
      this.Action = params.action;

      this.buscarBarrio();

      if (this.Id !== 0 && this.Action === 'edit') {
        this.buscarById(this.Id);
      }

    }); // Constructor

  } // constructor

  ngOnInit() {
  }

  buscarById( EdificioID: number ) {

    this._NgxSpinnerService.show();
    this._EdificioService.buscarById(EdificioID)
                      .subscribe(  async (res: Edificio) => {
                        this.currentEdificio = res;

                        this._NgxSpinnerService.hide();
                      }, error => {
                        this._NgxSpinnerService.hide();
                        this._MessageBoxService.Error('Ha ocurrido un error inesperado en el módulo.', this._MessageBoxService.getErrorMessage(error));
                    } );
  } // buscarById

  buscarBarrio(ComunaID: number = 0) {

    this._BarrioService.buscar(this._UsuarioService._DataSession.EmpresaID, ComunaID, '' )
                        .subscribe(  barrio => {
                          this.listaBarrio = barrio;
                        }, error => {
                          this._MessageBoxService.Error('Ha ocurrido un error inesperado en el módulo.', this._MessageBoxService.getErrorMessage(error));
                      });

  } // buscarBarrio


  validarGuardar() {

    if (this.validarDato() === false) {
      return;
    }

    this.guardar();
  } // validarGuardar

  guardar() {

    const EmpresaID: number = this._UsuarioService._DataSession.EmpresaID;
    this.currentEdificio.EmpresaID = EmpresaID;
    this._NgxSpinnerService.show();

    if (this.Action === 'edit') {

      this._EdificioService.Update(this.currentEdificio)
                        .subscribe( async () => {

                          this._MessageBoxService.Success('Registro Actualizado', 'El registro ha sido actualizado de correctamente.');
                          this._NgxSpinnerService.hide();

                          }, error => {
                            this._MessageBoxService.Error('Ha ocurrido un error inesperado en el módulo.', this._MessageBoxService.getErrorMessage(error));
                            this._NgxSpinnerService.hide();
                      });
    } else {

      this._EdificioService.Add(this.currentEdificio)
                      .subscribe( async (resp: Edificio) => {

                        this.currentEdificio = resp;
                        this.Id = resp.EdificioID;
                        this.Action = 'edit';

                        this._MessageBoxService.Success('Registro Creado', 'El registro ha sido creado de correctamente.');
                        this._NgxSpinnerService.hide();

                      }, error => {
                        this._NgxSpinnerService.hide();
                        this._MessageBoxService.Error('Ha ocurrido un error inesperado en el módulo.', this._MessageBoxService.getErrorMessage(error));
                    });

    }

  } // guardar

  validarDato(): boolean {
    const msg = 'El campo "Nombre" es requerido';
  
    // Validación para valores nulos, vacíos o solo con espacios
    if (!this.currentEdificio?.Nombre?.trim()) {
      this._MessageBoxService.Warning('Nombre', msg, true, 3000);
      return false;
    }
  
    return true;
  }

  cancelar() {

    if (this.Id < 0 && this.Action === 'new') {
      this._Router.navigate([ '/edificio-list' ]);
    } else {
      this._Router.navigate([ '/edificio-view', this.Id]);
    }

  } // atrás
}
