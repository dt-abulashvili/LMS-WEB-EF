using LMS_WEB.Models;
using LMS_WEB.Repositories.Interfaces;

namespace LMS_WEB.Services;

public class AuthorService
{
    private readonly IUnitOfWork _unitOfWork;

    public AuthorService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}
