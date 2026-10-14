using Microsoft.AspNetCore.Mvc;
using MealOrderCollection.Models;

namespace MealOrderCollection.Controllers
{
    public class OrderController : Controller
    {
        // GET: /Order/Index  veya  /siparisler
        // Teslim durumuna bakılmaksızın tüm siparişleri listeler.
        public IActionResult Index()
        {
            var orders = Repository.GetMealOrders();

            ViewData["Title"] = "Tüm Yemek Siparişleri";
            ViewBag.TotalCount = orders.Count;
            ViewBag.CollectedCount = orders.Count(o => o.Collected);

            return View(orders);
        }

        // GET: /Order/Details/O001  veya  /siparis/O001
        // Parametre olarak Sipariş ID alır ve teslim bilgisini gösterir.
        public IActionResult Details(string id)
        {
            var order = Repository.GetMealOrderById(id);

            if (order == null)
            {
                ViewData["Title"] = "Sipariş Bulunamadı";
                ViewBag.SearchedId = id;
                Response.StatusCode = 404;
                return View("NotFound");
            }

            ViewData["Title"] = $"Teslim Bilgisi - {order.OrderID}";
            return View(order);
        }

        // GET: /Order/Collect  veya  /teslim-al
        // Teslim alma formunu gösterir.
        [HttpGet]
        public IActionResult Collect()
        {
            ViewData["Title"] = "Yemek Teslim Al";
            return View(new CollectRequest());
        }

        // POST: /Order/Collect
        // Model binding ile formdan gelen Sipariş ID'yi alır ve siparişi teslim alındı olarak işaretler.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Collect(CollectRequest request)
        {
            ViewData["Title"] = "Yemek Teslim Al";

            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var order = Repository.GetMealOrderById(request.OrderID);

            if (order == null)
            {
                ModelState.AddModelError(nameof(request.OrderID),
                    $"'{request.OrderID}' numaralı bir sipariş bulunamadı.");
                return View(request);
            }

            if (order.Collected)
            {
                ModelState.AddModelError(nameof(request.OrderID),
                    $"'{order.OrderID}' numaralı sipariş zaten {order.CollectedAt:dd.MM.yyyy HH:mm} tarihinde teslim alınmış.");
                return View(request);
            }

            Repository.CollectMealOrder(order.OrderID);

            // PRG (Post-Redirect-Get) deseni: başarı mesajını TempData ile taşıyıp teslim bilgisi sayfasına yönlendir.
            TempData["SuccessMessage"] = $"'{order.OrderID}' numaralı sipariş ({order.MealName} - {order.StudentName}) başarıyla teslim alındı.";
            return RedirectToAction(nameof(Details), new { id = order.OrderID });
        }
    }
}
