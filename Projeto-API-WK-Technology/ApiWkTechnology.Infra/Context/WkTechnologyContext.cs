using ApiWkTechnology.Domain.Entities;
using ApiWkTechnology.Infra.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace ApiWkTechnology.Infra.Context
{
    public class WkTechnologyContext : DbContext
    {
        public WkTechnologyContext(DbContextOptions<WkTechnologyContext> options) : base(options)
        {

        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Seed

            #region SeedCategoria
            modelBuilder.Entity<Categoria>().HasData(new Categoria(Guid.Parse("5aa6c1d0-0eb4-4dae-8813-08d9e2b4aa87"), "Utensílios de cozinha", "Categoria reservada para panelas e utensílios da cozinha"));
            modelBuilder.Entity<Categoria>().HasData(new Categoria(Guid.Parse("03e68c0c-1164-43c9-6bb9-08d9e34472ad"), "Móveis", "Categoria reservada para móveis e produtos de decoração"));
            modelBuilder.Entity<Categoria>().HasData(new Categoria(Guid.Parse("69881eb1-b47e-4d56-6bc1-08d9e34472ad"), "Peças de informática", "Categoria reservada para equipamentos eletrônicos"));
            #endregion

            #region SeedProdutos

            //Produtos da Categoria Utensílios de cozinha
            modelBuilder.Entity<Produto>()
                .HasData(new Produto(Guid.Parse("93f1dc21-f381-46ff-0990-08d9e28b76b2"),
                "Panela de Pressão aço reforçado, Cor: Preta", "Panela de Pressão",
                29.99, "INOX", Guid.Parse("5aa6c1d0-0eb4-4dae-8813-08d9e2b4aa87")));

            modelBuilder.Entity<Produto>()
                .HasData(new Produto(Guid.Parse("d68e04a3-0612-4034-098e-08d9e28b76b2"),
                "Frigideira anti-aderente, Cor: Azul", "Frigideira",
                19.50, "INOX", Guid.Parse("5aa6c1d0-0eb4-4dae-8813-08d9e2b4aa87")));

            modelBuilder.Entity<Produto>()
                .HasData(new Produto(Guid.Parse("c4edecaa-0ca1-4113-098f-08d9e28b76b2"),
                "Liquidificador, Cor: Branco", "Liquidificador",
                89.25, "Britânia", Guid.Parse("5aa6c1d0-0eb4-4dae-8813-08d9e2b4aa87")));

            //Produtos da Categoria Móveis

            modelBuilder.Entity<Produto>()
               .HasData(new Produto(Guid.Parse("f80244ce-8a53-4d00-8810-08d9e2b4aa87"),
               "Poltrona Inclinável 90°, Cor: Preta", "Poltrona",
               299.99, "Ortobom", Guid.Parse("03e68c0c-1164-43c9-6bb9-08d9e34472ad")));

            modelBuilder.Entity<Produto>()
                .HasData(new Produto(Guid.Parse("6da8a2ce-5eeb-4adf-8811-08d9e2b4aa87"),
                "Sofá 3 lugares, Cor: Preta", "Sofá",
                910.00, "Orthoflex", Guid.Parse("03e68c0c-1164-43c9-6bb9-08d9e34472ad")));

            modelBuilder.Entity<Produto>()
                .HasData(new Produto(Guid.Parse("d61bcb30-ed4f-4dc0-8812-08d9e2b4aa87"),
                "Mesa de Janta 8 lugares", "Mesa",
                1200.00, "Madereira Selva", Guid.Parse("03e68c0c-1164-43c9-6bb9-08d9e34472ad")));

            //Produtos da Peças de informática

            modelBuilder.Entity<Produto>()
               .HasData(new Produto(Guid.Parse("5aa6c1d0-0eb4-4dae-8813-08d9e2b4aa87"),
               "Memória ram 8GB 2400MHZ", "Memória 8GB",
               199.99, "HyperX", Guid.Parse("69881eb1-b47e-4d56-6bc1-08d9e34472ad")));

            modelBuilder.Entity<Produto>()
                .HasData(new Produto(Guid.Parse("a086f9b0-fac6-4301-3854-08d9e2c206fe"),
                "Monitor 144 Hz , 0.5 ms IPS", "Monitor 144",
                1500, "ACE", Guid.Parse("69881eb1-b47e-4d56-6bc1-08d9e34472ad")));

            modelBuilder.Entity<Produto>()
                .HasData(new Produto(Guid.Parse("f7bdc102-84e9-41f7-3855-08d9e2c206fe"),
                "Monitor UltraWide 29 polegadas, 75 Hz , 5 ms", "UltraWide 29",
                1299.99, "LG", Guid.Parse("69881eb1-b47e-4d56-6bc1-08d9e34472ad")));

            #endregion

            #endregion

            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
