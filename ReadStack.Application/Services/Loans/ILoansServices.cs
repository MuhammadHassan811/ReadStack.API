using ReadStack.Application.Models;
using ReadStack.Application.Models;

namespace ReadStack.Application.Services.Loans
{
    public interface ILoansServices
    {
        ResultViewModel<List<LoanViewModel>> GetAll(string search = "");
        ResultViewModel<LoanViewModel> GetById(int id);
        ResultViewModel<int> Post(CreateLoanInputModel model);
        ResultViewModel Put(int id, UpdateLoanInputModel model);
        ResultViewModel Delete(int id);
        ResultViewModel LoanReturned(int idUser, int idBook);


    }
}
