import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { UsuarioService } from '../services/usuario/usuario.service';

@Injectable({ providedIn: 'root' })
export class LoginGuard  {

  constructor(
    public _usuarioService: UsuarioService,
    public router: Router
  ) {}

  canActivate() {

    if ( this._usuarioService.estaLogueado() ) {
      return true;
    } else {
      this.router.navigate(['/login']);
      return false;
    }

  } // canActivate

}
