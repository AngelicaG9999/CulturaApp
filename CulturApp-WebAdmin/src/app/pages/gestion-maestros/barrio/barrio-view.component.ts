import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, ActivatedRoute } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';

import Swal from 'sweetalert2';

// Services
import { BarrioService } from '@services/gestion-maestros/config-general/barrio.service';
import { MessageBoxService } from '@services/tools/message-box.service';

// Models
import { Barrio } from '@models/gestion-maestros/config-general/barrio.model';

@Component({
  selector: 'app-barrio-view',
  standalone: true,
  imports: [CommonModule, NgxSpinnerModule],
  templateUrl: './barrio-view.component.html',
})
export class BarrioViewComponent implements OnInit {

  //Se inicializan los servicios
  _BarrioService = inject(BarrioService);
  _MessageBoxService = inject(MessageBoxService);
  _NgxSpinnerService = inject(NgxSpinnerService);
  _Router = inject(Router);
  _ActivatedRoute = inject(ActivatedRoute);
  
  //Modelo
  currentBarrio: Barrio;

  //Se inicializa el constructor
  constructor() {
    this._ActivatedRoute.params.subscribe( params => {

      const id = params.id;
      this.buscarById( id );

    });

  } // constructor

  ngOnInit() {
    this.currentBarrio = new Barrio();
  }

  buscarById( BarrioID: number ) {

    this._NgxSpinnerService.show();
    this.currentBarrio = new Barrio();
    this._BarrioService.buscarById(BarrioID)
                      .subscribe(  async (res: Barrio) => {
                        this.currentBarrio = res;

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
        this._BarrioService.Delete(this.currentBarrio.BarrioID)
                                .subscribe( () => {
                                  this._BarrioService.buscarById(this.currentBarrio.BarrioID)
                                                      .subscribe(  (res: Barrio) => {
                                                        if (res.BarrioID !== 0) {
                                                          this._MessageBoxService.Warning('Registro no eliminado.', 'Por favor valide que el registro no tenga información asociada.');
                                                        } else {
                                                          this._Router.navigate([ '/barrio-list' ]);
                                                        }
                                                      }, error => {
                                                        this._MessageBoxService.Error('Error inesperado', this._MessageBoxService.getErrorMessage(error));
                                                    } );
                                }, error => {
                                  this._MessageBoxService.Error('Ha ocurrido un error inesperado en el módulo.', this._MessageBoxService.getErrorMessage(error));
                              });
      }
    });
  } // deleteItem

  atras() {
    this._Router.navigate([ '/barrio-list']);
  } // atras

  newItem() {
    this._Router.navigate([ '/barrio-form', this.currentBarrio.BarrioID, 'new']);
  } // newItem

  editItem() {
    this._Router.navigate([ '/barrio-form', this.currentBarrio.BarrioID, 'edit']);
  } // editItem

}
