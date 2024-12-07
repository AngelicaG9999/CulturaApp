import { Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import Swal from 'sweetalert2';


@Injectable({
  providedIn: 'root'
})
export class MessageBoxService {

  constructor() {}

  Success(_title: string, _text: string, _showConfirmButton: boolean = true, _timer: number = 3000) {

    Swal.fire({
      icon: 'success',
      title: _title,
      text: _text,
      showConfirmButton: _showConfirmButton,
      timer: _timer
    });

  }

  Info(_title: string, _text: string, _showConfirmButton: boolean = true, _timer: number = 4000) {

    Swal.fire({
      icon: 'info',
      title: _title,
      text: _text,
      showConfirmButton: _showConfirmButton,
      timer: _timer
    });

  }

  Warning(_title: string, _text: string, _showConfirmButton: boolean = true, _timer: number = 4000) {

    Swal.fire({
      icon: 'warning',
      title: _title,
      text: _text,
      showConfirmButton: _showConfirmButton,
      timer: _timer
    });

  }

  Error(_title: string, _text: string, _showConfirmButton: boolean = true, _timer: number = 0) {

    Swal.fire({
      icon: 'error',
      title: _title,
      html: _text,
      showConfirmButton: _showConfirmButton,
      timer: _timer === 0 ? null : _timer
    });

  }

  getErrorMessage(objError: any): string {
    let errorMessage = '';
    console.log(objError);

    if (objError.error instanceof ErrorEvent) {
      // client-side error
      errorMessage = `${objError.error.message}`;
    } else {
      // server-side error
      if (objError.error !== undefined) { errorMessage = `${objError.error}<br/>`; }
      if (objError.error.ExceptionMessage !== undefined) { errorMessage = errorMessage + `${objError.error.ExceptionMessage}<br/><br/>${objError.message}<br/>`; }
      if (objError.error.MessageDetail !== undefined) { errorMessage = errorMessage + '<br/>' + objError.error.MessageDetail + '<br/>'; }
      if (objError.message !== undefined) { errorMessage = errorMessage + '<br/>' + objError.message + '<br/>'; }
      if (objError.error.Message !== undefined) { errorMessage = errorMessage + '<br/>' + objError.error.Message + '<br/>'; }
    }

    return errorMessage;
  }

}
