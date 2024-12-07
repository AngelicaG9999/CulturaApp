import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, ActivatedRoute } from '@angular/router';

import { MatButtonModule } from '@angular/material/button';

import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2';

// Services
import { EventoService } from '@services/gestion-maestros/config-general/evento.service';
import { MessageBoxService } from '@services/tools/message-box.service';

// Models
import { Evento } from '@models/gestion-maestros/config-general/evento.model';

@Component({
  selector: 'app-evento-view',
  standalone: true,
  imports: [CommonModule, NgxSpinnerModule, MatButtonModule],
  templateUrl: './evento-view.component.html'
})
export class EventoViewComponent implements OnInit {

  _EventoService = inject(EventoService);
  _MessageBoxService = inject(MessageBoxService);
  _NgxSpinnerService = inject(NgxSpinnerService);
  _Router = inject(Router);
  _ActivatedRoute = inject(ActivatedRoute);

  currentEvento: Evento;

  constructor() {
    this._ActivatedRoute.params.subscribe( params => {

      const id = params.id;
      this.buscarById( id );

    });

  } // constructor

  ngOnInit() {
    this.currentEvento = new Evento();
  } // ngOnInit

  buscarById( EventoID: number ) {

    this._NgxSpinnerService.show();
    this.currentEvento = new Evento();
    this._EventoService.buscarById(EventoID)
                      .subscribe(  async (res: Evento) => {
                        this.currentEvento = res;

                        this._NgxSpinnerService.hide();
                      }, error => {
                        this._NgxSpinnerService.hide();
                        this._MessageBoxService.Error('Ha ocurrido un error inesperado en el módulo.', this._MessageBoxService.getErrorMessage(error));
                    } );
  } // buscarById

  deleteItem() {
    Swal.fire({
      title: '¿Estás seguro de que desea eliminar el registro?',
      text: 'Una vez que se elimine, no podrá se recuperado.',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#d33',
      confirmButtonText: 'Sí, Eliminar',
      cancelButtonColor: '#3085d6',
      cancelButtonText: 'No, Cancelar'
    }).then((result) => {
      if (result.value) {
        this._EventoService.Delete(this.currentEvento.EventoID)
                                .subscribe( () => {
                                  this._EventoService.buscarById(this.currentEvento.EventoID)
                                                      .subscribe(  (res: Evento) => {
                                                        if (res.EventoID !== 0) {
                                                          this._MessageBoxService.Warning('Registro no eliminado.', 'Por favor valide que el registro no tenga información asociada.');
                                                        } else {
                                                          this._Router.navigate([ '/evento-list' ]);
                                                        }
                                                      }, error => {
                                                        this._MessageBoxService.Error('Ha ocurrido un error inesperado en el módulo.', this._MessageBoxService.getErrorMessage(error));
                                                    } );
                                }, error => {
                                  this._MessageBoxService.Error('Ha ocurrido un error inesperado en el módulo.', this._MessageBoxService.getErrorMessage(error));
                              });
      }
    });
  } // deleteItem

  atras() {
    this._Router.navigate([ '/evento-list']);
  } // atras

  newItem() {
    this._Router.navigate([ '/evento-form', this.currentEvento.EventoID, 'new']);
  } // newItem

  editItem() {
    this._Router.navigate([ '/evento-form', this.currentEvento.EventoID, 'edit']);
  } // editItem

} // Component

