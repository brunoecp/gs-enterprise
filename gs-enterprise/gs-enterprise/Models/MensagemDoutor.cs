using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gs_enterprise.Models
{
    [Table("T_med_mensagem_medico")]

    public class MensagemDoutor
    {
        [Required]
        [Key]

        public int DoutorId { get; set; }
        public Doutor Doutor { get; set; }

        public String mensagem { get; set; }
    }
}
