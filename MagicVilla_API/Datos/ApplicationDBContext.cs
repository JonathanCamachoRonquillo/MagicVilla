using MagicVilla_API.Modelos;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_API.Datos
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options)
        {
            
        }
        //Crear modelos de tablas en la base de datos
        public DbSet<Villa> Villas { get; set; }//Despues crear conexion en 'appsetting.json'

        //Método para insertar datos a tabla Villas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                    new Villa()
                    {
                        Id = 1,
                        Nombre = "Villa Real",
                        Detalle = "Villa del Real Madrid",
                        ImagenURL = "",
                        Ocupantes = 100,
                        MetrosCuadrados = 2000,
                        Tarifa = 220d,
                        Amenidad = "",
                        FechaCreacion = DateTime.Now,
                        FechaActualizacion = DateTime.Now
                    },
                    new Villa()
                    {
                        Id = 2,
                        Nombre = "Villa Rica",
                        Detalle = "Villa con buena vista",
                        ImagenURL = "",
                        Ocupantes = 10,
                        MetrosCuadrados = 200,
                        Tarifa = 120d,
                        Amenidad = "",
                        FechaCreacion = DateTime.Now,
                        FechaActualizacion = DateTime.Now
                    }
            );
        }
    }
}
