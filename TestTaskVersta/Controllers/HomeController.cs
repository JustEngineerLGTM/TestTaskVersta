using AutoMapper;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestTaskVersta.Models.Entities;
using TestTaskVersta.Models.ViewModels;
using TestTaskVersta.Services;

namespace TestTaskVersta.Controllers;

public class HomeController(IOrderService orderService, IMapper mapper) : Controller
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

        var order = mapper.Map<Order>(model);

        await orderService.CreateOrderAsync(order);

        TempData["Success"] = "Заказ успешно создан";
        return RedirectToAction("Create");
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var orders = await orderService.GetOrdersAsync();
        var viewModels = mapper.Map<List<OrderListViewModel>>(orders);

        return View(viewModels);
    }

    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}