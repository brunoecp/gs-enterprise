using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace gsenterprise.Migrations
{
    /// <inheritdoc />
    public partial class initiall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.CreateTable(
                name: "T_med_Doutor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nmcompleto = table.Column<string>(name: "nm_completo", type: "longtext", nullable: false),
                    dsemail = table.Column<string>(name: "ds_email", type: "longtext", nullable: false),
                    dtnascimento = table.Column<DateTime>(name: "dt_nascimento", type: "datetime(6)", nullable: false),
                    nrcrm = table.Column<string>(name: "nr_crm", type: "longtext", nullable: false),
                    dssenha = table.Column<string>(name: "ds_senha", type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_med_Doutor", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "T_med_paciente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nmcompleto = table.Column<string>(name: "nm_completo", type: "longtext", nullable: false),
                    dsemail = table.Column<string>(name: "ds_email", type: "longtext", nullable: false),
                    dtnascimento = table.Column<DateTime>(name: "dt_nascimento", type: "datetime(6)", nullable: false),
                    nrcpf = table.Column<string>(name: "nr_cpf", type: "longtext", nullable: false),
                    dssenha = table.Column<string>(name: "ds_senha", type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_med_paciente", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "T_med_mensagem_medico",
                columns: table => new
                {
                    DoutorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DoutorId1 = table.Column<int>(type: "int", nullable: false),
                    mensagem = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_med_mensagem_medico", x => x.DoutorId);
                    table.ForeignKey(
                        name: "FK_T_med_mensagem_medico_T_med_Doutor_DoutorId1",
                        column: x => x.DoutorId1,
                        principalTable: "T_med_Doutor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "T_med_informações",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    dslatitude = table.Column<int>(name: "ds_latitude", type: "int", nullable: false),
                    dslongitude = table.Column<int>(name: "ds_longitude", type: "int", nullable: false),
                    nrtemperatura = table.Column<int>(name: "nr_temperatura", type: "int", nullable: false),
                    nrunmidade = table.Column<int>(name: "nr_unmidade", type: "int", nullable: false),
                    nrbatimento = table.Column<int>(name: "nr_batimento", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_med_informações", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_med_informações_T_med_paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "T_med_paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "T_med_mensagem_paciente",
                columns: table => new
                {
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PacienteId1 = table.Column<int>(type: "int", nullable: false),
                    mensagem = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_med_mensagem_paciente", x => x.PacienteId);
                    table.ForeignKey(
                        name: "FK_T_med_mensagem_paciente_T_med_paciente_PacienteId1",
                        column: x => x.PacienteId1,
                        principalTable: "T_med_paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "T_med_chat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    MensagemDoutorId = table.Column<int>(type: "int", nullable: false),
                    MensagemPacienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_med_chat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_med_chat_T_med_mensagem_medico_MensagemDoutorId",
                        column: x => x.MensagemDoutorId,
                        principalTable: "T_med_mensagem_medico",
                        principalColumn: "DoutorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_med_chat_T_med_mensagem_paciente_MensagemPacienteId",
                        column: x => x.MensagemPacienteId,
                        principalTable: "T_med_mensagem_paciente",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_T_med_chat_MensagemDoutorId",
                table: "T_med_chat",
                column: "MensagemDoutorId");

            migrationBuilder.CreateIndex(
                name: "IX_T_med_chat_MensagemPacienteId",
                table: "T_med_chat",
                column: "MensagemPacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_T_med_informações_PacienteId",
                table: "T_med_informações",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_T_med_mensagem_medico_DoutorId1",
                table: "T_med_mensagem_medico",
                column: "DoutorId1");

            migrationBuilder.CreateIndex(
                name: "IX_T_med_mensagem_paciente_PacienteId1",
                table: "T_med_mensagem_paciente",
                column: "PacienteId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_med_chat");

            migrationBuilder.DropTable(
                name: "T_med_informações");

            migrationBuilder.DropTable(
                name: "T_med_mensagem_medico");

            migrationBuilder.DropTable(
                name: "T_med_mensagem_paciente");

            migrationBuilder.DropTable(
                name: "T_med_Doutor");

            migrationBuilder.DropTable(
                name: "T_med_paciente");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }
    }
}
