import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

// Services
import { AppConfigService } from '../../app-config.service';

// Models
import { Departamento } from '@models/admin-sistema/generales/departamento.model';

@Injectable({
  providedIn: 'root'
})
export class DepartamentoService {

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

  buscar(PaisID: number, Nombre: string): Observable<Departamento[]> {

    const url = this._AppConfigService.apiAdminUrl + `Departamento/GetAll?PaisID=${PaisID}&Nombre=${Nombre}`;
    return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: Departamento[] ) => resp ));

  } // buscar

  buscarById(DepartamentoID: number): Observable<Departamento> {

    const url = this._AppConfigService.apiAdminUrl + `Departamento/GetById?DepartamentoID=${DepartamentoID}`;
    return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: Departamento ) => resp ));

  } // buscarById

  Add( _Departamento: Departamento ): Observable<Departamento> {

    const url = this._AppConfigService.apiAdminUrl + 'Departamento/Add';
    return this._HttpClient.post( url, _Departamento, this.httpOptions ).pipe( map( (resp: Departamento ) => resp ));

  } // Add

  Update( _Departamento: Departamento ): Observable<Departamento> {

    const url = this._AppConfigService.apiAdminUrl + 'Departamento/Update';
    return this._HttpClient.put( url, _Departamento, this.httpOptions ).pipe( map( () => _Departamento ));

  } // Update

  Delete(DepartamentoID: number) {

    const url = this._AppConfigService.apiAdminUrl +  `Departamento/Delete?DepartamentoID=${DepartamentoID}`;
    return this._HttpClient.delete( url, this.httpOptions ).pipe( map( (resp: any ) => resp ));

  } // Delete

} // Service
