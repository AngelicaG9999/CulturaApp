import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

// Services
import { AppConfigService } from '@services/app-config.service';

// Models
import { ClaseTercero } from '@models/gestion-maestros/terceros/clase-tercero.model';

@Injectable({
  providedIn: 'root'
})
export class ClaseTerceroService {

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

    buscar(EmpresaID: number, Nombre: string): Observable<ClaseTercero[]> {

    const url = this._AppConfigService.apiAdminUrl + `ClaseTercero/GetAll?EmpresaID=${EmpresaID}&Nombre=${Nombre}`;
      return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: ClaseTercero[] ) => resp ));

  } // buscar

    buscarById(ClaseTerceroID: number): Observable<ClaseTercero> {

    const url = this._AppConfigService.apiAdminUrl + `ClaseTercero/GetById?ClaseTerceroID=${ClaseTerceroID}`;
      return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: ClaseTercero ) => resp ));

  } // buscarById

    Add( _ClaseTercero: ClaseTercero ): Observable<ClaseTercero> {

    const url = this._AppConfigService.apiAdminUrl + 'ClaseTercero/Add';
      return this._HttpClient.post( url, _ClaseTercero, this.httpOptions ).pipe( map( (resp: ClaseTercero ) => resp ));

  } // Add

    Update( _ClaseTercero: ClaseTercero ): Observable<ClaseTercero> {

    const url = this._AppConfigService.apiAdminUrl + 'ClaseTercero/Update';
      return this._HttpClient.put( url, _ClaseTercero, this.httpOptions ).pipe( map( (resp: any ) => _ClaseTercero ));

  } // Update

  Delete(ClaseTerceroID: number) {

    const url = this._AppConfigService.apiAdminUrl +  `ClaseTercero/Delete?ClaseTerceroID=${ClaseTerceroID}`;
    return this._HttpClient.delete( url , this.httpOptions ).pipe( map( (resp: any ) => resp ));

  } // Delete

} // Service
