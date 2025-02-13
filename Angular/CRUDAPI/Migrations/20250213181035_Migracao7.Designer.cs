﻿// <auto-generated />
using System;
using CRUDAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CRUDAPI.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20250213181035_Migracao7")]
    partial class Migracao7
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CRUDAPI.Models.Categoria", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CompeticaoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ValorInscricao")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CompeticaoId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("CRUDAPI.Models.Competicao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("BannerImagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CriadorUsuarioId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modalidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CriadorUsuarioId");

                    b.ToTable("Competicoes");
                });

            modelBuilder.Entity("CRUDAPI.Models.Competidor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CriadorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagemUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CriadorId");

                    b.ToTable("Competidores");
                });

            modelBuilder.Entity("CRUDAPI.Models.Confronto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataTermino")
                        .HasColumnType("datetime2");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Confrontos");
                });

            modelBuilder.Entity("CRUDAPI.Models.ConfrontoInscricao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ConfrontoId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ConfrontoInscricaoPaiId")
                        .HasColumnType("bigint");

                    b.Property<long>("InscricaoId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ConfrontoId");

                    b.HasIndex("ConfrontoInscricaoPaiId");

                    b.HasIndex("InscricaoId");

                    b.ToTable("ConfrontoInscricao");
                });

            modelBuilder.Entity("CRUDAPI.Models.Inscricao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CategoriaId")
                        .HasColumnType("bigint");

                    b.Property<long>("CompetidorId")
                        .HasColumnType("bigint");

                    b.Property<long?>("CompetidorId1")
                        .HasColumnType("bigint");

                    b.Property<long>("PagamentoId")
                        .HasColumnType("bigint");

                    b.Property<int?>("Posição")
                        .HasColumnType("int");

                    b.Property<long?>("PremioResgatavelId")
                        .HasColumnType("bigint");

                    b.Property<bool>("WO")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("CompetidorId");

                    b.HasIndex("CompetidorId1");

                    b.HasIndex("PagamentoId");

                    b.HasIndex("PremioResgatavelId");

                    b.ToTable("Inscricoes");
                });

            modelBuilder.Entity("CRUDAPI.Models.Notificacao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("BannerImagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataExpiracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPublicacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PagamentoId")
                        .HasColumnType("bigint");

                    b.Property<string>("TipoAnuncio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PagamentoId");

                    b.ToTable("Notificacoes");
                });

            modelBuilder.Entity("CRUDAPI.Models.Premio", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DataEntrega")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PagamentoId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PagamentoId");

                    b.ToTable("Premios");
                });

            modelBuilder.Entity("CRUDAPI.Models.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CpfCnpj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmado")
                        .HasColumnType("bit");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagemUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("SenhaHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SenhaValidada")
                        .HasColumnType("bit");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TokenConfirmacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("CRUDAPI.Models.UsuarioNotificacao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("DataLeitura")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Lido")
                        .HasColumnType("bit");

                    b.Property<long>("NotificacaoId")
                        .HasColumnType("bigint");

                    b.Property<bool>("UsuarioAnunciante")
                        .HasColumnType("bit");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("NotificacaoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioNotificacoes");
                });

            modelBuilder.Entity("Pagamento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("FavorecidoId")
                        .HasColumnType("bigint");

                    b.Property<string>("InfoPagamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PagadorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Txid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pagamentos");
                });

            modelBuilder.Entity("CRUDAPI.Models.Categoria", b =>
                {
                    b.HasOne("CRUDAPI.Models.Competicao", "Competicao")
                        .WithMany("Categorias")
                        .HasForeignKey("CompeticaoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Competicao");
                });

            modelBuilder.Entity("CRUDAPI.Models.Competicao", b =>
                {
                    b.HasOne("CRUDAPI.Models.Usuario", "CriadorUsuario")
                        .WithMany()
                        .HasForeignKey("CriadorUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CriadorUsuario");
                });

            modelBuilder.Entity("CRUDAPI.Models.Competidor", b =>
                {
                    b.HasOne("CRUDAPI.Models.Usuario", "Criador")
                        .WithMany("Competidores")
                        .HasForeignKey("CriadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Criador");
                });

            modelBuilder.Entity("CRUDAPI.Models.ConfrontoInscricao", b =>
                {
                    b.HasOne("CRUDAPI.Models.Confronto", "Confronto")
                        .WithMany("ConfrontoInscricoes")
                        .HasForeignKey("ConfrontoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CRUDAPI.Models.ConfrontoInscricao", "ConfrontoInscricaoPai")
                        .WithMany()
                        .HasForeignKey("ConfrontoInscricaoPaiId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CRUDAPI.Models.Inscricao", "Inscricao")
                        .WithMany("ConfrontoInscricoes")
                        .HasForeignKey("InscricaoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Confronto");

                    b.Navigation("ConfrontoInscricaoPai");

                    b.Navigation("Inscricao");
                });

            modelBuilder.Entity("CRUDAPI.Models.Inscricao", b =>
                {
                    b.HasOne("CRUDAPI.Models.Categoria", "Categoria")
                        .WithMany("Inscricoes")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CRUDAPI.Models.Competidor", "Competidor")
                        .WithMany()
                        .HasForeignKey("CompetidorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CRUDAPI.Models.Competidor", null)
                        .WithMany("Inscricoes")
                        .HasForeignKey("CompetidorId1");

                    b.HasOne("Pagamento", "Pagamento")
                        .WithMany()
                        .HasForeignKey("PagamentoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CRUDAPI.Models.Premio", "PremioResgatavel")
                        .WithMany()
                        .HasForeignKey("PremioResgatavelId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Categoria");

                    b.Navigation("Competidor");

                    b.Navigation("Pagamento");

                    b.Navigation("PremioResgatavel");
                });

            modelBuilder.Entity("CRUDAPI.Models.Notificacao", b =>
                {
                    b.HasOne("Pagamento", "Pagamento")
                        .WithMany()
                        .HasForeignKey("PagamentoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Pagamento");
                });

            modelBuilder.Entity("CRUDAPI.Models.Premio", b =>
                {
                    b.HasOne("Pagamento", "Pagamento")
                        .WithMany()
                        .HasForeignKey("PagamentoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Pagamento");
                });

            modelBuilder.Entity("CRUDAPI.Models.UsuarioNotificacao", b =>
                {
                    b.HasOne("CRUDAPI.Models.Notificacao", "Notificacao")
                        .WithMany("UsuariosAlvo")
                        .HasForeignKey("NotificacaoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CRUDAPI.Models.Usuario", "Usuario")
                        .WithMany("AnunciosRecebidos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Notificacao");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CRUDAPI.Models.Categoria", b =>
                {
                    b.Navigation("Inscricoes");
                });

            modelBuilder.Entity("CRUDAPI.Models.Competicao", b =>
                {
                    b.Navigation("Categorias");
                });

            modelBuilder.Entity("CRUDAPI.Models.Competidor", b =>
                {
                    b.Navigation("Inscricoes");
                });

            modelBuilder.Entity("CRUDAPI.Models.Confronto", b =>
                {
                    b.Navigation("ConfrontoInscricoes");
                });

            modelBuilder.Entity("CRUDAPI.Models.Inscricao", b =>
                {
                    b.Navigation("ConfrontoInscricoes");
                });

            modelBuilder.Entity("CRUDAPI.Models.Notificacao", b =>
                {
                    b.Navigation("UsuariosAlvo");
                });

            modelBuilder.Entity("CRUDAPI.Models.Usuario", b =>
                {
                    b.Navigation("AnunciosRecebidos");

                    b.Navigation("Competidores");
                });
#pragma warning restore 612, 618
        }
    }
}
