import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, ActivatedRoute } from '@angular/router';

import { MatButtonModule } from '@angular/material/button';

import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2';

// Services
import { SalaService } from '@services/gestion-maestros/config-general/sala.service';
import { MessageBoxService } from '@services/tools/message-box.service';

// Models
import { Sala } from '@models/gestion-maestros/config-general/sala.model';

@Component({
  selector: 'app-sala-view',
  standalone: true,
  imports: [CommonModule, NgxSpinnerModule, MatButtonModule],
  templateUrl: './sala-view.component.html'
})
export class SalaViewComponent implements OnInit {

  //Se inicializan de servicios
  _SalaService = inject(SalaService);
  _MessageBoxService = inject(MessageBoxService);
  _NgxSpinnerService = inject(NgxSpinnerService);
  _Router = inject(Router);
  _ActivatedRoute = inject(ActivatedRoute);

  currentSala: Sala;

  constructor(){
    this._ActivatedRoute.params.subscribe( params => {

      const id = params.id;
      this.buscarById( id );

    });
  }

  ngOnInit() {
    this.currentSala = new Sala();
  } // ngOnInit

  buscarById( SalaID: number ) {

    this._NgxSpinnerService.show();
    this.currentSala = new Sala();
    this._SalaService.buscarById(SalaID)
                      .subscribe(  async (res: Sala) => {
                        this.currentSala = res;

                        this._NgxSpinnerService.hide();
                      }, error => {
                        this._NgxSpinnerService.hide();
                        this._MessageBoxService.Error('Se ha presentado un error inesperado en el módulo.', this._MessageBoxService.getErrorMessage(error));
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
        this._SalaService.Delete(this.currentSala.SalaID)
                                .subscribe( () => {
                                  this._SalaService.buscarById(this.currentSala.SalaID)
                                                      .subscribe(  (res: Sala) => {
                                                        if (res.SalaID !== 0) {
                                                          this._MessageBoxService.Warning('Registro no eliminado.', 'Por favor valide que el registro no tenga información asociada.');
                                                        } else {
                                                          this._Router.navigate([ '/sala-list' ]);
                                                        }
                                                      }, error => {
                                                        this._MessageBoxService.Error('Se ha presentado un error inesperado en el módulo.', this._MessageBoxService.getErrorMessage(error));
                                                    } );
                                }, error => {
                                  this._MessageBoxService.Error('Se ha presentado un error inesperado en el módulo.', this._MessageBoxService.getErrorMessage(error));
                              });
      }
    });
  } // deleteItem

  atras() {
    this._Router.navigate([ '/sala-list']);
  } // atras

  newItem() {
    this._Router.navigate([ '/sala-form', this.currentSala.SalaID, 'new']);
  } // newItem

  editItem() {
    this._Router.navigate([ '/sala-form', this.currentSala.SalaID, 'edit']);
  } // editItem
}
