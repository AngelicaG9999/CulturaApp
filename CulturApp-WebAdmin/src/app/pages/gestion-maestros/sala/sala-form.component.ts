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
import { SalaService } from '@services/gestion-maestros/config-general/sala.service';
import { EdificioService } from '@services/gestion-maestros/config-general/edificio.service';
import { MessageBoxService } from '@services/tools/message-box.service';
import { UsuarioService } from '@services/usuario/usuario.service';

// Models
import { Sala } from '@models/gestion-maestros/config-general/sala.model';
import { Edificio } from '@models/gestion-maestros/config-general/edificio.model';


@Component({
  selector: 'app-sala-form',
  standalone: true,
  imports: [CommonModule, NgxSpinnerModule, MatFormFieldModule, FormsModule, MatInputModule, MatButtonModule, MatSelectModule],
  templateUrl: './sala-form.component.html'

})
export class SalaFormComponent implements OnInit {

  //Se inicializan los servicios
  _UsuarioService = inject(UsuarioService);
  _SalaService = inject(SalaService);
  _EdificioService = inject(EdificioService);
  _MessageBoxService = inject(MessageBoxService);
  _NgxSpinnerService = inject(NgxSpinnerService);
  _Router = inject(Router);
  _ActivatedRoute = inject(ActivatedRoute);
  
  currentSala: Sala;
  listaEdificio: Edificio[] = [];

  Id = 0;
  Action: string = null;

  constructor() {
    this._ActivatedRoute.params.subscribe( params => {

      this.currentSala = new Sala();

      this.Id = params.id;
      this.Action = params.action;

      this.buscarEdificio();

      if (this.Id !== 0 && this.Action === 'edit') {
        this.buscarById(this.Id);
      }

    });

  } // constructor

  ngOnInit(): void {
    
  }

  buscarById( SalaID: number ) {

    this._NgxSpinnerService.show();
    this._SalaService.buscarById(SalaID)
                      .subscribe(  async (res: Sala) => {
                        this.currentSala = res;

                        this._NgxSpinnerService.hide();
                      }, error => {
                        this._NgxSpinnerService.hide();
                        this._MessageBoxService.Error('Ha ocurrido un error inesperado en el módulo.', this._MessageBoxService.getErrorMessage(error));
                    } );
  } // buscarById

  buscarEdificio() {

    this._EdificioService.buscar(this._UsuarioService._DataSession.EmpresaID, 0, '')
                        .subscribe(  Edificio => {
                          this.listaEdificio = Edificio;
                        }, error => {
                          this._MessageBoxService.Error('Ha ocurrido un error inesperado en el módulo.', this._MessageBoxService.getErrorMessage(error));
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
    this.currentSala.EmpresaID = EmpresaID;
    this._NgxSpinnerService.show();

    if (this.Action === 'edit') {

      this._SalaService.Update(this.currentSala)
                        .subscribe( async () => {

                          this._MessageBoxService.Success('Registro Actualizado', 'El registro ha sido actualizado de correctamente.');
                          this._NgxSpinnerService.hide();

                          }, error => {
                            this._MessageBoxService.Error('Ha ocurrido un error inesperado en el módulo.', this._MessageBoxService.getErrorMessage(error));
                            this._NgxSpinnerService.hide();
                      });
    } else {

      this._SalaService.Add(this.currentSala)
                      .subscribe( async (resp: Sala) => {

                        this.currentSala = resp;
                        this.Id = resp.SalaID;
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
    if (!this.currentSala?.Nombre?.trim()) {
      this._MessageBoxService.Warning('Nombre', msg, true, 3000);
      return false;
    }
  
    return true;
  }

  cancelar() {

    if (this.Id < 0 && this.Action === 'new') {
      this._Router.navigate([ '/sala-list' ]);
    } else {
      this._Router.navigate([ '/sala-view', this.Id]);
    }

  } // atras

}
