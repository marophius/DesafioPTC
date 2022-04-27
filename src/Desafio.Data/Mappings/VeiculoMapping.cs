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
    public class VeiculoMapping : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Marca)
                .WithMany(x => x.Veiculos);

            builder.HasOne(x => x.Proprietario)
                .WithMany(x => x.Veiculos)
                .HasForeignKey(x => x.ProprietarioId);

            builder.Property(x => x.MarcaId)
                .IsRequired();

            builder.Property(x => x.Modelo)
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(x => x.Quilometragem)
                .IsRequired()
                .HasColumnType("DECIMAL(10, 2)");

            builder.Property(x => x.Renavam)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.Valor)
                .IsRequired()
                .HasColumnType("DECIMAL(10, 2)");

            builder.Property(x => x.AnoFabricacao)
                .IsRequired();

            builder.Property(x => x.AnoModelo)
                .IsRequired();

            builder.HasIndex(x => x.Renavam)
                .IsUnique();

            builder.ToTable("Veiculos");

        }
    }
}
