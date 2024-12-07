import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

// Services
import { AppConfigService } from '@services/app-config.service';

// Models
import { TerceroInfoGeografica } from '@models/gestion-maestros/terceros/tercero-info-geografica.model';

@Injectable({
  providedIn: 'root'
})
export class TerceroInfoGeograficaService {

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

  buscar(TerceroID: number) {

    const url = this._AppConfigService.apiAdminUrl + `TerceroInfoGeografica/GetById?TerceroID=${TerceroID}`;
    return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: any ) => resp ));

  } // buscar

  buscarById(TerceroID: number) {

    const url = this._AppConfigService.apiAdminUrl + `TerceroInfoGeografica/GetById?TerceroID=${TerceroID}`;
    return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: any ) => resp ));

  } // buscarById

  Add( _TerceroInfoGeografica: TerceroInfoGeografica ) {

    const url = this._AppConfigService.apiAdminUrl + 'TerceroInfoGeografica/Add';
    return this._HttpClient.post( url, _TerceroInfoGeografica , this.httpOptions ).pipe( map( (resp: any ) => resp ));

  } // Add

  Update( _TerceroInfoGeografica: TerceroInfoGeografica ) {

    const url = this._AppConfigService.apiAdminUrl + 'TerceroInfoGeografica/Update';
    return this._HttpClient.put( url, _TerceroInfoGeografica , this.httpOptions ).pipe( map( (resp: any ) => _TerceroInfoGeografica ));

  } // Update

  Delete(TerceroID: number) {

    const url = this._AppConfigService.apiAdminUrl +  `TerceroInfoGeografica/Delete?TerceroID=${TerceroID}`;
    return this._HttpClient.delete( url , this.httpOptions ).pipe( map( (resp: any ) => resp ));

  } // Delete

} // Service
