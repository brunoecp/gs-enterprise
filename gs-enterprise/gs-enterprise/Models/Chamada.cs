using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gs_enterprise.Models
{
    [Table("T_med_chamada")]
    public class Chamada
    {
        [Required]
        [Key]
        private int Id { get; set; }

        public int DoutorId { get; set; }
        public Doutor Doutor { get; set; }

        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }

    }
}
