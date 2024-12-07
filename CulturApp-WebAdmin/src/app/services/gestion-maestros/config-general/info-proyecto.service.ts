import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

// Services
import { AppConfigService } from '@services/app-config.service';

// Models
import { InfoProyecto } from '@models/gestion-maestros/config-general/info-proyecto.model';

@Injectable({
  providedIn: 'root'
})
export class InfoProyectoService {

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

    buscar(EmpresaID: number, InscripcionID: number): Observable<InfoProyecto[]> {

    const url = this._AppConfigService.apiCulturAppUrl + `InfoProyecto/GetAll?EmpresaID=${EmpresaID}&InscripcionID=${InscripcionID}`;
      return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: InfoProyecto[] ) => resp ));

  } // buscar

    buscarById(InfoProyectoID: number): Observable<InfoProyecto> {

    const url = this._AppConfigService.apiCulturAppUrl + `InfoProyecto/GetById?InfoProyectoID=${InfoProyectoID}`;
      return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: InfoProyecto ) => resp ));

  } // buscarById

    Add( _InfoProyecto: InfoProyecto ): Observable<InfoProyecto> {

    const url = this._AppConfigService.apiCulturAppUrl + 'InfoProyecto/Add';
      return this._HttpClient.post( url, _InfoProyecto, this.httpOptions ).pipe( map( (resp: InfoProyecto ) => resp ));

  } // Add

    Update( _InfoProyecto: InfoProyecto ): Observable<InfoProyecto> {

    const url = this._AppConfigService.apiCulturAppUrl + 'InfoProyecto/Update';
      return this._HttpClient.put( url, _InfoProyecto, this.httpOptions ).pipe( map( (resp: any ) => _InfoProyecto ));

  } // Update

  Delete(InfoProyectoID: number) {

    const url = this._AppConfigService.apiCulturAppUrl +  `InfoProyecto/Delete?InfoProyectoID=${InfoProyectoID}`;
    return this._HttpClient.delete( url , this.httpOptions ).pipe( map( (resp: any ) => resp ));

  } // Delete

} // Service
