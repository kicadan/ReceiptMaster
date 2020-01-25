using Microsoft.EntityFrameworkCore;
using ReceiptMaster.Models;

namespace ReceiptMaster.Data
{
    public class MvcReceiptContext : DbContext
    {
        public MvcReceiptContext(DbContextOptions<MvcReceiptContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Receipt> Receipt { get; set; }
    }
}
