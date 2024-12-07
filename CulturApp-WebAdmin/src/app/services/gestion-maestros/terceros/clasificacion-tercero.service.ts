import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

// Services
import { AppConfigService } from '@services/app-config.service';

// Models
import { ClasificacionTercero } from '@models/gestion-maestros/terceros/clasificacion-tercero.model';

@Injectable({
  providedIn: 'root'
})
export class ClasificacionTerceroService {

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

    buscar(EmpresaID: number, Nombre: string): Observable<ClasificacionTercero[]> {

    const url = this._AppConfigService.apiAdminUrl + `ClasificacionTercero/GetAll?EmpresaID=${EmpresaID}&Nombre=${Nombre}`;
      return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: ClasificacionTercero[] ) => resp ));

  } // buscar

    buscarById(ClasificacionTerceroID: number): Observable<ClasificacionTercero> {

    const url = this._AppConfigService.apiAdminUrl + `ClasificacionTercero/GetById?ClasificacionTerceroID=${ClasificacionTerceroID}`;
      return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: ClasificacionTercero ) => resp ));

  } // buscarById

    Add( _ClasificacionTercero: ClasificacionTercero ): Observable<ClasificacionTercero> {

    const url = this._AppConfigService.apiAdminUrl + 'ClasificacionTercero/Add';
      return this._HttpClient.post( url, _ClasificacionTercero, this.httpOptions ).pipe( map( (resp: ClasificacionTercero ) => resp ));

  } // Add

    Update( _ClasificacionTercero: ClasificacionTercero ): Observable<ClasificacionTercero> {

    const url = this._AppConfigService.apiAdminUrl + 'ClasificacionTercero/Update';
      return this._HttpClient.put( url, _ClasificacionTercero, this.httpOptions ).pipe( map( () => _ClasificacionTercero ));

  } // Update

  Delete(ClasificacionTerceroID: number) {

    const url = this._AppConfigService.apiAdminUrl +  `ClasificacionTercero/Delete?ClasificacionTerceroID=${ClasificacionTerceroID}`;
    return this._HttpClient.delete( url , this.httpOptions ).pipe( map( (resp: any ) => resp ));

  } // Delete

} // Service
