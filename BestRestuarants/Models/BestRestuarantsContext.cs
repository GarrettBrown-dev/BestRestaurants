using Microsoft.EntityFrameworkCore;

namespace BestRestuarants.Models
{
  public class BestRestuarantsContext : DbContext
  {
    public virtual DbSet<Cuisine> Cuisines { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }

    public BestRestuarantsContext(DbContextOptions options) : base(options) { }
  }
}