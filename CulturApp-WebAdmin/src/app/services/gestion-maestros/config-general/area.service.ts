import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

// Services
import { AppConfigService } from '@services/app-config.service';

// Models
import { Area } from '@models/gestion-maestros/config-general/area.model';

@Injectable({
  providedIn: 'root'
})
export class AreaService {

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

    buscar(EmpresaID: number, Nombre: string, ModalidadID: number): Observable<Area[]> {

    const url = this._AppConfigService.apiCulturAppUrl + `Area/GetAll?EmpresaID=${EmpresaID}&Nombre=${Nombre}&ModalidadID=${ModalidadID}`;
      return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: Area[] ) => resp ));

  } // buscar

    buscarById(AreaID: number): Observable<Area> {

    const url = this._AppConfigService.apiCulturAppUrl + `Area/GetById?AreaID=${AreaID}`;
      return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: Area ) => resp ));

  } // buscarById

    Add( _Area: Area ): Observable<Area> {

    const url = this._AppConfigService.apiCulturAppUrl + 'Area/Add';
      return this._HttpClient.post( url, _Area, this.httpOptions ).pipe( map( (resp: Area ) => resp ));

  } // Add

    Update( _Area: Area ): Observable<Area> {

    const url = this._AppConfigService.apiCulturAppUrl + 'Area/Update';
      return this._HttpClient.put( url, _Area, this.httpOptions ).pipe( map( (resp: any ) => _Area ));

  } // Update

  Delete(AreaID: number) {

    const url = this._AppConfigService.apiCulturAppUrl +  `Area/Delete?AreaID=${AreaID}`;
    return this._HttpClient.delete( url , this.httpOptions ).pipe( map( (resp: any ) => resp ));

  } // Delete

} // Service
