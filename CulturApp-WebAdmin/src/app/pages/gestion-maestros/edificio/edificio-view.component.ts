import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, ActivatedRoute } from '@angular/router';

import { MatButtonModule } from '@angular/material/button';
import { MatTabsModule} from '@angular/material/tabs';

import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2';

// Services
import { EdificioService } from '@services/gestion-maestros/config-general/edificio.service';
import { MessageBoxService } from '@services/tools/message-box.service';

// Models
import { Edificio } from '@models/gestion-maestros/config-general/edificio.model';

// Components

@Component({
  selector: 'app-edificio-view',
  standalone: true,
  imports: [CommonModule, NgxSpinnerModule, MatButtonModule, MatTabsModule],
  templateUrl: './edificio-view.component.html'
})
export class EdificioViewComponent implements OnInit {

  //Se inicializan los servicios 
  _EdificioService = inject(EdificioService);
  _MessageBoxService = inject(MessageBoxService);
  _NgxSpinnerService = inject(NgxSpinnerService);
  _Router = inject(Router);
  _ActivatedRoute = inject(ActivatedRoute);

  //Lista de objetos
  currentEdificio: Edificio;
  EdificioID: number;

  constructor() {
    this._ActivatedRoute.params.subscribe( params => {

      this.EdificioID = params.id;
      this.buscarById( this.EdificioID );

    });

  } // constructor
  
  ngOnInit() {
    this.currentEdificio = new Edificio();
  }

  buscarById( EdificioID: number ) {

    this._NgxSpinnerService.show();
    this.currentEdificio = new Edificio();
    this._EdificioService.buscarById(EdificioID)
                      .subscribe(  async (res: Edificio) => {
                        this.currentEdificio = res;

                        this._NgxSpinnerService.hide();
                      }, error => {
                        this._NgxSpinnerService.hide();
                        this._MessageBoxService.Error('Ha ocurrido un error inesperado en el módulo', this._MessageBoxService.getErrorMessage(error));
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
        this._EdificioService.Delete(this.currentEdificio.EdificioID)
                                .subscribe( () => {
                                  this._EdificioService.buscarById(this.currentEdificio.EdificioID)
                                                      .subscribe(  (res: Edificio) => {
                                                        if (res.EdificioID !== 0) {
                                                          this._MessageBoxService.Warning('Registro no eliminado.', 'Por favor valide que el registro no tenga información asociada.');
                                                        } else {
                                                          this._Router.navigate([ '/edificio-list' ]);
                                                        }
                                                      }, error => {
                                                        this._MessageBoxService.Error('Error inesperado', this._MessageBoxService.getErrorMessage(error));
                                                    } );
                                }, error => {
                                  this._MessageBoxService.Error('Ha ocurrido un error inesperado en el módulo', this._MessageBoxService.getErrorMessage(error));
                              });
      }
    });
  } // deleteItem

  atras() {
    this._Router.navigate([ '/edificio-list']);
  } // atras

  newItem() {
    this._Router.navigate([ '/edificio-form', this.currentEdificio.EdificioID, 'new']);
  } // newItem

  editItem() {
    this._Router.navigate([ '/edificio-form', this.currentEdificio.EdificioID, 'edit']);
  } // editItem

}
