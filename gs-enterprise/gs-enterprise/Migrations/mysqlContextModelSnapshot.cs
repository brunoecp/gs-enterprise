﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using gs_enterprise.Data;

#nullable disable

namespace gsenterprise.Migrations
{
    [DbContext(typeof(mysqlContext))]
    partial class mysqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("gs_enterprise.Models.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MensagemDoutorId")
                        .HasColumnType("int");

                    b.Property<int>("MensagemPacienteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MensagemDoutorId");

                    b.HasIndex("MensagemPacienteId");

                    b.ToTable("T_med_chat");
                });

            modelBuilder.Entity("gs_enterprise.Models.Doutor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("crm")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nr_crm");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("ds_email");

                    b.Property<DateTime>("nascimento")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("dt_nascimento");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nm_completo");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("ds_senha");

                    b.HasKey("Id");

                    b.ToTable("T_med_Doutor");
                });

            modelBuilder.Entity("gs_enterprise.Models.Informacoes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<int>("batimento")
                        .HasColumnType("int")
                        .HasColumnName("nr_batimento");

                    b.Property<int>("latitude")
                        .HasColumnType("int")
                        .HasColumnName("ds_latitude");

                    b.Property<int>("longitude")
                        .HasColumnType("int")
                        .HasColumnName("ds_longitude");

                    b.Property<int>("temp")
                        .HasColumnType("int")
                        .HasColumnName("nr_temperatura");

                    b.Property<int>("umidade")
                        .HasColumnType("int")
                        .HasColumnName("nr_unmidade");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.ToTable("T_med_informações");
                });

            modelBuilder.Entity("gs_enterprise.Models.MensagemDoutor", b =>
                {
                    b.Property<int>("DoutorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DoutorId1")
                        .HasColumnType("int");

                    b.Property<string>("mensagem")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("DoutorId");

                    b.HasIndex("DoutorId1");

                    b.ToTable("T_med_mensagem_medico");
                });

            modelBuilder.Entity("gs_enterprise.Models.MensagemPaciente", b =>
                {
                    b.Property<int>("PacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PacienteId1")
                        .HasColumnType("int");

                    b.Property<string>("mensagem")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PacienteId");

                    b.HasIndex("PacienteId1");

                    b.ToTable("T_med_mensagem_paciente");
                });

            modelBuilder.Entity("gs_enterprise.Models.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nr_cpf");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("ds_email");

                    b.Property<DateTime>("nascimento")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("dt_nascimento");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nm_completo");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("ds_senha");

                    b.HasKey("Id");

                    b.ToTable("T_med_paciente");
                });

            modelBuilder.Entity("gs_enterprise.Models.Chat", b =>
                {
                    b.HasOne("gs_enterprise.Models.MensagemDoutor", "Doutor")
                        .WithMany()
                        .HasForeignKey("MensagemDoutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("gs_enterprise.Models.MensagemPaciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("MensagemPacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doutor");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("gs_enterprise.Models.Informacoes", b =>
                {
                    b.HasOne("gs_enterprise.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("gs_enterprise.Models.MensagemDoutor", b =>
                {
                    b.HasOne("gs_enterprise.Models.Doutor", "Doutor")
                        .WithMany()
                        .HasForeignKey("DoutorId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doutor");
                });

            modelBuilder.Entity("gs_enterprise.Models.MensagemPaciente", b =>
                {
                    b.HasOne("gs_enterprise.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");
                });
#pragma warning restore 612, 618
        }
    }
}