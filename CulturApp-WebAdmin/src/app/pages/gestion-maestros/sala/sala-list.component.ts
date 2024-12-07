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
import { MatSelectModule } from '@angular/material/select';

import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';

// Services
import { UsuarioService } from '@services/usuario/usuario.service';
import { SalaService } from '@services/gestion-maestros/config-general/sala.service';
import { EdificioService } from '@services/gestion-maestros/config-general/edificio.service';
import { MessageBoxService } from '@services/tools/message-box.service';

// Models
import { Sala } from '@models/gestion-maestros/config-general/sala.model';
import { Edificio } from '@models/gestion-maestros/config-general/edificio.model';

@Component({
  selector: 'app-sala-list',
  standalone: true,
  imports: [CommonModule, NgxSpinnerModule, MatExpansionModule, MatFormFieldModule, FormsModule,
    MatTableModule, MatPaginatorModule, MatInputModule, MatButtonModule, MatSelectModule],
  templateUrl: './sala-list.component.html'
})
export class SalaListComponent implements OnInit {

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;

    //Se inicializan los servicios
   _UsuarioService = inject(UsuarioService);
  _SalaService = inject(SalaService);
  _EdificioService = inject(EdificioService);
  _MessageBoxService = inject(MessageBoxService);
  _NgxSpinnerService = inject(NgxSpinnerService);
  _Router = inject(Router);

  displayedColumns: string[] = ['Nombre', 'Descripcion', 'Capacidad', 'Edificio','Actions'];
  dataSource = new MatTableDataSource();

  salaList: Sala[] = [];
  salaSearch: Sala;
  listaEdificio: Edificio[] = [];

  constructor() {
    this.buscarEdificio();
  } // constructor

  ngOnInit() {

    this.clearSearch();
    this.searchData();

  } // ngOnInit

  clearSearch() {
    this.salaSearch = new Sala();
    this.salaSearch.Nombre = '%';
  } // clearSearch

  searchData() {
    this._NgxSpinnerService.show();
    this._SalaService.buscar(this._UsuarioService._DataSession.EmpresaID, this.salaSearch.EdificioID, this.salaSearch.Nombre, )
                        .subscribe(  sala => {
                          this.salaList = sala;

                          this.dataSource.data = this.salaList;
                          this.dataSource.paginator = this.paginator;
                          this.dataSource.sort = this.sort;
                          this._NgxSpinnerService.hide();
                        }, error => {
                          this._NgxSpinnerService.hide();
                          this._MessageBoxService.Error('Se ha presentado un error inesperado en el módulo.', this._MessageBoxService.getErrorMessage(error));
                        } );

  } // searchData

  buscarEdificio() {

    this._EdificioService.buscar(this._UsuarioService._DataSession.EmpresaID, 0, '')
                        .subscribe(  edificio => {
                          this.listaEdificio = edificio;
                        }, error => {
                          this._MessageBoxService.Error('Se ha presentado un error inesperado en el módulo.', this._MessageBoxService.getErrorMessage(error));
                      });

  } // buscarModalidad

  newItem() {
    this._Router.navigate([ '/sala-form', -1, 'new']);
  } // newItem

  viewItem(ID: number) {
    this._Router.navigate([ '/sala-view', ID]);
  } // viewItem

  closeOpenPanel(panel: any) {
    if (panel._expanded) {
      panel.close();
    } else {
      panel.open();
    }
  } // closeOpenPanel

}
