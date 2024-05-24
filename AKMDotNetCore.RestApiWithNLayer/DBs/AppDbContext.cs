
using AKMDotNetCore.RestApiWithNLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKMDotNetCore.RestApiWithNLayer.DBs;


internal class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings.stringBuilder.ConnectionString);
    }

    public DbSet<BlogModel> Blogs { get; set; }
}
