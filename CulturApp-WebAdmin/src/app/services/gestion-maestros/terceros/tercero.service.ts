import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

// Services
import { AppConfigService } from '@services/app-config.service';

// Models
import { Tercero } from '@models/gestion-maestros/terceros/tercero.model';

@Injectable({
  providedIn: 'root'
})
export class TerceroService {

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

    buscar(EmpresaID: number, Nombre: string = '%', Documento: string = '%'): Observable<Tercero[]> {

      const url = this._AppConfigService.apiAdminUrl + `Tercero/GetAll?EmpresaID=${EmpresaID}&Nombre=${Nombre}&Documento=${Documento}`;
      return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: Tercero[] ) => resp ));

  } // buscar

    buscarByName(EmpresaID: number, Nombre: string): Observable<Tercero[]> {

    const url = this._AppConfigService.apiAdminUrl + `Tercero/GetByName?EmpresaID=${EmpresaID}&Nombre=${Nombre}`;
      return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: Tercero[] ) => resp ));

  } // buscar

    buscarById(TerceroID: number): Observable<Tercero> {

    const url = this._AppConfigService.apiAdminUrl + `Tercero/GetById?TerceroID=${TerceroID}`;
      return this._HttpClient.get(url, this.httpOptions).pipe( map( (resp: Tercero ) => resp ));

  } // buscarById

    Add( _Tercero: Tercero ): Observable<Tercero> {

    const url = this._AppConfigService.apiAdminUrl + 'Tercero/Add';
      return this._HttpClient.post( url, _Tercero, this.httpOptions ).pipe( map( (resp: Tercero ) => resp ));

  } // Add

    Update( _Tercero: Tercero ): Observable<Tercero> {

    const url = this._AppConfigService.apiAdminUrl + 'Tercero/Update';
      return this._HttpClient.put( url, _Tercero, this.httpOptions ).pipe( map( () => _Tercero ));

  } // Update

  Delete(TerceroID: number) {

    const url = this._AppConfigService.apiAdminUrl +  `Tercero/Delete?TerceroID=${TerceroID}`;
    return this._HttpClient.delete( url , this.httpOptions ).pipe( map( (resp: any ) => resp ));

  } // Delete

  SendPushNotification(TerceroID: number, Titulo: string, Texto: string) {

    const url = this._AppConfigService.apiAdminUrl +  `Tercero/SendPushNotification?TerceroID=${TerceroID}&Titulo=${Titulo}&Texto=${Texto}`;
    return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: any ) => resp ));

  } // SendPushNotification

} // Service
