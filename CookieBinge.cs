using System;

namespace CookieBinge2
{
    public class CookieBinge
    {
        public Guid Id { get; set; }
        public DateTime TimeOccurred { get; set; }
        public int HowMany { get; set; }
        public bool WorthIt { get; set; }
    }
}

