using CrudPatrimonioEmpresarial.Models.Marca;
using CrudPatrimonioEmpresarial.Models.Patrimonio;
using CrudPatrimonioEmpresarial.Models.Usuario;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CrudPatrimonioEmpresarial.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Marca> Marca { get; set; }
        public DbSet<Patrimonio> Patrimonio { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}