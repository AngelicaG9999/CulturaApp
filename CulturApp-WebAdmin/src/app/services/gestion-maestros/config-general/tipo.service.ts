import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

// Services
import { AppConfigService } from '@services/app-config.service';

// Models
import { Tipo } from '@models/gestion-maestros/config-general/tipo.model';

@Injectable({
  providedIn: 'root'
})
export class TipoService {

  // Http Options
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  _HttpClient = inject(HttpClient);
  _AppConfigService = inject(AppConfigService);

  constructor() {
    
  } // constructor

    buscar(EmpresaID: number, Nombre: string): Observable<Tipo[]> {

    const url = this._AppConfigService.apiCulturAppUrl + `Tipo/GetAll?EmpresaID=${EmpresaID}&Nombre=${Nombre}`;
      return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: Tipo[] ) => resp ));

  } // buscar

    buscarById(TipoID: number): Observable<Tipo> {

    const url = this._AppConfigService.apiCulturAppUrl + `Tipo/GetById?TipoID=${TipoID}`;
      return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: Tipo ) => resp ));

  } // buscarById

    Add( _Tipo: Tipo ): Observable<Tipo> {

    const url = this._AppConfigService.apiCulturAppUrl + 'Tipo/Add';
      return this._HttpClient.post( url, _Tipo, this.httpOptions ).pipe( map( (resp: Tipo ) => resp ));

  } // Add

    Update( _Tipo: Tipo ): Observable<Tipo> {

    const url = this._AppConfigService.apiCulturAppUrl + 'Tipo/Update';
      return this._HttpClient.put( url, _Tipo, this.httpOptions ).pipe( map( (resp: any ) => _Tipo ));

  } // Update

  Delete(TipoID: number) {

    const url = this._AppConfigService.apiCulturAppUrl +  `Tipo/Delete?TipoID=${TipoID}`;
    return this._HttpClient.delete( url , this.httpOptions ).pipe( map( (resp: any ) => resp ));

  } // Delete

} // Service
