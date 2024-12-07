import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

// Services
import { AppConfigService } from '../../app-config.service';

// Models
import { Componente } from './../../../models/admin-sistema/generales/componente.model';

@Injectable({
  providedIn: 'root'
})
export class ComponenteService {

  constructor(
    private http: HttpClient,
    private appConfigService: AppConfigService
  ) { }

  buscar(EmpresaID: number): Observable<Componente[]> {

    const url = this.appConfigService.apiAdminUrl + `Componente/GetAll?EmpresaID=${EmpresaID}`;
    return this.http.get(url).pipe( map( (resp: Componente[] ) => resp ));

  } // buscar

} // Service
