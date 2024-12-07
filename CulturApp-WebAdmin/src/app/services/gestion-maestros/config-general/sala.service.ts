import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

// Services
import { AppConfigService } from '@services/app-config.service';

//Models
import { Sala } from '@models/gestion-maestros/config-general/sala.model';

@Injectable({
    providedIn: 'root'
  })
  export class SalaService {
  
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
  
      buscar(EmpresaID: number, EdificioID: number, Nombre: string): Observable<Sala[]> {
  
      const url = this._AppConfigService.apiCulturAppUrl + `Sala/GetAll?EmpresaID=${EmpresaID}&EdificioID=${EdificioID}&Nombre=${Nombre}`;
        return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: Sala[] ) => resp ));
  
    } // buscar
  
      buscarById(SalaID: number): Observable<Sala> {
  
      const url = this._AppConfigService.apiCulturAppUrl + `Sala/GetById?SalaID=${SalaID}`;
        return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: Sala ) => resp ));
  
    } // buscarById
  
      Add( _Sala: Sala ): Observable<Sala> {
  
      const url = this._AppConfigService.apiCulturAppUrl + 'Sala/Add';
        return this._HttpClient.post( url, _Sala, this.httpOptions ).pipe( map( (resp: Sala ) => resp ));
  
    } // Add
  
      Update( _Sala: Sala ): Observable<Sala> {
  
      const url = this._AppConfigService.apiCulturAppUrl + 'Sala/Update';
        return this._HttpClient.put( url, _Sala, this.httpOptions ).pipe( map( (resp: any ) => _Sala ));
  
    } // Update
  
    Delete(SalaID: number) {
  
      const url = this._AppConfigService.apiCulturAppUrl +  `Sala/Delete?SalaID=${SalaID}`;
      return this._HttpClient.delete( url , this.httpOptions ).pipe( map( (resp: any ) => resp ));
  
    } // Delete
  
  } // Service
  