using System.Data.Entity;
using MvcRssReader.Models;

namespace MvcRssReader.Concrete
{
    public class RssReaderDbContext : DbContext
    {
        public DbSet<RssReaderUser> RssReaderUsers { get; set; }
    }
}