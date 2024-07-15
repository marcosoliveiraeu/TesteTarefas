using Microsoft.EntityFrameworkCore;
using TarefasApi.Data;
using TarefasApi.Models;
using TarefasApi.Repositories.Interfaces;

namespace TarefasApi.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly ApplicationDbContext _context;

        public TarefaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tarefa>> GetTarefas()
        {

            try
            {
                return await _context.Tarefas.Include(t => t.Status).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar tarefas no banco de dados", ex);
            }
            
        }

        public async Task<Tarefa> GetTarefaById(int id)
        {
            try
            {
                return await _context.Tarefas.Include(t => t.Status).FirstOrDefaultAsync(t => t.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar tarefa com id = {id} no banco de dados",ex);
            }
        }

        public async Task<Tarefa> IncluirTarefa(Tarefa tarefa)
        {
            try
            {

                _context.Tarefas.Add(tarefa);
                await _context.SaveChangesAsync();
                return tarefa;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao incluir tarefa no banco de dados",ex);
            }
        }

        public async Task<Tarefa> AlterarTarefa(Tarefa tarefa)
        {
            try
            {
                _context.Entry(tarefa).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return tarefa;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao alterar tarefa com id= {tarefa.Id} no banco de dados",ex);
            }
        }

        public async Task<bool> ExcluirTarefa(int id)
        {
            try
            {
                var tarefa = await _context.Tarefas.FindAsync(id);
                if (tarefa == null)
                {
                    return false;
                }

                _context.Tarefas.Remove(tarefa);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao excluir tarefa com id= {id} no banco de dados", ex);
            }
        }

        public async Task<StatusTarefa> GetStatusTarefaByIdAsync(int id)
        {
            try
            {
                return await _context.StatusTarefas.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao busca status de tarefa com id= {id} from database.", ex);
            }
        }

    }

}
