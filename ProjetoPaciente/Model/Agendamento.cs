using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoPaciente.Model
{
    [Table("Agendamento")]
    public class Agendamento
    {
        [Key]
        public int AgendamentoId { get; set; }
        
        public Pessoa Paciente{ get; set; }
        public string Hora { get; set; }
        
        public string Data { get; set; }
        public string Especialidade { get; set; }


        

    }
}
