using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jQueryAjaxInAsp.NETMVC.Models
{
    public class TarnsactionDbContext:DbContext
    {
        public TarnsactionDbContext(DbContextOptions<TarnsactionDbContext> options):base(options)
        {  }

        public DbSet<TransactionModel> Transactions { get; set; }
    }
}
