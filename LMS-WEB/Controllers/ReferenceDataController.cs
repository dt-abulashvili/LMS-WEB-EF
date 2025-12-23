using LMS_WEB.Data;
using LMS_WEB.Repositories.Interfaces;
using LMS_WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LMS_WEB.Controllers;

public class ReferenceDataController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public ReferenceDataController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        var vm = new ReferenceDataViewModel
        {
            Countries = await _unitOfWork.Countries.GetAllAsync(),
            Cities = await _unitOfWork.Cities.GetAllAsync(),
            Nationalities = await _unitOfWork.Nationalities.GetAllAsync(),
            Publishers = await _unitOfWork.Publishers.GetAllAsync(),
            Genres = await _unitOfWork.Genres.GetAllAsync()
        };

        return View(vm);
    }

    // Create
    [HttpPost]
    public async Task<IActionResult> AddCountry(string name)
    {
        _unitOfWork.Countries.Add(new Models.Country { Name = name });
        await _unitOfWork.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> AddCity(string name, int countryId)
    {
        _unitOfWork.Cities.Add(new Models.City { Name = name, CountryID =  countryId});
        await _unitOfWork.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> AddNationality(string name)
    {
        _unitOfWork.Nationalities.Add(new Models.Nationality { Name = name });
        await _unitOfWork.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> AddPublisher(string name, int cityId)
    {
        _unitOfWork.Publishers.Add(new Models.Publisher { Name = name, CityId = cityId });
        await _unitOfWork.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> AddGenre(string name)
    {
        _unitOfWork.Genres.Add(new Models.Genre { Name = name });
        await _unitOfWork.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    // Delete
    public async Task<IActionResult> DeleteCountry(int id)
    {
        _unitOfWork.Countries.Delete(id);
        await _unitOfWork.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> DeleteCity(int id)
    {
        _unitOfWork.Cities.Delete(id);
        await _unitOfWork.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> DeleteNationality(int id)
    {
        _unitOfWork.Nationalities.Delete(id);
        await _unitOfWork.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> DeletePublisher(int id)
    {
        _unitOfWork.Publishers.Delete(id);
        await _unitOfWork.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> DeleteGenre(int id)
    {
        _unitOfWork.Genres.Delete(id);
        await _unitOfWork.SaveChangesAsync();

        return RedirectToAction("Index");
    }
}
