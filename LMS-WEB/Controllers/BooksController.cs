using LMS_WEB.Repositories.Interfaces;
using LMS_WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LMS_WEB.Controllers;

public class BooksController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public BooksController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index(string? search, int? authorId, int? genreId, int? publisherId)
    {
        var books = await _unitOfWork.Books.FilterAsync(search, authorId, genreId, publisherId);

        var vm = new BooksViewModel
        {
            Books = books,
            Authors = await _unitOfWork.Authors.GetAllAsync(),
            Genres = await _unitOfWork.Genres.GetAllAsync(),
            Publishers = await _unitOfWork.Publishers.GetAllAsync()
        };
        return View(vm);
    }

    // Create
    [HttpPost]
    public async Task<IActionResult> AddBook(string title, int publishedYear, int authorId, int genreId, int publisherId)
    {
        _unitOfWork.Books.Add(new Models.Book { Title = title, PublishedYear = publishedYear, AuthorID = authorId, GenreID = genreId, PublisherId = publisherId });
        await _unitOfWork.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}
