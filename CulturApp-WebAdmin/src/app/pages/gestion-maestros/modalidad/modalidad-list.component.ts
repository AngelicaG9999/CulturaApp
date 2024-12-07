
import { Component, OnInit, ViewChild, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { Router } from '@angular/router';

import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatFormFieldModule} from '@angular/material/form-field';

import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';


import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';

// Services
import { UsuarioService } from '@services/usuario/usuario.service';
import { ModalidadService } from '@services/gestion-maestros/config-general/modalidad.service';
import { MessageBoxService } from '@services/tools/message-box.service';

// Models
import { Modalidad } from '@models/gestion-maestros/config-general/modalidad.model'

@Component({
  selector: 'app-modalidad-list',
  standalone: true,
  imports: [
    CommonModule, NgxSpinnerModule, MatExpansionModule, MatFormFieldModule, FormsModule,
    MatTableModule, MatPaginatorModule, MatInputModule, MatButtonModule
  ],
  templateUrl: './modalidad-list.component.html',
  styles: ``
})
export class ModalidadListComponent implements OnInit{

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;
  
  _UsuarioService = inject(UsuarioService);
  _ModalidadService = inject(ModalidadService);
  _MessageBoxService = inject(MessageBoxService);
  _NgxSpinnerService = inject(NgxSpinnerService);
  _Router = inject(Router);

  displayedColumns: string[] = ['Nombre', 'Descripcion', 'Actions'];
  dataSource = new MatTableDataSource();

  modalidadList: Modalidad[] = [];
  modalidadSearch: Modalidad;

  constructor() { } // constructor

  ngOnInit() {

    this.clearSearch();
    this.searchData();

  } // ngOnInit

  clearSearch() {
    this.modalidadSearch = new Modalidad();
    this.modalidadSearch.Nombre = '%';
  } // clearSearch

  searchData() {
    this._NgxSpinnerService.show();
    this._ModalidadService.buscar(this._UsuarioService._DataSession.EmpresaID, this.modalidadSearch.Nombre)
                        .subscribe(  modalidads => {
                          this.modalidadList = modalidads;

                          this.dataSource.data = this.modalidadList;
                          this.dataSource.paginator = this.paginator;
                          this.dataSource.sort = this.sort;
                          this._NgxSpinnerService.hide();
                        }, error => {
                          this._NgxSpinnerService.hide();
                          this._MessageBoxService.Error('Error inesperado', this._MessageBoxService.getErrorMessage(error));
                        } );

  } // searchData

  newItem() {
    this._Router.navigate([ '/modalidad-form', -1, 'new']);
  } // newItem

  viewItem(ID: number) {
    this._Router.navigate([ '/modalidad-vew', ID]);
  } // viewItem

  closeOpenPanel(panel: any) {
    if (panel._expanded) {
      panel.close();
    } else {
      panel.open();
    }
  } // closeOpenPanel

} // Component
