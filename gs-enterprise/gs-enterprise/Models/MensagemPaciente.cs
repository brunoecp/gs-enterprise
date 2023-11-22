using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gs_enterprise.Models
{
    [Table("T_med_mensagem_paciente")]
    public class MensagemPaciente
    {
        [Required]
        [Key]
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        public String mensagem {  get; set; }
    }
}
