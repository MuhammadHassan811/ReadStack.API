using ReadStack.API.Persistence;
using ReadStack.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace ReadStack.Application.Services.Loans
{
    public class LoansServices : ILoansServices
    {
        private readonly ReadStackDbContext _context;

        public LoansServices(ReadStackDbContext context)
        {
            _context = context;
        }

        public ResultViewModel<List<LoanViewModel>> GetAll(string search = "")
        {
            var loans = _context.Loans
            .Include(u => u.User)
            .Include(b => b.Book)
            .Where(l => !l.IsDeleted && (search == "" || l.Book.Title.Contains(search)))
            .ToList();

            var model = loans.Select(LoanViewModel.FromEntity).ToList();

            return ResultViewModel<List<LoanViewModel>>.Success(model);
        }

        public ResultViewModel<LoanViewModel> GetById(int id)
        {
            var loan = _context.Loans.SingleOrDefault(l => l.Id == id);

            if (loan != null)
            {
                return ResultViewModel<LoanViewModel>.Erro("Loan not found.");
            }

            var model = LoanViewModel.FromEntity(loan);

            return ResultViewModel<LoanViewModel>.Success(model);
        }

        public ResultViewModel<int> Post(CreateLoanInputModel model)
        {
            var loan = model.ToEntity();

            loan.Lend();

            _context.Loans.Add(loan);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(loan.Id);
        }

        public ResultViewModel Put(int id, UpdateLoanInputModel model)
        {
            var loan = _context.Loans.SingleOrDefault(l => l.Id == id);

            if (loan == null)
            {
                return ResultViewModel.Erro("Loan not found.");
            }

            loan.Update(model.BookId, model.Cost);

            _context.Loans.Update(loan);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel Delete(int id)
        {
            var loan = _context.Loans.SingleOrDefault(l => l.Id == id);

            if (loan == null)
            {
                return ResultViewModel.Erro("Loan not found.");
            }

            loan.SetAsDeleted();
            _context.Loans.Update(loan);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel LoanReturned(int idUser, int idBook)
        {
            var loanReturn = _context.Loans
            .Include(u => u.User)
            .Include(b => b.Book)
            .SingleOrDefault(x => x.UserId == idUser && x.BookId == idBook);

            if (loanReturn == null)
            {
                throw new ArgumentException("Loan not found for the specified user or book");
            }

            if (loanReturn.ReturnDate < DateTime.Now)
            {
                throw new InvalidOperationException("The book is late.");
            }

            loanReturn.Returned();
            _context.Loans.Update(loanReturn);
            _context.SaveChanges();

            //return Ok("The book is up to date");
            return ResultViewModel.Success("The book is up to date");
        }
    }
}
