// Controllers/HomeController.cs

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestTaskVersta.Models;
using TestTaskVersta.Models.Entities;
using TestTaskVersta.Models.ViewModels;
using TestTaskVersta.Services;

namespace TestTaskVersta.Controllers;

public class HomeController(IOrderService orderService) : Controller
{
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var order = new Order
        {
            SenderCity = model.SenderCity,
            SenderAddress = model.SenderAddress,
            ReceiverCity = model.ReceiverCity,
            ReceiverAddress = model.ReceiverAddress,
            Weight = model.Weight,
            PickupDate = model.PickupDate
        };

        await orderService.CreateOrderAsync(order);

        TempData["Success"] = "Заказ успешно создан";
        return RedirectToAction("Create");
    }
    
    [HttpGet]
    public async Task<IActionResult> List()
    {
        var orders = await orderService.GetOrdersAsync();

        var viewModels = orders.Select(o => new OrderListViewModel
        {
            Id = o.Id,
            OrderNumber = o.OrderNumber,
            SenderCity = o.SenderCity,
            SenderAddress = o.SenderAddress,
            ReceiverCity = o.ReceiverCity,
            ReceiverAddress = o.ReceiverAddress,
            Weight = o.Weight,
            PickupDate = o.PickupDate
        }).ToList();

        return View(viewModels);
    }

    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}