using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gs_enterprise.Models
{
    [Table("T_med_paciente")]
    public class Paciente
    {
        [Required]
        [Key]
        public int PacienteId {  get; set; }

        [Required]
        [Column("nm_completo")]
        public String nome { get; set; }
        [Required]
        [Column("ds_email")]
        public String email { get; set; }
        [Required]
        [Column("dt_nascimento")]
        public DateTime nascimento{ get; set; }
        [Required]
        [Column("nr_cpf")]
        public String cpf { get; set; }
        [Required]
        [Column("ds_senha")]
        public String senha { get; set; }
        public ICollection<MensagemPaciente> mensagemPacientes { get; set; }

    }
}
