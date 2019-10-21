using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DAL
{
    public class Contexto : DbContext
    {


        public DbSet<Pagos> Pagos { get; set; }
        public DbSet<Analisis> Analisis { get; set; }
        public DbSet<Pacientes> Pacientes { get; set; }
        public DbSet<TipoAnalisis> TipoAnaliss { get; set; }


        public Contexto() : base("ConStr")
        { }

    }
}
