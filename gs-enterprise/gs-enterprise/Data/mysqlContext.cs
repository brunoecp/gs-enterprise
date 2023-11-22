using gs_enterprise.Models;
using Microsoft.EntityFrameworkCore;

namespace gs_enterprise.Data
{
    public class mysqlContext: DbContext
    { 
        public DbSet<Doutor> doutores {  get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Informacoes> Informacoes { get; set; }
        public DbSet<MensagemDoutor> MensagemDoutores { get; set; }
        public DbSet<MensagemPaciente> MensagemPacientes{ get; set; }


        public mysqlContext(DbContextOptions<mysqlContext> options) : base(options)
        {

        }
    }
}
