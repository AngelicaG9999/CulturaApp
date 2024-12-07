import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

// Services
import { AppConfigService } from '../../app-config.service';

// Models
import { Ciudad } from '@models/admin-sistema/generales/ciudad.model';

@Injectable({
  providedIn: 'root'
})
export class CiudadService {

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

  buscar(DepartamentoID: number, Nombre: string): Observable<Ciudad[]>{

    const url = this._AppConfigService.apiAdminUrl + `Ciudad/GetAll?DepartamentoID=${DepartamentoID}&Nombre=${Nombre}`;
    return this._HttpClient.get<Ciudad[]>( url, this.httpOptions ).pipe( map( (resp: Ciudad[] ) => resp ));

  } // buscar

  getById(CiudadID: number): Observable<Ciudad> {

    const url = this._AppConfigService.apiAdminUrl + `Ciudad/GetById?CiudadID=${CiudadID}`;
    return this._HttpClient.get<Ciudad>(url, this.httpOptions).pipe( map( (resp: Ciudad ) => resp ));

  } // buscarById

  Add( _Ciudad: Ciudad ): Observable<Ciudad> {

    const url = this._AppConfigService.apiAdminUrl + 'Ciudad/Add';
    return this._HttpClient.post<Ciudad>( url, _Ciudad, this.httpOptions ).pipe( map( (resp: Ciudad ) => resp ));

  } // Add

  Update( _Ciudad: Ciudad ): Observable<Ciudad> {

    const url = this._AppConfigService.apiAdminUrl + 'Ciudad/Update';
    return this._HttpClient.put<Ciudad>( url, _Ciudad, this.httpOptions ).pipe( map( (resp: Ciudad ) => _Ciudad ));

  } // Update

  Delete(CiudadID: number) {

    const url = this._AppConfigService.apiAdminUrl +  `Ciudad/Delete?CiudadID=${CiudadID}`;
    return this._HttpClient.delete( url, this.httpOptions ).pipe( map( (resp: any ) => resp ));

  } // Delete

} // Service
