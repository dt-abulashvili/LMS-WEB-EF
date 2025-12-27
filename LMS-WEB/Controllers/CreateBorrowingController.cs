using LMS_WEB.Models;
using LMS_WEB.ViewModels;
using LMS_WEB.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LMS_WEB.Controllers;

public class CreateBorrowingController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateBorrowingController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        var vm = new CreateBorrowingViewModel
        {
            Customers = await _unitOfWork.Customers.GetAllAsync(),
            Books = await _unitOfWork.Books.GetAllAsync(),
            BorrowDate = DateTime.UtcNow,
            DueDate = DateTime.UtcNow
        };

        return View(vm);
    }

    // Create
    [HttpPost]
    public async Task<IActionResult> AddBorrowing(CreateBorrowingViewModel model)
    {
        if (!ModelState.IsValid)
            return View("Index", model);

        var customer = await _unitOfWork.Customers
            .GetWithSubscriptionsAsync(model.CustomerId);

        if (customer == null)
            return NotFound();

        var activeSubscription = customer.Subscriptions
            .FirstOrDefault(s => s.IsActive);

        var borrowing = new Borrowing
        {
            BorrowDate = model.BorrowDate,
            DueDate = model.DueDate,
            CustomerId = customer.CustomerID,
            SubscriptionID = activeSubscription?.SubscriptionID,
            Subscription = activeSubscription,
        };

        var books = await _unitOfWork.Books.WhereAsync(b => model.SelectedBookIds.Contains(b.BookID));

        foreach (var book in books)
        {
            borrowing.Books.Add(book);
        }

        _unitOfWork.Borrowings.Add(borrowing);
        await _unitOfWork.SaveChangesAsync();

        return RedirectToAction("Index");
    }
}