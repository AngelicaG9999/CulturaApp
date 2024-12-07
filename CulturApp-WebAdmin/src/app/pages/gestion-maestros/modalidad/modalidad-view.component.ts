import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, ActivatedRoute } from '@angular/router';

import { MatButtonModule } from '@angular/material/button';

import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2';

// Services
import { ModalidadService } from '@services/gestion-maestros/config-general/modalidad.service';
import { MessageBoxService } from '@services/tools/message-box.service';

// Models
import { Modalidad } from '@models/gestion-maestros/config-general/modalidad.model';

@Component({
  selector: 'app-modalidad-view',
  standalone: true,
  imports: [CommonModule, NgxSpinnerModule, MatButtonModule],
  templateUrl: './modalidad-view.component.html',
  styles: ``
})
export class ModalidadViewComponent implements OnInit {

  _ModalidadService = inject(ModalidadService);
  _MessageBoxService = inject(MessageBoxService);
  _NgxSpinnerService = inject(NgxSpinnerService);
  _Router = inject(Router);
  _ActivatedRoute = inject(ActivatedRoute);
  
  currentModalidad: Modalidad;

  constructor() {
    this._ActivatedRoute.params.subscribe( params => {

      const id = params.id;
      this.buscarById( id );

    });

  } // constructor

  ngOnInit() {
    this.currentModalidad = new Modalidad();
  } // ngOnInit

  buscarById( ModalidadID: number ) {

    this._NgxSpinnerService.show();
    this.currentModalidad = new Modalidad();
    this._ModalidadService.buscarById(ModalidadID)
                      .subscribe(  async (res: Modalidad) => {
                        this.currentModalidad = res;

                        this._NgxSpinnerService.hide();
                      }, error => {
                        this._NgxSpinnerService.hide();
                        this._MessageBoxService.Error('Error inesperado', this._MessageBoxService.getErrorMessage(error));
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
        this._ModalidadService.Delete(this.currentModalidad.ModalidadID)
                                .subscribe( () => {
                                  this._ModalidadService.buscarById(this.currentModalidad.ModalidadID)
                                                      .subscribe(  (res: Modalidad) => {
                                                        if (res.ModalidadID !== 0) {
                                                          this._MessageBoxService.Warning('Registro no elminado.', 'Por favor valide que el registro no tenga información asociada.');
                                                        } else {
                                                          this._Router.navigate([ '/modalidad-list' ]);
                                                        }
                                                      }, error => {
                                                        this._MessageBoxService.Error('Error inesperado', this._MessageBoxService.getErrorMessage(error));
                                                    } );
                                }, error => {
                                  this._MessageBoxService.Error('Error inesperado', this._MessageBoxService.getErrorMessage(error));
                              });
      }
    });
  } // deleteItem

  atras() {
    this._Router.navigate([ '/modalidad-list']);
  } // atras

  newItem() {
    this._Router.navigate([ '/modalidad-form', this.currentModalidad.ModalidadID, 'new']);
  } // newItem

  editItem() {
    this._Router.navigate([ '/modalidad-form', this.currentModalidad.ModalidadID, 'edit']);
  } // editItem

} // Component
