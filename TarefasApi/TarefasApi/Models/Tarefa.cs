using System.ComponentModel.DataAnnotations;

namespace TarefasApi.Models
{
    public class Tarefa
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o título da tarefa.")]
        [StringLength(100, ErrorMessage = "O numero máximo de caracteres é 100.")]
        [MinLength(4 , ErrorMessage = "O título deve conter pelo menos 4 caracteres.")]
        public  string Titulo { get; set; }

        [Required(ErrorMessage = "Digite a descrição da tarefa.")]
        [StringLength(500, ErrorMessage = "O numero máximo de caracteres é 500.")]
        [MinLength(4, ErrorMessage = "A descrição da tarefa deve conter pelo menos 4 caracteres.")]
        public  string Descricao { get; set; }

        [Required]
        public  StatusTarefa Status {  get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime  DtAbertura { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DtConclusao { get; set; }

    }
}
