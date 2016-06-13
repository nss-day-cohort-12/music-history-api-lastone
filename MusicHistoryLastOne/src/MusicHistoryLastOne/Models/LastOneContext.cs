using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MusicHistoryLastOne.Models
{
    public class LastOneContext : DbContext
    {
        public LastOneContext(DbContextOptions<LastOneContext> options)
            : base(options)
        { }

        public DbSet<LastOneUsers> LastOneUsers { get; set; }
        public DbSet<Tracks> Tracks { get; set; }
        public DbSet<Albums> Albums { get; set; }
    }
}
