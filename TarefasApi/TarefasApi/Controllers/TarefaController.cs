using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TarefasApi.DTOs;
using TarefasApi.Models;
using TarefasApi.Services.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TarefasApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;

    
        public TarefasController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }


        [AllowAnonymous]
        [HttpGet("GetTarefas")]
        public async Task<IActionResult> GetTarefas()
        {
            try
            {

                var tarefas = await _tarefaService.GetTarefas();
                return Ok(tarefas);

            }
            catch (Exception erro)
            {
                return StatusCode(500, "Error : " + erro);
            }
        }

        [AllowAnonymous]
        [HttpGet("GetTarefasById")]
        public async Task<IActionResult> GetTarefa(int id)
        {

            try { 

                var tarefa = await _tarefaService.GetTarefaById(id);
                if (tarefa == null)
                {
                    return NotFound($"Não foi encontrada nenhuma tarefa com Id = {id}");
                }

                return Ok(tarefa);

            }
            catch (Exception erro)
            {
                return StatusCode(500, "Error : " + erro);
            }
        }

        [AllowAnonymous]
        [HttpPost("CriarTarefa")]
        public async Task<IActionResult> AddTarefa([FromBody] TarefaCreateDto tarefaDto)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var novaTarefa = await _tarefaService.IncluirTarefa(tarefaDto.Titulo!, tarefaDto.Descricao!);
                return CreatedAtAction(nameof(GetTarefa), new { id = novaTarefa.Id }, novaTarefa);
            }
            catch (Exception erro)
            {
                return StatusCode(500, "Error : " + erro);
            }

        }

        [AllowAnonymous]
        [HttpPut("EditarTarefa")]
        public async Task<IActionResult> UpdateTarefa(int id, [FromBody] TarefaUpdateDto tarefaDto)
        {

            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != tarefaDto.Id)
                {
                    return BadRequest("Ids inconsistentes");
                }

                var tarefa = await _tarefaService.GetTarefaById(id);
                if (tarefa == null)
                {
                    return NotFound($"Tarefa não encontrada para id= {id}");
                }


                var tarefaAtualizada = await _tarefaService.AlterarTarefa(tarefa , tarefaDto);

                if (tarefa == null)
                    return BadRequest("Erro ao atualizar");

                return Ok();
            }
            catch (Exception erro)
            {
                return StatusCode(500, "Error : " + erro);
            }

        }

        [AllowAnonymous]
        [HttpDelete("ExcluirTarefa")]
        public async Task<IActionResult> DeleteTarefa(int id)
        {

            try
            {
                var sucesso = await _tarefaService.ExcluirTarefa(id);
                if (!sucesso)
                {
                    return NotFound($"Não foi possível excluir tarefa com id= {id}");
                }

                //return Ok($"Tarefa com id= {id} excluída com sucesso");
                return Ok();
            }
            catch (Exception erro)
            {
                return StatusCode(500, "Error : " + erro);
            }
        }
    }

}
