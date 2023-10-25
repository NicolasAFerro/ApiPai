using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apipai.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoTabelaServicos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
        name: "Servicos",   // Nome da tabela
        columns: table => new
        {
            Id = table.Column<int>(nullable: false)
                .Annotation("SqlServer:Identity", "1, 1"),
            Categoria = table.Column<int>(nullable: false),  // Defina o tipo e as propriedades das colunas
            ClientesId = table.Column<int>(nullable: false),
            Data = table.Column<DateTime>(nullable: false),
            Descricao = table.Column<string>(nullable: false),
            Valor = table.Column<double>(nullable: false),
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_Servicos", x => x.Id);  // Define a chave primária
        });

    migrationBuilder.CreateIndex(
        name: "IX_Servicos_ClientesId",
        table: "Servicos",
        column: "ClientesId");

    migrationBuilder.AddForeignKey(
        name: "FK_Servicos_Clientes_ClientesId",
        table: "Servicos",
        column: "ClientesId",
        principalTable: "Clientes",
        principalColumn: "Id",
        onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
