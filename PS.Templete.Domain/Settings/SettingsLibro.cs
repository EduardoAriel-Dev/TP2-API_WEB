using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PS.Template.Domain.Models;

namespace PS.Template.Domain.Settings
{
    public class SettingsLibro
    {
        public SettingsLibro(EntityTypeBuilder<Libros> BuilderLibros)
        {
            //Primary Key.
            BuilderLibros.HasKey(X => X.ISBN);
            //BuilderLibros.Property(X => X.ISBN).HasMaxLength(45);

            //Others Entitys.
            BuilderLibros.Property(X => X.Titulo).HasMaxLength(45).IsRequired();
            BuilderLibros.Property(X => X.Autor).HasMaxLength(45).IsRequired();
            BuilderLibros.Property(X => X.Editorial).HasMaxLength(45).IsRequired();
            BuilderLibros.Property(X => X.Edicion).HasMaxLength(45).IsRequired();
            BuilderLibros.Property(X => X.Stock).IsRequired();
            BuilderLibros.Property(X => X.Imagen).HasMaxLength(100).IsRequired();

            //Foraing Key.
            // BuilderLibros.HasMany(X => X.alquileres_L).WithOne(Z => Z.ISBNId).HasForeignKey(X => X.Id);
            //Esto no se si esta bien.

            BuilderLibros.HasData(new Libros
            {
                ISBN = "1407134612",
                Titulo = "La profecia del cuervo",
                Autor = "Maggie Stiefvater",
                Editorial = "Sm",
                Edicion = "1",
                Stock = 0,
                Imagen = "https://ecat-server.grupo-sm.com/ecat_Imagenes/Original/141850_194725.jpg"
            });
            BuilderLibros.HasData(new Libros
            {
                ISBN = "8467559217",
                Titulo = "Los saqueadores del sueño",
                Autor = "Maggie Stiefvater",
                Editorial = "Sm",
                Edicion = "1",
                Stock = 2,
                Imagen = "https://http2.mlstatic.com/D_NQ_NP_602833-MLA41780313102_052020-O.jpg"
            });
            BuilderLibros.HasData(new Libros
            {
                ISBN = "9789871783144",
                Titulo = "La Piramide Roja",
                Autor = "Rick Riordan",
                Editorial = "Montena",
                Edicion = "1",
                Stock = 4,
                Imagen = "https://images.cdn3.buscalibre.com/fit-in/360x360/90/4a/904a56e1088179d1aa7cce5421c1f32a.jpg"
            });
            BuilderLibros.HasData(new Libros
            {
                ISBN = "9789878000183",
                Titulo = "El ladron del rayo",
                Autor = "Rick Riordan",
                Editorial = "Salamandra",
                Edicion = "1",
                Stock = 3,
                Imagen = "https://images.cdn2.buscalibre.com/fit-in/360x360/b8/86/b886a5ec056f6eea24f542dde45f11ef.jpg"
            });
            BuilderLibros.HasData(new Libros
            {
                ISBN = "9788498387193",
                Titulo = "El mar de los Monstruos",
                Autor = "Rick Riordan",
                Editorial = "Salamandra",
                Edicion = "1",
                Stock = 3,
                Imagen = "https://m.media-amazon.com/images/I/41ucgFcdpsL._AC_SY580_.jpg"
            });
            BuilderLibros.HasData(new Libros
            {
                ISBN = "8408083805",
                Titulo = "Cazadores de Sombras - Ciudad de Ceniza",
                Autor = "Cassandra Clare",
                Editorial = "Booket",
                Edicion = "2014",
                Stock = 3,
                Imagen = "https://imagessl1.casadellibro.com/a/l/t7/01/9788408083801.jpg"
            });
            BuilderLibros.HasData(new Libros
            {
                ISBN = "9789875807105",
                Titulo = "Cazadores de Sombras - Ciudad de Hueso",
                Autor = "Cassandra Clare",
                Editorial = "Booket",
                Edicion = "1",
                Stock = 2,
                Imagen = "https://images.cdn2.buscalibre.com/fit-in/360x360/b5/e4/b5e4f0f82c7df83d073462f6dea866ad.jpg"
            });
            BuilderLibros.HasData(new Libros
            {
                ISBN = "9789878000107",
                Titulo = "Harry Potter y la Piedra Filosofa",
                Autor = "J.K. Rowling",
                Editorial = "Salamandra",
                Edicion = "1",
                Stock = 5,
                Imagen = "https://http2.mlstatic.com/D_NQ_NP_722711-MLA42906730908_072020-O.jpg"
            });
            BuilderLibros.HasData(new Libros
            {
                ISBN = "9789878000114",
                Titulo = "Harry Potter Y La Camara Secreta",
                Autor = "J.K. Rowling",
                Editorial = "Salamandra",
                Edicion = "1",
                Stock = 4,
                Imagen = "https://images.cdn2.buscalibre.com/fit-in/360x360/ad/4d/ad4df4ba516014a9fc39a0288a70957f.jpg"
            });
            BuilderLibros.HasData(new Libros
            {
                ISBN = "9789878000121",
                Titulo = "Harry Potter y el Prisionero de Azkaban",
                Autor = "J.K. Rowling",
                Editorial = "Salamandra",
                Edicion = "1",
                Stock = 3,
                Imagen = "https://contentv2.tap-commerce.com/cover/large/9789878000121_1.jpg?id_com=1113"
            });
        }
    }
}
