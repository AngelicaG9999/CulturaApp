import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

// Services
import { AppConfigService } from '@services/app-config.service';

// Models
import { Modalidad } from '@models/gestion-maestros/config-general/modalidad.model';

@Injectable({
  providedIn: 'root'
})
export class ModalidadService {

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

    buscar(EmpresaID: number, Nombre: string): Observable<Modalidad[]> {

    const url = this._AppConfigService.apiCulturAppUrl + `Modalidad/GetAll?EmpresaID=${EmpresaID}&Nombre=${Nombre}`;
      return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: Modalidad[] ) => resp ));

  } // buscar

    buscarById(ModalidadID: number): Observable<Modalidad> {

    const url = this._AppConfigService.apiCulturAppUrl + `Modalidad/GetById?ModalidadID=${ModalidadID}`;
      return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: Modalidad ) => resp ));

  } // buscarById

    Add( _Modalidad: Modalidad ): Observable<Modalidad> {

    const url = this._AppConfigService.apiCulturAppUrl + 'Modalidad/Add';
      return this._HttpClient.post( url, _Modalidad, this.httpOptions ).pipe( map( (resp: Modalidad ) => resp ));

  } // Add

    Update( _Modalidad: Modalidad ): Observable<Modalidad> {

    const url = this._AppConfigService.apiCulturAppUrl + 'Modalidad/Update';
      return this._HttpClient.put( url, _Modalidad, this.httpOptions ).pipe( map( (resp: any ) => _Modalidad ));

  } // Update

  Delete(ModalidadID: number) {

    const url = this._AppConfigService.apiCulturAppUrl +  `Modalidad/Delete?ModalidadID=${ModalidadID}`;
    return this._HttpClient.delete( url , this.httpOptions ).pipe( map( (resp: any ) => resp ));

  } // Delete

} // Service
