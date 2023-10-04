using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using webapi.healthclinica.tarde.Domains;

namespace webapi.healthclinica.tarde.Context
{
    public class HealthContext : DbContext
    {

        public DbSet<ClinicaDomain> Clinica { get; set; }

        public DbSet<Consulta> Consulta { get; set; }

        public DbSet<Especialidade> Especialidade { get; set; }

        public DbSet<Medico> Medico { get; set; }

        public DbSet<Paciente> Paciente { get; set; }

        public DbSet<TipoDeUsuario> TipoDeUsuario { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE02-S14; Database=HealthClinica_Tarde; User Id=sa; Pwd=Senai@134; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
