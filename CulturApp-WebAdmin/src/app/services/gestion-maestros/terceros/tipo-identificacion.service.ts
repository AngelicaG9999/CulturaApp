import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

// Services
import { AppConfigService } from '@services/app-config.service';

// Models
import { TipoIdentificacion } from '@models/gestion-maestros/terceros/tipo-identificacion.model';

@Injectable({
  providedIn: 'root'
})
export class TipoIdentificacionService {

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

    buscar(EmpresaID: number, Nombre: string): Observable<TipoIdentificacion[]> {

    const url = this._AppConfigService.apiAdminUrl + `TipoIdentificacion/GetAll?EmpresaID=${EmpresaID}&Nombre=${Nombre}`;
      return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: TipoIdentificacion[] ) => resp ));

  } // buscar

    buscarById(TipoIdentificacionID: number): Observable<TipoIdentificacion> {

    const url = this._AppConfigService.apiAdminUrl + `TipoIdentificacion/GetById?TipoIdentificacionID=${TipoIdentificacionID}`;
      return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: TipoIdentificacion ) => resp ));

  } // buscarById

    Add( _TipoIdentificacion: TipoIdentificacion ): Observable<TipoIdentificacion> {

    const url = this._AppConfigService.apiAdminUrl + 'TipoIdentificacion/Add';
      return this._HttpClient.post( url, _TipoIdentificacion, this.httpOptions ).pipe( map( (resp: TipoIdentificacion ) => resp ));

  } // Add

    Update( _TipoIdentificacion: TipoIdentificacion ): Observable<TipoIdentificacion> {

    const url = this._AppConfigService.apiAdminUrl + 'TipoIdentificacion/Update';
      return this._HttpClient.put( url, _TipoIdentificacion, this.httpOptions ).pipe( map( () => _TipoIdentificacion ));

  } // Update

  Delete(TipoIdentificacionID: number) {

    const url = this._AppConfigService.apiAdminUrl +  `TipoIdentificacion/Delete?TipoIdentificacionID=${TipoIdentificacionID}`;
    return this._HttpClient.delete( url , this.httpOptions ).pipe( map( (resp: any ) => resp ));

  } // Delete

} // Service
