using ReadStack.Application.Models;
using ReadStack.Application.Models;

namespace ReadStack.Application.Services.Books
{
    public interface IBooksServices
    {
        ResultViewModel<List<BooksViewModel>> GetAll(string search = "");
        ResultViewModel<BooksViewModel> GetById(int id);
        ResultViewModel<int> Post(CreateBookInputModel model);
        ResultViewModel Delete(int id);
    }
}