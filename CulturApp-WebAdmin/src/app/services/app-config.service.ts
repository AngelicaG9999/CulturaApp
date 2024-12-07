import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { AppConfig } from '../models/app-config.model';


@Injectable({
  providedIn: 'root'
})
export class AppConfigService {


  private _jsonURL = 'assets/data/app-config.json';
  private appConfig: AppConfig = new AppConfig();

  constructor(
    private _HttpClient: HttpClient
  ) {}

  loadAppConfig() {
    return this._HttpClient.get<AppConfig>(this._jsonURL)
      .toPromise()
      .then( (data: AppConfig) => {
        this.appConfig = data;
      });
  }

  get apiAdminUrl() {

    if (!this.appConfig) {
      throw Error('Config file not loaded!');
    }

    return this.appConfig.UrlApiAdmin;
  }

  get apiCulturAppUrl() {

    if (!this.appConfig) {
      throw Error('Config file not loaded!');
    }

    return this.appConfig.UrlApiCulturApp;
  }

  get apiDriveUrl() {

    if (!this.appConfig) {
      throw Error('Config file not loaded!');
    }

    return this.appConfig.UrlDrive;
  }

  // PASSWORD_KEY
  get passwordKey() {

    if (!this.appConfig) {
      throw Error('Config file not loaded!');
    }

    return this.appConfig.PasswordKey;
  }

}
