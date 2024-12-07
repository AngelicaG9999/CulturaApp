import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

// Services
import { AppConfigService } from '@services/app-config.service';

// Models
import { Inscripcion } from '@models/gestion-maestros/config-general/inscripcion.model';

@Injectable({
  providedIn: 'root'
})
export class InscripcionService {

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

    buscar(EmpresaID: number, EstimuloID: number, Radicado: string, TipoID: number): Observable<Inscripcion[]> {

    const url = this._AppConfigService.apiCulturAppUrl + `Inscripcion/GetAll?EmpresaID=${EmpresaID}&EstimuloID=${EstimuloID}&Radicado=${Radicado}&TipoID=${TipoID}`;
      return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: Inscripcion[] ) => resp ));

  } // buscar

    buscarById(InscripcionID: number): Observable<Inscripcion> {

    const url = this._AppConfigService.apiCulturAppUrl + `Inscripcion/GetById?InscripcionID=${InscripcionID}`;
      return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: Inscripcion ) => resp ));

  } // buscarById

    Add( _Inscripcion: Inscripcion ): Observable<Inscripcion> {

    const url = this._AppConfigService.apiCulturAppUrl + 'Inscripcion/Add';
      return this._HttpClient.post( url, _Inscripcion, this.httpOptions ).pipe( map( (resp: Inscripcion ) => resp ));

  } // Add

    Update( _Inscripcion: Inscripcion ): Observable<Inscripcion> {

    const url = this._AppConfigService.apiCulturAppUrl + 'Inscripcion/Update';
      return this._HttpClient.put( url, _Inscripcion, this.httpOptions ).pipe( map( (resp: any ) => _Inscripcion ));

  } // Update

  Delete(InscripcionID: number) {

    const url = this._AppConfigService.apiCulturAppUrl +  `Inscripcion/Delete?InscripcionID=${InscripcionID}`;
    return this._HttpClient.delete( url , this.httpOptions ).pipe( map( (resp: any ) => resp ));

  } // Delete

} // Service
