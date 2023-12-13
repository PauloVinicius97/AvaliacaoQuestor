using AvaliacaoQuestor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoQuestor.Infra.Data.Mappings
{
    public class BoletoMap : IEntityTypeConfiguration<Boleto>
    {
        public void Configure(EntityTypeBuilder<Boleto> builder)
        {
            builder.Property(c => c.Id)
            .HasColumnName("Id")
            .IsRequired();

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.BancoId)
                .IsRequired();

            builder.HasOne<Banco>()
                .WithMany()
                .HasForeignKey(c => c.BancoId);

            builder.Property(c => c.Name)
                .IsRequired();

            builder.Property(c => c.CPF)
                .IsRequired();

            builder.Property(c => c.Amount)
                .IsRequired();

            builder.Property(c => c.DueDate)
                .IsRequired();

            builder.Property(c => c.Observation);
        }
    }
}
