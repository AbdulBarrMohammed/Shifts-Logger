using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class ShiftsDbContext : DbContext
    {
        public ShiftsDbContext(DbContextOptions options) : base(options){}
        public DbSet<Shift> Shifts { get; set;}
    }
}
