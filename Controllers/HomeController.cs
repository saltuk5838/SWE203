using Microsoft.AspNetCore.Mvc;
using MealOrderCollection.Models;

namespace MealOrderCollection.Controllers
{
    public class HomeController : Controller
    {
        // GET: /  veya  /Home/Index
        public IActionResult Index()
        {
            // ViewBag ile yemekhane adı ve bugünün tarihi
            ViewBag.CafeteriaName = "Sakarya Üniversitesi Yemekhanesi";
            ViewBag.CurrentDate = DateTime.Now.ToString("dd.MM.yyyy dddd");

            // ViewData ile teslim alınmış sipariş sayısı
            var collectedOrders = Repository.GetCollectedMealOrders();
            ViewData["CollectedCount"] = collectedOrders.Count;
            ViewData["TotalCount"] = Repository.GetMealOrders().Count;

            // Model olarak teslim alınmış siparişler
            return View(collectedOrders);
        }
    }
}
