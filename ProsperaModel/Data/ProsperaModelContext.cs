using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SeuProjeto.Models;
using ProsperaModel.Models;

namespace ProsperaModel.Data
{
    public class ProsperaModelContext : DbContext
    {
        public ProsperaModelContext (DbContextOptions<ProsperaModelContext> options)
            : base(options)
        {
        }

        public DbSet<SeuProjeto.Models.TerceirosModel> TerceirosModel { get; set; } = default!;

        public DbSet<ProsperaModel.Models.UsuarioModel>? UsuarioModel { get; set; }

        public DbSet<ProsperaModel.Models.ConfiguracaoUsuarioModel>? ConfiguracaoUsuarioModel { get; set; }

        public DbSet<ProsperaModel.Models.ContaBancariaModel>? ContaBancariaModel { get; set; }

        public DbSet<ProsperaModel.Models.ContasPagarModel>? ContasPagarModel { get; set; }

        public DbSet<ProsperaModel.Models.ContasReceberModel>? ContasReceberModel { get; set; }

        public DbSet<ProsperaModel.Models.DevedorModel>? DevedorModel { get; set; }

        public DbSet<ProsperaModel.Models.ExtratoModel>? ExtratoModel { get; set; }

        public DbSet<ProsperaModel.Models.MetaModel>? MetaModel { get; set; }

        public DbSet<ProsperaModel.Models.OrcamentoModel>? OrcamentoModel { get; set; }

        public DbSet<StatusContBancariaModel>? StatusContBancariaModel { get; set; }

        public DbSet<StatusCRModel>? StatusCRModel { get; set; }

        public DbSet<StatusMetaModel>? StatusMetaModel { get; set; }

        public DbSet<StatusOrcamentoModel>? StatusOrcamentoModel { get; set; }

        public DbSet<StatusTransferenciaModel>? StatusTransferenciaModel { get; set; }

        public DbSet<StatusUsuarioModel>? StatusUsuarioModel { get; set; }

        public DbSet<ProsperaModel.Models.TransferenciaModel>? TransferenciaModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Defina o tipo da coluna para suas propriedades 'decimal'
            modelBuilder.Entity<ContaBancariaModel>()
                .Property(e => e.SaldoContBan)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<ContasPagarModel>()
                .Property(e => e.ValorCP)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<ContasReceberModel>()
                .Property(e => e.ValorCR)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<DevedorModel>()
                .Property(e => e.SaldoDevedor)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<ExtratoModel>()
                .Property(e => e.ValorExtrat)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<MetaModel>()
                .Property(e => e.ValorMeta)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<OrcamentoModel>()
                .Property(e => e.ValorOrca)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<TransferenciaModel>()
                .Property(e => e.ValorTransfe)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<TerceirosModel>()
                .Property(e => e.SaldoTerceiros)
                .HasColumnType("decimal(18, 2)");

        }



    }
}
