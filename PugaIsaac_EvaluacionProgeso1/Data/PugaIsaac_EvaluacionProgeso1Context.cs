using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PugaIsaac_EvaluacionProgeso1.Models;

namespace PugaIsaac_EvaluacionProgeso1.Data
{
    public class PugaIsaac_EvaluacionProgeso1Context : DbContext
    {
        public PugaIsaac_EvaluacionProgeso1Context (DbContextOptions<PugaIsaac_EvaluacionProgeso1Context> options)
            : base(options)
        {
        }

        public DbSet<PugaIsaac_EvaluacionProgeso1.Models.PIsaac> PIsaac { get; set; } = default!;
        public DbSet<PugaIsaac_EvaluacionProgeso1.Models.Celular> Celular { get; set; } = default!;
    }
}
