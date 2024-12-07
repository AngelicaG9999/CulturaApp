import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

export interface DialogData {
  EmpresaID: number;
}

@Component({
    selector: 'app-acerca-de',
    templateUrl: './acerca-de.component.html',
    styles: [],
    standalone: true
})
export class AcercaDeComponent implements OnInit {

  EmpresaID = 0;
  Titulo = 'Acerca de';

  constructor(
    private dialogRef: MatDialogRef<AcercaDeComponent>,
    @Inject(MAT_DIALOG_DATA) private data: DialogData
  ) { }

  ngOnInit() {
  }

  save() {
    this.dialogRef.close(this.data);
  }

  close() {
    this.dialogRef.close();
  }

}
