using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteLanches.Migrations
{
    public partial class PopularLanche : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId, Nome, DescricaoCurta, DescricaoDetalhada, Preco, ImagemURL, ImagemThumbnailUrl,IsLanchePreferido, EmEstoque) " +
               "VALUES(1,'Xis','Lanche delicia', 'Pao, cebola, hamburguer, queijo, salada e muita maionese', 22.35, 'https://img.restaurantguru.com/r434-Tuni-kao-Lanches-burger-2021-09-1.jpg','https://img.restaurantguru.com/rf0b-burger-Tuni-kao-Lanches-2021-09.jpg',1,1)");
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId, Nome, DescricaoCurta, DescricaoDetalhada, Preco, ImagemURL, ImagemThumbnailUrl,IsLanchePreferido, EmEstoque) " +
               "VALUES(2,'Sanduiche','Lanche natural', 'Pao integral, frango, queijo, salada e muita maionese', 18.00, 'https://i0.wp.com/porkworld.com.br/wp-content/uploads/2022/07/recheio-de-frango-cremoso-para-sanduiche-natural-de-frango-receita-facil-e-rapida-lanche-da-tarde.jpg?resize=800%2C530&ssl=1','https://assets.unileversolutions.com/recipes-v2/99461.jpg?imwidth=800',0,1)");
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId, Nome, DescricaoCurta, DescricaoDetalhada, Preco, ImagemURL, ImagemThumbnailUrl,IsLanchePreferido, EmEstoque) " +
               "VALUES(1,'Batata Frita','Friturinha', 'Batata Frita', 14.05, 'https://www.estadao.com.br/resizer/UfLOp1sZi62lOSEL3OBY2H71q-k=/720x503/filters:format(jpg):quality(80)/cloudfront-us-east-1.images.arcpublishing.com/estadao/SHJEVWJAMBLGHNNFD2RA7RFY2U.jpg','https://as1.ftcdn.net/v2/jpg/03/34/28/68/1000_F_334286843_r0lBsnZYEuxsjn0K5x2E9Gr0IHcepzyW.jpghttps://as1.ftcdn.net/v2/jpg/03/34/28/68/1000_F_334286843_r0lBsnZYEuxsjn0K5x2E9Gr0IHcepzyW.jpg',1,0)");
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId, Nome, DescricaoCurta, DescricaoDetalhada, Preco, ImagemURL, ImagemThumbnailUrl,IsLanchePreferido, EmEstoque) " +
               "VALUES(1,'Nuggets','Friturinha', 'Feito apenas do mais puro sassami, como todo nugget', 25.55, 'https://veja.abril.com.br/wp-content/uploads/2017/03/nuggets-de-frango.jpg?quality=90&strip=info&w=1125&h=720&crop=1','https://comidinhasdochef.com/wp-content/uploads/2016/07/Nuggets-de-Frango-Caseiros.jpg',1,0)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Lanches");
        }
    }
}
