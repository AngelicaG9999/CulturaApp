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
import { EdificioService } from '@services/gestion-maestros/config-general/edificio.service';
import { BarrioService} from '@services/gestion-maestros/config-general/barrio.service';
import { MessageBoxService } from '@services/tools/message-box.service';

// Models
import { Edificio } from '@models/gestion-maestros/config-general/edificio.model';
import { Barrio } from '@models/gestion-maestros/config-general/barrio.model';

@Component({
  selector: 'app-edificio-list',
  standalone: true,
  imports: [CommonModule, NgxSpinnerModule, MatExpansionModule, MatFormFieldModule, FormsModule,
    MatTableModule, MatPaginatorModule, MatInputModule, MatButtonModule, MatSelectModule],
  templateUrl: './edificio-list.component.html'
})
export class EdificioListComponent implements OnInit{


  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;
  
  //Se inicializan los servicios
  _EdificioService = inject(EdificioService);
  _UsuarioService = inject(UsuarioService);
  _BarrioService = inject(BarrioService);
  _MessageBoxService = inject(MessageBoxService);
  _NgxSpinnerService = inject(NgxSpinnerService);
  _Router = inject(Router);

  displayedColumns: string[] = ['Nombre', 'Barrio', 'Direccion', 'Actions'];
  dataSource = new MatTableDataSource();

  //Lista objetos
  EdificioList: Edificio[] = [];
  EdificioSearch: Edificio;
  listaBarrio: Barrio[] = [];


  constructor() {
    this.buscarBarrio();
  } // constructor

  ngOnInit() {

    this.clearSearch();
    this.searchData();

  } // ngOnInit

  clearSearch() {
    this.EdificioSearch = new Edificio();
    this.EdificioSearch.Nombre = '%';
  } // clearSearch

  searchData() {
    this._NgxSpinnerService.show();
    this._EdificioService.buscar(this._UsuarioService._DataSession.EmpresaID, this.EdificioSearch.BarrioID, this.EdificioSearch.Nombre )
                        .subscribe(  edificio => {
                          this.EdificioList = edificio;

                          this.dataSource.data = this.EdificioList;
                          this.dataSource.paginator = this.paginator;
                          this.dataSource.sort = this.sort;
                          this._NgxSpinnerService.hide();
                        }, error => {
                          this._NgxSpinnerService.hide();
                          this._MessageBoxService.Error('Ha ocurrido un error inesperado en el módulo.', this._MessageBoxService.getErrorMessage(error));
                        } );

  } // searchData

  buscarBarrio(ComunaID: number = 0) {

    this._BarrioService.buscar(this._UsuarioService._DataSession.EmpresaID, ComunaID, '' )
                        .subscribe(  barrio => {
                          this.listaBarrio = barrio;
                        }, error => {
                          this._MessageBoxService.Error('Ha ocurrido un error inesperado en el módulo.', this._MessageBoxService.getErrorMessage(error));
                      });

  } // buscarBarrio

  newItem() {
    this._Router.navigate([ '/edificio-form', -1, 'new']);
  } // newItem

  viewItem(ID: number) {
    this._Router.navigate([ '/edificio-view', ID]);
  } // viewItem

  closeOpenPanel(panel: any) {
    if (panel._expanded) {
      panel.close();
    } else {
      panel.open();
    }
  } // closeOpenPanel
}
