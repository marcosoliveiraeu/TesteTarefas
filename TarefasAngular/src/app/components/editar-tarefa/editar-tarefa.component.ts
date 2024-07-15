

import { Component, Inject ,OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Tarefa } from '../../models/tarefa.model';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { TarefaService } from '../../services/Tarefa.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { PipesModule } from '../../pipes/pipes.module';
import { DateFormatPipe } from '../../pipes/date-format.pipe';

@Component({
  selector: 'app-editar-tarefa',
  standalone: true,
  imports: [MatDialogModule,MatFormFieldModule,CommonModule,ReactiveFormsModule,PipesModule],
  templateUrl: './editar-tarefa.component.html',
  styleUrls: ['./editar-tarefa.component.css'],
  providers: [DateFormatPipe]
})
export class EditarTarefaComponent implements OnInit {

  tarefaForm: FormGroup;
  originalConclusaoDate?: string | null;


  constructor(private fb: FormBuilder,
              private tarefaService: TarefaService,
              public dialogRef: MatDialogRef<EditarTarefaComponent>,
              @Inject(MAT_DIALOG_DATA) public data: Tarefa,
              private snackBar: MatSnackBar,
              private dateFormatPipe: DateFormatPipe)
  {

    this.originalConclusaoDate = this.dateFormatPipe.transform(data.dtConclusao);

    this.tarefaForm = this.fb.group({
      titulo: [data.titulo, [Validators.required, Validators.minLength(4), Validators.maxLength(100)]],
      descricao: [data.descricao, [Validators.required, Validators.minLength(4), Validators.maxLength(500)]],
      statusId: [data.status.id],
      dtConclusao: [this.dateFormatPipe.transform(data.dtConclusao)]

    });

  }

  ngOnInit(): void {

    this.tarefaForm.get('statusId')?.valueChanges.subscribe((statusId) => {
        this.atualizaData(Number(statusId));
    });
  }

  atualizaData(statusId: number) {

    const today = new Date().toLocaleDateString('pt-BR');

    if (statusId === 2) {
      this.tarefaForm.get('dtConclusao')!.setValue(this.originalConclusaoDate || today);
    } else {
      this.tarefaForm.get('dtConclusao')!.setValue(null);
    }

  }

  onSave() {

    if (this.tarefaForm.valid ) {

      const updatedTask = {
        id: this.data.id,
        titulo: this.tarefaForm.value.titulo,
        descricao: this.tarefaForm.value.descricao,
        statusId: this.tarefaForm.value.statusId
      };

      this.tarefaService.editarTarefa(this.data.id!, updatedTask).subscribe({
        next: () => {
          this.dialogRef.close(true)
        },
        error: () => {
          this.snackBar.open('Erro ao alterar tarefa. Tente novamente.', 'Fechar', {
            duration: 5000,
            panelClass: ['error-snackbar']
          });

        }
      });

    }else{
      this.showValidationErrors();
    }
  }


  private showValidationErrors(): void {
    const errors = this.tarefaForm.controls;
    for (const control in errors) {
      if (errors[control].invalid) {
        const errorMessage = this.getErrorMessage(control);
        this.snackBar.open(errorMessage, 'Fechar', {
          duration: 5000,
          panelClass: ['error-snackbar']
        });
      }
    }
  }

  private getErrorMessage(controlName: string): string {
    const control = this.tarefaForm.get(controlName);
    if (control?.hasError('required')) {
      return `${controlName.charAt(0).toUpperCase() + controlName.slice(1)} é obrigatório.`;
    }
    if (control?.hasError('minlength')) {
      return `${controlName.charAt(0).toUpperCase() + controlName.slice(1)} deve ter pelo menos ${control.getError('minlength').requiredLength} caracteres.`;
    }
    if (control?.hasError('maxlength')) {
      return `${controlName.charAt(0).toUpperCase() + controlName.slice(1)} deve ter no máximo ${control.getError('maxlength').requiredLength} caracteres.`;
    }
    return '';
  }



  onCancel(): void {
    this.dialogRef.close();
  }
}

