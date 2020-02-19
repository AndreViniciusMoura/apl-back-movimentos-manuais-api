using apl_movimentos_manuais.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apl_movimentos_manuais.Infra.Persistence.Mappings
{
    class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(e => e.CodProduto);

            builder.ToTable("PRODUTO");

            builder.Property(e => e.CodProduto)
                .HasColumnName("COD_PRODUTO")
                .HasMaxLength(4)
                .IsUnicode(false)
                .ValueGeneratedNever();

            builder.Property(e => e.DesProduto)
                .HasColumnName("DES_PRODUTO")
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.StaStatus)
                .HasColumnName("STA_STATUS")
                .HasMaxLength(1)
                .IsUnicode(false);
        }
    }
}
