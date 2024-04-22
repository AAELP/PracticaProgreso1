using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PracticaProgreso1.Models;

namespace PracticaProgreso1.Data
{
    public class PracticaProgreso1Context : DbContext
    {
        public PracticaProgreso1Context (DbContextOptions<PracticaProgreso1Context> options)
            : base(options)
        {
        }

        public DbSet<PracticaProgreso1.Models.PRobalino> PRobalino { get; set; } = default!;
    }
}
