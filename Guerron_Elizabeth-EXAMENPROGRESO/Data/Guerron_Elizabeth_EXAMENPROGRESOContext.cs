using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Guerron_Elizabeth_EXAMENPROGRESO.Models;

namespace Guerron_Elizabeth_EXAMENPROGRESO.Data
{
    public class Guerron_Elizabeth_EXAMENPROGRESOContext : DbContext
    {
        public Guerron_Elizabeth_EXAMENPROGRESOContext (DbContextOptions<Guerron_Elizabeth_EXAMENPROGRESOContext> options)
            : base(options)
        {
        }

        public DbSet<Guerron_Elizabeth_EXAMENPROGRESO.Models.EGuerron> EGuerron { get; set; } = default!;
        public DbSet<Guerron_Elizabeth_EXAMENPROGRESO.Models.Celular> Celular { get; set; } = default!;
    }
}
