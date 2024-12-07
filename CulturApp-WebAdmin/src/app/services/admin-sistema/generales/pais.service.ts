import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

// Services
import { AppConfigService } from '../../app-config.service';

// Models
import { Pais } from '@models/admin-sistema/generales/pais.model';

@Injectable({
  providedIn: 'root'
})
export class PaisService {

  // Http Options
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(
    private _HttpClient: HttpClient,
    private _AppConfigService: AppConfigService
    ) {

    } // constructor

  buscar(Codigo: string, Nombre: string): Observable<Pais[]> {

    const url = this._AppConfigService.apiAdminUrl + `Pais/GetAll?Codigo=${Codigo}&Nombre=${Nombre}`;
    return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: Pais[] ) => resp ));

  } // buscar

  buscarById(PaisID: number): Observable<Pais> {

    const url = this._AppConfigService.apiAdminUrl + `Pais/GetById?PaisID=${PaisID}`;
    return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: Pais ) => resp ));

  } // buscarById

  Add( _Pais: Pais ): Observable<Pais> {

    const url = this._AppConfigService.apiAdminUrl + 'Pais/Add';
    return this._HttpClient.post( url, _Pais, this.httpOptions ).pipe( map( (resp: Pais ) => resp ));

  } // Add

  Update( _Pais: Pais ): Observable<Pais> {

    const url = this._AppConfigService.apiAdminUrl + 'Pais/Update';
    return this._HttpClient.put( url, _Pais, this.httpOptions ).pipe( map( () => _Pais ));

  } // Update

  Delete(PaisID: number) {

    const url = this._AppConfigService.apiAdminUrl +  `Pais/Delete?PaisID=${PaisID}`;
    return this._HttpClient.delete( url, this.httpOptions ).pipe( map( (resp: any ) => resp ));

  } // Delete

} // Service
