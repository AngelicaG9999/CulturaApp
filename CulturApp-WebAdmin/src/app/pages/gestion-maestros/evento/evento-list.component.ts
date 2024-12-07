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
import { EventoService } from '@services/gestion-maestros/config-general/evento.service';
import { SalaService } from '@services/gestion-maestros/config-general/sala.service';
import { MessageBoxService } from '@services/tools/message-box.service';

// Models
import { Evento } from '@models/gestion-maestros/config-general/evento.model';
import { Sala } from '@models/gestion-maestros/config-general/sala.model';

@Component({
  selector: 'app-evento-list',
  standalone: true,
  imports: [CommonModule, NgxSpinnerModule, MatExpansionModule, MatFormFieldModule, FormsModule,
    MatTableModule, MatPaginatorModule, MatInputModule, MatButtonModule, MatSelectModule],
  templateUrl: './evento-list.component.html'
})
export class EventoListComponent implements OnInit {

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;
  
  _UsuarioService = inject(UsuarioService);
  _EventoService = inject(EventoService);
  _SalaService = inject(SalaService);
  _MessageBoxService = inject(MessageBoxService);
  _NgxSpinnerService = inject(NgxSpinnerService);
  _Router = inject(Router);

  displayedColumns: string[] = ['Nombre', 'FechaHora', 'Lugar', 'Dirección', 'Actions'];
  dataSource = new MatTableDataSource();

  eventoList: Evento[] = [];
  eventoSearch: Evento;
  listaSala: Sala[] = [];

  constructor() {
    this.buscarSala();
  } // constructor

  ngOnInit() {

    this.clearSearch();
    this.searchData();

  } // ngOnInit

  clearSearch() {
    this.eventoSearch = new Evento();
    this.eventoSearch.Nombre = '%';
  } // clearSearch

  searchData() {
    this._NgxSpinnerService.show();
    this._EventoService.buscar(this._UsuarioService._DataSession.EmpresaID, this.eventoSearch.SalaID, this.eventoSearch.Nombre, this.eventoSearch.FechaHora)
                        .subscribe(  evento => {
                          this.eventoList = evento;

                          this.dataSource.data = this.eventoList;
                          this.dataSource.paginator = this.paginator;
                          this.dataSource.sort = this.sort;
                          this._NgxSpinnerService.hide();
                        }, error => {
                          this._NgxSpinnerService.hide();
                          this._MessageBoxService.Error('Ha ocurrido un error inesperado en el módulo.', this._MessageBoxService.getErrorMessage(error));
                        } );

  } // searchData

  buscarSala() {

    this._SalaService.buscar(this._UsuarioService._DataSession.EmpresaID, 0, '')
                        .subscribe(  sala => {
                          this.listaSala = sala;
                        }, error => {
                          this._MessageBoxService.Error('Ha ocurrido un error inesperado en el módulo.', this._MessageBoxService.getErrorMessage(error));
                      });

  } // buscarModalidad

  newItem() {
    this._Router.navigate([ '/evento-form', -1, 'new']);
  } // newItem

  viewItem(ID: number) {
    this._Router.navigate([ '/evento-view', ID]);
  } // viewItem

  closeOpenPanel(panel: any) {
    if (panel._expanded) {
      panel.close();
    } else {
      panel.open();
    }
  } // closeOpenPanel
}
