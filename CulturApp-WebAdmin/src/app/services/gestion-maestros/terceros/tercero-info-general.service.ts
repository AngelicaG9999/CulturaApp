import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

// Services
import { AppConfigService } from '@services/app-config.service';

// Models
import { TerceroInfoGeneral } from '@models/gestion-maestros/terceros/tercero-info-general.model';

@Injectable({
  providedIn: 'root'
})
export class TerceroInfoGeneralService {

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

  buscarById(TerceroID: number): Observable<TerceroInfoGeneral> {

      const url = this._AppConfigService.apiAdminUrl + `TerceroInfoGeneral/GetById?TerceroID=${TerceroID}`;
      return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: TerceroInfoGeneral ) => resp ));

  } // buscarById

  Add( _TerceroInfoGeneral: TerceroInfoGeneral ): Observable<TerceroInfoGeneral> {

      const url = this._AppConfigService.apiAdminUrl + 'TerceroInfoGeneral/Add';
      return this._HttpClient.post( url, _TerceroInfoGeneral, this.httpOptions ).pipe( map( (resp: TerceroInfoGeneral ) => resp ));

  } // Add

  Update( _TerceroInfoGeneral: TerceroInfoGeneral ): Observable<TerceroInfoGeneral> {

    const url = this._AppConfigService.apiAdminUrl + 'TerceroInfoGeneral/Update';
      return this._HttpClient.put( url, _TerceroInfoGeneral, this.httpOptions ).pipe( map( () => _TerceroInfoGeneral ));

  } // Update

  Delete(TerceroID: number) {

    const url = this._AppConfigService.apiAdminUrl +  `TerceroInfoGeneral/Delete?TerceroID=${TerceroID}`;
    return this._HttpClient.delete( url , this.httpOptions ).pipe( map( (resp: any ) => resp ));

  } // Delete

} // Service
