using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NTTData.Core.Entities;

namespace NTTData.Infrastructure.DATA.Context
{
    public partial class BaseDataContext : DbContext
    {
        public BaseDataContext()
        {
        }

        public BaseDataContext(DbContextOptions<BaseDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Cuenta> Cuenta { get; set; } = null!;
        public virtual DbSet<Movimiento> Movimientos { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.Clienteid).HasColumnName("clienteid");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("contrasena");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Personaid).HasColumnName("personaid");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.Personaid)
                    .HasConstraintName("fkpersonas");
            });

            modelBuilder.Entity<Cuenta>(entity =>
            {
                //entity.HasNoKey();

                entity.Property(e => e.Clienteid).HasColumnName("clienteid");

                entity.Property(e => e.Cuentaid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("cuentaid");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Numerocuenta)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("numerocuenta");

                entity.Property(e => e.SaldoInicial)
                    .HasColumnType("decimal(15, 2)")
                    .HasColumnName("saldoInicial");

                entity.Property(e => e.Tipocuenta)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tipocuenta");

                entity.HasOne(d => d.Cliente)
                    .WithMany()
                    .HasForeignKey(d => d.Clienteid)
                    .HasConstraintName("fkcliente");
            });

            modelBuilder.Entity<Movimiento>(entity =>
            {
              //  entity.HasNoKey();

                entity.Property(e => e.Clienteid).HasColumnName("clienteid");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Movimientoid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("movimientoid");

                entity.Property(e => e.Saldo)
                    .HasColumnType("decimal(15, 2)")
                    .HasColumnName("saldo");

                entity.Property(e => e.SaldoInicial)
                    .HasColumnType("decimal(15, 2)")
                    .HasColumnName("saldoInicial");

                entity.Property(e => e.Tipomovimiento)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("tipomovimiento");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(15, 2)")
                    .HasColumnName("valor");

                entity.HasOne(d => d.Cliente)
                    .WithMany()
                    .HasForeignKey(d => d.Clienteid)
                    .HasConstraintName("fkcuenta");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("Persona");

                entity.Property(e => e.Personaid).HasColumnName("personaid");

                entity.Property(e => e.Dirección)
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("dirección");

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Genero)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("genero");

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("identificacion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Teléfono)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("teléfono");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
