using Curriculum.Models;
using Microsoft.EntityFrameworkCore;

namespace Curriculum.Datos
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
        }
        //Aqui se agregan los modelos
        public DbSet< Usuario> Usuario { get; set; }
        
    }
}
