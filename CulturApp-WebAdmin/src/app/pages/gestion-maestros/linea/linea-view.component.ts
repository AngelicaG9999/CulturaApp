import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, ActivatedRoute } from '@angular/router';

import { MatButtonModule } from '@angular/material/button';
import {MatTabChangeEvent, MatTabsModule} from '@angular/material/tabs';

import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2';

// Services
import { LineaService } from '@services/gestion-maestros/config-general/linea.service';
import { MessageBoxService } from '@services/tools/message-box.service';

// Models
import { Linea } from '@models/gestion-maestros/config-general/linea.model';

// Components


@Component({
    selector: 'app-linea-view',
    standalone: true,
    templateUrl: './linea-view.component.html',
    styles: ``,
    imports: [CommonModule, NgxSpinnerModule, MatButtonModule, MatTabsModule]
})
export class LineaViewComponent implements OnInit {

  _LineaService = inject(LineaService);
  _MessageBoxService = inject(MessageBoxService);
  _NgxSpinnerService = inject(NgxSpinnerService);
  _Router = inject(Router);
  _ActivatedRoute = inject(ActivatedRoute);
  
  currentLinea: Linea;
  LineaID: number;

  constructor() {
    this._ActivatedRoute.params.subscribe( params => {

      this.LineaID = params.id;
      this.buscarById( this.LineaID );

    });

  } // constructor

  ngOnInit() {
    this.currentLinea = new Linea();
  } // ngOnInit

  buscarById( LineaID: number ) {

    this._NgxSpinnerService.show();
    this.currentLinea = new Linea();
    this._LineaService.buscarById(LineaID)
                      .subscribe(  async (res: Linea) => {
                        this.currentLinea = res;

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
        this._LineaService.Delete(this.currentLinea.LineaID)
                                .subscribe( () => {
                                  this._LineaService.buscarById(this.currentLinea.LineaID)
                                                      .subscribe(  (res: Linea) => {
                                                        if (res.LineaID !== 0) {
                                                          this._MessageBoxService.Warning('Registro no elminado.', 'Por favor valide que el registro no tenga información asociada.');
                                                        } else {
                                                          this._Router.navigate([ '/linea-list' ]);
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
    this._Router.navigate([ '/linea-list']);
  } // atras

  newItem() {
    this._Router.navigate([ '/linea-form', this.currentLinea.LineaID, 'new']);
  } // newItem

  editItem() {
    this._Router.navigate([ '/linea-form', this.currentLinea.LineaID, 'edit']);
  } // editItem

} // Component
