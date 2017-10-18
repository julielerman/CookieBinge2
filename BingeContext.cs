using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Windows.Storage;

namespace CookieBinge2
{
    public class BingeContext:DbContext
    {
        public DbSet<CookieBinge> Binges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var dbPath = "CookieBinge.db";
            try
            {
                dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, dbPath);
            }
            catch (InvalidOperationException) { }

            options.UseSqlite($"Data source={dbPath}");

        }
    }
}
