import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

// Services
import { AppConfigService } from '@services/app-config.service';

//Models
import { Edificio } from '@models/gestion-maestros/config-general/edificio.model';


@Injectable({
    providedIn: 'root'
  })
  export class EdificioService {
  
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
  
      buscar(EmpresaID: number, BarrioID: number, Nombre: string): Observable<Edificio[]> {
  
      const url = this._AppConfigService.apiCulturAppUrl + `Edificio/GetAll?EmpresaID=${EmpresaID}&BarrioID=${BarrioID}&Nombre=${Nombre}`;
        return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: Edificio[] ) => resp ));
  
    } // buscar
  
      buscarById(EdificioID: number): Observable<Edificio> {
  
      const url = this._AppConfigService.apiCulturAppUrl + `Edificio/GetById?EdificioID=${EdificioID}`;
        return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: Edificio ) => resp ));
  
    } // buscarById
  
      Add( _Edificio: Edificio ): Observable<Edificio> {
  
      const url = this._AppConfigService.apiCulturAppUrl + 'Edificio/Add';
        return this._HttpClient.post( url, _Edificio, this.httpOptions ).pipe( map( (resp: Edificio ) => resp ));
  
    } // Add
  
      Update( _Edificio: Edificio ): Observable<Edificio> {
  
      const url = this._AppConfigService.apiCulturAppUrl + 'Edificio/Update';
        return this._HttpClient.put( url, _Edificio, this.httpOptions ).pipe( map( (resp: any ) => _Edificio ));
  
    } // Update
  
    Delete(EdificioID: number) {
  
      const url = this._AppConfigService.apiCulturAppUrl +  `Edificio/Delete?EdificioID=${EdificioID}`;
      return this._HttpClient.delete( url , this.httpOptions ).pipe( map( (resp: any ) => resp ));
  
    } // Delete
  
  } // Service
  