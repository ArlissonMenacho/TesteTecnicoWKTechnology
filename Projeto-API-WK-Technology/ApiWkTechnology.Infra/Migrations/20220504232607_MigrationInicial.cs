using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiWkTechnology.Infra.Migrations
{
    public partial class MigrationInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Preco = table.Column<double>(type: "double", nullable: false),
                    Marca = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoriaId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[] { new Guid("03e68c0c-1164-43c9-6bb9-08d9e34472ad"), "Categoria reservada para móveis e produtos de decoração", "Móveis" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[] { new Guid("5aa6c1d0-0eb4-4dae-8813-08d9e2b4aa87"), "Categoria reservada para panelas e utensílios da cozinha", "Utensílios de cozinha" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[] { new Guid("69881eb1-b47e-4d56-6bc1-08d9e34472ad"), "Categoria reservada para equipamentos eletrônicos", "Peças de informática" });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "CategoriaId", "Descricao", "Marca", "Nome", "Preco" },
                values: new object[,]
                {
                    { new Guid("5aa6c1d0-0eb4-4dae-8813-08d9e2b4aa87"), new Guid("69881eb1-b47e-4d56-6bc1-08d9e34472ad"), "Memória ram 8GB 2400MHZ", "HyperX", "Memória 8GB", 199.99000000000001 },
                    { new Guid("6da8a2ce-5eeb-4adf-8811-08d9e2b4aa87"), new Guid("03e68c0c-1164-43c9-6bb9-08d9e34472ad"), "Sofá 3 lugares, Cor: Preta", "Orthoflex", "Sofá", 910.0 },
                    { new Guid("93f1dc21-f381-46ff-0990-08d9e28b76b2"), new Guid("5aa6c1d0-0eb4-4dae-8813-08d9e2b4aa87"), "Panela de Pressão aço reforçado, Cor: Preta", "INOX", "Panela de Pressão", 29.989999999999998 },
                    { new Guid("a086f9b0-fac6-4301-3854-08d9e2c206fe"), new Guid("69881eb1-b47e-4d56-6bc1-08d9e34472ad"), "Monitor 144 Hz , 0.5 ms IPS", "ACE", "Monitor 144", 1500.0 },
                    { new Guid("c4edecaa-0ca1-4113-098f-08d9e28b76b2"), new Guid("5aa6c1d0-0eb4-4dae-8813-08d9e2b4aa87"), "Liquidificador, Cor: Branco", "Britânia", "Liquidificador", 89.25 },
                    { new Guid("d61bcb30-ed4f-4dc0-8812-08d9e2b4aa87"), new Guid("03e68c0c-1164-43c9-6bb9-08d9e34472ad"), "Mesa de Janta 8 lugares", "Madereira Selva", "Mesa", 1200.0 },
                    { new Guid("d68e04a3-0612-4034-098e-08d9e28b76b2"), new Guid("5aa6c1d0-0eb4-4dae-8813-08d9e2b4aa87"), "Frigideira anti-aderente, Cor: Azul", "INOX", "Frigideira", 19.5 },
                    { new Guid("f7bdc102-84e9-41f7-3855-08d9e2c206fe"), new Guid("69881eb1-b47e-4d56-6bc1-08d9e34472ad"), "Monitor UltraWide 29 polegadas, 75 Hz , 5 ms", "LG", "UltraWide 29", 1299.99 },
                    { new Guid("f80244ce-8a53-4d00-8810-08d9e2b4aa87"), new Guid("03e68c0c-1164-43c9-6bb9-08d9e34472ad"), "Poltrona Inclinável 90°, Cor: Preta", "Ortobom", "Poltrona", 299.99000000000001 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaId",
                table: "Produtos",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
