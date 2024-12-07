import { APP_INITIALIZER, ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideHttpClient, withFetch, withInterceptorsFromDi } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { provideAnimations } from '@angular/platform-browser/animations';
import { provideRouter, withHashLocation } from '@angular/router';


import { NgxSpinnerModule } from 'ngx-spinner';

import { appRoutes } from '../app/app.routes';
import { AppConfigService } from './services/app-config.service';

export const appConfig: ApplicationConfig = {
    providers: [
        provideRouter(appRoutes, withHashLocation()),
        importProvidersFrom(BrowserModule, FormsModule, NgxSpinnerModule),
        {
            provide: APP_INITIALIZER, multi: true, deps: [AppConfigService], useFactory: (appConfigService: AppConfigService) => () => appConfigService.loadAppConfig()
        },
        provideHttpClient(withFetch(), withInterceptorsFromDi()),
        provideAnimations()
    ]
};