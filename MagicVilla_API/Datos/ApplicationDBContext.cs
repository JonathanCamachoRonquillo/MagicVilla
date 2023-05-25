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


    }
}
