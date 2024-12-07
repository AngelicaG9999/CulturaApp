import { Component, inject, OnInit, ViewChild } from '@angular/core';
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
import { MatSelectModule } from '@angular/material/select';

import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';

// Services
import { UsuarioService } from '@services/usuario/usuario.service';
import { BarrioService } from '@services/gestion-maestros/config-general/barrio.service';
import { ComunaService } from '@services/gestion-maestros/config-general/comuna.service';
import { MessageBoxService } from '@services/tools/message-box.service';

// Models
import { Barrio } from '@models/gestion-maestros/config-general/barrio.model';
import { Comuna } from '@models/gestion-maestros/config-general/comuna.model';

@Component({
  selector: 'app-barrio-list',
  standalone: true,
  imports: [
    CommonModule, NgxSpinnerModule, MatExpansionModule, MatFormFieldModule, FormsModule,
    MatTableModule, MatPaginatorModule, MatInputModule, MatButtonModule, MatSelectModule
  ],
  templateUrl: './barrio-list.component.html',
})
export class BarrioListComponent implements OnInit{

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;

  //Se inicializan los servicios
  _UsuarioService = inject(UsuarioService);
  _BarrioService = inject(BarrioService);
  _ComunaService = inject(ComunaService);
  _MessageBoxService = inject(MessageBoxService);
  _NgxSpinnerService = inject(NgxSpinnerService);
  _Router = inject(Router);

  //Se asigna un nombre a las columnas de la tabla
  displayedColumns: string[] = ['Nombre', 'Comuna', 'Descripcion', 'Actions'];
  dataSource = new MatTableDataSource();

  //List objetos
    BarrioList: Barrio[] = [];
    barrioSearch: Barrio;
    ComunaList: Comuna[] = [];
    ComunaSearch: Comuna;

  //Se inicializa el constructor
  constructor(){
    this.buscarComunas();
  }

  ngOnInit(){
    this.clearSearch();
    this.searchData();
  }

  clearSearch() {
    this.barrioSearch = new Barrio();
    this.barrioSearch.Nombre = '%';
  } // clearSearch

  searchData() {
    this._NgxSpinnerService.show();
    this._BarrioService.buscar(this._UsuarioService._DataSession.EmpresaID, this.barrioSearch.ComunaID, this.barrioSearch.Nombre)
                        .subscribe(  barrio => {
                          this.BarrioList = barrio;

                          this.dataSource.data = this.BarrioList;
                          this.dataSource.paginator = this.paginator;
                          this.dataSource.sort = this.sort;
                          this._NgxSpinnerService.hide();
                        }, error => {
                          this._NgxSpinnerService.hide();
                          this._MessageBoxService.Error('Ha ocurrido un error en el módulo.', this._MessageBoxService.getErrorMessage(error));
                        } );

  } // searchData

  buscarComunas() {

    this._ComunaService.buscar(this._UsuarioService._DataSession.EmpresaID, '')
                        .subscribe(  comuna => {
                          this.ComunaList = comuna;
                        }, error => {
                          this._MessageBoxService.Error('Ha ocurrido un error en el módulo.', this._MessageBoxService.getErrorMessage(error));
                      });

  } // buscarComunas

  newItem() {
    this._Router.navigate([ '/barrio-form', -1, 'new']);
  } // newItem

  viewItem(ID: number) {
    this._Router.navigate([ '/barrio-view', ID]);
  } // viewItem

  closeOpenPanel(panel: any) {
    if (panel._expanded) {
      panel.close();
    } else {
      panel.open();
    }
  } // closeOpenPanel
}
