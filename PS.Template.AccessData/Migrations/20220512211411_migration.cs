using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PS.Template.AccessData.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "estadoDeAlquileres",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estadoDeAlquileres", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "libros",
                columns: table => new
                {
                    ISBN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Editorial = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Edicion = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_libros", x => x.ISBN);
                });

            migrationBuilder.CreateTable(
                name: "alquileres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    IsbnId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaAlquiler = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaReserva = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaDevolucion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alquileres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_alquileres_clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_alquileres_estadoDeAlquileres_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "estadoDeAlquileres",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_alquileres_libros_IsbnId",
                        column: x => x.IsbnId,
                        principalTable: "libros",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "estadoDeAlquileres",
                columns: new[] { "EstadoId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Alquilado" },
                    { 2, "Reservado" },
                    { 3, "Cancelado" }
                });

            migrationBuilder.InsertData(
                table: "libros",
                columns: new[] { "ISBN", "Autor", "Edicion", "Editorial", "Imagen", "Stock", "Titulo" },
                values: new object[,]
                {
                    { "1407134612", "Maggie Stiefvater", "1", "Sm", "https://ecat-server.grupo-sm.com/ecat_Imagenes/Original/141850_194725.jpg", 0, "La profecia del cuervo" },
                    { "8408083805", "Cassandra Clare", "2014", "Booket", "https://imagessl1.casadellibro.com/a/l/t7/01/9788408083801.jpg", 3, "Cazadores de Sombras - Ciudad de Ceniza" },
                    { "8467559217", "Maggie Stiefvater", "1", "Sm", "https://http2.mlstatic.com/D_NQ_NP_602833-MLA41780313102_052020-O.jpg", 2, "Los saqueadores del sueño" },
                    { "9788498387193", "Rick Riordan", "1", "Salamandra", "https://m.media-amazon.com/images/I/41ucgFcdpsL._AC_SY580_.jpg", 3, "El mar de los Monstruos" },
                    { "9789871783144", "Rick Riordan", "1", "Montena", "https://images.cdn3.buscalibre.com/fit-in/360x360/90/4a/904a56e1088179d1aa7cce5421c1f32a.jpg", 4, "La Piramide Roja" },
                    { "9789875807105", "Cassandra Clare", "1", "Booket", "https://images.cdn2.buscalibre.com/fit-in/360x360/b5/e4/b5e4f0f82c7df83d073462f6dea866ad.jpg", 2, "Cazadores de Sombras - Ciudad de Hueso" },
                    { "9789878000107", "J.K. Rowling", "1", "Salamandra", "https://http2.mlstatic.com/D_NQ_NP_722711-MLA42906730908_072020-O.jpg", 5, "Harry Potter y la Piedra Filosofa" },
                    { "9789878000114", "J.K. Rowling", "1", "Salamandra", "https://images.cdn2.buscalibre.com/fit-in/360x360/ad/4d/ad4df4ba516014a9fc39a0288a70957f.jpg", 4, "Harry Potter Y La Camara Secreta" },
                    { "9789878000121", "J.K. Rowling", "1", "Salamandra", "https://contentv2.tap-commerce.com/cover/large/9789878000121_1.jpg?id_com=1113", 3, "Harry Potter y el Prisionero de Azkaban" },
                    { "9789878000183", "Rick Riordan", "1", "Salamandra", "https://images.cdn2.buscalibre.com/fit-in/360x360/b8/86/b886a5ec056f6eea24f542dde45f11ef.jpg", 3, "El ladron del rayo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_alquileres_ClienteId",
                table: "alquileres",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_alquileres_EstadoId",
                table: "alquileres",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_alquileres_IsbnId",
                table: "alquileres",
                column: "IsbnId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alquileres");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "estadoDeAlquileres");

            migrationBuilder.DropTable(
                name: "libros");
        }
    }
}
