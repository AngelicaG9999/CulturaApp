import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import * as CryptoJS from 'crypto-js';

// Services
import { AppConfigService } from '../app-config.service';

// Models
import { DataSession } from '../../models/data-session.model';
import { Usuario } from '../../models/usuario.model';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  public _DataSession: DataSession;

  // Http Options
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(
    private _HttpClient: HttpClient,
    private _AppConfigService: AppConfigService,
    public _Router: Router
    ) {
      this.cargarStorage();
    }

login(Empresa: string, UserName: string, Password: string, Recordar: boolean = false) {

  if ( Recordar ) {
    localStorage.setItem('Empresa', CryptoJS.AES.encrypt(Empresa, this._AppConfigService.passwordKey).toString() );
    localStorage.setItem('Usuario', CryptoJS.AES.encrypt(UserName, this._AppConfigService.passwordKey).toString() );
    localStorage.setItem('Password', CryptoJS.AES.encrypt(Password, this._AppConfigService.passwordKey).toString() );
  } else {
    localStorage.removeItem('Empresa');
    localStorage.removeItem('Usuario');
    localStorage.removeItem('Password');
  }

  const eEmpresa = this.Encryption(Empresa);
  const eUserName = this.Encryption(UserName);
  const ePassword = this.Encryption(Password);

  const url = this._AppConfigService.apiAdminUrl + `Usuario/GetByUserAndPassword?Empresa=${eEmpresa}&UserName=${eUserName}&Password=${ePassword}`;
  return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: DataSession ) => {
                                                            this.guardarStorage( resp );
                                                            return resp;
                                                          } ));

  } // login

  estaLogueado() {

    let logueado = false;

    if ( this._DataSession != null) {
      if ( this._DataSession.Acceso === true ) {
        logueado = true;
      } else {
        logueado = false;
      }
    } else {
      logueado = false;
    }

    return logueado;
  } // estaLogueado

  cargarStorage() {

    if ( localStorage.getItem('DataSession')) {
      this._DataSession = JSON.parse( localStorage.getItem('DataSession') );
    } else {
      this._DataSession = null;
    }

  } // cargarStorage

  guardarStorage( dataSession: DataSession ) {
    localStorage.setItem('DataSession', JSON.stringify(dataSession) );
    this._DataSession = dataSession;
  } // guardarStorage

  logout() {
    this._DataSession = null;
    localStorage.removeItem('DataSession');

    this._Router.navigate(['/login']);
  } // logout

  buscar(EmpresaID: number, TerceroID: number, UserName: string): Observable<Usuario[]>{

    const url = this._AppConfigService.apiAdminUrl + `Usuario/GetAll?EmpresaID=${EmpresaID}&TerceroID=${TerceroID}&UserName=${UserName}`;
    return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: Usuario[] ) => resp ));

  } // buscar

  buscarById(UsuarioID: number) {

    const url = this._AppConfigService.apiAdminUrl + `Usuario/GetById?UsuarioID=${UsuarioID}`;
    return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: Usuario ) => resp ));

  } // buscarById

  Add( _Usuario: Usuario ) {

    const url = this._AppConfigService.apiAdminUrl + 'Usuario/Add';
    return this._HttpClient.post( url, _Usuario, this.httpOptions ).pipe( map( (resp: Usuario ) => resp ));

  } // Add

  Update( _Usuario: Usuario ) {

    const url = this._AppConfigService.apiAdminUrl + 'Usuario/Update';
    return this._HttpClient.put( url, _Usuario, this.httpOptions ).pipe( map( () => _Usuario ));

  } // Update

  UpdatePassword(UsuarioID: number, Password: string) {

    const url = this._AppConfigService.apiAdminUrl + `Usuario/UpdatePassword?UsuarioID=${UsuarioID}&Password=${Password}`;
    return this._HttpClient.get( url, this.httpOptions ).pipe( map( (resp: DataSession ) => resp ));

  } // buscar

  Delete(UsuarioID: number) {

    const url = this._AppConfigService.apiAdminUrl +  `Usuario/Delete?UsuarioID=${UsuarioID}`;
    return this._HttpClient.delete( url, this.httpOptions ).pipe( map( (resp: any ) => resp ));

  } // Delete

  Encryption(value: string): string {

    const key = CryptoJS.enc.Utf8.parse('7061737323313233');
    const iv = CryptoJS.enc.Utf8.parse('7061737323313233');
    const encrypted = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse(value), key,
            {
                keySize: 128 / 8,
                iv,
                mode: CryptoJS.mode.CBC,
                padding: CryptoJS.pad.Pkcs7
            });
        return encrypted.toString();

  } // Encryption

} // Service
