
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
import { ComunaService } from '@services/gestion-maestros/config-general/comuna.service';
import { UsuarioService } from '@services/usuario/usuario.service';
import { MessageBoxService } from '@services/tools/message-box.service';

// Models
import { Comuna } from '@models/gestion-maestros/config-general/comuna.model';

@Component({
  selector: 'app-comuna-list',
  standalone: true,
  imports: [CommonModule, NgxSpinnerModule, MatExpansionModule, MatFormFieldModule, FormsModule,
    MatTableModule, MatPaginatorModule, MatInputModule, MatButtonModule],
  templateUrl: './comuna-list.component.html'
})

export class ComunaListComponent implements OnInit {
  
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;
  
  _ComunaService = inject(ComunaService);
  _UsuarioService = inject(UsuarioService);
  _MessageBoxService = inject(MessageBoxService);
  _NgxSpinnerService = inject(NgxSpinnerService);
  _Router = inject(Router);

  displayedColumns: string[] = ['Nombre', 'Descripcion', 'Actions'];
  dataSource = new MatTableDataSource();

  //List Objetos
  comunaList: Comuna[] = [];
  comunaSearch: Comuna;

  constructor() { } 
  // constructor

  ngOnInit() {

    this.clearSearch();
    this.searchData();

  } // ngOnInit

  clearSearch() {
    this.comunaSearch = new Comuna();
    this.comunaSearch.Nombre = '%';
  } // clearSearch

  searchData() {
    this._NgxSpinnerService.show();
    this._ComunaService.buscar(this._UsuarioService._DataSession.EmpresaID, this.comunaSearch.Nombre)
                        .subscribe(  comuna => {
                          this.comunaList = comuna;

                          this.dataSource.data = this.comunaList;
                          this.dataSource.paginator = this.paginator;
                          this.dataSource.sort = this.sort;
                          this._NgxSpinnerService.hide();
                        }, error => {
                          this._NgxSpinnerService.hide();
                          this._MessageBoxService.Error('Ha ocurrido un error inesperado en el módulo.', this._MessageBoxService.getErrorMessage(error));
                        } );

  } // searchData

  newItem() {
    this._Router.navigate([ '/comuna-form', -1, 'new']);
  } // newItem

  viewItem(ID: number) {
    this._Router.navigate([ '/comuna-view', ID]);
  } // viewItem

  closeOpenPanel(panel: any) {
    if (panel._expanded) {
      panel.close();
    } else {
      panel.open();
    }
  } // closeOpenPanel

}
