using System;
using System.Collections.Generic;
using System.Linq;

namespace CookieBinge2
{
    public static class BingeService
    {
        public static void RecordBinge(int count, bool worthIt)
        {
            var binge = new CookieBinge
            {
                HowMany = count,
                WorthIt = worthIt,
                TimeOccurred = DateTime.Now
            };

            using (var context = new BingeContext())
            {
                context.Binges.Add(binge);
                context.SaveChanges();
            }
        }

        public static IEnumerable<CookieBinge> GetRecentBinges(int numberToRetrieve)
        {
            using (var context = new BingeContext())
            {
                return context.Binges
                  .OrderByDescending(b => b.TimeOccurred)
                  .Take(numberToRetrieve).ToList();
            }
        }

        public static void ClearHistory()
        {
            using (var context = new BingeContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }
    }
}