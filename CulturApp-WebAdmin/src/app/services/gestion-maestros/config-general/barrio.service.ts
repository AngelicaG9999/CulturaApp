import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

// Services
import { AppConfigService } from '@services/app-config.service';

//Models
import { Barrio } from '@models/gestion-maestros/config-general/barrio.model';

@Injectable({
    providedIn: 'root'
  })
  export class BarrioService {
  
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
  
      buscar(EmpresaID: number, ComunaID: number, Nombre: string): Observable<Barrio[]> {
  
      const url = this._AppConfigService.apiCulturAppUrl + `Barrio/GetAll?EmpresaID=${EmpresaID}&ComunaID=${ComunaID}&Nombre=${Nombre}`;
        return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: Barrio[] ) => resp ));
  
    } // buscar
  
      buscarById(BarrioID: number): Observable<Barrio> {
  
      const url = this._AppConfigService.apiCulturAppUrl + `Barrio/GetById?BarrioID=${BarrioID}`;
        return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: Barrio ) => resp ));
  
    } // buscarById
  
      Add( _Barrio: Barrio ): Observable<Barrio> {
  
      const url = this._AppConfigService.apiCulturAppUrl + 'Barrio/Add';
        return this._HttpClient.post( url, _Barrio, this.httpOptions ).pipe( map( (resp: Barrio ) => resp ));
  
    } // Add
  
      Update( _Barrio: Barrio ): Observable<Barrio> {
  
      const url = this._AppConfigService.apiCulturAppUrl + 'Barrio/Update';
        return this._HttpClient.put( url, _Barrio, this.httpOptions ).pipe( map( (resp: any ) => _Barrio ));
  
    } // Update
  
    Delete(BarrioID: number) {
  
      const url = this._AppConfigService.apiCulturAppUrl +  `Barrio/Delete?BarrioID=${BarrioID}`;
      return this._HttpClient.delete( url , this.httpOptions ).pipe( map( (resp: any ) => resp ));
  
    } // Delete
  
  } // Service
  