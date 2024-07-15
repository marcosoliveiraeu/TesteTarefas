
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { TarefaService } from '../../services/Tarefa.service';

import { MatDialogRef, MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';

@Component({
  selector: 'app-nova-tarefa',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, MatFormFieldModule, MatInputModule, MatButtonModule, MatDialogModule, MatSnackBarModule],
  templateUrl: './nova-tarefa.component.html',
  styleUrls: ['./nova-tarefa.component.css']
})
export class NovaTarefaComponent {
  taskForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<NovaTarefaComponent>,
    private tarefaService: TarefaService,
    private snackBar: MatSnackBar
  ) {
    this.taskForm = this.fb.group({

      titulo: ['', [Validators.required, Validators.minLength(4),Validators.maxLength(100)]],
      descricao: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(500)]]

    });
  }

  onCancel(): void {
    this.dialogRef.close();
  }

  onSubmit(): void {
    if (this.taskForm.valid) {
      const newTask = {
        titulo: this.taskForm.value.titulo,
        descricao: this.taskForm.value.descricao
      };


      this.tarefaService.NovaTarefa(newTask).subscribe({
        next: () => {
          this.dialogRef.close(true);
        },
        error: () => {
          this.snackBar.open('Erro ao criar tarefa. Tente novamente.', 'Fechar', {
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
    const errors = this.taskForm.controls;
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
    const control = this.taskForm.get(controlName);
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


}

