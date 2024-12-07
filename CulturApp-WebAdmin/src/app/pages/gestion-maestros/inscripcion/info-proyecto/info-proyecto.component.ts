import { Component, Input, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatButtonModule } from '@angular/material/button';

import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';


// Services
import { MessageBoxService } from '@services/tools/message-box.service';
import { UsuarioService } from '@services/usuario/usuario.service';
import { InfoProyectoService } from '@services/gestion-maestros/config-general/info-proyecto.service';

// Models
import { InfoProyecto } from '@models/gestion-maestros/config-general/info-proyecto.model';


@Component({
  selector: 'app-info-proyecto',
  standalone: true,
  imports: [CommonModule, NgxSpinnerModule, MatButtonModule],
  templateUrl: './info-proyecto.component.html',
  styles: ``
})
export class InfoProyectoComponent implements OnInit {

  @Input() InscripcionID: number;

  _UsuarioService = inject(UsuarioService);
  _InfoProyectoService = inject(InfoProyectoService);
  _MessageBoxService = inject(MessageBoxService);
  _NgxSpinnerService = inject(NgxSpinnerService);
  
  currentInfoProyecto: InfoProyecto;
  infoProyectoList: InfoProyecto[] = [];

  constructor() {

  } // constructor

  ngOnInit() {
    this.currentInfoProyecto = new InfoProyecto();
    this.searchData();
  } // ngOnInit

  searchData() {
    this._NgxSpinnerService.show();
    this._InfoProyectoService.buscar(
                                    this._UsuarioService._DataSession.EmpresaID,
                                    this.InscripcionID,
                                  )
                            .subscribe(  inscripcions => {
                              this.infoProyectoList = inscripcions;
                              this.currentInfoProyecto = this.infoProyectoList[0];
                              console.log(this.currentInfoProyecto);

                              this._NgxSpinnerService.hide();
                            }, error => {
                              this._NgxSpinnerService.hide();
                              this._MessageBoxService.Error('Error inesperado', this._MessageBoxService.getErrorMessage(error));
                            } );

  } // searchData

  atras() {

  } // atras

  newItem() {
  
  } // newItem

  editItem() {

  } // editItem

} // Component
