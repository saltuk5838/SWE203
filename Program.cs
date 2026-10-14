using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Tarih/saat biçimlendirmesi için Türkçe kültür ayarı
var culture = new CultureInfo("tr-TR");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

app.UseStaticFiles();

// Routing: okunabilir özel rotalar
app.MapControllerRoute(
    name: "orderDetails",
    pattern: "siparis/{id}",
    defaults: new { controller = "Order", action = "Details" });

app.MapControllerRoute(
    name: "collect",
    pattern: "teslim-al",
    defaults: new { controller = "Order", action = "Collect" });

app.MapControllerRoute(
    name: "orderList",
    pattern: "siparisler",
    defaults: new { controller = "Order", action = "Index" });

// Varsayılan rota: {controller=Home}/{action=Index}/{id?}
app.MapDefaultControllerRoute();

app.Run();
