﻿using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mappings
{
    internal class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {

        public EnderecoMapping()
        {
            
        }

        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Numero)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Cep)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(c => c.Complemento)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.Bairro)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Cidade)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.ToTable("Enderecos");
        }
    }
}
