using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Use a fixed culture so date/time formatting is consistent regardless of the host machine.
var culture = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

app.UseStaticFiles();

// Routing: readable custom routes
app.MapControllerRoute(
    name: "orderDetails",
    pattern: "orders/{id}",
    defaults: new { controller = "Order", action = "Details" });

app.MapControllerRoute(
    name: "collect",
    pattern: "collect",
    defaults: new { controller = "Order", action = "Collect" });

app.MapControllerRoute(
    name: "orderList",
    pattern: "orders",
    defaults: new { controller = "Order", action = "Index" });

// Default route: {controller=Home}/{action=Index}/{id?}
app.MapDefaultControllerRoute();

app.Run();
