using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gs_enterprise.Models
{
    [Table("T_med_informações")]
    public class Informacoes
    {
        [Required]
        [Key]
        public int Id { get; set; }

        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        [Required]
        [Column("ds_latitude")]
        public int latitude { get; set; }
        [Required]
        [Column("ds_longitude")]
        public int longitude { get; set; }
        [Required]
        [Column("nr_temperatura")]
        public int temp { get; set; }
        [Required]
        [Column("nr_unmidade")]
        public int umidade { get; set; }
        [Required]
        [Column("nr_batimento")]
        public int batimento { get; set; }
    }
}
