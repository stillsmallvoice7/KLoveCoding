using KLoveCoding.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace KLoveCoding.DAL.Data
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Favorite> Favorite { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
