using Microsoft.EntityFrameworkCore;
using PharmacyCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyCore.DBContexts
{
    public class PharmacyContext : DbContext
    {
        public PharmacyContext(DbContextOptions<PharmacyContext> options) : base(options)
        {

        }

        public DbSet<Medicine> Medicines { get; set; }
    }
}
