using Desafio.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Data.Mappings
{
    public class ProprietarioMapping : IEntityTypeConfiguration<Proprietario>
    {
        public void Configure(EntityTypeBuilder<Proprietario> builder)
        {
            

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(x => x.Documento)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnType("int");

            builder.HasIndex(x => x.Documento)
                .IsUnique();

            builder.OwnsOne(x => x.Nome, n =>
            {
                n.Property(x => x.Valor)
                .HasMaxLength(50)
                .HasColumnType("varchar(30)")
                .IsRequired();
            });

            builder.OwnsOne(x => x.Endereco, e =>
            {
                e.Property(x => x.Cep)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnType("varchar(11)");

                e.Property(x => x.Street)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

                e.Property(x => x.NeighborHood)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

                e.Property(x => x.Service)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

                e.Property(x => x.State)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

                e.Property(x => x.City)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");
            });

            builder.ToTable("Proprietarios");
        }
    }
}
