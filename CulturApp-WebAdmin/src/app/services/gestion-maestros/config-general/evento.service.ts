import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import * as moment from 'moment';


// Services
import { AppConfigService } from '@services/app-config.service';

//Models
import { Evento } from '@models/gestion-maestros/config-general/evento.model';

@Injectable({
    providedIn: 'root'
  })
  export class EventoService {
  
    // Http Options
    httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
  
    _HttpClient = inject(HttpClient);
    _AppConfigService = inject(AppConfigService);
  
    constructor() {
      
    } // constructor
  
      buscar(EmpresaID: number, SalaID: number, Nombre: string, FechaHora: string): Observable<Evento[]> {

      let fechaHora = FechaHora ? moment(FechaHora).format('DD-MM-YYYY') : moment('').toJSON();

      const url = this._AppConfigService.apiCulturAppUrl + `Evento/GetAll?EmpresaID=${EmpresaID}&SalaID=${SalaID}&Nombre=${Nombre}&fechaHora=${fechaHora}`;
        return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: Evento[] ) => resp ));
  
    } // buscar
  
      buscarById(EventoID: number): Observable<Evento> {
  
      const url = this._AppConfigService.apiCulturAppUrl + `Evento/GetById?EventoID=${EventoID}`;
        return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: Evento ) => resp ));
  
    } // buscarById
  
      Add( _Evento: Evento ): Observable<Evento> {
  
      const url = this._AppConfigService.apiCulturAppUrl + 'Evento/Add';
        return this._HttpClient.post( url, _Evento, this.httpOptions ).pipe( map( (resp: Evento ) => resp ));
  
    } // Add
  
      Update( _Evento: Evento ): Observable<Evento> {
  
      const url = this._AppConfigService.apiCulturAppUrl + 'Evento/Update';
        return this._HttpClient.put( url, _Evento, this.httpOptions ).pipe( map( (resp: any ) => _Evento ));
  
    } // Update
  
    Delete(EventoID: number) {
  
      const url = this._AppConfigService.apiCulturAppUrl +  `Evento/Delete?EventoID=${EventoID}`;
      return this._HttpClient.delete( url , this.httpOptions ).pipe( map( (resp: any ) => resp ));
  
    } // Delete
  
  } // Service
  