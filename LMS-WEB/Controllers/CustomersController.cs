using LMS_WEB.Repositories.Interfaces;
using LMS_WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LMS_WEB.Controllers;

public class CustomersController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomersController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index(string? search, int? cityId)
    {
        var customers = await _unitOfWork.Customers.FilterAsync(search, cityId);

        var vm = new CustomersViewModel
        {
            Customers = customers,
            Cities = await _unitOfWork.Cities.GetAllAsync(),
            Nationalities = await _unitOfWork.Nationalities.GetAllAsync()
        };
        return View(vm);
    }

    // Create
    [HttpPost]
    public async Task<IActionResult> AddCustomer(string fullName, int cityId, int nationalityId)
    {
        _unitOfWork.Customers.Add(new Models.Customer { FullName = fullName, CityID = cityId, NationalityID = nationalityId });
        await _unitOfWork.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    // Subscriptions
    public async Task<IActionResult> ShowSubscriptions(int id)
    {
        var customer = await _unitOfWork.Customers.GetWithSubscriptionsAsync(id);

        if (customer == null)
            return NotFound();

        var vm = new CustomerSubscriptionsViewModel
        {
            CustomerName = $"{customer.FullName}",
            Subscriptions = customer.Subscriptions
        };

        return View(vm);
    }
}
