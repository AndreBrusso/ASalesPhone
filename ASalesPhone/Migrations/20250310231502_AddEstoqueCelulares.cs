using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASalesPhone.Migrations
{
    public partial class AddEstoqueCelulares : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "estoquecelulares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Modelo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estoquecelulares", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            // Inserir dados iniciais
            migrationBuilder.InsertData(
                table: "estoquecelulares",
                columns: new[] { "Modelo", "Quantidade" },
                values: new object[,]
                {
                    { "iPhone 16", 10 },
                    { "iPhone 16 Pro Max", 10 },
                    { "iPhone 15", 10 },
                    { "iPhone 14", 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "estoquecelulares");
        }
    }
} 