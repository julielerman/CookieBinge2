using System;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Windows.Storage;

namespace CookieBinge20
{
    public class BingeContext:DbContext
    {
        public DbSet<CookieBinge> Binges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

           

            options.UseSqlite($"Data source={databaseFilePath}");
        }
    }
}
