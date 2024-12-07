import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, ActivatedRoute } from '@angular/router';

import { MatButtonModule } from '@angular/material/button';

import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2';

// Services
import { AreaService } from '@services/gestion-maestros/config-general/area.service';
import { MessageBoxService } from '@services/tools/message-box.service';

// Models
import { Area } from '@models/gestion-maestros/config-general/area.model';

@Component({
  selector: 'app-area-view',
  standalone: true,
  imports: [CommonModule, NgxSpinnerModule, MatButtonModule],
  templateUrl: './area-view.component.html',
  styles: ``
})
export class AreaViewComponent implements OnInit {

  _AreaService = inject(AreaService);
  _MessageBoxService = inject(MessageBoxService);
  _NgxSpinnerService = inject(NgxSpinnerService);
  _Router = inject(Router);
  _ActivatedRoute = inject(ActivatedRoute);
  
  currentArea: Area;

  constructor() {
    this._ActivatedRoute.params.subscribe( params => {

      const id = params.id;
      this.buscarById( id );

    });

  } // constructor

  ngOnInit() {
    this.currentArea = new Area();
  } // ngOnInit

  buscarById( AreaID: number ) {

    this._NgxSpinnerService.show();
    this.currentArea = new Area();
    this._AreaService.buscarById(AreaID)
                      .subscribe(  async (res: Area) => {
                        this.currentArea = res;

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
        this._AreaService.Delete(this.currentArea.AreaID)
                                .subscribe( () => {
                                  this._AreaService.buscarById(this.currentArea.AreaID)
                                                      .subscribe(  (res: Area) => {
                                                        if (res.AreaID !== 0) {
                                                          this._MessageBoxService.Warning('Registro no elminado.', 'Por favor valide que el registro no tenga información asociada.');
                                                        } else {
                                                          this._Router.navigate([ '/area-list' ]);
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
    this._Router.navigate([ '/area-list']);
  } // atras

  newItem() {
    this._Router.navigate([ '/area-form', this.currentArea.AreaID, 'new']);
  } // newItem

  editItem() {
    this._Router.navigate([ '/area-form', this.currentArea.AreaID, 'edit']);
  } // editItem

} // Component
