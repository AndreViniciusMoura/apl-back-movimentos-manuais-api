using apl_movimentos_manuais.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apl_movimentos_manuais.Infra.Persistence.Mappings
{
    class ProdutoCosifMapping : IEntityTypeConfiguration<ProdutoCosif>
    {
        public void Configure(EntityTypeBuilder<ProdutoCosif> builder)
        {
            builder.HasKey(e => new { e.CodProduto, e.CodCosif });

            builder.ToTable("PRODUTO_COSIF");

            builder.Property(e => e.CodProduto)
                   .HasColumnName("COD_PRODUTO")
                   .HasMaxLength(4)
                   .IsUnicode(false);

            builder.Property(e => e.CodCosif)
                   .HasColumnName("COD_COSIF")
                   .HasMaxLength(11)
                   .IsUnicode(false);

            builder.Property(e => e.CodClassificacao)
                   .HasColumnName("COD_CLASSIFICACAO")
                   .HasMaxLength(6)
                   .IsUnicode(false);

            builder.Property(e => e.StaStatus)
                   .HasColumnName("STA_STATUS")
                   .HasMaxLength(1)
                   .IsUnicode(false);

            builder.HasOne(d => d.CodProdutoNavigation)
                   .WithMany(p => p.ProdutoCosif)
                   .HasForeignKey(d => d.CodProduto)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_PRODUTO_COSIF_PRODUTO");
        }
    }
}
