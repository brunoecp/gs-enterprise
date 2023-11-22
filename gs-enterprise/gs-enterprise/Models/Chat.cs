using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gs_enterprise.Models
{
    [Table("T_med_chat")]
    public class Chat
    {
        public int Id { get; set; }
        public int MensagemDoutorId { get; set; }
        public MensagemDoutor Doutor { get; set; }

        public int MensagemPacienteId { get; set; }
        public MensagemPaciente Paciente { get; set; }
    }
}
