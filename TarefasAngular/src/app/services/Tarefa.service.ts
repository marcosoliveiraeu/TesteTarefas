import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse  } from '@angular/common/http';
import { environment } from "../../environments/environment";
import { Observable , throwError  } from "rxjs";
import { catchError } from "rxjs/operators";
import { Tarefa } from "../models/tarefa.model";

@Injectable({
  providedIn: 'root'
})

export class TarefaService{

  private url = `${environment.api}/Tarefas`

  //teste com db.json
  //private url = 'http://localhost:3000/tarefas';


  constructor( private httpClient: HttpClient) {
  }

  GetTarefas() : Observable<Tarefa[]>{

    const endpoint = `${this.url}/GetTarefas` ;
    return this.httpClient.get<Tarefa[]>(endpoint).pipe(catchError(this.handleError));

  }


  NovaTarefa(tarefa: { titulo: string; descricao: string }): Observable<Tarefa> {
    return this.httpClient.post<Tarefa>(`${this.url}/CriarTarefa`, tarefa)
      .pipe(catchError(this.handleError));
  }

  deleteTarefa(id: number): Observable<void> {
    return this.httpClient.delete<void>(`${this.url}/ExcluirTarefa?id=${id}`).pipe(
      catchError(this.handleError)
    );
  }

  editarTarefa(id: number, tarefa: any): Observable<void> {

    return this.httpClient.put<void>(`${this.url}/EditarTarefa?id=${id}`, {
      id: tarefa.id,
      titulo: tarefa.titulo,
      descricao: tarefa.descricao,
      statusId: tarefa.statusId
    }).pipe(
      catchError(this.handleError)
    );
  }





  private handleError(error: HttpErrorResponse): Observable<never> {
    let errorMessage = '';
    if (error.error instanceof Error) {
      errorMessage = `Erro no cliente: ${error.error.message}`;
    } else {
      errorMessage = `Erro do servidor: ${error.status} - ${error.message}`;
    }

    console.error({
      errorMessage,
      status: error.status,
      statusText: error.statusText,
      url: error.url,
      errorObject: error
    });


    return throwError(() => new Error(errorMessage));
  }

}
