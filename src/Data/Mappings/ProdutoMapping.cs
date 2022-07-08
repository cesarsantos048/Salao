using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Unidade)
               .IsRequired()
               .HasColumnType("int(2)");

            builder.Property(p => p.PrecoCompra)
               .IsRequired()
               .HasColumnType("decimal(10,2)");

            builder.Property(p => p.PrecoVenda)
               .IsRequired()
               .HasColumnType("decimal(10,2)");

            builder.Property(p => p.Estoque)
               .IsRequired()
               .HasColumnType("int(20)");

            builder.Property(p => p.Status)
               .IsRequired()
               .HasColumnType("int(2)");


            builder.ToTable("Produtos");

        }
    }
}
