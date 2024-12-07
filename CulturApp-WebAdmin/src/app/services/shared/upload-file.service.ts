import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

// Services
import { AppConfigService } from '../app-config.service';

@Injectable({
  providedIn: 'root'
})
export class UploadFileService {

  public ValidVize: number;

  constructor(
    private http: HttpClient,
    private appConfigService: AppConfigService
    ) { }

  postFile(Nombre: string, Ruta: string, fileToUpload: File) {
    const endpoint = this.appConfigService.apiAdminUrl + 'Upload/File';
    const formData: FormData = new FormData();
    formData.append('FileToUpload', fileToUpload, fileToUpload.name);
    formData.append('FileName', Nombre);
    formData.append('FilePath', Ruta);
    return this.http.post(endpoint, formData);
  }

  validateSize(size: number): boolean {
    let rValue: boolean;
    const kb: number = size / 1000;

    rValue = false;
    if ( kb <= this.ValidVize) {
      rValue = true;
    }

    return rValue;
  }

}
