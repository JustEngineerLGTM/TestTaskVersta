using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTaskVersta.Models;

namespace TestTaskVersta.Controllers;

public class HomeController(AppDbContext db) : Controller
{
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(Order order)
    {
        if (!ModelState.IsValid)
            return View(order);
        
        order.PickupDate = DateTime.SpecifyKind(order.PickupDate, DateTimeKind.Utc);
        db.Orders.Add(order);
        await db.SaveChangesAsync();

        TempData["Success"] = "Заказ успешно создан";
        return RedirectToAction("Create"); 
    }
    
    [HttpGet]
    public async Task<IActionResult> List()
    {
        var orders = await db.Orders.OrderByDescending(o => o.Id).ToListAsync();
        return View(orders);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}