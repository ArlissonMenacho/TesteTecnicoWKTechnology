using ApiWkTechnology.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiWkTechnology.Infra.EntityConfig
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(produto => produto.Id);
            builder.Property(produto => produto.Nome);
            builder.Property(produto => produto.Descricao);
            builder.Property(produto => produto.Preco);
            builder.Property(produto => produto.Marca);

            builder.HasOne(produto => produto.Categoria)
                .WithMany(categoria => categoria.Produtos)
                .HasForeignKey(produto => produto.CategoriaId);
        }
    }
}
