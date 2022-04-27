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
    public class MarcaMapping : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.ToTable("Marcas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnName("Nome");

            builder.OwnsOne(c => c.Nome, v =>
            {
                v.Property(x => x.Valor)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnType("varchar(50)");

                v.HasIndex(x => x.Valor)
                .IsUnique();
            });

            builder.HasMany(x => x.Veiculos)
                .WithOne(x => x.Marca)
                .HasForeignKey(x => x.MarcaId);

            // QUESTIONAR SOBRE ENUMS NO EF CORE

            builder.Property(c => c.Status)
                .IsRequired()
                .HasColumnType("");
        }
    }
}
