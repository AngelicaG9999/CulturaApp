
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
import { InscripcionService } from '@services/gestion-maestros/config-general/inscripcion.service';
import { TipoService } from '@services/gestion-maestros/config-general/tipo.service';
import { MessageBoxService } from '@services/tools/message-box.service';

// Models
import { Inscripcion } from '@models/gestion-maestros/config-general/inscripcion.model';
import { Tipo } from '@models/gestion-maestros/config-general/tipo.model';
import { Parametros } from '@models/parametros.model';

@Component({
  selector: 'app-inscripcion-list',
  standalone: true,
  imports: [
    CommonModule, NgxSpinnerModule, MatExpansionModule, MatFormFieldModule, FormsModule,
    MatTableModule, MatPaginatorModule, MatInputModule, MatButtonModule, MatSelectModule
  ],
  templateUrl: './inscripcion-list.component.html',
  styles: ``
})
export class InscripcionListComponent implements OnInit{

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;
  
  _UsuarioService = inject(UsuarioService);
  _InscripcionService = inject(InscripcionService);
  _TipoService = inject(TipoService);
  _MessageBoxService = inject(MessageBoxService);
  _NgxSpinnerService = inject(NgxSpinnerService);
  _Router = inject(Router);

  displayedColumns: string[] = ['Radicado', 'Tipo', 'Nombre', 'TipoDocId', 'DocId', 'Titulo', 'Actions'];
  dataSource = new MatTableDataSource();

  lParams: Parametros[] = [];
  param: Parametros;

  inscripcionList: Inscripcion[] = [];
  inscripcionSearch: Inscripcion;
  listaTipos: Tipo[] = [];

  constructor() {
    this.buscarTipos();
  } // constructor

  ngOnInit() {

    this.clearSearch();
    this.getParams('Inscripcion');
    // this.searchData();

  } // ngOnInit

  clearSearch() {
    this.inscripcionSearch = new Inscripcion();
    this.inscripcionSearch.Radicado = '%';
    this.inscripcionSearch.DocId = '%';
    this.inscripcionSearch.Nombre = '%';
    this.inscripcionSearch.Titulo = '%';
    this.inscripcionSearch.TipoID = 0;
  } // clearSearch

  searchData() {
    this._NgxSpinnerService.show();
    this.setParams('Inscripcion');
    this._InscripcionService.buscar(
                                    this._UsuarioService._DataSession.EmpresaID,
                                    this.inscripcionSearch.EstimuloID,
                                    this.inscripcionSearch.Radicado,
                                    this.inscripcionSearch.TipoID
                                  )
                            .subscribe(  inscripcions => {
                              this.inscripcionList = inscripcions;

                              this.dataSource.data = this.inscripcionList;
                              this.dataSource.paginator = this.paginator;
                              this.dataSource.sort = this.sort;
                              this._NgxSpinnerService.hide();
                            }, error => {
                              this._NgxSpinnerService.hide();
                              this._MessageBoxService.Error('Error inesperado', this._MessageBoxService.getErrorMessage(error));
                            } );

  } // searchData

  buscarTipos() {

    this._TipoService.buscar(this._UsuarioService._DataSession.EmpresaID, '')
                        .subscribe(  Tipos => {
                          this.listaTipos = Tipos;
                        }, error => {
                          this._MessageBoxService.Error('Error inesperado', this._MessageBoxService.getErrorMessage(error));
                      });

  } // buscarTipo

  newItem() {
    this._Router.navigate([ '/inscripcion-form', -1, 'new']);
  } // newItem

  viewItem(ID: number) {
    this._Router.navigate([ '/inscripcion-vew', ID]);
  } // viewItem

  getParams(Pantalla: string) {
    this.lParams = JSON.parse( localStorage.getItem('Params') );

    this.lParams.forEach( element => {

      // filtra la pantalla
      if (element.Pantalla === Pantalla) {
        element.Maestro.forEach (mtr => {

          // filtra los campos
          switch (mtr.Campo) {
            case 'Radicado':
              this.inscripcionSearch.Radicado = mtr.Valor;
              break;
            case 'DocId':
              this.inscripcionSearch.DocId = mtr.Valor;
              break;
            case 'Nombre':
              this.inscripcionSearch.Nombre = mtr.Valor;
              break;
            case 'Titulo':
              this.inscripcionSearch.Titulo =  mtr.Valor;
              break;
            case 'TipoID':
              this.inscripcionSearch.TipoID = Number(mtr.Valor);
          } // switch

        }); // forEach ==> Maestro
      } 

    }); // forEach ==> lParams

    if ( 
      this.inscripcionSearch.Radicado !== '' || 
      this.inscripcionSearch.DocId !== '' ||
      this.inscripcionSearch.Nombre !== '' ||
      this.inscripcionSearch.Titulo !== '' ||
      this.inscripcionSearch.TipoID !== 0
    ) {
        this.searchData();
      }

  } //==>getParams

  setParams(Pantalla: string) {
    const params = localStorage.getItem('Params');
    this.lParams = params ? JSON.parse(params) : [];
    let encontrado = false;

    this.lParams.forEach( element => {

      if (element.Pantalla === Pantalla) {
        encontrado = true;

        element.Maestro.forEach (mtr => {

          // filtra los campos
          switch (mtr.Campo) {
            case 'Radicado':
              mtr.Valor = this.inscripcionSearch.Radicado;
              break;
            case 'DocId':
              mtr.Valor = this.inscripcionSearch.DocId;
              break;
            case 'Nombre':
              mtr.Valor = this.inscripcionSearch.Nombre;
              break;
            case 'Titulo':
              mtr.Valor = String(this.inscripcionSearch.Titulo);
              break;
            case 'TipoID':
              mtr.Valor = String(this.inscripcionSearch.TipoID);
              break;
          } // switch

        }); // forEach ==> Maestro

      }

      localStorage.setItem('Params', JSON.stringify(this.lParams) );
    }); // forEach ==> lParams

    // si no se encuntra en el localStorage se crea
    if ( encontrado === false ) {

      this.param = new Parametros();
      this.param.Pantalla = Pantalla;
      this.param.Maestro.push( { Campo: 'Radicado', Valor: this.inscripcionSearch.Radicado } );
      this.param.Maestro.push( { Campo: 'DocId', Valor: this.inscripcionSearch.DocId } );
      this.param.Maestro.push( { Campo: 'Nombre', Valor: this.inscripcionSearch.Nombre } );
      this.param.Maestro.push( { Campo: 'Titulo', Valor: this.inscripcionSearch.Titulo } );
      this.param.Maestro.push( { Campo: 'TipoID', Valor: String(this.inscripcionSearch.TipoID) } );
      this.lParams.push(this.param);

      localStorage.setItem('Params', JSON.stringify(this.lParams) );

    }

  } //==>setParams

  closeOpenPanel(panel: any) {
    if (panel._expanded) {
      panel.close();
    } else {
      panel.open();
    }
  } // closeOpenPanel

} // Component
