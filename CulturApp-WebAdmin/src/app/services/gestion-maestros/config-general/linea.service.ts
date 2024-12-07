import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

// Services
import { AppConfigService } from '@services/app-config.service';

// Models
import { Linea } from '@models/gestion-maestros/config-general/linea.model';

@Injectable({
  providedIn: 'root'
})
export class LineaService {

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

    buscar(EmpresaID: number, Nombre: string, AreaID: number, Tipo: string): Observable<Linea[]> {

    const url = this._AppConfigService.apiCulturAppUrl + `Linea/GetAll?EmpresaID=${EmpresaID}&Nombre=${Nombre}&AreaID=${AreaID}&Tipo=${Tipo}`;
      return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: Linea[] ) => resp ));

  } // buscar

    buscarById(LineaID: number): Observable<Linea> {

    const url = this._AppConfigService.apiCulturAppUrl + `Linea/GetById?LineaID=${LineaID}`;
      return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: Linea ) => resp ));

  } // buscarById

    Add( _Linea: Linea ): Observable<Linea> {

    const url = this._AppConfigService.apiCulturAppUrl + 'Linea/Add';
      return this._HttpClient.post( url, _Linea, this.httpOptions ).pipe( map( (resp: Linea ) => resp ));

  } // Add

    Update( _Linea: Linea ): Observable<Linea> {

    const url = this._AppConfigService.apiCulturAppUrl + 'Linea/Update';
      return this._HttpClient.put( url, _Linea, this.httpOptions ).pipe( map( (resp: any ) => _Linea ));

  } // Update

  Delete(LineaID: number) {

    const url = this._AppConfigService.apiCulturAppUrl +  `Linea/Delete?LineaID=${LineaID}`;
    return this._HttpClient.delete( url , this.httpOptions ).pipe( map( (resp: any ) => resp ));

  } // Delete

} // Service
