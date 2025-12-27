using LMS_WEB.Models;
using LMS_WEB.Repositories.Interfaces;
using LMS_WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LMS_WEB.Controllers;

public class BorrowingsController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public BorrowingsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index(int? customerId, BorrowingStatus? status)
    {
        var borrowings = await _unitOfWork.Borrowings.FilterAsync(customerId, status);

        var vm = new BorrowingsViewModel
        {
            Borrowings = borrowings,
            Customers = await _unitOfWork.Customers.GetAllAsync(),
            Subscriptions = await _unitOfWork.Subscriptions.GetAllAsync()
        };
        return View(vm);
    }

    // Delete
    public async Task<IActionResult> DeleteBorrowing(int id)
    {
        _unitOfWork.Borrowings.Delete(id);
        await _unitOfWork.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    // Books
    public async Task<IActionResult> ShowBooks(int id)
    {
        var borrowing = await _unitOfWork.Borrowings.GetBooksFromBorrowing(id);

        if (borrowing == null)
            return NotFound();

        return View(borrowing);
    }

    // Return
    [HttpPost]
    public async Task<IActionResult> ReturnBooks(int id)
    {
        await _unitOfWork.Borrowings.ReturnBorrowingAsync(id);
        await _unitOfWork.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}
