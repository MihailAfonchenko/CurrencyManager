using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyManager.Entities
{
    public class CurrencyMarketContext : DbContext
    {
        public CurrencyMarketContext() : base("DefaultDB") { }

        public DbSet<CurrencyMarket> Currencies { get; set; }
        public DbSet<MarketLibrary> Libraries { get; set; }
    }
}
