
import { Component, OnInit, Compiler } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm, FormsModule } from '@angular/forms';
import { NgxSpinnerService, NgxSpinnerModule } from 'ngx-spinner';

// Services
import { UsuarioService } from '../services/usuario/usuario.service';
import { MessageBoxService } from '../services/tools/message-box.service';
import { AppConfigService } from '../services/app-config.service';
import { Parametros } from '../models/parametros.model';

import * as CryptoJS from 'crypto-js';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';


@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css'],
    standalone: true,
    imports: [NgxSpinnerModule, FormsModule, MatFormFieldModule, MatInputModule, MatCheckboxModule, MatButtonModule]
})
export class LoginComponent implements OnInit {

  empresa: string;
  email: string;
  password: string;
  dataSession: string;

  recuerdame = false;

  lParams: Parametros[] = [];
  param: Parametros;

  constructor(
    private _UsuarioService: UsuarioService,
    private _MessageBoxService: MessageBoxService,
    private _NgxSpinnerService: NgxSpinnerService,
    private _AppConfigService: AppConfigService,
    private _Router: Router,
    private _Compiler: Compiler
    ) {
      this._Compiler.clearCache();

      const empresaTemp: string = localStorage.getItem('Empresa') || '';
      const emailTemp: string = localStorage.getItem('Usuario') || '';
      const passwordTemp: string = localStorage.getItem('Password') || '';

      this.dataSession = localStorage.getItem('DataSession') || '';

      this.empresa = CryptoJS.AES.decrypt(empresaTemp, this._AppConfigService.passwordKey).toString(CryptoJS.enc.Utf8);
      this.email = CryptoJS.AES.decrypt(emailTemp, this._AppConfigService.passwordKey).toString(CryptoJS.enc.Utf8);
      this.password = CryptoJS.AES.decrypt(passwordTemp, this._AppConfigService.passwordKey).toString(CryptoJS.enc.Utf8);

      if (this.email.length >= 1) {
        this.recuerdame = true;

        if (this.dataSession.length > 1) {
          this.validateLogin(this.empresa, this.email, this.password, this.recuerdame);
        }

      }

    } // constructor

  ngOnInit() {
    this.probar();
  } // ngOnInit

  ingresar(forma: NgForm) {

    if ( forma.invalid) {
      return;
    }

    this.validateLogin(this.empresa, this.email, this.password, this.recuerdame);

  } // ingresar

  validateLogin(Empresa: string, UserName: string, Password: string, Recordar: boolean = false) {

    this._NgxSpinnerService.show();
    this._UsuarioService.login(Empresa, UserName, Password, Recordar)
                        .subscribe( respuesta => {

                          this._NgxSpinnerService.hide();

                          if ( respuesta.Acceso === true ) {
                            this._Router.navigate([ '/dashboard' ]);
                          } else {
                            this._MessageBoxService.Warning('Credenciales Invalidas.', 'Por favor validar sus datos de acceso.');
                          }

                        }, error => {
                          this._NgxSpinnerService.hide();
                          this._MessageBoxService.Error('Error inesperado', this._MessageBoxService.getErrorMessage(error));
                        });

  } // validateLogin

  probar() {

    this.lParams = [];

    this.param = new Parametros();
    this.param.Pantalla = 'Tercero';
    this.param.Maestro.push( {Campo: 'Documento', Valor: ''} );
    this.param.Maestro.push( {Campo: 'Nombre', Valor: ''} );
    this.lParams.push(this.param);

    this.param = new Parametros();
    this.param.Pantalla = 'Producto';
    this.param.Maestro.push( {Campo: 'Codigo', Valor: 'Eco'} );
    this.param.Maestro.push( {Campo: 'Nombre', Valor: 'Plan Eco'} );
    this.lParams.push(this.param);

    this.param = new Parametros();
    this.param.Pantalla = 'Pregunta';
    this.param.Maestro.push( {Campo: 'Asunto', Valor: ''} );
    this.lParams.push(this.param);


    localStorage.setItem('Params', JSON.stringify(this.lParams) );


    this.lParams.forEach( element => {

      // filtra la pantalla
      if (element.Pantalla === 'Producto') {
        element.Maestro.forEach (mtr => {

          // filtra los campos
          switch (mtr.Campo) {
            case 'Codigo':
              console.log(`Codigo: ${mtr.Valor}`);
              break;
            case 'Nombre':
              console.log(`Nombre: ${mtr.Valor}`);
              break;
          }

        });
      }

    }); // forEach ==> lParams


  } // probar

} // Component
