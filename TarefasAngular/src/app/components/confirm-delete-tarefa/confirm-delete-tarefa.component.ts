import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA  } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';


import { MatDialogModule } from '@angular/material/dialog';


@Component({
  selector: 'app-confirm-delete-tarefa',
  standalone: true,
  imports: [MatButtonModule,MatDialogModule],
  templateUrl: './confirm-delete-tarefa.component.html',
  styleUrl: './confirm-delete-tarefa.component.css'
})
export class ConfirmDeleteTarefaComponent {

  constructor(
    public dialogRef: MatDialogRef<ConfirmDeleteTarefaComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { id: number; titulo: string }
  ) {}

  onCancel(): void {
    this.dialogRef.close(false);
  }

  onConfirm(): void {
    this.dialogRef.close(true);
  }

}
