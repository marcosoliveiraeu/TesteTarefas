using TarefasApi.Models;

namespace TarefasApi.Repositories.Interfaces
{
    public interface ITarefaRepository
    {
        Task<IEnumerable<Tarefa>> GetTarefas();
        Task<Tarefa> GetTarefaById(int id);
        Task<Tarefa> IncluirTarefa(Tarefa tarefa);
        Task<Tarefa> AlterarTarefa(Tarefa tarefa);
        Task<bool> ExcluirTarefa(int id);

        Task<StatusTarefa> GetStatusTarefaByIdAsync(int id);
    }

}
