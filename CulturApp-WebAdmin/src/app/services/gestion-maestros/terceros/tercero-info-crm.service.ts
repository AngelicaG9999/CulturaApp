import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

// Services
import { AppConfigService } from '@services/app-config.service';

// Models
import {TerceroInfoCrm } from '@models/gestion-maestros/terceros/tercero-info-crm.model';

@Injectable({
  providedIn: 'root'
})
export class TerceroInfoCrmService {

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

    buscarById(TerceroID: number): Observable<TerceroInfoCrm> {

      const url = this._AppConfigService.apiAdminUrl + `TerceroInfoCrm/GetById?TerceroID=${TerceroID}`;
      return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: TerceroInfoCrm ) => resp ));

  } // buscarById

    Add( _TerceroInfoCrm: TerceroInfoCrm ): Observable<TerceroInfoCrm> {

    const url = this._AppConfigService.apiAdminUrl + 'TerceroInfoCrm/Add';
      return this._HttpClient.post( url, _TerceroInfoCrm, this.httpOptions ).pipe( map( (resp: TerceroInfoCrm ) => resp ));

  } // Add

    Update( _TerceroInfoCrm: TerceroInfoCrm ): Observable<TerceroInfoCrm> {

    const url = this._AppConfigService.apiAdminUrl + 'TerceroInfoCrm/Update';
      return this._HttpClient.put( url, _TerceroInfoCrm, this.httpOptions ).pipe( map( () => _TerceroInfoCrm ));

  } // Update

  Delete(TerceroID: number) {

    const url = this._AppConfigService.apiAdminUrl +  `TerceroInfoCrm/Delete?TerceroID=${TerceroID}`;
    return this._HttpClient.delete( url , this.httpOptions ).pipe( map( (resp: any ) => resp ));

  } // Delete

} // Service
