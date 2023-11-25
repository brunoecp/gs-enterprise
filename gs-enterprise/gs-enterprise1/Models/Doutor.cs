using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace gs_enterprise.Models
{
    [Table("T_med_Doutor")]
    public class Doutor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("nm_completo")]
        public String nome { get; set; }
        [Required]
        [Column("ds_email")]
        public String email { get; set; }
        [Required]
        [Column("dt_nascimento")]
        public DateTime nascimento { get; set; }
        [Required]
        [Column("nr_crm")]
        public String crm { get; set; }
        [Required]
        [Column("ds_senha")]
        public String senha { get; set; }
        public ICollection<MensagemDoutor> mensagemDoutors { get; set; }
    }
}

