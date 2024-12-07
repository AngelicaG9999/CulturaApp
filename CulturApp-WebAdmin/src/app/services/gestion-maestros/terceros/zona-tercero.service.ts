import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

// Services
import { AppConfigService } from '@services/app-config.service';

// Models
import { ZonaTercero } from '@models/gestion-maestros/terceros/zona-tercero.model';

@Injectable({
  providedIn: 'root'
})
export class ZonaTerceroService {

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

    buscar(EmpresaID: number, Nombre: string): Observable<ZonaTercero[]> {

    const url = this._AppConfigService.apiAdminUrl + `ZonaTercero/GetAll?EmpresaID=${EmpresaID}&Nombre=${Nombre}`;
      return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: ZonaTercero[] ) => resp ));

  } // buscar

    buscarById(ZonaTerceroID: number): Observable<ZonaTercero> {

    const url = this._AppConfigService.apiAdminUrl + `ZonaTercero/GetById?ZonaTerceroID=${ZonaTerceroID}`;
      return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: ZonaTercero ) => resp ));

  } // buscarById

    Add( _ZonaTercero: ZonaTercero ): Observable<ZonaTercero> {

    const url = this._AppConfigService.apiAdminUrl + 'ZonaTercero/Add';
      return this._HttpClient.post( url, _ZonaTercero, this.httpOptions ).pipe( map( (resp: ZonaTercero ) => resp ));

  } // Add

    Update( _ZonaTercero: ZonaTercero ): Observable<ZonaTercero> {

    const url = this._AppConfigService.apiAdminUrl + 'ZonaTercero/Update';
      return this._HttpClient.put( url, _ZonaTercero, this.httpOptions ).pipe( map( () => _ZonaTercero ));

  } // Update

  Delete(ZonaTerceroID: number) {

    const url = this._AppConfigService.apiAdminUrl +  `ZonaTercero/Delete?ZonaTerceroID=${ZonaTerceroID}`;
    return this._HttpClient.delete( url , this.httpOptions ).pipe( map( (resp: any ) => resp ));

  } // Delete

} // Service
