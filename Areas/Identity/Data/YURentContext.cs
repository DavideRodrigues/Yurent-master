using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YURent.Areas.Identity.Data;

namespace YURent.Data
{
    public class YURentContext : IdentityDbContext<YURentUser>
    {
        public YURentContext(DbContextOptions<YURentContext> options)
            : base(options)
        {
        }

        public DbSet<Anuncios> Anuncios { get; set; }
        public DbSet<Faturacao> Faturacao { get; set; }
        public DbSet<Verificacao> Verificacao { get; set; }
        public DbSet<Reservas> Reservas { get; set; }
        public DbSet<Transacoes> Transacoes { get; set; }
        public DbSet<Mensagens> Mensagens { get; set; }
        public DbSet<Utilizador> Utilizador { get; set; }
        public DbSet<Guardados> Guardados { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
