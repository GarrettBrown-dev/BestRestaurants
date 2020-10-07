
namespace BestRestuarants.Models
{
  public class Cuisine
  {
    public Cuisine()
    {
      this.Restuarants = new HashSet<Restuarant>();
    }

    public int CuisineId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Restuarant> Restuarants { get; set; }
  }
}