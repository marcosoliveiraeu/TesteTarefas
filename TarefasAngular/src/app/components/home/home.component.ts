import { Component, OnInit } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { TarefaService } from '../../services/Tarefa.service';
import { Tarefa } from '../../models/tarefa.model';
import { MatDialog } from '@angular/material/dialog';
import { NovaTarefaComponent } from '../nova-tarefa/nova-tarefa.component';
import { ConfirmDeleteTarefaComponent } from '../confirm-delete-tarefa/confirm-delete-tarefa.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatButtonModule } from '@angular/material/button';
import { EditarTarefaComponent } from '../editar-tarefa/editar-tarefa.component';
import { PipesModule } from '../../pipes/pipes.module';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, DatePipe,  MatButtonModule , PipesModule] ,
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{

  tarefas: Tarefa[] = [];

  constructor(
      private tarefaService: TarefaService,
      private dialog: MatDialog,
      private snackBar: MatSnackBar
  ){}

  ngOnInit(): void {

    this.tarefaService.GetTarefas().subscribe((data) =>{

      const dados = data;

      dados.map((item)=> {


       /*  //item.dtAbertura = new Date(item.dtAbertura!).toLocaleDateString('pt-BR');

        item.dtAbertura = this.formatDate(item.dtAbertura)

        if(item.dtConclusao){
          item.dtConclusao = new Date(item.dtConclusao!).toLocaleDateString('pt-BR');
        }else{
          item.dtConclusao = "";
        } */

      })

      this.tarefas = dados;

    });



  }

  /* formatDate(date: string | null): string {

    console.log(date);

    if (!date) return '';
    const parsedDate = new Date(date);
    return isNaN(parsedDate.getTime()) ? '' : parsedDate.toLocaleDateString('pt-BR');

  } */

  openCreateTaskDialog(): void {
    const dialogRef = this.dialog.open(NovaTarefaComponent, {
      width: '600px', height: '450px'
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.ngOnInit();

        this.snackBar.open('Tarefa criada com sucesso!', 'Fechar', {
          duration: 3000,
          panelClass: ['success-snackbar']
        });

      }
    });
  }


  editTask(task: Tarefa): void {
    const dialogRef = this.dialog.open(EditarTarefaComponent, {
      data: task,
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {

        this.ngOnInit();

        this.snackBar.open('Tarefa atualizada com sucesso!', 'Fechar', {
          duration: 3000,
          panelClass: ['success-snackbar']
        });
      }
    });
  }

  deleteTask(id: number, titulo: string): void {
    const dialogRef = this.dialog.open(ConfirmDeleteTarefaComponent, {
      data: { id, titulo },
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.tarefaService.deleteTarefa(id).subscribe({
          next: () => {
            this.tarefas = this.tarefas.filter(tarefa => tarefa.id !== id);
            this.snackBar.open('Tarefa excluída com sucesso!', 'Fechar', {
              duration: 3000,
              panelClass: ['success-snackbar']
            });
          },
          error: (err) => {
            console.error(err);
            this.snackBar.open('Erro ao excluir a tarefa. Tente novamente.', 'Fechar', {
              duration: 3000,
              panelClass: ['error-snackbar']
            });
          }
        });
      }
    });
  }
}
