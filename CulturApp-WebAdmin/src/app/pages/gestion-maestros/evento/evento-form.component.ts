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
import { EventoService } from '@services/gestion-maestros/config-general/evento.service';
import { SalaService } from '@services/gestion-maestros/config-general/sala.service';
import { MessageBoxService } from '@services/tools/message-box.service';
import { UsuarioService } from '@services/usuario/usuario.service';

// Models
import { Evento } from '@models/gestion-maestros/config-general/evento.model';
import { Sala } from '@models/gestion-maestros/config-general/sala.model';

@Component({
  selector: 'app-evento-form',
  standalone: true,
  imports: [CommonModule, NgxSpinnerModule, MatFormFieldModule, FormsModule, MatInputModule, MatButtonModule, MatSelectModule],
  templateUrl: './evento-form.component.html'
})
export class EventoFormComponent implements OnInit{

  _UsuarioService = inject(UsuarioService);
  _EventoService = inject(EventoService);
  _SalaService = inject(SalaService);
  _MessageBoxService = inject(MessageBoxService);
  _NgxSpinnerService = inject(NgxSpinnerService);
  _Router = inject(Router);
  _ActivatedRoute = inject(ActivatedRoute);

  currentEvento: Evento;
  listaSala: Sala[] = [];

  Id = 0;
  Action: string = null;

  constructor() {
    this._ActivatedRoute.params.subscribe( params => {

      this.currentEvento = new Evento();

      this.Id = params.id;
      this.Action = params.action;

      this.buscarSala();

      if (this.Id !== 0 && this.Action === 'edit') {
        this.buscarById(this.Id);
      }

    });

  } // constructor

  ngOnInit(): void {}

  buscarById( EventoID: number ) {

    this._NgxSpinnerService.show();
    this._EventoService.buscarById(EventoID)
                      .subscribe(  async (res: Evento) => {
                        this.currentEvento = res;

                        this._NgxSpinnerService.hide();
                      }, error => {
                        this._NgxSpinnerService.hide();
                        this._MessageBoxService.Error('Ha ocurrido un error inesperado en el módulo.', this._MessageBoxService.getErrorMessage(error));
                    } );
  } // buscarById

  buscarSala() {

    this._SalaService.buscar(this._UsuarioService._DataSession.EmpresaID, 0, '')
                        .subscribe(  sala => {
                          this.listaSala = sala;
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
    this.currentEvento.EmpresaID = EmpresaID;
    this._NgxSpinnerService.show();

    if (this.Action === 'edit') {

      this._EventoService.Update(this.currentEvento)
                        .subscribe( async () => {

                          this._MessageBoxService.Success('Registro Actualizado', 'El registro ha sido actualizado de correctamente.');
                          this._NgxSpinnerService.hide();

                          }, error => {
                            this._MessageBoxService.Error('Ha ocurrido un error inesperado en el módulo.', this._MessageBoxService.getErrorMessage(error));
                            this._NgxSpinnerService.hide();
                      });
    } else {

      this._EventoService.Add(this.currentEvento)
                      .subscribe( async (resp: Evento) => {

                        this.currentEvento = resp;
                        this.Id = resp.EventoID;
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
    const msg = 'El campo es requerido';

    if (this.currentEvento.Nombre === null || this.currentEvento.Nombre.trim().length === 0) {
      this._MessageBoxService.Warning('Nombre', msg, true, 3000);
      return false;
    }

    return true;
  }

  cancelar() {

    if (this.Id < 0 && this.Action === 'new') {
      this._Router.navigate([ '/evento-list' ]);
    } else {
      this._Router.navigate([ '/evento-view', this.Id]);
    }

  } // atras

}
