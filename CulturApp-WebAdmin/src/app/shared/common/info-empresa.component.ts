import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';

export interface DialogData {
  EmpresaID: number;
}

@Component({
    selector: 'app-info-empresa',
    templateUrl: './info-empresa.component.html',
    styles: [],
    standalone: true,
    imports: [MatButtonModule]
})
export class InfoEmpresaComponent implements OnInit {

  EmpresaID = 0;
  Titulo = 'Info Empresa';

  constructor(
    private dialogRef: MatDialogRef<InfoEmpresaComponent>,
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
