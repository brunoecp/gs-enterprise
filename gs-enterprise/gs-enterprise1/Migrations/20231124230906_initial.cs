using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace gs_enterprise1.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "T_med_Doutor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nm_completo = table.Column<string>(type: "longtext", nullable: false),
                    ds_email = table.Column<string>(type: "longtext", nullable: false),
                    dt_nascimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    nr_crm = table.Column<string>(type: "longtext", nullable: false),
                    ds_senha = table.Column<string>(type: "longtext", nullable: false)
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
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nm_completo = table.Column<string>(type: "longtext", nullable: false),
                    ds_email = table.Column<string>(type: "longtext", nullable: false),
                    dt_nascimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    nr_cpf = table.Column<string>(type: "longtext", nullable: false),
                    ds_senha = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_med_paciente", x => x.PacienteId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "T_med_mensagem_medico",
                columns: table => new
                {
                    MensagemDoutorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DoutorId = table.Column<int>(type: "int", nullable: false),
                    mensagem = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_med_mensagem_medico", x => x.MensagemDoutorId);
                    table.ForeignKey(
                        name: "FK_T_med_mensagem_medico_T_med_Doutor_DoutorId",
                        column: x => x.DoutorId,
                        principalTable: "T_med_Doutor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "T_med_chamada",
                columns: table => new
                {
                    ChamadaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    duracao = table.Column<int>(type: "int", nullable: false),
                    DoutorId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_med_chamada", x => x.ChamadaId);
                    table.ForeignKey(
                        name: "FK_T_med_chamada_T_med_Doutor_DoutorId",
                        column: x => x.DoutorId,
                        principalTable: "T_med_Doutor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_med_chamada_T_med_paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "T_med_paciente",
                        principalColumn: "PacienteId",
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
                    ds_latitude = table.Column<int>(type: "int", nullable: false),
                    ds_longitude = table.Column<int>(type: "int", nullable: false),
                    nr_temperatura = table.Column<int>(type: "int", nullable: false),
                    nr_unmidade = table.Column<int>(type: "int", nullable: false),
                    nr_batimento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_med_informações", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_med_informações_T_med_paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "T_med_paciente",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "T_med_mensagem_paciente",
                columns: table => new
                {
                    MensagemPacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    mensagem = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_med_mensagem_paciente", x => x.MensagemPacienteId);
                    table.ForeignKey(
                        name: "FK_T_med_mensagem_paciente_T_med_paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "T_med_paciente",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "T_med_chat",
                columns: table => new
                {
                    ChatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    MensagemDoutorId = table.Column<int>(type: "int", nullable: false),
                    MensagemPacienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_med_chat", x => x.ChatId);
                    table.ForeignKey(
                        name: "FK_T_med_chat_T_med_mensagem_medico_MensagemDoutorId",
                        column: x => x.MensagemDoutorId,
                        principalTable: "T_med_mensagem_medico",
                        principalColumn: "MensagemDoutorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_med_chat_T_med_mensagem_paciente_MensagemPacienteId",
                        column: x => x.MensagemPacienteId,
                        principalTable: "T_med_mensagem_paciente",
                        principalColumn: "MensagemPacienteId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_T_med_chamada_DoutorId",
                table: "T_med_chamada",
                column: "DoutorId");

            migrationBuilder.CreateIndex(
                name: "IX_T_med_chamada_PacienteId",
                table: "T_med_chamada",
                column: "PacienteId");

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
                name: "IX_T_med_mensagem_medico_DoutorId",
                table: "T_med_mensagem_medico",
                column: "DoutorId");

            migrationBuilder.CreateIndex(
                name: "IX_T_med_mensagem_paciente_PacienteId",
                table: "T_med_mensagem_paciente",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_med_chamada");

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
        }
    }
}
