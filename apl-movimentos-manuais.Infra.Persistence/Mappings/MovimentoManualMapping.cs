using apl_movimentos_manuais.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace apl_movimentos_manuais.Infra.Persistence.Mappings
{
    public class MovimentoManualMapping : IEntityTypeConfiguration<MovimentoManual>
    {
        public void Configure(EntityTypeBuilder<MovimentoManual> builder)
        {
            builder.HasKey(e => new { e.DataMes, e.DataAno, e.NumLancamento, e.CodProduto, e.CodCosif });

            builder.ToTable("MOVIMENTO_MANUAL");

            builder.Property(e => e.DataMes)
                .HasColumnName("DAT_MES")
                .HasColumnType("numeric(2, 0)");

            builder.Property(e => e.DataAno)
                .HasColumnName("DAT_ANO")
                .HasColumnType("numeric(4, 0)");

            builder.Property(e => e.NumLancamento)
                .HasColumnName("NUM_LANCAMENTO")
                .HasColumnType("numeric(18, 0)");

            builder.Property(e => e.CodProduto)
                .HasColumnName("COD_PRODUTO")
                .HasMaxLength(4)
                .IsUnicode(false);

            builder.Property(e => e.CodCosif)
                .HasColumnName("COD_COSIF")
                .HasMaxLength(11)
                .IsUnicode(false);

            builder.Property(e => e.CodUsuario)
                .IsRequired()
                .HasColumnName("COD_USUARIO")
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.DataMovimento)
                .HasColumnName("DAT_MOVIMENTO")
                .HasColumnType("smalldatetime")
                .ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()").IsRequired();

            builder.Property(e => e.DesDescricao)
                .IsRequired()
                .HasColumnName("DES_DESCRICAO")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Valor)
                .HasColumnName("VAL_VALOR")
                .HasColumnType("numeric(18, 2)");

            builder.HasOne(d => d.Cod)
                .WithMany(p => p.MovimentoManual)
                .HasForeignKey(d => new { d.CodProduto, d.CodCosif })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MOVIMENTO_MANUAL_PRODUTO_COSIF");
        }
    }
}
