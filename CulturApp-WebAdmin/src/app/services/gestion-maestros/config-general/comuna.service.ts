import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

// Services
import { AppConfigService } from '@services/app-config.service';

// Models
import { Comuna } from '@models/gestion-maestros/config-general/comuna.model';

@Injectable({
    providedIn: 'root'
  })

  export class ComunaService {

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
  
      buscar(EmpresaID: number, Nombre: string): Observable<Comuna[]> {
  
        const url = this._AppConfigService.apiCulturAppUrl + `Comuna/GetAll?EmpresaID=${EmpresaID}&Nombre=${Nombre}`;
        return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: Comuna[] ) => resp ));
  
    } // buscar
  
      buscarById(ComunaID: number): Observable<Comuna> {
  
      const url = this._AppConfigService.apiCulturAppUrl + `Comuna/GetById?ComunaID=${ComunaID}`;
        return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: Comuna ) => resp ));
  
    } // buscarById
  
      Add( _Comuna: Comuna ): Observable<Comuna> {
  
      const url = this._AppConfigService.apiCulturAppUrl + 'Comuna/Add';
        return this._HttpClient.post( url, _Comuna, this.httpOptions ).pipe( map( (resp: Comuna ) => resp ));
  
    } // Add
  
      Update( _Comuna: Comuna ): Observable<Comuna> {
  
      const url = this._AppConfigService.apiCulturAppUrl + 'Comuna/Update';
        return this._HttpClient.put( url, _Comuna, this.httpOptions ).pipe( map( (resp: any ) => _Comuna ));
  
    } // Update
  
    Delete(ComunaID: number) {
  
      const url = this._AppConfigService.apiCulturAppUrl +  `Comuna/Delete?ComunaID=${ComunaID}`;
      return this._HttpClient.delete( url , this.httpOptions ).pipe( map( (resp: any ) => resp ));
  
    } // Delete
  
  } // Service
  