using Microsoft.EntityFrameworkCore;
using TarefasApi.DTOs;
using TarefasApi.Models;
using TarefasApi.Repositories.Interfaces;
using TarefasApi.Services.Interfaces;

namespace TarefasApi.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<IEnumerable<Tarefa>> GetTarefas()
        {
            try
            {
                return await _tarefaRepository.GetTarefas();
            }catch (Exception ex)
            {
                throw new Exception("Erro ao buscar tarefas no repositorio.", ex);
            }
        }

        public async Task<Tarefa> GetTarefaById(int id)
        {
            try
            {
                return await _tarefaRepository.GetTarefaById(id);
            }catch (Exception ex)
            {
                throw new Exception("Erro ao buscar tarefa com id = " + id + " no repositorio.", ex);
            }
        }

        public async Task<Tarefa> IncluirTarefa(string titulo, string descricao)
        {
            try
            {

                var statusPendente = await _tarefaRepository.GetStatusTarefaByIdAsync(1);
                if (statusPendente == null)
                {
                    throw new Exception("Status Pendente não encontrado.");
                }

                var tarefa = new Tarefa
                {
                    Titulo = titulo,
                    Descricao = descricao,
                    Status = statusPendente,
                    DtAbertura = DateTime.Now,
                    DtConclusao = null
                };

                return await _tarefaRepository.IncluirTarefa(tarefa);
            }catch(Exception ex)
            {
                throw new Exception("Erro ao incluir tarefa no repositorio",ex);
            }
        }

        public async Task<Tarefa> AlterarTarefa(Tarefa tarefa , TarefaUpdateDto tarefaDto)
        {
            try
            {

                tarefa.Titulo = tarefaDto.Titulo;
                tarefa.Descricao = tarefaDto.Descricao;


                // se os status permanecerem iguais , não altera a data de conclusão
                if (tarefaDto.StatusId != tarefa.Status.Id)
                {
                    var novoStatus = await _tarefaRepository.GetStatusTarefaByIdAsync(tarefaDto.StatusId);
                    if (novoStatus == null)
                    {
                        throw new Exception("Status não encontrado.");
                    }

                    tarefa.Status = novoStatus;

                    switch (tarefaDto.StatusId)
                    {
                        case 1:
                            // se o status novo for pendente
                            tarefa.DtConclusao = null; 
                            break;

                        case 2:
                            // se status novo for concluido
                            tarefa.DtConclusao = DateTime.Now;
                            break ;

                        default:
                            throw new Exception("Regra do status não definida.");

                    }

                }                   

                return await _tarefaRepository.AlterarTarefa(tarefa);

            }
            catch(Exception ex)
            {
                throw new Exception($"Erro ao alterar tarefa com id = {tarefa.Id} no repositorio",ex);
            }
        }

        public async Task<bool> ExcluirTarefa(int id)
        {
            try
            {
                return await _tarefaRepository.ExcluirTarefa(id);
            }
            catch(Exception ex)
            {
                throw new Exception($"Erro ao excluir tarefa com id = {id} no repositorio",ex);
            }
        }
    }

}
