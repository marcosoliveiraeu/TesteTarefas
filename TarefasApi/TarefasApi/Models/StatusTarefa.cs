using System.ComponentModel.DataAnnotations;

namespace TarefasApi.Models
{
    public class StatusTarefa
    {

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public  string Descricao { get; set; }

    }
}
