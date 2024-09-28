using ReadStack.API.Persistence;
using ReadStack.Application.Models;
using ReadStack.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ReadStack.Application.Services.Books
{
    public class BooksServices : IBooksServices
    {
        private readonly ReadStackDbContext _context;

        public BooksServices(ReadStackDbContext context)
        {
            _context = context;
        }

        public ResultViewModel<List<BooksViewModel>> GetAll(string search = "")
        {
            var books = _context.Books.Where(b => !b.IsDeleted).ToList();
            
            if (books is null)
            {
                return ResultViewModel<List<BooksViewModel>>.Erro("The books were not found.");
            }

            var model = books.Select(BooksViewModel.FromEntity).ToList();

            return ResultViewModel<List<BooksViewModel>>.Success(model);
        }

        public ResultViewModel<BooksViewModel> GetById(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if (book is null)
            {
                return ResultViewModel<BooksViewModel>.Erro("The book was not found.");
            }

            var model = BooksViewModel.FromEntity(book);

            return ResultViewModel<BooksViewModel>.Success(model);
        }

        public ResultViewModel<int> Post(CreateBookInputModel model)
        {
            var book = model.ToEntity();

            _context.Books.Add(book);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(book.Id);
        }

        public ResultViewModel Delete(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if (book is null)
            {
                return ResultViewModel.Erro("Book not found");
            }
            book.SetAsDeleted();

            _context.Books.Update(book);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}
