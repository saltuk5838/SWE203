using Microsoft.AspNetCore.Mvc;
using MealOrderCollection.Models;

namespace MealOrderCollection.Controllers
{
    public class OrderController : Controller
    {
        // GET: /Order/Index  or  /orders
        // Lists all meal orders regardless of their collection status.
        public IActionResult Index()
        {
            var orders = Repository.GetMealOrders();

            ViewData["Title"] = "All Meal Orders";
            ViewBag.TotalCount = orders.Count;
            ViewBag.CollectedCount = orders.Count(o => o.Collected);

            return View(orders);
        }

        // GET: /Order/Details/O001  or  /orders/O001
        // Takes an Order ID as a parameter and shows the collection information.
        public IActionResult Details(string id)
        {
            var order = Repository.GetMealOrderById(id);

            if (order == null)
            {
                ViewData["Title"] = "Order Not Found";
                ViewBag.SearchedId = id;
                Response.StatusCode = 404;
                return View("NotFound");
            }

            ViewData["Title"] = $"Collection Information - {order.OrderID}";
            return View(order);
        }

        // GET: /Order/Collect  or  /collect
        // Shows the meal collection form.
        [HttpGet]
        public IActionResult Collect()
        {
            ViewData["Title"] = "Collect Meal";
            return View(new CollectRequest());
        }

        // POST: /Order/Collect
        // Receives the Order ID from the form via model binding and marks the order as collected.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Collect(CollectRequest request)
        {
            ViewData["Title"] = "Collect Meal";

            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var order = Repository.GetMealOrderById(request.OrderID);

            if (order == null)
            {
                ModelState.AddModelError(nameof(request.OrderID),
                    $"No order with ID '{request.OrderID}' was found.");
                return View(request);
            }

            if (order.Collected)
            {
                ModelState.AddModelError(nameof(request.OrderID),
                    $"Order '{order.OrderID}' has already been collected on {order.CollectedAt:dd.MM.yyyy HH:mm}.");
                return View(request);
            }

            Repository.CollectMealOrder(order.OrderID);

            // PRG (Post-Redirect-Get) pattern: carry the success message via TempData and redirect to the details page.
            TempData["SuccessMessage"] = $"Order '{order.OrderID}' ({order.MealName} - {order.StudentName}) has been collected successfully.";
            return RedirectToAction(nameof(Details), new { id = order.OrderID });
        }
    }
}
