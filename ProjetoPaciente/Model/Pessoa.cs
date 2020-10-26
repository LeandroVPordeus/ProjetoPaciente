using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoPaciente.Model
{
    [Table("Pessoa")]
    public class Pessoa
    {
        [Key]
        public int PacienteId { get; set; }
        public string Nome { get; set; }

      
    }
}
