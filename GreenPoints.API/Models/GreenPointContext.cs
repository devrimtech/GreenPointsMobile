using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GreenPoints.API.Models
{
    public class GreenPointContext : DbContext
    {
        public GreenPointContext(DbContextOptions<GreenPointContext> options) : base (options)
        {

        }

        public DbSet<GreenPointItem> GreenPointItem { get; set; }
        public DbSet<GreenPointUserItem> GreenPointUserItem { get; set; }
    }
}
