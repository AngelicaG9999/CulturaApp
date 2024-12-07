import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, ActivatedRoute } from '@angular/router';

import { MatButtonModule } from '@angular/material/button';
import { MatTabChangeEvent, MatTabsModule} from '@angular/material/tabs';

import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2';

// Services
import { InscripcionService } from '@services/gestion-maestros/config-general/inscripcion.service';
import { MessageBoxService } from '@services/tools/message-box.service';

// Models
import { Inscripcion } from '@models/gestion-maestros/config-general/inscripcion.model';

// Components
import { InfoProyectoComponent } from './info-proyecto/info-proyecto.component';
import { InfoPersonaComponent } from './info-personal/info-persona.component';
import { InfoRepresentanteComponent } from './info-representante/info-representante.component';
import { InfoIntegranteComponent } from './info-integrante/info-integrante.component';

@Component({
  selector: 'app-inscripcion-view',
  standalone: true,
  imports: [
    CommonModule, NgxSpinnerModule, MatButtonModule, MatTabsModule,
    InfoProyectoComponent, InfoPersonaComponent, InfoRepresentanteComponent, InfoIntegranteComponent
  ],
  templateUrl: './inscripcion-view.component.html',
  styles: ``
})
export class InscripcionViewComponent implements OnInit {

  _InscripcionService = inject(InscripcionService);
  _MessageBoxService = inject(MessageBoxService);
  _NgxSpinnerService = inject(NgxSpinnerService);
  _Router = inject(Router);
  _ActivatedRoute = inject(ActivatedRoute);
  
  currentInscripcion: Inscripcion;
  InscripcionID: number;

  constructor() {
    this._ActivatedRoute.params.subscribe( params => {

      this.InscripcionID = params.id;
      this.buscarById( this.InscripcionID );

    });

  } // constructor

  ngOnInit() {
    this.currentInscripcion = new Inscripcion();
  } // ngOnInit

  buscarById( InscripcionID: number ) {

    this._NgxSpinnerService.show();
    this.currentInscripcion = new Inscripcion();
    this._InscripcionService.buscarById(InscripcionID)
                      .subscribe(  async (res: Inscripcion) => {
                        this.currentInscripcion = res;

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
        this._InscripcionService.Delete(this.currentInscripcion.InscripcionID)
                                .subscribe( () => {
                                  this._InscripcionService.buscarById(this.currentInscripcion.InscripcionID)
                                                      .subscribe(  (res: Inscripcion) => {
                                                        if (res.InscripcionID !== 0) {
                                                          this._MessageBoxService.Warning('Registro no elminado.', 'Por favor valide que el registro no tenga información asociada.');
                                                        } else {
                                                          this._Router.navigate([ '/inscripcion-list' ]);
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
    this._Router.navigate([ '/inscripcion-list']);
  } // atras

  newItem() {
    this._Router.navigate([ '/inscripcion-form', this.currentInscripcion.InscripcionID, 'new']);
  } // newItem

  editItem() {
    this._Router.navigate([ '/inscripcion-form', this.currentInscripcion.InscripcionID, 'edit']);
  } // editItem

} // Component
