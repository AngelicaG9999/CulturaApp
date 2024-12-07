import { RouterModule, Routes } from '@angular/router';

//==> Guards
import { LoginGuard } from './guards/login.guard';

//==> Components
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './login/register.component';
import { PagesComponent } from './pages/pages.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';

import { ModalidadFormComponent } from './pages/gestion-maestros/modalidad/modalidad-form.component';
import { ModalidadListComponent } from './pages/gestion-maestros/modalidad/modalidad-list.component';
import { ModalidadViewComponent } from './pages/gestion-maestros/modalidad/modalidad-view.component';
import { AreaFormComponent } from './pages/gestion-maestros/area/area-form.component';
import { AreaListComponent } from './pages/gestion-maestros/area/area-list.component';
import { AreaViewComponent } from './pages/gestion-maestros/area/area-view.component';
import { LineaFormComponent } from './pages/gestion-maestros/linea/linea-form.component';
import { LineaListComponent } from './pages/gestion-maestros/linea/linea-list.component';
import { LineaViewComponent } from './pages/gestion-maestros/linea/linea-view.component';
import { InscripcionFormComponent } from './pages/gestion-maestros/inscripcion/inscripcion-form.component';
import { InscripcionListComponent } from './pages/gestion-maestros/inscripcion/inscripcion-list.component';
import { InscripcionViewComponent } from './pages/gestion-maestros/inscripcion/inscripcion-view.component';
import { BarrioFormComponent } from './pages/gestion-maestros/barrio/barrio-form.component';
import { BarrioListComponent } from './pages/gestion-maestros/barrio/barrio-list.component';
import { BarrioViewComponent } from './pages/gestion-maestros/barrio/barrio-view.component';
import { ComunaFormComponent } from './pages/gestion-maestros/comuna/comuna-form.component';
import { ComunaListComponent } from './pages/gestion-maestros/comuna/comuna-list.component';
import { ComunaViewComponent } from './pages/gestion-maestros/comuna/comuna-view.component';
import { EdificioFormComponent } from './pages/gestion-maestros/edificio/edificio-form.component';
import { EdificioListComponent } from './pages/gestion-maestros/edificio/edificio-list.component';
import { EdificioViewComponent } from './pages/gestion-maestros/edificio/edificio-view.component';
import { SalaFormComponent } from './pages/gestion-maestros/sala/sala-form.component';
import { SalaListComponent } from './pages/gestion-maestros/sala/sala-list.component';
import { SalaViewComponent } from './pages/gestion-maestros/sala/sala-view.component';
import { EventoFormComponent } from './pages/gestion-maestros/evento/evento-form.component';
import { EventoListComponent } from './pages/gestion-maestros/evento/evento-list.component';
import { EventoViewComponent } from './pages/gestion-maestros/evento/evento-view.component';


export const appRoutes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    {
        path: '', component: PagesComponent, canActivate: [ LoginGuard ],
        children: [
            { path: 'dashboard', component: DashboardComponent, data: { option: 'Principal', titulo: 'Dashboard' } },

            { path: 'modalidad-list', component: ModalidadListComponent, data: { titulo: '' } },
            { path: 'modalidad-vew/:id', component: ModalidadViewComponent, data: { titulo: '' } },
            { path: 'modalidad-form/:id/:action', component: ModalidadFormComponent, data: { titulo: '' } },

            { path: 'area-list', component: AreaListComponent, data: { titulo: '' } },
            { path: 'area-vew/:id', component: AreaViewComponent, data: { titulo: '' } },
            { path: 'area-form/:id/:action', component: AreaFormComponent, data: { titulo: '' } },

            { path: 'linea-list', component: LineaListComponent, data: { titulo: '' } },
            { path: 'linea-vew/:id', component: LineaViewComponent, data: { titulo: '' } },
            { path: 'linea-form/:id/:action', component: LineaFormComponent, data: { titulo: '' } },

            { path: 'inscripcion-list', component: InscripcionListComponent, data: { titulo: '' } },
            { path: 'inscripcion-vew/:id', component: InscripcionViewComponent, data: { titulo: '' } },
            { path: 'inscripcion-form/:id/:action', component: InscripcionFormComponent, data: { titulo: '' } },

            { path: 'comuna-list', component: ComunaListComponent, data: { titulo: '' } },
            { path: 'comuna-view/:id', component: ComunaViewComponent, data: { titulo: '' } },
            { path: 'comuna-form/:id/:action', component: ComunaFormComponent, data: { titulo: '' } },

            { path: 'barrio-list', component: BarrioListComponent, data: { titulo: '' } },
            { path: 'barrio-view/:id', component: BarrioViewComponent, data: { titulo: '' } },
            { path: 'barrio-form/:id/:action', component: BarrioFormComponent, data: { titulo: '' } },

            { path: 'edificio-list', component: EdificioListComponent, data: { titulo: '' } },
            { path: 'edificio-view/:id', component: EdificioViewComponent, data: { titulo: '' } },
            { path: 'edificio-form/:id/:action', component: EdificioFormComponent, data: { titulo: '' } },

            { path: 'sala-list', component: SalaListComponent, data: { titulo: '' } },
            { path: 'sala-view/:id', component: SalaViewComponent, data: { titulo: '' } },
            { path: 'sala-form/:id/:action', component: SalaFormComponent, data: { titulo: '' } },

            { path: 'evento-list', component: EventoListComponent, data: { titulo: '' } },
            { path: 'evento-view/:id', component: EventoViewComponent, data: { titulo: '' } },
            { path: 'evento-form/:id/:action', component: EventoFormComponent, data: { titulo: '' } },

            { path: '', redirectTo: '/dashboard', pathMatch: 'full' }
        ]
    }
];
