import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { VERSION } from '@angular/material/core';
import { MatDialog } from '@angular/material/dialog';

// Services
import { UsuarioService } from '../../services/usuario/usuario.service';
import { ComponenteService } from '../../services/admin-sistema/generales/componente.service';
import { MessageBoxService } from '../../services/tools/message-box.service';

// Models
import { NavItem } from '../../models/nav-item';
import { Componente } from '../../models/admin-sistema/generales/componente.model';

// Components
import { InfoEmpresaComponent } from '../common/info-empresa.component';
import { AcercaDeComponent } from '../common/acerca-de.component';
import { ModulosComponent } from '../common/modulos.component';
import { MenuItemComponent } from '../menu-item/menu-item.component';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { NgFor, NgIf } from '@angular/common';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.css'],
    standalone: true,
    imports: [RouterLink, NgFor, NgIf, MatButtonModule, MatMenuModule, MenuItemComponent]
})
export class HeaderComponent implements OnInit {
  version = VERSION;
  navItems: NavItem[] = [
    {
      displayName: 'Dashboard',
      iconName: 'hide-menu', route: '/dashboard',
      children: []
    },
    {
      displayName: 'Aplicación',
      iconName: 'hide-menu',
      children: [
        {
          displayName: 'Configuración General',
          iconName: 'menu',
          children: [

          ]
        },
        {
          displayName: 'Gestión de Maestros',
          iconName: 'menu',
          children: [
            {displayName: 'Modalidad', iconName: 'video_label', route: '/modalidad-list'},
            {displayName: 'Área', iconName: 'video_label', route: '/area-list'},
            {displayName: 'Línea', iconName: 'video_label', route: '/linea-list'},
            {displayName: 'Comuna', iconName: 'video_label', route: '/comuna-list'},
            {displayName: 'Barrio', iconName: 'video_label', route: '/barrio-list'},
            {displayName: 'Edificio', iconName: 'video_label', route: '/edificio-list'},
            {displayName: 'Sala', iconName: 'video_label', route: '/sala-list'},
            {displayName: 'Evento', iconName: 'video_label', route: '/evento-list'},
          ]
        },
        {
          displayName: 'Programa de Estimulos',
          iconName: 'menu',
          children: [
            {displayName: 'Inscripciones', iconName: 'video_label', route: '/inscripcion-list'}
          ]
        }
      ]
    }
  ];

  ListaComponentes: Componente[] = [];

  constructor(
    public _UsuarioService: UsuarioService,
    public _ComponenteService: ComponenteService,
    private _MessageBoxService: MessageBoxService,
    private _Router: Router,
    private _MatDialog: MatDialog
  ) { }

  ngOnInit() {
    this.buscarComponentes();
  } // ngOnInit

  infoEmpresa(): void {
    const dialogRef = this._MatDialog.open(InfoEmpresaComponent, {
      height: '430px',
      width: '1010px',
      disableClose: false,
      autoFocus: true,
      data: {EmpresaID: this._UsuarioService._DataSession.EmpresaID}
    });

    dialogRef.afterClosed().subscribe((result) => {
      // this.animal = result;
    });
  } // infoEmpresa

  acercaDe(): void {
    const dialogRef = this._MatDialog.open(AcercaDeComponent, {
      height: '430px',
      width: '1010px',
      disableClose: false,
      autoFocus: true,
      data: {EmpresaID: this._UsuarioService._DataSession.EmpresaID}
    });

    dialogRef.afterClosed().subscribe((result) => {
      // this.animal = result;
    });
  } // acercaDe

  modulos(): void {
    const dialogRef = this._MatDialog.open(ModulosComponent, {
      height: '430px',
      width: '1010px',
      disableClose: false,
      autoFocus: true,
      data: {EmpresaID: this._UsuarioService._DataSession.EmpresaID}
    });

    dialogRef.afterClosed().subscribe((result) => {
      // this.animal = result;
    });
  } // acercaDe

  buscarComponentes() {
    this._ComponenteService.buscar(this._UsuarioService._DataSession.EmpresaID)
                        .subscribe(  Componentes => {
                          this.ListaComponentes = Componentes;
                        }, error => {
                          this._MessageBoxService.Error('Error inesperado', this._MessageBoxService.getErrorMessage(error));
                      });

  } // buscarComponentes

  goToProfile(): void {
    this._Router.navigate([ '/profile' ]);
  }

  closeOpenMenu() {
    const sidebar = document.querySelector('.sidebar');
    const btn = document.getElementById('btn');

    sidebar.classList.toggle('open');
    btn.classList.replace('bx-menu', 'bx-menu-alt-left');
  }

  panelUserDetail() {
    const panelUserDetail = document.getElementById('panelUserDetail');

    panelUserDetail.classList.toggle('show');
  }
} // Component
