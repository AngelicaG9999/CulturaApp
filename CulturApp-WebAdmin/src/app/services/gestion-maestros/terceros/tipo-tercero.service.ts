import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

// Services
import { AppConfigService } from '@services/app-config.service';

// Models
import { TipoTercero } from '@models/gestion-maestros/terceros/tipo-tercero.model';

@Injectable({
  providedIn: 'root'
})
export class TipoTerceroService {

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

    buscar(EmpresaID: number, Nombre: string): Observable<TipoTercero[]> {

    const url = this._AppConfigService.apiAdminUrl + `TipoTercero/GetAll?EmpresaID=${EmpresaID}&Nombre=${Nombre}`;
      return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: TipoTercero[] ) => resp ));

  } // buscar

    buscarById(TipoTerceroID: number): Observable<TipoTercero> {

    const url = this._AppConfigService.apiAdminUrl + `TipoTercero/GetById?TipoTerceroID=${TipoTerceroID}`;
      return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: TipoTercero ) => resp ));

  } // buscarById

    Add( _TipoTercero: TipoTercero ): Observable<TipoTercero> {

    const url = this._AppConfigService.apiAdminUrl + 'TipoTercero/Add';
      return this._HttpClient.post( url, _TipoTercero, this.httpOptions ).pipe( map( (resp: TipoTercero ) => resp ));

  } // Add

    Update( _TipoTercero: TipoTercero ): Observable<TipoTercero> {

    const url = this._AppConfigService.apiAdminUrl + 'TipoTercero/Update';
      return this._HttpClient.put( url, _TipoTercero, this.httpOptions ).pipe( map( () => _TipoTercero ));

  } // Update

  Delete(TipoTerceroID: number) {

    const url = this._AppConfigService.apiAdminUrl +  `TipoTercero/Delete?TipoTerceroID=${TipoTerceroID}`;
    return this._HttpClient.delete( url , this.httpOptions ).pipe( map( (resp: any ) => resp ));

  } // Delete

} // Service
