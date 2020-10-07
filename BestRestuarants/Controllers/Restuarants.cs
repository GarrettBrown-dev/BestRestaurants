using Microsoft.AspNetCore.Mvc;
using BestRestuarants.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BestRestuarants.Controllers
{
  public class RestuarantsController : Controller
  {
    private readonly BestRestuarantsContext _db;

    public RestuarantsController(BestRestuarantsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Restuarant> model = _db.Restuarants.Include(restuarants => restuarants.Cuisine).ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
      return View();
    }
    [HttpPost]
    public ActionResult Create(Restuarant restuarant)
    {
      _db.Restuarants.Add(restuarant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      Restuarant thisRestuarant = _db.Restuarants.FirstOrDefault(restuarants => restuarants.RestuarantId == id);
      return View(thisRestuarant);
    }

    public ActionResult Edit(int id)
    {
      var thisRestuarant = _db.Restuarants.FirstOrDefault(restuarants => restuarants.RestuarantId == id);
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
      return View(thisRestuarant);
    }

    [HttpPost]
    public ActionResult Edit(Restuarant restuarant)
    {
      _db.Entry(restuarant).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisRestuarant = _db.Restuarants.FirstOrDefault(restuarant => restuarants.RestuarantId == id);
      return View(thisRestuarant);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisRestuarant = _db.Restuarants.FirstOrDefault(restuarants => restuarants.RestuarantId == id);
      _db.Restuarants.Remove(thisRestuarant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}