using System.ComponentModel.DataAnnotations;

namespace TarefasApi.DTOs
{
    public class TarefaCreateDto
    {
        [Required(ErrorMessage = "Digite o título da tarefa.")]
        [StringLength(100, ErrorMessage = "O numero máximo de caracteres é 100.")]
        [MinLength(4, ErrorMessage = "O título deve conter pelo menos 4 caracteres.")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "Digite a descrição da tarefa.")]
        [StringLength(500, ErrorMessage = "O numero máximo de caracteres é 500.")]
        [MinLength(4, ErrorMessage = "A descrição da tarefa deve conter pelo menos 4 caracteres.")]
        public string? Descricao { get; set; }
    }
}
