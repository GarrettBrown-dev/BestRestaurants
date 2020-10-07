using System.Collections.Generic;

namespace BestRestuarants.Models
{
  public class Restuarant
  {
    public int RestuarantId { get; set; }
    public string Description { get; set; }
    public int CuisineId { get; set; }
    public virtual Cuisine Cuisine { get; set; }
  }
}