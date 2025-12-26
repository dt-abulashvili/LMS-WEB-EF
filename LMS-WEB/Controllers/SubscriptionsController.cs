using LMS_WEB.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using LMS_WEB.ViewModels;
using LMS_WEB.Models;

namespace LMS_WEB.Controllers;

public class SubscriptionsController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public SubscriptionsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index(int? customerId, SubscriptionStatus? status)
    {
        var subscriptions = await _unitOfWork.Subscriptions.FilterAsync(customerId, status);

        var vm = new SubscriptionsViewModel
        {
            Subscriptions = subscriptions,
            Customers = await _unitOfWork.Customers.GetAllAsync(),
            StartDate = DateTime.Today
        };
        return View(vm);
    }

    // Create
    [HttpPost]
    public async Task<IActionResult> AddSubscription(SubscriptionPeriod period, DateTime startDate, int customerId)
    {
        _unitOfWork.Subscriptions.Add(new Models.Subscription { Period = period, StartDate = startDate, CustomerId = customerId});
        await _unitOfWork.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    // Cancel
    [HttpPost]
    public async Task<IActionResult> CancelSubscription(int id)
    {
        await _unitOfWork.Subscriptions.CancelAsync(id);
        await _unitOfWork.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}
