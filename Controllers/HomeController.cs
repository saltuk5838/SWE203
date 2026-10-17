using Microsoft.AspNetCore.Mvc;
using MealOrderCollection.Models;

namespace MealOrderCollection.Controllers
{
    public class HomeController : Controller
    {
        // GET: /  or  /Home/Index
        public IActionResult Index()
        {
            // Cafeteria name and today's date via ViewBag
            ViewBag.CafeteriaName = "Sakarya University Cafeteria";
            ViewBag.CurrentDate = DateTime.Now.ToString("dddd, dd MMMM yyyy");

            // Number of collected orders via ViewData
            var collectedOrders = Repository.GetCollectedMealOrders();
            ViewData["CollectedCount"] = collectedOrders.Count;
            ViewData["TotalCount"] = Repository.GetMealOrders().Count;

            // Collected orders are passed as the model
            return View(collectedOrders);
        }
    }
}
