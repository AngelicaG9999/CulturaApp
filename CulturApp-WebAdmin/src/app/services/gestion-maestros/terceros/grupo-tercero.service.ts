import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

// Services
import { AppConfigService } from '@services/app-config.service';

// Models
import { GrupoTercero } from '@models/gestion-maestros/terceros/grupo-tercero.model';

@Injectable({
  providedIn: 'root'
})
export class GrupoTerceroService {

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

    buscar(EmpresaID: number, Nombre: string): Observable<GrupoTercero[]> {

    const url = this._AppConfigService.apiAdminUrl + `GrupoTercero/GetAll?EmpresaID=${EmpresaID}&Nombre=${Nombre}`;
      return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: GrupoTercero[] ) => resp ));

  } // buscar

    buscarById(GrupoTerceroID: number): Observable<GrupoTercero> {

    const url = this._AppConfigService.apiAdminUrl + `GrupoTercero/GetById?GrupoTerceroID=${GrupoTerceroID}`;
      return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: GrupoTercero ) => resp ));

  } // buscarById

    Add( _GrupoTercero: GrupoTercero ): Observable<GrupoTercero> {

    const url = this._AppConfigService.apiAdminUrl + 'GrupoTercero/Add';
      return this._HttpClient.post( url, _GrupoTercero, this.httpOptions ).pipe( map( (resp: GrupoTercero ) => resp ));

  } // Add

    Update( _GrupoTercero: GrupoTercero ): Observable<GrupoTercero> {

    const url = this._AppConfigService.apiAdminUrl + 'GrupoTercero/Update';
      return this._HttpClient.put( url, _GrupoTercero, this.httpOptions ).pipe( map( () => _GrupoTercero ));

  } // Update

  Delete(GrupoTerceroID: number) {

    const url = this._AppConfigService.apiAdminUrl +  `GrupoTercero/Delete?GrupoTerceroID=${GrupoTerceroID}`;
    return this._HttpClient.delete( url , this.httpOptions ).pipe( map( (resp: any ) => resp ));

  } // Delete

} // Service
