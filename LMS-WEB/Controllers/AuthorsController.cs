using LMS_WEB.Data;
using LMS_WEB.Repositories;
using LMS_WEB.Repositories.Interfaces;
using LMS_WEB.Services;
using LMS_WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LMS_WEB.Controllers;

public class AuthorsController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public AuthorsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        var vm = new AuthorsViewModel
        {
            Authors = await _unitOfWork.Authors.GetAllAsync(),
            Cities = await _unitOfWork.Cities.GetAllAsync(),
            Nationalities = await _unitOfWork.Nationalities.GetAllAsync()
        };
        return View(vm);
    }

    // Create
    [HttpPost]
    public async Task<IActionResult> AddAuthor(string firstName, string lastName, int cityId, int NationalityId)
    {
        _unitOfWork.Authors.Add(new Models.Author { FirstName = firstName, LastName = lastName, CityID = cityId, NationalityID = NationalityId });
        await _unitOfWork.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    // Delete
    public async Task<IActionResult> DeleteAuthor(int id)
    {
        _unitOfWork.Authors.Delete(id);
        await _unitOfWork.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    // Update

}
