using Microsoft.EntityFrameworkCore;
using MVC_Blazor.Model;
using System;

namespace MVC_Blazor.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios1 { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; } 
    }
}
