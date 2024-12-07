import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, ActivatedRoute } from '@angular/router';

import { MatButtonModule } from '@angular/material/button';

import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2';

// Services
import { ComunaService } from '@services/gestion-maestros/config-general/comuna.service';
import { MessageBoxService } from '@services/tools/message-box.service';

// Models
import { Comuna } from '@models/gestion-maestros/config-general/comuna.model';

@Component({
  selector: 'app-comuna-view',
  standalone: true,
  imports: [CommonModule, NgxSpinnerModule, MatButtonModule],
  templateUrl: './comuna-view.component.html'
})

export class ComunaViewComponent implements OnInit {

  // Se inicializan los servicios
  _ComunaService = inject(ComunaService);
  _MessageBoxService = inject(MessageBoxService);
  _NgxSpinnerService = inject(NgxSpinnerService);
  _Router = inject(Router);
  _ActivatedRoute = inject(ActivatedRoute);
  
  //Clase
  currentComuna: Comuna;

  constructor() {
    this._ActivatedRoute.params.subscribe( params => {

      const id = params.id;
      this.buscarById( id );

    });

  } // constructor

  ngOnInit() {
    this.currentComuna = new Comuna();
  } // ngOnInit

  buscarById(ComunaID: number ) {

    this._NgxSpinnerService.show();
    this.currentComuna = new Comuna();
    this._ComunaService.buscarById(ComunaID)
                      .subscribe(  async (res: Comuna) => {
                        this.currentComuna = res;

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
        this._ComunaService.Delete(this.currentComuna.ComunaID)
                                .subscribe( () => {
                                  this._ComunaService.buscarById(this.currentComuna.ComunaID)
                                                      .subscribe(  (res: Comuna) => {
                                                        if (res.ComunaID !== 0) {
                                                          this._MessageBoxService.Warning('Registro no eliminado.', 'Por favor valide que el registro no tenga información asociada.');
                                                        } else {
                                                          this._Router.navigate([ '/comuna-list' ]);
                                                        }
                                                      }, error => {
                                                        this._MessageBoxService.Error('Ha ocurrido un error inesperado en el módulo', this._MessageBoxService.getErrorMessage(error));
                                                    } );
                                }, error => {
                                  this._MessageBoxService.Error('Error inesperado', this._MessageBoxService.getErrorMessage(error));
                              });
      }
    });
  } // deleteItem

  atras() {
    this._Router.navigate([ '/comuna-list']);
  } // atras

  newItem() {
    this._Router.navigate([ '/comuna-form', this.currentComuna.ComunaID, 'new']);
  } // newItem

  editItem() {
    this._Router.navigate([ '/comuna-form', this.currentComuna.ComunaID, 'edit']);
  } // editItem


}
