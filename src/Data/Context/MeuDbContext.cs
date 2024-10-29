using Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options) { }


        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            // Configura a exclusão em cascata para Fornecedores e seus Endereços associados
            modelBuilder.Entity<Fornecedor>()
            .HasOne(f => f.Endereco)
            .WithOne(e => e.Fornecedor)
            .HasForeignKey<Endereco>(e => e.FornecedorId)
            .OnDelete(DeleteBehavior.Cascade);

            // Define o comportamento padrão para outros relacionamentos
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                if (relationship.PrincipalEntityType.ClrType != typeof(Fornecedor) || relationship.DeclaringEntityType.ClrType != typeof(Endereco))
                {
                    relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
                }
            }

            base.OnModelCreating(modelBuilder);
        }

    }
}
