using Microsoft.EntityFrameworkCore.Migrations;

namespace APICatalago.Migrations
{
    public partial class Populadb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Categorias(Nome, ImagemUrl) Values('Bebidas', 'http://www.macoratti.net/Imagens/1.jpg')");
            migrationBuilder.Sql("Insert into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) Values('Coca Cola', 'Refrigerante de cola', 5.45, 'http://www.macoratti.net/Imagens/coca.jpg', 50, now(),(Select CategoriaId from Categorias where Nome='Bebidas'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Categorias");
            migrationBuilder.Sql("Produtos");
        }
    }
}
