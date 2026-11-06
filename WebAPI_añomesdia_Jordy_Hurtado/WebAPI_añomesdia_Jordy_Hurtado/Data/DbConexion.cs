

using Microsoft.EntityFrameworkCore;
using WebAPI_añomesdia_Jordy_Hurtado.Models;

namespace WebAPI_añomesdia_Jordy_Hurtado.Data
{
    public class DbConexion : DbContext
    {
        public DbConexion(DbContextOptions<DbConexion> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; } = null!;

    }
}
