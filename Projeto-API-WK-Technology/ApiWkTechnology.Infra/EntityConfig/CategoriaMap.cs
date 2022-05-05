using ApiWkTechnology.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiWkTechnology.Infra.EntityConfig
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(categoria => categoria.Id);
            builder.Property(categoria => categoria.Nome);
            builder.Property(categoria => categoria.Descricao);

            builder.HasMany(categoria => categoria.Produtos)
                .WithOne(produto => produto.Categoria)
                .HasForeignKey(produto => produto.CategoriaId);
        }
    }
}
