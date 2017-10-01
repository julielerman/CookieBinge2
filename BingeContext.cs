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
