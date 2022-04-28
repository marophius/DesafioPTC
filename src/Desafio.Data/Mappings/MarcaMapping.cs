using Desafio.Domain.Entidades;
using Desafio.Domain.Enums;
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


            builder.OwnsOne(c => c.Nome, v =>
            {
                v.Property(x => x.Valor)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("Nome");

                v.HasIndex(x => x.Valor)
                .IsUnique();
            });

            builder.HasMany(x => x.Veiculos)
                .WithOne(x => x.Marca)
                .HasForeignKey(x => x.MarcaId);

            // QUESTIONAR SOBRE ENUMS NO EF CORE

            builder.Property(c => c.Status)
                .IsRequired()
                .HasConversion(v => v.ToString(), v => (EStatus)Enum.Parse(typeof(EStatus), v));
        }
    }
}
