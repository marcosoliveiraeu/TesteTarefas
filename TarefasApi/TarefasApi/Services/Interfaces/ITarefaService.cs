using TarefasApi.DTOs;
using TarefasApi.Models;

namespace TarefasApi.Services.Interfaces
{
    public interface ITarefaService
    {
        Task<IEnumerable<Tarefa>> GetTarefas();
        Task<Tarefa> GetTarefaById(int id);
        Task<Tarefa> IncluirTarefa(string titulo, string descricao);
        Task<Tarefa> AlterarTarefa(Tarefa tarefa, TarefaUpdateDto tarefaDto);
        Task<bool> ExcluirTarefa(int id);
    }

}
