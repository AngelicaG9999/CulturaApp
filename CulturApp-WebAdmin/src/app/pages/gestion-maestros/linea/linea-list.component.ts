
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

import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';


import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';

// Services
import { UsuarioService } from '@services/usuario/usuario.service';
import { LineaService } from '@services/gestion-maestros/config-general/linea.service';
import { ModalidadService } from '@services/gestion-maestros/config-general/modalidad.service';
import { AreaService } from '@services/gestion-maestros/config-general/area.service';
import { MessageBoxService } from '@services/tools/message-box.service';

// Models
import { Linea } from '@models/gestion-maestros/config-general/linea.model';
import { Modalidad } from '@models/gestion-maestros/config-general/modalidad.model';
import { Area } from '@models/gestion-maestros/config-general/area.model';

@Component({
  selector: 'app-linea-list',
  standalone: true,
  imports: [
    CommonModule, NgxSpinnerModule, MatExpansionModule, MatFormFieldModule, FormsModule,
    MatTableModule, MatPaginatorModule, MatInputModule, MatButtonModule, MatSelectModule
  ],
  templateUrl: './linea-list.component.html',
  styles: ``
})
export class LineaListComponent implements OnInit{

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;
  
  _UsuarioService = inject(UsuarioService);
  _LineaService = inject(LineaService);
  _ModalidadService = inject(ModalidadService);
  _AreaService = inject(AreaService);
  _MessageBoxService = inject(MessageBoxService);
  _NgxSpinnerService = inject(NgxSpinnerService);
  _Router = inject(Router);

  displayedColumns: string[] = ['Nombre', 'Tipo', 'Modalidad', 'Area', 'Descripcion', 'Actions'];
  dataSource = new MatTableDataSource();

  lineaList: Linea[] = [];
  lineaSearch: Linea;
  listaModalidads: Modalidad[] = [];
  listaAreas: Area[] = [];

  constructor() {
    this.buscarCumunas();
    this.buscarAreas();
  } // constructor

  ngOnInit() {

    this.clearSearch();
    this.searchData();

  } // ngOnInit

  clearSearch() {
    this.lineaSearch = new Linea();
    this.lineaSearch.Nombre = '%';
  } // clearSearch

  searchData() {
    this._NgxSpinnerService.show();
    this._LineaService.buscar(this._UsuarioService._DataSession.EmpresaID, this.lineaSearch.Nombre, this.lineaSearch.AreaID, this.lineaSearch.Tipo)
                        .subscribe(  lineas => {
                          this.lineaList = lineas;

                          this.dataSource.data = this.lineaList;
                          this.dataSource.paginator = this.paginator;
                          this.dataSource.sort = this.sort;
                          this._NgxSpinnerService.hide();
                        }, error => {
                          this._NgxSpinnerService.hide();
                          this._MessageBoxService.Error('Error inesperado', this._MessageBoxService.getErrorMessage(error));
                        } );

  } // searchData

  buscarCumunas() {

    this._ModalidadService.buscar(this._UsuarioService._DataSession.EmpresaID, '')
                        .subscribe(  Modalidads => {
                          this.listaModalidads = Modalidads;
                        }, error => {
                          this._MessageBoxService.Error('Error inesperado', this._MessageBoxService.getErrorMessage(error));
                      });

  } // buscarModalidad

  buscarAreas(ModalidadID: number = 0) {

    this._AreaService.buscar(this._UsuarioService._DataSession.EmpresaID, '', ModalidadID)
                        .subscribe(  Areas => {
                          this.listaAreas = Areas;
                        }, error => {
                          this._MessageBoxService.Error('Error inesperado', this._MessageBoxService.getErrorMessage(error));
                      });

  } // buscarAreas

  modalidad_selectionChange(ModalidadSelected: any) {
    this.buscarAreas(ModalidadSelected.value);
  }

  newItem() {
    this._Router.navigate([ '/linea-form', -1, 'new']);
  } // newItem

  viewItem(ID: number) {
    this._Router.navigate([ '/linea-vew', ID]);
  } // viewItem

  closeOpenPanel(panel: any) {
    if (panel._expanded) {
      panel.close();
    } else {
      panel.open();
    }
  } // closeOpenPanel

} // Component
