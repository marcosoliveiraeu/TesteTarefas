import { StatusTarefa } from "./statusTarefa.model";

export interface Tarefa{
  id?: number,
  titulo: string,
  descricao: string,
  status: StatusTarefa,
  dtAbertura: string,
  dtConclusao: string
}
